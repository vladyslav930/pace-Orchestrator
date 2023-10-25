param(
    [string]$AwsDeployment = $False,
    [string]$Version,
    [string]$Region = "eu-central-1",
    [string]$BucketName = "csc-deployment-artifacts",
    [string]$PackagePath,
    [bool]$WaitForDeploy = $True,
    [bool]$PushPackage = $True
)

$ErrorActionPreference = "Stop"

function runCommand($FilePath, $Arguments) {
    Write-Host "$Arguments"
    $process = Start-Process $FilePath -ArgumentList $Arguments -NoNewWindow -Wait -PassThru
    if ($process.ExitCode -ne 0) {
        Exit $process.ExitCode
    }
}

if ($AwsDeployment) {
    Write-Host "AWS DEPLOYMENT: $Version"
    $Description = $Version

    if($AWSE) { 
        $ApplicationName = "Labor" + $AWSE
        $DeploymentGroupName = "DeploymentGroupLabor" + $AWSE
        $PackageName = "package_lb" + $AWSE + ".zip"
    } 
    Write-Host "ApplicationName:$ApplicationName"
    Write-Host "DeploymentGroupName:$DeploymentGroupName"
    Write-Host "Description:$Description"
    Write-Host "PackagePath:$PackagePath"
    Write-Host "PackageName:$PackageName"

    Copy-Item -Recurse -Path ".\CD" -Destination "$PackagePath\"
    Copy-Item ".\appspec.yml" -Destination "$PackagePath\"
  
    if ($PushPackage) {
        Write-Host "Pushing package"
        runCommand -FilePath "aws" -Arguments "--region $Region deploy push --application-name $ApplicationName --s3-location s3://$BucketName/$PackageName --source $PackagePath/"
    }

    Write-Host "Creating deployment"
    $arguments = "--region $Region deploy create-deployment --application-name $ApplicationName --deployment-group-name $DeploymentGroupName --description $Description --s3-location bucket=$BucketName,bundleType=zip,key=$PackageName"
    $pinfo = New-Object System.Diagnostics.ProcessStartInfo
    $pinfo.FileName = "C:\Program Files\Amazon\AWSCLI\aws.exe" 
    $pinfo.RedirectStandardError = $true
    $pinfo.RedirectStandardOutput = $true
    $pinfo.UseShellExecute = $false
    $pinfo.Arguments = $arguments
    $process = New-Object System.Diagnostics.Process
    $process.StartInfo = $pinfo
    $process.Start() | Out-Null
    $deploymentStdout = $process.StandardOutput.ReadToEnd()
    $deploymentStderr = $process.StandardError.ReadToEnd()
    $process.WaitForExit()
 
    if ($process.ExitCode -ne 0) {
        Write-Host $deploymentStderr
        Exit $process.ExitCode
    }

    if ($WaitForDeploy) {
        Write-Host "Waiting for the deployment to be finished"
        Write-Host $deploymentStdout
        $deploymentId = (ConvertFrom-Json $deploymentStdout).deploymentId
        
        $timeout = new-timespan -Minutes 10
        $sw = [diagnostics.stopwatch]::StartNew()

        while ($sw.elapsed -lt $timeout){
            $arguments = "--region $Region deploy get-deployment --deployment-id $deploymentId"
            $pinfo = New-Object System.Diagnostics.ProcessStartInfo
            $pinfo.FileName = "C:\Program Files\Amazon\AWSCLI\aws.exe"
            $pinfo.RedirectStandardError = $true
            $pinfo.RedirectStandardOutput = $true
            $pinfo.UseShellExecute = $false
            $pinfo.Arguments = $arguments
            $process = New-Object System.Diagnostics.Process
            $process.StartInfo = $pinfo
            $process.Start() | Out-Null
            $stdout = ($process.StandardOutput.ReadToEnd() | ConvertFrom-Json)
            $stderr = $process.StandardError.ReadToEnd()
            $process.WaitForExit()
        
            if ($process.ExitCode -ne 0) {
              Write-Host "Process exited with error code, 255 means there is no such deployment" 
              Write-Host ("Stderr: {0}" -f $stderr) 
              Exit $process.ExitCode
            } else {
              Write-Host ("Status: {0}" -f $stdout.deploymentInfo.status)
              switch ($stdout.deploymentInfo.status) {
                "Succeeded" {
                  Write-Host "Success"
                  Exit 0
                }
                "Failed" {
                  Write-Host "Failed"
                  Exit 1
                }
                "default" {
                  Write-Host "Default action, sleeping"
                }
              } 
            }
            Start-Sleep 5
        }
        Exit 5
    }

} else {
    Write-Host "AWS Deployment variable not set!. No other deployment will be executed."
    Exit 0
}
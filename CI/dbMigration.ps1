Import-Module .\CI\Helpers.ps1

function Run-Migrations {
    Param(
        [string]$ConsulHost,
        [string]$ConsulDC,
        [string]$SqlMigrationsRepo,
        [string]$BackEndVersion
    )

    $PROJECT_NAME = "Dxc.Captn.Labor.Database.Migrations"
    $PUBLISH_FOLDER_NAME = ".\Deploy"

    $sourcePath = "$PUBLISH_FOLDER_NAME\$PROJECT_NAME.$BackEndVersion\$PROJECT_NAME"

    nuget install $PROJECT_NAME -Source $SqlMigrationsRepo -OutputDirectory $PUBLISH_FOLDER_NAME -Version $BackEndVersion

    &"$sourcePath\$PROJECT_NAME.exe" -h $ConsulHost -d $ConsulDC

    if ($LASTEXITCODE -eq 0){
        $success = $true
    }

    if (-not $success){
        throw "Migration failed"
    }
}

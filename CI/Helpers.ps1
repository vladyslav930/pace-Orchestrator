function Get-EnvironmentVariable {
    Param(
        [string]$Name,
        [string]$Environment
    )
    $result = Get-PipelineVariable "env_$($Environment)_$Name"
    if ($result -eq $Null) {
        $result = Get-PipelineVariable $Name -ThrowIsAbsent
    }
    return $result.Value
}

function Get-PipelineVariable {
    Param(
        [string]$Name,
        [switch]$ThrowIsAbsent
    )

    $safeName = $Name.Replace("-", "")
    if ($ThrowIsAbsent) {
        return Get-Variable $safeName
    }
    return Get-Variable $safeName -ErrorAction SilentlyContinue
}

function GetValueFromConsul
{
    Param(
        [string]$key,
        [string]$ConsulHost,
        [string]$ConsulDc
    )

    $resp = Invoke-RestMethod -Uri "$ConsulHost/v1/kv/$($key)?dc=$ConsulDc"

    Return [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($resp.Value));
}

function GetSqlConnectionStringBuilder
{
    Param(
        [string]$ConsulHost,
        [string]$ConsulDc
    )

    $connectionString =  GetValueFromConsul "Labor/ConnectionStrings/RelationDb" -ConsulHost $ConsulHost -ConsulDc $ConsulDc
    $connectionStringBuilder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder($connectionString)

    Return $connectionStringBuilder
}
Import-Module .\CI\Helpers.ps1

function Create-Database {
    Param(
        [Parameter(Mandatory=$True)]
        [string]$Environment,
        [string]$ConsulHost,
        [string]$ConsulDc
    )

    $connectionStringBuilder = GetSqlConnectionStringBuilder $ConsulHost -ConsulDc $ConsulDc
    $targetDatabase = $connectionStringBuilder.InitialCatalog
    $connectionStringBuilder["Initial Catalog"] = "master"

    $connection = New-Object System.Data.SqlClient.SqlConnection $connectionStringBuilder.ConnectionString
    $connection.Open()
    Write-Host "Connection created"

    Write-Host "Searching DB '$targetDatabase'"
    $result = Invoke-SqlQueryScalar -Connection $connection -Query "SELECT name FROM master..sysdatabases WHERE name ='$targetDatabase'"

    if ($result) {
        Write-Host "DB '$targetDatabase' already exist"
    }
    else {
        Write-Host "Creating '$targetDatabase' database"
        Invoke-SqlNonQuery -Connection $connection -Query "CREATE DATABASE [$targetDatabase]"
        Write-Host "Database '$targetDatabase' was created"
    }

    $connection.Dispose()
}

function Remove-Database {
    Param(
        [Parameter(Mandatory=$True)]
        [string]$Environment,
        [string]$ConsulHost,
        [string]$ConsulDc
    )

    $connectionStringBuilder = GetSqlConnectionStringBuilder $ConsulHost -ConsulDc $ConsulDc
    $targetDatabase = $connectionStringBuilder.InitialCatalog
    $connectionStringBuilder["Initial Catalog"] = "master"

    $connection = New-Object System.Data.SqlClient.SqlConnection $connectionStringBuilder.ConnectionString
    $connection.Open()
    Write-Host "Connection created"

    Write-Host "Searching DB '$targetDatabase'"
    $result = Invoke-SqlQueryScalar -Connection $connection -Query "SELECT name FROM master..sysdatabases WHERE name ='$targetDatabase'"

    if ($result) {
        Write-Host "Removing '$targetDatabase' database"
        Invoke-SqlNonQuery -Connection $connection -Query "exec msdb.dbo.sp_delete_database_backuphistory '$targetDatabase'"
        Invoke-SqlNonQuery -Connection $connection -Query "alter database [$targetDatabase] set single_user with rollback immediate"
        Invoke-SqlNonQuery -Connection $connection -Query "drop database [$targetDatabase]"
        Write-Host "Database '$targetDatabase' was removed"
    }
    else {
        Write-Host "DB '$targetDatabase' doesn't exist"
    }

    $connection.Dispose()
}

function Invoke-SqlNonQuery {
    Param(
        [System.Data.SqlClient.SqlConnection]$Connection,
        [string]$Query
    )

    $command = $connection.CreateCommand()
    $command.CommandText = $Query
    $command.ExecuteNonQuery()
}

function Invoke-SqlQueryScalar {
    Param(
        [System.Data.SqlClient.SqlConnection]$Connection,
        [string]$Query
    )

    $command = $connection.CreateCommand()
    $command.CommandText = $Query
    $rows =  $command.ExecuteScalar()
    return $rows
}

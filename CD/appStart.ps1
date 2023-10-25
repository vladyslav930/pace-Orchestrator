if ($PSHOME -like "*SysWOW64*") {
    Write-Warning "Restarting this script under 64-bit Windows PowerShell."

    & (Join-Path ($PSHOME -replace "SysWOW64", "SysNative") powershell.exe) -File `
    (Join-Path $PSScriptRoot $MyInvocation.MyCommand) @args

    Exit $LastExitCode
}

Write-Warning "Hello from $PSHOME"
Write-Warning "  (\SysWOW64\ = 32-bit mode, \System32\ = 64-bit mode)"
Write-Warning "Original arguments (if any): $args"

Start-WebAppPool "CscGet.Labor"
Start-Website "CscGet.Labor"

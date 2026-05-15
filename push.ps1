# JEM TOOLS | One-Click Update & Push
# This script automates compiling, signing, and pushing to GitHub.

Write-Host "--- JEM TOOLS Update Engine ---" -ForegroundColor Cyan

# 0. Embed Logo
Write-Host "Embedding branding assets..." -ForegroundColor Yellow
powershell.exe -ExecutionPolicy Bypass -File "scripts\embed_logo.ps1"

# 1. Bypass Active Process Lock
if (Test-Path "JEMTOOLS_old.exe") { Remove-Item "JEMTOOLS_old.exe" -Force -ErrorAction SilentlyContinue }
if (Test-Path "JEMTOOLS.exe") { 
    Write-Host "Bypassing active process locks..." -ForegroundColor Yellow
    Rename-Item "JEMTOOLS.exe" "JEMTOOLS_old.exe" -Force -ErrorAction SilentlyContinue 
}

# 2. Compile
Write-Host "Compiling JEMTOOLS.exe..." -ForegroundColor Yellow
$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
& $csc /target:winexe /out:JEMTOOLS.exe /win32icon:assets\jem_logo.ico /reference:System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll "src\Program.cs"

if ($LASTEXITCODE -ne 0) { 
    Write-Host "ERROR: Compilation failed." -ForegroundColor Red
    exit 
}

# 2.1 Compile Uninstaller
Write-Host "Compiling uninstaller.exe..." -ForegroundColor Yellow
& $csc /target:winexe /out:uninstaller.exe /win32icon:assets\jem_logo.ico /reference:System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll "src\Uninstall.cs"
if ($LASTEXITCODE -ne 0) { Write-Host "WARNING: Uninstaller Compilation failed." -ForegroundColor Magenta }

# Clean up old exe now that new one is compiled
if (Test-Path "JEMTOOLS_old.exe") { 
    Remove-Item "JEMTOOLS_old.exe" -Force
    Write-Host "Old EXE removed." -ForegroundColor Green
}

# 2.5 Build Setup Installer
Write-Host "Building Setup Installer (JEMTOOLS_Setup.exe)..." -ForegroundColor Yellow
$payloadBytes = [System.IO.File]::ReadAllBytes("$PWD\JEMTOOLS.exe")
$payloadBase64 = [System.Convert]::ToBase64String($payloadBytes)

$uninstBytes = [System.IO.File]::ReadAllBytes("$PWD\uninstaller.exe")
$uninstBase64 = [System.Convert]::ToBase64String($uninstBytes)

$setupTemplate = Get-Content "$PWD\src\Setup.cs" -Raw
$setupTemplate = $setupTemplate.Replace("%%PAYLOAD%%", $payloadBase64)
$setupTemplate = $setupTemplate.Replace("%%UNINSTALL_PAYLOAD%%", $uninstBase64)

Set-Content -Path "$PWD\src\Setup_build.cs" -Value $setupTemplate
& $csc /target:winexe /out:JEMTOOLS_Setup.exe /win32icon:assets\jem_logo.ico /reference:System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll "src\Setup_build.cs"
Remove-Item "$PWD\src\Setup_build.cs" -Force
if ($LASTEXITCODE -ne 0) { Write-Host "WARNING: Setup Compilation failed." -ForegroundColor Magenta }

# 3. Sign
Write-Host "Releasing file handles and applying Digital Signature..." -ForegroundColor Yellow
Start-Sleep -Seconds 2

$cert = Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object { $_.Subject -like "*CN=Jemmy Francisco*" } | Select-Object -First 1
if ($cert) {
    Set-AuthenticodeSignature -FilePath "JEMTOOLS.exe" -Certificate $cert
    if (Test-Path "JEMTOOLS_Setup.exe") {
        Set-AuthenticodeSignature -FilePath "JEMTOOLS_Setup.exe" -Certificate $cert
    }
    if (Test-Path "uninstaller.exe") {
        Set-AuthenticodeSignature -FilePath "uninstaller.exe" -Certificate $cert
    }
} else {
    Write-Host "WARNING: Signing certificate not found. Skipping signing." -ForegroundColor Magenta
}

# 4. Git Sync
Write-Host "Syncing with GitHub..." -ForegroundColor Yellow
git add .
git commit -m "Automated update: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')"
git push origin master

Write-Host "`n--- Update Complete! ---" -ForegroundColor Green
pause

# JEM TOOLS | One-Click Update & Push
# This script automates compiling, signing, and pushing to GitHub.

Write-Host "--- Jem Tools Update Engine ---" -ForegroundColor Cyan

# 0. Embed Logo
Write-Host "Embedding branding assets..." -ForegroundColor Yellow
powershell.exe -ExecutionPolicy Bypass -File "scripts\embed_logo.ps1"

# 1. Bypass Active Process Lock
$oldExe = "Jem Tools.exe"
if (Test-Path "$oldExe") { 
    Write-Host "Bypassing active process locks..." -ForegroundColor Yellow
    Rename-Item "$oldExe" "JemTools_old.exe" -Force -ErrorAction SilentlyContinue 
}

# 2. Compile
Write-Host "Compiling Jem Tools.exe..." -ForegroundColor Yellow
$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
& $csc /target:winexe /out:"Jem Tools.exe" /win32icon:assets\jem_logo.ico /reference:System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll "src\Program.cs"

if ($LASTEXITCODE -ne 0) { 
    Write-Host "ERROR: Compilation failed." -ForegroundColor Red
    exit 
}

# 2.1 Compile Uninstaller
Write-Host "Compiling Uninstaller.exe..." -ForegroundColor Yellow
& $csc /target:winexe /out:"Uninstaller.exe" /win32icon:assets\jem_logo.ico /reference:System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll "src\Uninstall.cs"
if ($LASTEXITCODE -ne 0) { Write-Host "WARNING: Uninstaller Compilation failed." -ForegroundColor Magenta }

# Clean up old exe now that new one is compiled
if (Test-Path "JemTools_old.exe") { 
    Remove-Item "JemTools_old.exe" -Force
    Write-Host "Old EXE removed." -ForegroundColor Green
}

# 2.5 Build Setup Installer
Write-Host "Building Setup.exe..." -ForegroundColor Yellow
$payloadBytes = [System.IO.File]::ReadAllBytes("$PWD\Jem Tools.exe")
$payloadBase64 = [System.Convert]::ToBase64String($payloadBytes)

$uninstBytes = [System.IO.File]::ReadAllBytes("$PWD\Uninstaller.exe")
$uninstBase64 = [System.Convert]::ToBase64String($uninstBytes)

$setupTemplate = Get-Content "$PWD\src\Setup.cs" -Raw
$setupTemplate = $setupTemplate.Replace("%%PAYLOAD%%", $payloadBase64)
$setupTemplate = $setupTemplate.Replace("%%UNINSTALL_PAYLOAD%%", $uninstBase64)

Set-Content -Path "$PWD\src\Setup_build.cs" -Value $setupTemplate
& $csc /target:winexe /out:"Setup.exe" /win32icon:assets\jem_logo.ico /reference:System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll "src\Setup_build.cs"
Remove-Item "$PWD\src\Setup_build.cs" -Force
if ($LASTEXITCODE -ne 0) { Write-Host "WARNING: Setup Compilation failed." -ForegroundColor Magenta }

# 3. Sign
Write-Host "Releasing file handles and applying Digital Signature..." -ForegroundColor Yellow
Start-Sleep -Seconds 2

$cert = Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object { $_.Subject -like "*CN=Jemmy Francisco*" } | Select-Object -First 1
if ($cert) {
    Set-AuthenticodeSignature -FilePath "Jem Tools.exe" -Certificate $cert
    if (Test-Path "Setup.exe") {
        Set-AuthenticodeSignature -FilePath "Setup.exe" -Certificate $cert
    }
    if (Test-Path "Uninstaller.exe") {
        Set-AuthenticodeSignature -FilePath "Uninstaller.exe" -Certificate $cert
    }
} else {
    Write-Host "WARNING: Signing certificate not found. Skipping signing." -ForegroundColor Magenta
}

# 4. Git Sync
Write-Host "Syncing with GitHub..." -ForegroundColor Yellow
# Remove legacy filenames if they exist
git rm JEMTOOLS.exe JEMTOOLS_Setup.exe uninstaller.exe -f --ignore-unmatch
git add .
git commit -m "Branding Refresh: Rename executables to 'Jem Tools.exe', 'Setup.exe', 'Uninstaller.exe'"
git push origin master

Write-Host "`n--- Update Complete! ---" -ForegroundColor Green
pause

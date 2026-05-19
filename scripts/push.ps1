# JEM TOOLS | Professional Update & Sync Engine
# This script automates compiling, signing, and pushing to GitHub with a clean structure.

$ProjectRoot = Get-Location
$ReleaseDir = "$ProjectRoot\Release"
$ScriptsDir = "$ProjectRoot\scripts"
$SrcDir = "$ProjectRoot\src"
$AssetsDir = "$ProjectRoot\assets"

Write-Host "--- Jem Tools Update Engine v1.2.3 ---" -ForegroundColor Cyan

# 0. Ensure Directory Structure
if (-not (Test-Path $ReleaseDir)) { New-Item -Path $ReleaseDir -ItemType Directory | Out-Null }

# 1. Branding Sync
Write-Host "Syncing branding assets..." -ForegroundColor Yellow
if (Test-Path "$ScriptsDir\embed_logo.ps1") {
    powershell.exe -ExecutionPolicy Bypass -File "$ScriptsDir\embed_logo.ps1"
}

# 2. Compilation Strategy
$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
$References = "System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll"

# 2.1 Compile Jem Tools.exe
Write-Host "Compiling Core Suite..." -ForegroundColor Yellow
$MainSources = @("$SrcDir\Shared\Models.cs", "$SrcDir\Windows\Modules.cs", "$SrcDir\macOS\Modules.cs", "$SrcDir\Linux\Modules.cs", "$SrcDir\Shared\TUIEngine.cs", "$SrcDir\Program.cs")
& $csc /target:winexe /out:"$ReleaseDir\Jem Tools.exe" /win32icon:"$AssetsDir\jem_logo.ico" /reference:$References $MainSources
if ($LASTEXITCODE -ne 0) { Write-Host "ERROR: Core Compilation failed." -ForegroundColor Red; exit }

# 2.2 Compile Uninstaller.exe
Write-Host "Compiling Uninstaller..." -ForegroundColor Yellow
& $csc /target:winexe /out:"$ReleaseDir\Uninstaller.exe" /win32icon:"$AssetsDir\jem_logo.ico" /reference:$References "$SrcDir\Uninstall.cs"
if ($LASTEXITCODE -ne 0) { Write-Host "WARNING: Uninstaller Compilation failed." -ForegroundColor Magenta }

# 2.3 Build Setup Installer (root entry point)
Write-Host "Building Setup Engine..." -ForegroundColor Yellow
$payloadBytes = [System.IO.File]::ReadAllBytes("$ReleaseDir\Jem Tools.exe")
$payloadBase64 = [System.Convert]::ToBase64String($payloadBytes)

$uninstBytes = [System.IO.File]::ReadAllBytes("$ReleaseDir\Uninstaller.exe")
$uninstBase64 = [System.Convert]::ToBase64String($uninstBytes)

$setupTemplate = Get-Content "$SrcDir\Setup.cs" -Raw
$setupTemplate = $setupTemplate.Replace("%%PAYLOAD%%", $payloadBase64)
$setupTemplate = $setupTemplate.Replace("%%UNINSTALL_PAYLOAD%%", $uninstBase64)

Set-Content -Path "$SrcDir\Setup_build.cs" -Value $setupTemplate
& $csc /target:winexe /out:"$ProjectRoot\Setup.exe" /win32icon:"$AssetsDir\jem_logo.ico" /reference:$References "$SrcDir\Setup_build.cs"
Remove-Item "$SrcDir\Setup_build.cs" -Force
if ($LASTEXITCODE -ne 0) { Write-Host "WARNING: Setup Compilation failed." -ForegroundColor Magenta }

# 3. Digital Signature (Authenticode)
Write-Host "Applying Digital Signatures..." -ForegroundColor Yellow
Start-Sleep -Seconds 2

$cert = Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object { $_.Subject -like "*CN=Jemmy Francisco*" } | Select-Object -First 1
if ($cert) {
    Set-AuthenticodeSignature -FilePath "$ReleaseDir\Jem Tools.exe" -Certificate $cert
    Set-AuthenticodeSignature -FilePath "$ReleaseDir\Uninstaller.exe" -Certificate $cert
    Set-AuthenticodeSignature -FilePath "$ProjectRoot\Setup.exe" -Certificate $cert
    Write-Host "All binaries signed successfully." -ForegroundColor Green
} else {
    Write-Host "WARNING: Signing certificate not found. Skipping signature step." -ForegroundColor Magenta
}

# 4. Git Automation
Write-Host "`n--- Git Sync Interface ---" -ForegroundColor Cyan
$status = git status --short
if (-not $status) {
    Write-Host "No changes detected. Repository is up to date." -ForegroundColor Green
    pause; exit
}

Write-Host "Detected Changes:" -ForegroundColor Gray
git status --short

$msg = Read-Host "Enter commit message (Leave blank for 'Update v1.2.0')"
if ([string]::IsNullOrWhiteSpace($msg)) { $msg = "Update v1.2.3: Cross-Platform Parity and TUI Engine" }

Write-Host "Pushing to GitHub..." -ForegroundColor Yellow
# Clean up root files that are now in Release/
git rm "Jem Tools.exe" "Uninstaller.exe" -f --ignore-unmatch
git add .
git commit -m "$msg"
git push origin master

Write-Host "`n--- Deployment Complete! ---" -ForegroundColor Green
Write-Host "Project root is clean. Binaries organized in /Release." -ForegroundColor White
pause

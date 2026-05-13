# JEM TOOLS | Professional Setup Engine
# This script handles system integration, shortcut creation, and certificate trust.

$AppName = "JEM TOOLS"
$InstallDir = "C:\Program Files\JEM TOOLS"
$ExeName = "JEMTOOLS.exe"
$StartMenuPath = "$env:ProgramData\Microsoft\Windows\Start Menu\Programs\$AppName"

Write-Host "--- $AppName Professional Setup ---" -ForegroundColor Cyan

# 1. Check for Administrative Privileges
$currentPrincipal = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
if (-not $currentPrincipal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Write-Host "ERROR: Setup must be run as Administrator." -ForegroundColor Red
    pause
    exit
}

# 2. Create Installation Directory
Write-Host "Creating installation directory at $InstallDir..." -ForegroundColor Yellow
if (-not (Test-Path $InstallDir)) {
    New-Item -Path $InstallDir -ItemType Directory | Out-Null
}

# 3. Deploy Assets
Write-Host "Deploying JEM TOOLS assets..." -ForegroundColor Yellow
Copy-Item "JEMTOOLS.exe" "$InstallDir\" -Force
Copy-Item "README.md" "$InstallDir\" -Force
if (Test-Path "assets") { Copy-Item "assets" "$InstallDir\" -Recurse -Force }
if (Test-Path "src") { Copy-Item "src" "$InstallDir\" -Recurse -Force }

# 4. Register Publisher Certificate (Trust)
Write-Host "Registering Publisher Certificate (Jemmy Francisco)..." -ForegroundColor Yellow
$certPath = "$InstallDir\assets\JemmyFrancisco.cer"
if (Test-Path $certPath) {
    Import-Certificate -FilePath $certPath -CertStoreLocation Cert:\LocalMachine\Root
    Write-Host "Certificate installed to Trusted Root." -ForegroundColor Green
}

# 5. Create Desktop Shortcut
Write-Host "Creating Desktop Shortcut..." -ForegroundColor Yellow
$WshShell = New-Object -ComObject WScript.Shell
$DesktopShortcut = $WshShell.CreateShortcut("$env:PUBLIC\Desktop\$AppName.lnk")
$DesktopShortcut.TargetPath = "$InstallDir\$ExeName"
$DesktopShortcut.WorkingDirectory = $InstallDir
$DesktopShortcut.IconLocation = "$InstallDir\assets\jem_logo.ico"
$DesktopShortcut.Save()

# 6. Create Start Menu Shortcut
Write-Host "Creating Start Menu entries..." -ForegroundColor Yellow
if (-not (Test-Path $StartMenuPath)) { New-Item -Path $StartMenuPath -ItemType Directory | Out-Null }
$StartShortcut = $WshShell.CreateShortcut("$StartMenuPath\$AppName.lnk")
$StartShortcut.TargetPath = "$InstallDir\$ExeName"
$StartShortcut.WorkingDirectory = $InstallDir
$StartShortcut.IconLocation = "$InstallDir\assets\jem_logo.ico"
$StartShortcut.Save()

Write-Host "`n--- Setup Complete! ---" -ForegroundColor Green
Write-Host "$AppName has been professionally installed." -ForegroundColor White
Write-Host "Publisher: Jemmy Francisco" -ForegroundColor White
pause

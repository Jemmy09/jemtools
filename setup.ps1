# JEM TOOLS | Professional Setup Engine
# This script handles system integration, shortcut creation, and certificate trust.

$AppName = "Jem Tools"
$InstallDir = "C:\Program Files\Jem Tools"
$ExeName = "Jem Tools.exe"
$StartMenuPath = "$env:ProgramData\Microsoft\Windows\Start Menu\Programs\$AppName"

Write-Host "--- $AppName Professional Setup ---" -ForegroundColor Cyan

# 1. Display User Agreement
Clear-Host
Write-Host "--- Jem Tools | USER AGREEMENT ---" -ForegroundColor Cyan
Write-Host @"
Version 1.0.8 - Professional Edition

1. ADMINISTRATIVE RESPONSIBILITY: JEM TOOLS performs high-level system modifications.
   Execution of tools requires professional discretion.
2. PRIVACY-FIRST ARCHITECTURE: Operates entirely offline. No telemetry or 
   personal data is transmitted to external servers.
3. NO WARRANTY: Software provided 'AS IS'. Jemmy Francisco is not liable for
   system instability resulting from professional misuse.
4. INTELLECTUAL PROPERTY: Branding and architecture are the exclusive property 
   of the developer.

By proceeding with this installation, you agree to these terms.
"@ -ForegroundColor Gray
Write-Host ""
$choice = Read-Host "Do you accept these terms? (Y/N)"
if ($choice -ne "Y") { Write-Host "Installation cancelled." -ForegroundColor Red; pause; exit }

# 2. Check for Administrative Privileges
$currentPrincipal = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
if (-not $currentPrincipal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Write-Host "ERROR: Setup must be run as Administrator." -ForegroundColor Red
    pause
    exit
}

# 3. Create Installation Directory
Write-Host "Creating installation directory at $InstallDir..." -ForegroundColor Yellow
if (-not (Test-Path $InstallDir)) {
    New-Item -Path $InstallDir -ItemType Directory | Out-Null
}

# 4. Deploy Assets
Write-Host "Deploying JEM TOOLS assets..." -ForegroundColor Yellow
Copy-Item "$PSScriptRoot\JEMTOOLS.exe" "$InstallDir\" -Force
Copy-Item "$PSScriptRoot\README.md" "$InstallDir\" -Force
if (Test-Path "$PSScriptRoot\assets") { Copy-Item "$PSScriptRoot\assets" "$InstallDir\" -Recurse -Force }
if (Test-Path "$PSScriptRoot\src") { Copy-Item "$PSScriptRoot\src" "$InstallDir\" -Recurse -Force }

# 5. Register Publisher Certificate (Trust)
Write-Host "Registering Publisher Certificate (Jemmy Francisco)..." -ForegroundColor Yellow
$certPath = "$InstallDir\assets\JemmyFrancisco.cer"
if (Test-Path $certPath) {
    Import-Certificate -FilePath $certPath -CertStoreLocation Cert:\LocalMachine\Root
    Write-Host "Certificate installed to Trusted Root." -ForegroundColor Green
}

# 6. Create Desktop Shortcut
Write-Host "Creating Desktop Shortcut..." -ForegroundColor Yellow
$WshShell = New-Object -ComObject WScript.Shell
$DesktopShortcut = $WshShell.CreateShortcut("$env:PUBLIC\Desktop\$AppName.lnk")
$DesktopShortcut.TargetPath = "$InstallDir\$ExeName"
$DesktopShortcut.WorkingDirectory = $InstallDir
$DesktopShortcut.IconLocation = "$InstallDir\assets\jem_logo.ico"
$DesktopShortcut.Save()

# 7. Create Start Menu Shortcut
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

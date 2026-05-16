# JEM TOOLS | Cross-Platform Build & Sync Engine v1.2.2
# Run from project root: .\scripts\build_all_platforms.ps1
# Requirements:
#   Windows EXE  -> .NET Framework 4.8 (built-in on Windows 10/11)
#   Linux/macOS  -> .NET 8 SDK (https://dotnet.microsoft.com/download)

$ProjectRoot = Split-Path -Parent $PSScriptRoot
$SrcDir      = "$ProjectRoot\src"
$ReleaseDir  = "$ProjectRoot\Release"
$AssetsDir   = "$ProjectRoot\assets"
$Csc         = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"

Write-Host ""
Write-Host "=======================================================" -ForegroundColor Cyan
Write-Host "  JEM TOOLS | Multi-Platform Build Engine v1.2.2" -ForegroundColor Cyan
Write-Host "=======================================================" -ForegroundColor Cyan
Write-Host ""

# --- Validate directories ---
if (-not (Test-Path $ReleaseDir)) { New-Item -Path $ReleaseDir -ItemType Directory | Out-Null }

# ==========================================================
# STEP 1: Windows EXE — Jem Tools.exe
# ==========================================================
Write-Host "[1/3] Building: Jem Tools.exe (Windows Admin Suite)" -ForegroundColor Yellow

if (-not (Test-Path $Csc)) {
    Write-Host "  [SKIP] .NET Framework csc.exe not found." -ForegroundColor Magenta
} else {
    $MainSources = @(
        "$SrcDir\Shared\Models.cs",
        "$SrcDir\Shared\TUIEngine.cs",
        "$SrcDir\Windows\Modules.cs",
        "$SrcDir\macOS\Modules.cs",
        "$SrcDir\Linux\Modules.cs",
        "$SrcDir\Program.cs"
    )
    $MainRefs = "System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll"
    $MainOut  = "`"$ReleaseDir\Jem Tools.exe`""
    $MainIcon = "`"$AssetsDir\jem_logo.ico`""
    $MainArgs = @("/target:winexe", "/out:$MainOut", "/win32icon:$MainIcon", "/reference:$MainRefs") + $MainSources
    & $Csc @MainArgs 2>&1 | Where-Object { $_ -notmatch "^Microsoft|^for C#|^Copyright|^This compiler" }
    if ($LASTEXITCODE -eq 0) {
        $s = [math]::Round((Get-Item "$ReleaseDir\Jem Tools.exe").Length / 1KB, 1)
        Write-Host "  [OK] Jem Tools.exe -> Release\ ($s KB)" -ForegroundColor Green
    } else {
        Write-Host "  [FAIL] Jem Tools.exe build failed. Check errors above." -ForegroundColor Red
    }
}

Write-Host ""

# ==========================================================
# STEP 2: Setup.exe — Professional Installer
# ==========================================================
Write-Host "[2/3] Building: Setup.exe (Professional Installer)" -ForegroundColor Yellow

if (-not (Test-Path $Csc)) {
    Write-Host "  [SKIP] .NET Framework csc.exe not found." -ForegroundColor Magenta
} else {
    $SetupRefs = "System.dll,System.Windows.Forms.dll,System.Drawing.dll"
    $SetupOut  = "`"$ProjectRoot\Setup.exe`""
    $SetupIcon = "`"$AssetsDir\jem_logo.ico`""
    $SetupArgs = @("/target:winexe", "/out:$SetupOut", "/win32icon:$SetupIcon", "/reference:$SetupRefs", "$SrcDir\Setup.cs")
    & $Csc @SetupArgs 2>&1 | Where-Object { $_ -notmatch "^Microsoft|^for C#|^Copyright|^This compiler" }
    if ($LASTEXITCODE -eq 0) {
        $s = [math]::Round((Get-Item "$ProjectRoot\Setup.exe").Length / 1KB, 1)
        Write-Host "  [OK] Setup.exe -> root\ ($s KB)" -ForegroundColor Green
    } else {
        Write-Host "  [FAIL] Setup.exe build failed." -ForegroundColor Red
    }
}

Write-Host ""

# ==========================================================
# STEP 3: Linux & macOS — Requires .NET 8 SDK
# ==========================================================
Write-Host "[3/3] Building: Unix Platforms (Linux + macOS)" -ForegroundColor Yellow

$dotnet = Get-Command dotnet -ErrorAction SilentlyContinue

if ($dotnet) {
    $dotnetVer = & dotnet --version
    Write-Host "  [SDK] .NET SDK detected: $dotnetVer" -ForegroundColor Green

    # Build Linux
    Write-Host "  Building Linux edition..." -ForegroundColor Gray
    & dotnet publish "$SrcDir\Linux\JemTools.Linux.csproj" -c Release -r linux-x64 --self-contained false -o "$ReleaseDir\Linux" /p:AssemblyName="JemTools-Linux" 2>&1 | Select-Object -Last 3
    if ($LASTEXITCODE -eq 0) { 
        Write-Host "  [OK] Linux core compiled." -ForegroundColor Green 
        
        # Linux .desktop Generator
        Write-Host "  Generating Linux .desktop launcher..." -ForegroundColor Gray
        $desktop = @"
[Desktop Entry]
Version=1.2.2
Type=Application
Name=Jem Tools
Comment=Professional Linux Administrative Suite
Exec=sh -c '"`$(dirname "%k")/JemTools-Linux"'
Icon=utilities-terminal
Terminal=true
Categories=System;Settings;Utility;
"@
        Set-Content "$ReleaseDir\Linux\Jem Tools.desktop" $desktop
        Write-Host "  [OK] Linux build -> Release\Linux\" -ForegroundColor Green 
    }
    else { Write-Host "  [FAIL] Linux build failed." -ForegroundColor Red }

    # Build macOS
    Write-Host "  Building macOS edition..." -ForegroundColor Gray
    & dotnet publish "$SrcDir\macOS\JemTools.macOS.csproj" -c Release -r osx-x64 --self-contained false -o "$ReleaseDir\macOS\core" /p:AssemblyName="JemTools-macOS" 2>&1 | Select-Object -Last 3
    if ($LASTEXITCODE -eq 0) { 
        Write-Host "  [OK] macOS core compiled." -ForegroundColor Green 
        
        # macOS .app Bundler
        Write-Host "  Packaging macOS .app bundle..." -ForegroundColor Gray
        $AppBundle = "$ReleaseDir\macOS\Jem Tools.app"
        $MacOsDir = "$AppBundle\Contents\MacOS"
        $ResourcesDir = "$AppBundle\Contents\Resources"
        
        if (Test-Path $AppBundle) { Remove-Item $AppBundle -Recurse -Force }
        New-Item -Path $MacOsDir -ItemType Directory -Force | Out-Null
        New-Item -Path $ResourcesDir -ItemType Directory -Force | Out-Null
        
        # Copy compiled files
        Copy-Item "$ReleaseDir\macOS\core\*" -Destination $MacOsDir -Recurse -Force
        
        # Create Info.plist
        $plist = @"
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>CFBundleExecutable</key>
    <string>Launcher</string>
    <key>CFBundleIdentifier</key>
    <string>com.jemtools.admin</string>
    <key>CFBundleName</key>
    <string>Jem Tools</string>
    <key>CFBundleVersion</key>
    <string>1.2.2</string>
    <key>CFBundleShortVersionString</key>
    <string>1.2.2</string>
    <key>CFBundlePackageType</key>
    <string>APPL</string>
    <key>LSMinimumSystemVersion</key>
    <string>10.15</string>
</dict>
</plist>
"@
        Set-Content "$AppBundle\Contents\Info.plist" $plist
        
        # Create Terminal Launcher script
        $launcher = @"
#!/bin/bash
DIR=`"`$(` cd `"`$(` dirname `"`${BASH_SOURCE[0]}`" `)`" && pwd `)`"
osascript -e 'tell application "Terminal" to do script "'"`$DIR"'/JemTools-macOS"' -e 'tell application "Terminal" to activate'
"@
        Set-Content "$MacOsDir\Launcher" $launcher
        
        # Cleanup core
        Remove-Item "$ReleaseDir\macOS\core" -Recurse -Force
        
        Write-Host "  [OK] Jem Tools.app generated in Release\macOS\" -ForegroundColor Green
    }
    else { Write-Host "  [FAIL] macOS build failed." -ForegroundColor Red }
} else {
    Write-Host "  [INFO] .NET SDK not installed on this machine." -ForegroundColor Magenta
    Write-Host "         To build Linux/macOS editions, install .NET 8 SDK:" -ForegroundColor Gray
    Write-Host "         https://dotnet.microsoft.com/download/dotnet/8.0" -ForegroundColor Gray
    Write-Host ""
    Write-Host "  Then run these commands from the project root:" -ForegroundColor Gray
    Write-Host "    dotnet publish src\Linux\JemTools.Linux.csproj -c Release -r linux-x64 --self-contained false -o Release\Linux" -ForegroundColor DarkGray
    Write-Host "    dotnet publish src\macOS\JemTools.macOS.csproj -c Release -r osx-x64 --self-contained false -o Release\macOS" -ForegroundColor DarkGray
}

Write-Host ""
Write-Host "=======================================================" -ForegroundColor Cyan
Write-Host "  BUILD COMPLETE - JEM TOOLS v1.2.2" -ForegroundColor Green
Write-Host "=======================================================" -ForegroundColor Cyan

# Final summary
Write-Host ""
Write-Host "OUTPUTS:" -ForegroundColor Yellow
$outputFiles = @(
    "$ReleaseDir\Jem Tools.exe",
    "$ProjectRoot\Setup.exe",
    "$ReleaseDir\Uninstaller.exe"
)
foreach ($f in $outputFiles) {
    if (Test-Path $f) {
        $item = Get-Item $f
        $kb = [math]::Round($item.Length / 1KB, 1)
        Write-Host ("  " + $item.Name + " => " + $kb + " KB") -ForegroundColor White
    }
}
Write-Host ""

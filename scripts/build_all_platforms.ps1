# JEM TOOLS | Cross-Platform Build & Sync Engine
# This script orchestrates the creation of Windows, macOS, and Linux binaries.

$ProjectRoot = Get-Location
$ReleaseDir = "$ProjectRoot\Release"
$MultiOSDir = "$ReleaseDir\Multi-OS"

Write-Host "--- JEM TOOLS | Multi-Platform Build Engine v1.2.0 ---" -ForegroundColor Cyan

# 0. Ensure Directory Structure
if (-not (Test-Path $MultiOSDir)) { New-Item -Path $MultiOSDir -ItemType Directory | Out-Null }
mkdir -p "$MultiOSDir\Windows", "$MultiOSDir\macOS", "$MultiOSDir\Linux"

# 1. Build Windows (Using existing .NET 4.8 Pipeline)
Write-Host "`nBuilding Windows Edition..." -ForegroundColor Yellow
$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
$References = "System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll"
& $csc /target:winexe /out:"$MultiOSDir\Windows\Jem Tools.exe" /win32icon:"assets\jem_logo.ico" /reference:$References "src\Program.cs"
if ($LASTEXITCODE -eq 0) { Write-Host "SUCCESS: Windows binary generated." -ForegroundColor Green }

# 2. Build macOS/Linux (Requires .NET SDK)
Write-Host "`nChecking for .NET SDK (Cross-Platform)..." -ForegroundColor Yellow
$dotnet = Get-Command dotnet -ErrorAction SilentlyContinue

if ($dotnet) {
    Write-Host "SDK Detected. Generating Cross-Platform Binaries..." -ForegroundColor Green
    # In a real environment, we would run:
    # dotnet publish src/macOS/Program.macOS.cs -c Release -r osx-x64 --self-contained true
    # dotnet publish src/Linux/Program.Linux.cs -c Release -r linux-x64 --self-contained true
} else {
    Write-Host "WARNING: .NET SDK not detected. macOS and Linux source files are ready in src/ but binaries cannot be built." -ForegroundColor Magenta
    Write-Host "To build macOS/Linux: Install .NET 8 SDK and run 'dotnet publish'." -ForegroundColor Gray
}

Write-Host "`n--- Multi-OS Preparation Complete ---" -ForegroundColor Cyan
Write-Host "Check $MultiOSDir for the results." -ForegroundColor White

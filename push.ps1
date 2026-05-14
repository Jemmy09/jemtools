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

# Clean up old exe now that new one is compiled
if (Test-Path "JEMTOOLS_old.exe") { 
    Remove-Item "JEMTOOLS_old.exe" -Force
    Write-Host "Old EXE removed." -ForegroundColor Green
}

# 3. Sign
Write-Host "Applying Digital Signature..." -ForegroundColor Yellow
$cert = Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object { $_.Subject -like "*CN=Jemmy Francisco*" } | Select-Object -First 1
if ($cert) {
    Set-AuthenticodeSignature -FilePath "JEMTOOLS.exe" -Certificate $cert
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

# JEM TOOLS | One-Click Update & Push
# This script automates compiling, signing, and pushing to GitHub.

Write-Host "--- JEM TOOLS Update Engine ---" -ForegroundColor Cyan

# 1. Compile
Write-Host "Compiling JEMTOOLS.exe..." -ForegroundColor Yellow
$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
& $csc /target:winexe /out:JEMTOOLS.exe /win32icon:assets\jem_logo.ico /reference:System.dll,System.Windows.Forms.dll,System.Drawing.dll,Microsoft.VisualBasic.dll,System.Core.dll "src\Program.cs"

if ($LASTEXITCODE -ne 0) { 
    Write-Host "ERROR: Compilation failed." -ForegroundColor Red
    exit 
}

# 2. Sign
Write-Host "Applying Digital Signature..." -ForegroundColor Yellow
$cert = Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object { $_.Subject -like "*CN=Jemmy Francisco*" } | Select-Object -First 1
if ($cert) {
    Set-AuthenticodeSignature -FilePath "JEMTOOLS.exe" -Certificate $cert
} else {
    Write-Host "WARNING: Signing certificate not found. Skipping signing." -ForegroundColor Magenta
}

# 3. Git Sync
Write-Host "Syncing with GitHub..." -ForegroundColor Yellow
git add .
git commit -m "Automated update: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')"
git push origin master

Write-Host "`n--- Update Complete! ---" -ForegroundColor Green
pause

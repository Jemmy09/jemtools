# JEM TOOLS | Logo Embedding Automation
# This script reads the logo image, converts it to Base64, and injects it into Program.cs

$logoPath = "assets/jem_logo.png"
$csPath = "src/Program.cs"

if (Test-Path $logoPath) {
    Write-Host "Encoding logo from $logoPath..." -ForegroundColor Cyan
    $bytes = [System.IO.File]::ReadAllBytes($logoPath)
    $b64 = [Convert]::ToBase64String($bytes)
    
    if (Test-Path $csPath) {
        Write-Host "Injecting Base64 into $csPath..." -ForegroundColor Yellow
        $csContent = [System.IO.File]::ReadAllText($csPath)
        
        $placeholder = 'return "BASE64_PLACEHOLDER";'
        $newValue = 'return "' + $b64 + '";'
        
        if ($csContent.Contains($placeholder)) {
            $csContent = $csContent.Replace($placeholder, $newValue)
            [System.IO.File]::WriteAllText($csPath, $csContent)
            Write-Host "Logo successfully embedded!" -ForegroundColor Green
        } else {
            Write-Host "WARNING: Placeholder not found in $csPath. Checking for existing logo..." -ForegroundColor Magenta
            # Regex to find existing return "..." in GetLogoBase64
            $regex = '(?s)private static string GetLogoBase64\(\)\s*\{.*?return ".*?";\s*\}'
            $newMethod = "private static string GetLogoBase64()`r`n        {`r`n            return `"$b64`";`r`n        }"
            if ($csContent -match $regex) {
                $csContent = $csContent -replace $regex, $newMethod
                [System.IO.File]::WriteAllText($csPath, $csContent)
                Write-Host "Existing logo updated successfully!" -ForegroundColor Green
            } else {
                Write-Host "ERROR: Could not find GetLogoBase64 method to update." -ForegroundColor Red
            }
        }
    } else {
        Write-Host "ERROR: $csPath not found." -ForegroundColor Red
    }
} else {
    Write-Host "ERROR: $logoPath not found." -ForegroundColor Red
}

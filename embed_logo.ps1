$b64 = [System.IO.File]::ReadAllText('logo_b64.txt')
$cs = [System.IO.File]::ReadAllText('Program.cs')

# Replace the file-based loading with embedded Base64 loading
$oldLine = 'try { logoBox.Image = Image.FromFile("jem_logo.png"); } catch { }'
$newLine = 'try { byte[] imgBytes = Convert.FromBase64String(GetLogoBase64()); using (var ms = new System.IO.MemoryStream(imgBytes)) { logoBox.Image = new Bitmap(ms); } } catch { }'

if ($cs.Contains($oldLine)) {
    $cs = $cs.Replace($oldLine, $newLine)
    Write-Host "Logo loading line replaced successfully."
} else {
    Write-Host "WARNING: Old line not found. Searching..."
    # Show what's around line 176
    $lines = $cs -split "`n"
    $lines[173..179] | ForEach-Object { Write-Host $_ }
}

# Add the GetLogoBase64 method before the closing brace of the class
$methodToAdd = @"

        private static string GetLogoBase64()
        {
            return "$b64";
        }
"@

# Insert before the last closing brace of the class
$insertMarker = '    }' + "`r`n}"
if ($cs.Contains($insertMarker)) {
    $cs = $cs.Replace($insertMarker, $methodToAdd + "`r`n    }`r`n}")
    Write-Host "GetLogoBase64 method added."
} else {
    Write-Host "WARNING: Insert marker not found."
}

[System.IO.File]::WriteAllText('Program.cs', $cs)
Write-Host "Program.cs updated successfully."

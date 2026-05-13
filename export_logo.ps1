$bytes = [System.IO.File]::ReadAllBytes("jem_logo.png")
$b64 = [System.Convert]::ToBase64String($bytes)
[System.IO.File]::WriteAllText("logo_b64.txt", $b64)
Write-Host "Done. Length: $($b64.Length)"

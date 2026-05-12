<div align="center">
  <img src="jem_logo.png" width="150" height="150" alt="JEM TOOLS Logo">
  
  # JEM TOOLS v1.0.3
  
  *A simple, sincere way to manage your Windows system tools.*

  [![Status](https://img.shields.io/badge/STATUS-LIVE-success?style=for-the-badge)](#)
  [![OS](https://img.shields.io/badge/WINDOWS-COMPATIBLE-blue?style=for-the-badge&logo=windows)](#)
  [![Version](https://img.shields.io/badge/VERSION-1.0.3-orange?style=for-the-badge)](#)
  [![Tech](https://img.shields.io/badge/C%23-.NET%204.8-purple?style=for-the-badge&logo=c-sharp)](#)
</div>

---

I built **JEM TOOLS** to make managing Windows system settings and administrative tasks a bit easier. It brings together **32 essential tools** and system commands into one simple dashboard so you don't have to go looking for them.

## What it does

- **All-in-one access**: Puts **32 different tools** from the Registry Editor to the Task Scheduler in one place.
- **System Monitoring**: Keeps a small eye on your CPU and RAM usage while you work.
- **Easy Navigation**: Categorized sections to help you find the right tool for the job.
- **Portable**: It's just one file. No need to install anything; just run it when you need it.
- **Compatible**: Should work fine on most versions of Windows (7, 8, 10, and 11).

## How to use it

### Quick Install via Terminal (PowerShell)
If you're in a hurry, you can just run this in PowerShell (as Administrator) to download and start the app:

```powershell
# Create folder and download files
mkdir "$env:USERPROFILE\Desktop\JEMTools"; cd "$env:USERPROFILE\Desktop\JEMTools"
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Jemmy09/jemtools/master/AdminTool.exe" -OutFile "AdminTool.exe"
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Jemmy09/jemtools/master/jem_logo.png" -OutFile "jem_logo.png"

# Launch the app
Start-Process ".\AdminTool.exe" -Verb runAs
```

### Manual Setup
1. Download `AdminTool.exe` and make sure `jem_logo.png` is in the same folder.
2. It's best to **Right-click** and **Run as Administrator** so it has the permissions it needs to open system tools.

### Finding Tools
- Use the **Sidebar** to filter by category if you know what you're looking for.
- Or just click the **🌐 ALL** button to see everything at once.
- The **Search bar** at the top is also pretty handy if you're in a hurry.

---

## A quick note on safety
Since this app opens system tools, just make sure you know what a tool does before you run it. 

I hope this helps make your system management a little faster!

---

<div align="center">
  <h2>👤 About the Developer</h2>
  
  **Jemmy Francisco**
  
  [<img src="https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white" alt="Facebook">](https://www.facebook.com/jemmy.francisco.98)
  [<img src="https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white" alt="Email">](mailto:Jemmyfrancisco30@gmail.com)

  <br><br>
  
  <b>JEM TOOLS - Precision System Intelligence.</b>
</div>

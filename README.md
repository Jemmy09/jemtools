# JEM TOOLS 🌐

I built **JEM TOOLS** to make managing Windows system settings and administrative tasks a bit easier. It brings together over 30 common tools and system commands into one simple dashboard so you don't have to go looking for them.

![JEM TOOLS Icon](jem_logo.png)

## What it does

- **All-in-one access**: Puts everything from the Registry Editor to the Task Scheduler in one place.
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

### Running a Tool
Just click on any card to open the tool. Some items (marked with a solid blue border) are "macros" that run a few system commands for you to save time.

## For Developers

If you want to look at the code or build it yourself from the `Program.cs` file, you can use the standard C# compiler:

```bash
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /out:AdminTool.exe Program.cs /r:System.dll,System.Drawing.dll,System.Windows.Forms.dll,Microsoft.VisualBasic.dll,System.Core.dll,System.Data.dll
```

## A quick note on safety
Since this app opens system tools, just make sure you know what a tool does before you run it. 

I hope this helps make your system management a little faster!

**JEM TOOLS - Precision System Intelligence.**

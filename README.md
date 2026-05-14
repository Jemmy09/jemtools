<div align="center">
  <img src="assets/jem_logo.png" width="120" height="120" alt="JEM TOOLS Logo">

  # JEM TOOLS
  ### Admin Edition · v1.0.7

  *Precision System Intelligence for Windows Professionals.*

  [![Status](https://img.shields.io/badge/STATUS-LIVE-00c853?style=for-the-badge)](#)
  [![Version](https://img.shields.io/badge/VERSION-1.0.7-0288d1?style=for-the-badge)](#)
  [![OS](https://img.shields.io/badge/WINDOWS-7%20%7C%208%20%7C%2010%20%7C%2011-0078d4?style=for-the-badge&logo=windows&logoColor=white)](#)
  [![Tech](https://img.shields.io/badge/C%23-.NET%204.8-7b1fa2?style=for-the-badge&logo=dotnet&logoColor=white)](#)
  [![License](https://img.shields.io/badge/License-MIT-f9a825?style=for-the-badge)](LICENSE)

</div>

---

## 🛠️ Project Blueprint
**JEM TOOLS** is a commercial-grade administrative utility designed for power users and IT professionals. It provides a centralized command center for system-level maintenance, security auditing, and real-time performance monitoring, all within a high-fidelity, privacy-first architecture.

The "Admin Edition" features the signature **Digital Gemstone** UI, providing a high-fidelity experience that turns complex system management into a streamlined, visual process.

---

## ✨ Premium Features

| Feature | Description |
|---|---|
| 🗂️ **51 Admin Modules** | Every essential Windows tool — from Registry Editor to Spotify Optimization — in one place |
| 📊 **Live Telemetry** | Real-time CPU & RAM monitoring with color-coded performance alerts |
| 🔍 **Instant Search** | Find any tool in milliseconds with the built-in search bar |
| 🗂️ **Category Filters** | Browse by Security, Admin, System, Maintenance, Network, or Utilities |
| 🛡️ **Interactive Setup** | Professional installer with EULA consent and customizable install options |
| ⚡ **Admin Macros** | One-click automated maintenance sequences for deep system care |
| 🖊️ **Digital Signature** | All binaries are verified and signed for system trust |
| 🖥️ **Portable Mode** | Use as a single `.exe` or install for system-wide integration |

---

## 🚀 Quick Installation (via PowerShell)
If you are comfortable with the command line, run this to deploy JEM TOOLS instantly:
1. Right-click the **Start Button** and select **Windows PowerShell (Admin)**.
2. Paste the command below and press Enter:
   ```powershell
   Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/Jemmy09/jemtools/master/setup.ps1'))
   ```

---

## 📦 Manual Installation (Beginner Friendly)
Follow these simple steps if you have no experience with GitHub or PowerShell:

### Step 1: Download
1. Click the green **Code** button at the top of this page.
2. Select **Download ZIP**.
3. Once the download finishes, right-click the file and select **Extract All...** to your Desktop.

### Step 2: Install
1. Open the extracted folder named `WinSystemTools`.
2. Find the file **`JEMTOOLS_Setup.exe`**.
3. **Right-click** it and select **Run as Administrator** (This ensures shortcuts are created correctly).

### Step 3: Finish
1. Check the box **"I have read and accept the User Agreement"**.
2. Choose if you want a **Desktop Shortcut** and click **Install**.
3. **JEM TOOLS** is now ready! You can find it on your Desktop or in `C:\Program Files\JEM TOOLS`.

---

## 🛠️ Automated Updates (Developer Only)
To update the application, recompile binaries, apply digital signatures, and sync with GitHub:
- Run `.\push.ps1`.

---

## 🗂️ Module Library

<details>
<summary><b>🔧 Maintenance (Deep Optimization)</b></summary>

- ⚡ **System Deep Clean**: Advanced junk removal and cache purging.
- 🌐 **Network Refresh**: Reset DNS, flush sockets, and optimize connectivity.
- 🛡️ **Security Lockdown**: Enforce recommended system security defaults.
- 🧹 **Disk Cleanup**: Native Windows disk optimization utility.
- 💿 **Defragment Drives**: Optimize file allocation for HDD performance.

</details>

<details>
<summary><b>💻 System (Core Management)</b></summary>

- 🔌 **Driver Updates**: Manage hardware drivers and resolve shortages.
- 🗑️ **Program Uninstaller**: Manage and remove installed applications.
- 💻 **Command Prompt**: Elevated terminal access.
- 🎛️ **Control Panel**: Centralized system settings.
- ⚙️ **System Configuration**: Manage startup and boot parameters (msconfig).
- ℹ️ **System Information**: Detailed hardware and software specifications.
- 📋 **Task Manager**: Real-time process monitoring and control.
- 📊 **Resource Monitor**: In-depth analysis of CPU, Memory, Disk, and Network.
- 🐚 **PowerShell Core**: Modern task automation shell.
- 🌀 **PowerShell ISE**: Integrated Scripting Environment for PowerShell.
- 🔑 **Registry Editor**: Advanced system registry database modification.
- 📡 **Remote Desktop**: Connect to and control remote workstations.
- 🏃 **Run Dialog**: Quickly execute commands or open programs.

</details>

<details>
<summary><b>⚙️ Admin (Infrastructure Tools)</b></summary>

- 🖥️ **Computer Management**: Consolidates multiple admin consoles.
- 💽 **Disk Management**: Partitioning and storage volume control.
- ⚙️ **Component Services**: Manage COM+ and DCOM configuration.
- 📜 **Event Viewer**: Analyze system logs and application errors.
- 📈 **Performance Monitor**: Detailed real-time system performance logging.
- 🛠️ **Services**: Manage background system services.
- 📅 **Task Scheduler**: Automate tasks and scripts via triggers.
- 🖨️ **Print Management**: Centralized printer and server control.
- 🗄️ **ODBC Data Sources**: Configure database connections and drivers.

</details>

<details>
<summary><b>🛡️ Security (Protection & Recovery)</b></summary>

- 🔒 **Security Policy**: Enforce local security and audit policies.
- 🧱 **Defender Firewall**: Advanced inbound/outbound security rules.
- 🔗 **iSCSI Initiator**: Connect to external network storage arrays.
- 🆘 **Recovery Drive**: Create a system repair environment.

</details>

<details>
<summary><b>📡 Network (Troubleshooting & Connectivity)</b></summary>

- 🔍 **IP Configuration**: Detailed network interface diagnostics.
- 🧼 **Flush DNS Cache**: Purge the local DNS resolver cache.
- 🔓 **Release/Renew IP**: Manage DHCP address leases.
- 🔄 **Reset Winsock**: Repair network catalog and protocols.
- 📶 **Reset TCP/IP**: Restore internet protocol suite to defaults.
- 📡 **Ping Google**: Continuous connectivity and latency test.
- 📊 **Network Statistics**: View active connections and listening ports.
- 🔗 **Network Connections**: Manage physical and virtual adapter settings.
- 🛠️ **Full Network Repair**: Total protocol stack restoration macro.

</details>

<details>
<summary><b>🔣 Utilities (Auxiliary Tools)</b></summary>

- 🔑 **Activation Methods**: Permanently activate Windows/Office via MAS.
- 🎵 **Spotify SpotX (Full)**: Comprehensive Spotify ad-blocker and optimizer.
- 🟢 **Spotify SpotX (New)**: Standard SpotX install with New Theme.
- 📻 **Spotify SpotX (Old)**: SpotX v1.2.13 with Old Theme and update blocking.
- 💎 **Spotify SpotX (Premium)**: Optimized configuration for Premium accounts.
- 🔣 **Character Map**: View and copy system character catalog.
- 📸 **Steps Recorder**: Capture UI actions for troubleshooting.
- 🧠 **Memory Diagnostic**: Check RAM for hardware-level errors.
- 🎵 **Media Player Legacy**: Classic Windows media playback hub.

</details>

---

## 🛠️ Recent Updates (v1.0.7)

- **Spotify SpotX Integration**: Added a dedicated suite of Spotify optimization tools for ad-blocking and theming.
- **Interactive Setup**: Redesigned `JEMTOOLS_Setup.exe` with EULA consent and customizable install options.
- **Visual Progress**: Added an animated loading bar to the installer for better feedback.
- **Module Expansion**: Integrated **Driver Updates** and **Activation Methods** (MAS).
- **Architecture**: Standardized installation to `C:\Program Files\JEM TOOLS` with Admin verification.
- **Optimization**: Implemented native alphabetical sorting for the entire 51-module library.
- **Publisher Verification**: Fully signed binaries by **Jemmy Francisco**.

---

## 📂 Repository Structure

| File/Folder | Description |
|---|---|
| 📁 **`src/`** | Core C# Source Code (Program.cs, Setup.cs) |
| 📁 **`assets/`** | Branding assets, icons, and Publisher certificates |
| 📁 **`scripts/`** | Deployment and automation logic |
| 📄 **`JEMTOOLS.exe`** | The signed, high-fidelity administrative suite |
| 📄 **`JEMTOOLS_Setup.exe`** | Professional graphical setup installer |
| 📄 **`setup.ps1`** | System-wide PowerShell deployment engine |
| 📄 **`push.ps1`** | Developer one-click build and sync tool |

---

## ⚠️ Safety Note
JEM TOOLS opens native Windows system utilities. Always ensure you understand a tool's function before execution. Run as **Administrator** to guarantee full functionality.

---

<div align="center">

## 👤 Developer

**Jemmy Francisco**
*Lead Architect & Developer*

[![Facebook](https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white)](https://www.facebook.com/jemmy.francisco.98)
[![Email](https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:Jemmyfrancisco30@gmail.com)

<br>

---

**JEM TOOLS · Admin Edition v1.0.7**
*© 2026 Jemmy Francisco · MIT License*

</div>

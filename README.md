<div align="center">
  <img src="assets/jem_logo.png" width="120" height="120" alt="JEM TOOLS Logo">

  # Jem Tools
  ### v1.0.8 (Production Edition)

  *Precision System Intelligence for Windows Professionals.*

  [![Status](https://img.shields.io/badge/STATUS-LIVE-00c853?style=for-the-badge)](#)
  [![Version](https://img.shields.io/badge/VERSION-1.0.8-0288d1?style=for-the-badge)](#)
  [![OS](https://img.shields.io/badge/WINDOWS-7%20%7C%208%20%7C%2010%20%7C%2011-0078d4?style=for-the-badge&logo=windows&logoColor=white)](#)
  [![Tech](https://img.shields.io/badge/C%23-.NET%204.8-7b1fa2?style=for-the-badge&logo=dotnet&logoColor=white)](#)
  [![License](https://img.shields.io/badge/License-MIT-f9a825?style=for-the-badge)](LICENSE)

</div>

---

## 🛠️ Project Blueprint
**Jem Tools** is a commercial-grade administrative utility designed for power users and IT professionals. It provides a centralized command center for system-level maintenance, security auditing, and real-time performance monitoring, all within a high-fidelity, privacy-first architecture.

The "Admin Edition" features a **Digital Gemstone** UI experience that turns complex system management into a streamlined, visual process.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🗂️ **60+ Admin Modules** | Every essential Windows tool — from Registry Editor to MRT — in one place |
| 📊 **Live Telemetry** | Real-time CPU & RAM monitoring with color-coded performance alerts |
| 🧠 **Ollama AI Core** | Automated local AI deployment via Winget and Llama3 for on-device intelligence |
| 🎵 **SpotX Integration** | Dedicated suite for Spotify optimization, ad-blocking, and modern theming |
| 🔍 **Instant Search** | Find any tool in milliseconds with the built-in infrastructure search |
| 🛡️ **Interactive Setup** | Professional installer with EULA consent and customizable deployment |
| ⚡ **Admin Macros** | One-click automated maintenance sequences for deep system care |
| 🖊️ **Digital Trust** | Signed binaries by **Jemmy Francisco** with included publisher certificate |

---

## 🚀 Quick Installation (via PowerShell)
Run this command in an **Elevated PowerShell** window to deploy JEM TOOLS instantly:

```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force; iwr 'https://github.com/Jemmy09/jemtools/archive/refs/heads/master.zip' -OutFile "$env:TEMP\jem.zip"; Expand-Archive "$env:TEMP\jem.zip" -Dest "$env:TEMP\jem" -Force; Start-Process "$env:TEMP\jem\jemtools-master\Setup.exe" -Verb RunAs
```

---

## 📦 Manual Installation

### Step 1: Download
1. Click the green **Code** button at the top of this page.
2. Select **Download ZIP**.
3. Extract the contents of the ZIP file to your Desktop.

### Step 2: Install
1. Open the extracted folder.
2. Find the file **`Setup.exe`**.
3. **Right-click** it and select **Run as Administrator**.

### Step 3: Deployment
1. Accept the **User Agreement**.
2. Select your installation preferences (Desktop Shortcut, Auto-Launch).
3. Click **Install**. JEM TOOLS will be deployed to `C:\Program Files\Jem Tools`.

---

## 🗂️ Module Library

<details>
<summary><b>🔧 Maintenance (Deep Optimization)</b></summary>

- ⚡ **System Deep Clean**: Advanced junk removal and cache purging.
- 🌐 **Network Refresh**: Reset DNS, flush sockets, and optimize connectivity.
- 🛡️ **Security Lockdown**: Enforce recommended system security defaults.
- 🧹 **Disk Cleanup**: Native Windows disk optimization utility.
- 💿 **Defragment Drives**: Optimize file allocation for HDD performance.
- 📂 **Prefetch Data**: Access prefetch optimization data for system speed.
- 🖼️ **Clear Icon Cache**: Reset and rebuild the Windows icon database.

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
- ⚙️ **System Properties**: Advanced system properties and environment variables.
- 🔑 **License Information**: View Windows license and activation status.

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
- 👥 **User Accounts (Advanced)**: Advanced user account management (netplwiz).
- 👤 **Local Users and Groups**: Local users and group management console.

</details>

<details>
<summary><b>🛡️ Security (Protection & Recovery)</b></summary>

- 🔒 **Security Policy**: Enforce local security and audit policies.
- 🧱 **Defender Firewall**: Advanced inbound/outbound security rules.
- 🔗 **iSCSI Initiator**: Connect to external network storage arrays.
- 🆘 **Recovery Drive**: Create a system repair environment.
- 🛡️ **Malicious Software Removal**: Microsoft Malicious Software Removal Tool (MRT).
- 🖋️ **File Signature Verifier**: Verify the integrity and signatures of system files.

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
- 📶 **Wi-Fi Settings**: Modern Windows Wi-Fi configuration portal.
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
- 🧠 **Memory Diagnostic**: Check system RAM for hardware errors.
- 🎵 **Media Player Legacy**: Access the classic multimedia player.
- 🧠 **Ollama AI Core**: Automated local AI deployment (Llama3).

</details>

---

## 🔒 Security & Trust
Jem Tools is built with a **Privacy-First** philosophy:
- **Offline Operation**: No telemetry or personal data leaves your machine.
- **Signed Binaries**: All executables are signed for publisher verification.
- **Manual Control**: Every tool can be launched via manual shortcut documented in the `About` view.

---

## 💻 System Requirements
- **OS**: Windows 7, 8, 10, 11 (64-bit recommended)
- **Runtime**: .NET Framework 4.8
- **Privileges**: Administrator access required for core modules.

---

## 📂 Repository Structure

| File/Folder | Description |
|---|---|
| 📁 **`Release/`** | Production-ready, signed binaries (Jem Tools.exe, Uninstaller.exe) |
| 📁 **`src/`** | Core C# Source Code (Program.cs, Setup.cs, Uninstall.cs) |
| 📁 **`assets/`** | Branding assets, icons, and Publisher certificates |
| 📁 **`scripts/`** | Build, deployment, and automation logic (push.ps1, setup.ps1) |
| 📄 **`Setup.exe`** | Professional graphical setup installer (Root Entry Point) |
| 📄 **`LICENSE`** | MIT License documentation |
| 📄 **`README.md`** | Project documentation and installation guide |

---

## 👤 Developer

**Jemmy Francisco**
*Lead Architect & Developer*

[![Facebook](https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white)](https://www.facebook.com/jemmy.francisco.98)
[![Email](https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:Jemmyfrancisco30@gmail.com)

---

<div align="center">

**JEM TOOLS · Admin Edition v1.0.8**
*© 2026 Jemmy Francisco · MIT License*

</div>

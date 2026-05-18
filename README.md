<div align="center">
  <img src="assets/jem_logo.png" width="120" height="120" alt="JEM TOOLS Logo">

  # Jem Tools
  ### v1.2.2 (Multi-Platform Edition)

  *Precision System Intelligence for Windows, macOS, and Linux Professionals.*

  [![Status](https://img.shields.io/badge/STATUS-LIVE-00c853?style=for-the-badge)](#)
  [![Version](https://img.shields.io/badge/VERSION-1.2.3-0288d1?style=for-the-badge)](#)
  [![Platforms](https://img.shields.io/badge/PLATFORMS-WIN%20%7C%20MAC%20%7C%20LINUX-0078d4?style=for-the-badge&logo=windows&logoColor=white)](#)
  [![QEMU](https://img.shields.io/badge/HYPERVISOR-QEMU%20q35-ff6f00?style=for-the-badge&logo=qemu&logoColor=white)](#)
  [![Tech](https://img.shields.io/badge/C%23-.NET%208%20%2F%204.8-7b1fa2?style=for-the-badge&logo=dotnet&logoColor=white)](#)
  [![License](https://img.shields.io/badge/License-MIT-f9a825?style=for-the-badge)](LICENSE)

</div>

---

## 🛠️ Project Blueprint
**Jem Tools** is a commercial-grade administrative utility designed for power users and IT professionals. It provides a centralized command center for system-level maintenance, security auditing, and real-time performance monitoring, all within a high-fidelity, privacy-first architecture.

The "Admin Edition" features a **Digital Gemstone** UI experience. v1.2.2 introduces the **JemVirtual Hypervisor Engine**, featuring a high-fidelity, card-based interface and professional system terminal for seamless, hardware-accelerated Virtual Machine deployment.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🗂️ **77 Professional Admin Modules** | Every essential system tool — from Registry Editor to MRT — in one place |
| 📊 **Live Telemetry** | Real-time CPU & RAM monitoring with color-coded performance alerts |
| 🖥️ **JemVirtual Hypervisor** | Full QEMU-powered VM engine with auto 40GB qcow2 disk, q35 SATA, hardware acceleration, USB passthrough & VRDP |
| 🧠 **Ollama AI Core** | Automated local AI deployment via Winget and Llama3 for on-device intelligence |
| 🎵 **SpotX Integration** | Dedicated suite for Spotify optimization, ad-blocking, and modern theming |
| 🔍 **Instant Search** | Find any tool in milliseconds with the built-in infrastructure search |
| 🛡️ **Interactive Setup** | Professional installer with EULA consent and customizable deployment |
| ⚡ **Admin Macros** | One-click automated maintenance sequences for deep system care |
| 🔌 **JemBoot Core** | Premium card-based boot engine for ISO/WIM/VHD deployment |
| 🖊️ **Digital Trust** | Signed binaries by **Jemmy Francisco** with included publisher certificate |

---

## 🚀 Installation

### 🟦 Windows (PowerShell)
Run this command in an **Elevated PowerShell** window to deploy JEM TOOLS instantly:
```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force; iwr 'https://github.com/Jemmy09/jemtools/archive/refs/heads/master.zip' -OutFile "$env:TEMP\jem.zip"; Expand-Archive "$env:TEMP\jem.zip" -Dest "$env:TEMP\jem" -Force; Start-Process "$env:TEMP\jem\jemtools-master\Setup.exe" -Verb RunAs
```

### 🍎 macOS (Terminal / .app Bundle)
```bash
git clone https://github.com/Jemmy09/jemtools.git
cd jemtools
dotnet run --project src/macOS/JemTools.macOS.csproj

# To generate a clickable "Jem Tools.app" bundle:
# Run the PowerShell build script: pwsh scripts/build_all_platforms.ps1
```

### 🐧 Linux (Bash / .desktop Launcher)
```bash
git clone https://github.com/Jemmy09/jemtools.git
cd jemtools
dotnet run --project src/Linux/JemTools.Linux.csproj

# To generate a clickable "Jem Tools.desktop" graphical launcher:
# Run the PowerShell build script: pwsh scripts/build_all_platforms.ps1
```

---

## 🗂️ Module Library (Cross-Platform Parity)
*All platforms (Windows, macOS, and Linux) feature exactly 77 professional administrative modules organized into the following 8 identical categories.*

<details>
<summary><b>🔧 Maintenance</b></summary>

- ⚡ **System Deep Clean**: Full administrative system maintenance.
- 📡 **Network Refresh**: Reset adapters and flush DNS.
- 🛡️ **Security Lockdown**: Enable all firewall profiles.
- 🧹 **Disk Cleanup**: Remove redundant files.
- 💿 **Defragment Drives**: Optimize storage performance.
- 📂 **Prefetch Data**: Access prefetch optimization data.
- 🖼️ **Clear Icon Cache**: Reset and rebuild the icon database.
</details>

<details>
<summary><b>💻 System</b></summary>

- 🔌 **Driver Updates**: Manage hardware and driver updates.
- 🗑️ **Program Uninstaller**: Add or remove programs.
- 💻 **Command Prompt**: Standard command-line.
- 🎛️ **Control Panel**: Legacy settings.
- ⚙️ **System Configuration**: Boot and service config.
- ℹ️ **System Information**: HW and SW environment details.
- 📋 **Task Manager**: Process governance.
- 📊 **Resource Monitor**: Resource analytics.
- 🐚 **PowerShell Core**: Modern system shell.
- 🌀 **PowerShell ISE**: Integrated Scripting Environment.
- 🔑 **Registry Editor**: Registry modification.
- 📡 **Remote Desktop**: Remote access.
- 🏃 **Run Dialog**: Classic run command.
- ⚙️ **System Properties**: Advanced system properties and variables.
- 🔑 **License Information**: View Windows license and activation status.
</details>

<details>
<summary><b>⚙️ Admin</b></summary>

- 🖥️ **Computer Management**: Unified admin console.
- 💽 **Disk Management**: Storage volume management.
- ⚙️ **Component Services**: COM+ and DCOM management.
- 📜 **Event Viewer**: System logs.
- 📈 **Performance Monitor**: Real-time HW monitoring.
- 🛠️ **Services**: Service management.
- 📅 **Task Scheduler**: Automated task engine.
- 🖨️ **Print Management**: Printer and driver console.
- 🗄️ **ODBC Data Sources**: Database connectivity (64-bit).
- 👥 **User Accounts (Advanced)**: Advanced user account management.
- 👤 **Local Users and Groups**: Local users and group console.
</details>

<details>
<summary><b>🛡️ Security</b></summary>

- 🔒 **Security Policy**: Local security policies.
- 🧱 **Defender Firewall**: Network security.
- 🔗 **iSCSI Initiator**: Storage area network config.
- 🆘 **Recovery Drive**: Create system recovery media.
- 🛡️ **Malicious Software Removal**: Microsoft Malicious Software Removal Tool.
- 🖋️ **File Signature Verifier**: Verify the integrity of system files.
</details>

<details>
<summary><b>🔣 Utilities</b></summary>

- 🔑 **Activation Methods**: Permanently activate Windows and Office.
- 🎵 **Spotify SpotX (Full)**: Full Spotify ad-block and theme optimization.
- 🟢 **Spotify SpotX (New)**: SpotX installation with New Theme.
- 📻 **Spotify SpotX (Old)**: SpotX installation with Old Theme (v1.2.13).
- 💎 **Spotify SpotX (Premium)**: Spotify optimization for Premium accounts.
- 🔣 **Character Map**: System character catalog.
- 📸 **Steps Recorder**: Record UI actions for debugging.
- 🧠 **Memory Diagnostic**: Check RAM for errors.
- 🎵 **Media Player Legacy**: Legacy multimedia hub.
- 🧠 **Ollama AI Core**: Deploy local AI with Llama3.
</details>

<details>
<summary><b>📡 Network</b></summary>

- 🔍 **IP Config (All)**: Detailed network interface configuration.
- 🧼 **Flush DNS Cache**: Purge the DNS resolver cache.
- 🔓 **Release IP**: Release current IPv4.
- 🔑 **Renew IP**: Request new IPv4.
- 🔄 **Winsock Reset**: Repair network catalog.
- 📶 **TCP/IP Reset**: Reset TCP/IP stack.
- 📡 **Ping Google**: Continuous connectivity test.
- 📊 **Network Stats**: View active ports.
- 🔗 **Network Connections**: Manage adapter settings.
- 📶 **Wi-Fi Settings**: Windows 10/11 Wi-Fi config.
- 🛠️ **Full Network Repair**: Total protocol restoration.
</details>

<details>
<summary><b>🔌 JemBoot</b></summary>

- 🔌 **List USB Drives**: List all connected USB storage devices.
- 🧹 **Quick Format USB**: Wipe and format USB drive as NTFS.
- ⏏️ **Eject All USBs**: Safely remove all USB storage devices.
</details>

<details>
<summary><b>📥 Installers</b></summary>

- 📦 **Install 7-Zip**: Open-source file archiver.
- 🗜️ **Install WinRAR**: Popular compression utility.
- 🗃️ **Install PeaZip**: Free archive manager.
- 💻 **Install VS Code**: Modern source code editor.
- 🤖 **Install Cursor**: AI-first code editor.
- ☕ **Install Eclipse**: Java Development IDE.
- 🎨 **Install Blender**: 3D creation suite.
- 📄 **Install Acrobat**: PDF viewer by Adobe.
- 🎬 **Install DaVinci Resolve**: Free video editor (Stable).
- 🖼️ **Install Photoshop CS6 x64**: Portable CS6 (x64).
- 🖌️ **Install Photoshop CS6 x86**: Portable CS6 (x86).
- 🎨 **Install Photoshop CS3**: Portable CS3.
- 💿 **Install CrystalDiskMark**: Disk benchmark tool v9.0.2.
- 🔥 **Install OCCT**: PC stability & stress test.
</details>

## 🗂️ Module Library (macOS)

<details>
<summary><b>🔧 Maintenance</b></summary>

- ⚡ **Software Update**: Check for system software updates.
- 🧹 **Clear User Cache**: Purge local user cache files.
- 📂 **Clear System Cache**: Purge system-wide cache files.
- 🔧 **Reset Permissions**: Fix home directory permissions.
- 📊 **Purge Memory**: Force flush disk buffers/cache.
- 🔍 **Spotlight Re-index**: Rebuild Spotlight search index.
- 🚀 **Launch Services Reset**: Rebuild app association database.
- 🔋 **Battery Health**: Check battery power status.
- 🌙 **System Sleep Image**: Check hibernation file size.
- 🔄 **System Restart**: Immediate system reboot.
</details>

<details>
<summary><b>💻 System</b></summary>

- 📋 **Activity Monitor**: Monitor processes and resources.
- ℹ️ **System Information**: Detailed HW/SW specifications.
- 💻 **Hardware Profiler**: CLI hardware summary.
- ⚙️ **CPU Brand String**: Detailed processor model.
- 📊 **Memory Capacity**: Total physical RAM in bytes.
- 🐧 **Kernel Version**: Darwin kernel build info.
- 🍎 **macOS Version**: Operating system build details.
- 📦 **Loaded Extensions**: List active kernel extensions.
- 🏁 **Boot Arguments**: View NVRAM boot parameters.
- 🐚 **Terminal Shell**: Standard macOS terminal.
</details>

<details>
<summary><b>⚙️ Admin</b></summary>

- ⚙️ **Service List**: List managed services.
- 💽 **Disk Utility**: Graphical disk management.
- 📜 **Console Logs**: System and app log viewer.
- 👥 **User Accounts**: List all system users.
- 👤 **Group Accounts**: List all system groups.
- 🗄️ **Directory Utility**: Advanced directory config.
- 📡 **Screen Sharing**: Remote desktop client.
- ⏱️ **System Uptime**: Check time since last boot.
- 🔌 **Power Management**: View energy saver settings.
- 📅 **Scheduled Events**: View wake/sleep schedule.
</details>

<details>
<summary><b>🛡️ Security</b></summary>

- 🛡️ **Firewall Status**: Check Application Firewall.
- 🔒 **Gatekeeper Info**: Audit app security policy.
- 🧱 **FileVault Status**: Check disk encryption.
- 📂 **Open Network Files**: List files with network IDs.
- 🔒 **Listening Ports**: Audit active listeners.
- 🗝️ **Login Items**: List startup applications.
- 🖋️ **Security Audit**: Audit code sign identities.
- 🗝️ **Keychain Info**: List active keychains.
- 📡 **Remote Login**: Check SSH/SFTP status.
- 🔐 **Firmware Security**: Check EFI password status.
</details>

<details>
<summary><b>📡 Network</b></summary>

- 🔍 **IP Configuration**: Detailed interface diagnostics.
- 🧼 **DNS Cache Flush**: Purge DNS resolver cache.
- 📡 **Wi-Fi Profile**: Detailed Wi-Fi connection info.
- 🔄 **Connectivity Test**: Check internet latency.
- 📶 **Trace Route**: Map network hop paths.
- 🛠️ **Network Diagnostics**: Legacy network toolkit.
- 🗺️ **Active Routing**: Analyze routing table.
- 👥 **ARP Table**: Analyze neighbor devices.
- 🌐 **DNS Query (Dig)**: Advanced DNS record lookup.
- 🔗 **Interface Setup**: List all network services.
</details>

<details>
<summary><b>🔣 Utilities</b></summary>

- 📝 **TextEdit**: Native plain text editor.
- 📁 **Finder**: Open current directory.
- 🧠 **Ollama AI Core**: Local AI deployment.
- 🧮 **Calculator**: Native math utility.
- 📅 **Calendar**: Schedule and events.
- 📸 **Screenshot Toolkit**: Capture screen images/video.
- 🔣 **Font Book**: Manage system fonts.
- 🗝️ **Keychain Access**: Manage saved passwords.
- 🎨 **ColorSync**: Display color management.
- 📜 **Script Editor**: AppleScript and JXA tool.
</details>

<details>
<summary><b>🔌 JemBoot</b></summary>

- 🔌 **List USB Drives**: Identify connected USB media.
- 💾 **Storage Usage**: Analyze mount points.
- 📀 **Verify Disk**: Check disk partition map.

</details>

## 🗂️ Module Library (Linux)

<details>
<summary><b>🔧 Maintenance</b></summary>

- ⚡ **System Update**: Full system package synchronization.
- 🧹 **Package Cleanup**: Remove unused dependencies.
- 💿 **SSD Trim**: Optimize SSD block allocation.
- 📂 **Clear System Logs**: Purge old journal entries.
- 🖼️ **Clear Temp Cache**: Purge temporary system files.
- 🏁 **Update Grub**: Refresh bootloader configuration.
- 🧠 **Refresh Initramfs**: Update initial RAM filesystem.
- 🔧 **Repair Packages**: Fix broken dependency trees.
- 🔓 **Fix Dpkg Lock**: Remove package manager locks.
- 🔄 **System Reboot**: Perform a clean system restart.
</details>

<details>
<summary><b>💻 System</b></summary>

- 📋 **Process Monitor**: Advanced interactive monitor.
- ℹ️ **System Info**: View architecture and kernel.
- 💻 **Hardware Lister**: Brief hardware configuration.
- ⚙️ **CPU Architecture**: Detailed processor specifications.
- 📊 **Memory Stats**: Analyze RAM and swap usage.
- 🔌 **PCI Bus Devices**: List all internal PCI devices.
- 🖱️ **USB Bus Devices**: List all connected USB devices.
- 🐧 **Kernel Specs**: View kernel and build details.
- 📦 **Loaded Modules**: List active kernel modules.
- 🐚 **Terminal Shell**: Open default system terminal.
</details>

<details>
<summary><b>⚙️ Admin</b></summary>

- ⚙️ **Service Manager**: List and manage background tasks.
- 💽 **Partition Editor**: Graphical disk management.
- 📜 **Real-time Logs**: Stream system log messages.
- 📅 **Task Scheduler**: View automated cron jobs.
- 👥 **User List**: List all registered accounts.
- 👤 **Active Sessions**: View currently logged in users.
- ⏱️ **System Uptime**: Check how long system has run.
- 🏃 **Runlevel Status**: Check current system state.
- 🏷️ **Hostname Config**: View system network name.
- 🗄️ **DMI Table Info**: View BIOS/Firmware data.
</details>

<details>
<summary><b>🛡️ Security</b></summary>

- 🛡️ **Firewall Status**: Audit UFW configurations.
- 🔒 **Network Ports**: Analyze listening services.
- 🗝️ **SSH Audit**: Review SSH login attempts.
- 🆘 **Failed Logins**: Check recent failed logins.
- 🔗 **AppArmor Status**: Check security profiles.
- 🧱 **SELinux Context**: Check SELinux enforcement.
- 🔑 **Password Aging**: View account security dates.
- 🖋️ **Sudoers Check**: Audit sudo privileges.
- 🆘 **File Integrity**: Check file attributes.
- 🎲 **System Entropy**: Analyze randomness pool.
</details>

<details>
<summary><b>📡 Network</b></summary>

- 🔍 **IP Config**: Analyze network interfaces.
- 🧼 **DNS Cache Flush**: Purge local DNS resolver.
- 📡 **Network Manager**: View device configurations.
- 🔄 **Connectivity Test**: Check internet latency.
- 📶 **Trace Route**: Map network hop paths.
- 🌐 **DNS Query (Dig)**: Perform advanced DNS lookup.
- 🔗 **Host Lookup**: Translate name to IP.
- 📊 **Socket Stats**: View connection summaries.
- 🗺️ **Route Table**: Analyze network routing.
- 👥 **ARP Table**: Analyze neighbor devices.
</details>

<details>
<summary><b>🔣 Utilities</b></summary>

- 📝 **Terminal Editor**: Lightweight text editor.
- 📁 **File Browser**: Open current directory.
- 🧠 **Ollama AI Core**: Local AI deployment.
- 🧮 **Calculator (bc)**: Precision math engine.
- 📅 **System Calendar**: View terminal calendar.
- 🔢 **Base64 Encoder**: Encode text to Base64.
- 💎 **SHA256 Hash**: Check file integrity.
- 🗝️ **Password Gen**: Create secure passwords.
- 🔣 **Character Map**: View symbol catalog.
- 🌍 **Localization**: View system locale.
</details>

<details>
<summary><b>🔌 JemBoot</b></summary>

- 🔌 **Block Layout**: Map all storage disks.
- 💾 **Active Mounts**: View mounted filesystems.
- 📀 **Disk Partitioning**: View partition tables.

</details>

## 🔒 Security & Trust
Jem Tools is built with a **Privacy-First** philosophy:
- **Offline Operation**: No telemetry or personal data leaves your machine.
- **Signed Binaries**: All executables are signed for publisher verification.
- **Manual Control**: Every tool can be launched via manual shortcut documented in the `About` view.

---

## 📂 Repository Structure

| File/Folder | Description |
|---|---|
| 📁 **`Release/`** | Production-ready, signed binaries (Jem Tools.exe, Uninstaller.exe) |
| 📁 **`src/`** | Core C# Source Code (Shared, Windows, macOS, Linux) |
| 📁 **`assets/`** | Branding assets, icons, and Publisher certificates |
| 📁 **`scripts/`** | Build, deployment, and automation PowerShell logic |
| 📄 **`Setup.exe`** | Professional graphical setup installer |
| 💾 **`JemVirtual_Disk.qcow2`** | Auto-generated 40GB sparse virtual hard disk (created on first VM boot) |

---

## 👤 Developer

**Jemmy Francisco**  
*Lead Architect & Developer*

---

## ⚙️ JemVirtual — Hypervisor Requirements

To use the **JemVirtual** virtualization engine, you need the following installed on your host Windows machine:

| Requirement | Details |
|---|---|
| 🔧 **QEMU for Windows** | Install from [qemu.org](https://www.qemu.org/download/#windows) — Default path: `C:\Program Files\qemu\` |
| ⚡ **Windows Hypervisor Platform** | Enable via *Turn Windows features on or off* for hardware-accelerated VM speed |
| 💾 **40GB Free Disk Space** | Required for the auto-generated `JemVirtual_Disk.qcow2` virtual hard disk |
| 🖥️ **Windows 10 / 11 ISO** | Your own legally obtained installation media |

> **Note:** The virtual disk is created automatically the first time you click **BOOT VIRTUAL MACHINE**. No manual configuration needed.

---
<div align="center">
  JEM TOOLS Build Engine | 2026 — v1.2.3 Hypervisor Edition
</div>

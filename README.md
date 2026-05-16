<div align="center">
  <img src="assets/jem_logo.png" width="120" height="120" alt="JEM TOOLS Logo">

  # Jem Tools
  ### v1.2.2 (Multi-Platform Edition)

  *Precision System Intelligence for Windows, macOS, and Linux Professionals.*

  [![Status](https://img.shields.io/badge/STATUS-LIVE-00c853?style=for-the-badge)](#)
  [![Version](https://img.shields.io/badge/VERSION-1.2.2-0288d1?style=for-the-badge)](#)
  [![Platforms](https://img.shields.io/badge/PLATFORMS-WIN%20%7C%20MAC%20%7C%20LINUX-0078d4?style=for-the-badge&logo=windows&logoColor=white)](#)
  [![Tech](https://img.shields.io/badge/C%23-.NET%208%20%2F%204.8-7b1fa2?style=for-the-badge&logo=dotnet&logoColor=white)](#)
  [![License](https://img.shields.io/badge/License-MIT-f9a825?style=for-the-badge)](LICENSE)

</div>

---

## 🛠️ Project Blueprint
**Jem Tools** is a commercial-grade administrative utility designed for power users and IT professionals. It provides a centralized command center for system-level maintenance, security auditing, and real-time performance monitoring, all within a high-fidelity, privacy-first architecture.

The "Admin Edition" features a **Digital Gemstone** UI experience. v1.2.2 introduces the **JemBoot Command Center**, featuring a high-fidelity, card-based interface and professional system terminal for streamlined media creation.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🗂️ **63+ Admin Modules** | Every essential system tool — from Registry Editor to MRT — in one place |
| 📊 **Live Telemetry** | Real-time CPU & RAM monitoring with color-coded performance alerts |
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
*All platforms (Windows, macOS, and Linux) feature exactly 63 professional administrative modules organized into the following 7 identical categories.*

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

<details>
<summary><b>🔌 JemBoot (Bootable Media Engine)</b></summary>

- 🔌 **Boot Command**: Dual-mode bootable creation (Single/Multi-Boot).
- 💿 **Integrated Engine**: Install JemBoot Core and simply drag & drop ISO files.
- 🛡️ **Secure Boot Support**: Signed bootloader for modern UEFI compatibility.
- 💾 **Universal Targets**: Transform USB Flash, SSD, and HDD into bootable media.
- 🧹 **Quick Format USB**: One-click NTFS/GPT initialization for removable storage.
- ⏏️ **Safely Eject All**: Automated sequence to safely unmount all USB devices.

</details>

<details open>
<summary><b>🌍 Multi-Platform Expansion (Windows, macOS, Linux)</b></summary>

- 🖥️ **Shared Intelligence**: Consistent 1:1 module parity across all operating systems.
- 🍎 **macOS Native Integration**: Tools utilizing `diskutil`, `softwareupdate`, `system_profiler`, and native launch daemons.
- 🐧 **Linux Native Integration**: Bash scripts leveraging `ufw`, `journalctl`, `fstrim`, `apt/dnf`, and `systemd`.
- 🔄 **Synchronized TUI**: High-fidelity Terminal User Interface (TUI) for Unix systems powered by `.NET 8`, ensuring the same "Digital Gemstone" aesthetic.
- 📦 **Native Execution**: Optimized command delivery using native shells (PowerShell, Zsh, Bash) for ultimate stability.

</details>

---

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
| 📁 **`scripts/`** | Build, deployment, and automation logic |
| 📄 **`Setup.exe`** | Professional graphical setup installer |

---

## 👤 Developer

**Jemmy Francisco**  
*Lead Architect & Developer*

---
<div align="center">
  JEM TOOLS Build Engine | 2026
</div>

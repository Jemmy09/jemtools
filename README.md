# JEM TOOLS | Admin Edition 🌐

**JEM TOOLS** is a professional-grade, high-fidelity administrative suite designed for Windows infrastructure management. It consolidates over 30+ critical system utilities, diagnostic tools, and administrative macros into a single, high-performance "Universal Edition" command center.

![JEM TOOLS Branding](jem_logo.png)

## 🚀 Key Features

- **Consolidated Governance**: Instant access to standard Windows tools (Registry Editor, Task Manager, Event Viewer) and specialized diagnostics.
- **Intelligence Hub**: Real-time telemetry monitoring for CPU and RAM performance.
- **Universal Compatibility**: Optimized for seamless operation across Windows 7, 8, 10, and 11.
- **Modern UI/UX**: Premium dark-mode interface with a responsive sidebar and unified branding.
- **Zero-Install Portability**: Runs as a single portable binary with no registry-bloating installation required.

---

## 🛠️ How to Install

JEM TOOLS is designed for portability and fast deployment.

### 1. Requirements
- **Operating System**: Windows 7 SP1 or newer.
- **Framework**: .NET Framework 4.8 (Included by default in Windows 10/11).

### 2. Setup
1. Download the latest `AdminTool.exe` and `jem_logo.png` from this repository.
2. Place both files in the same folder (e.g., `C:\Tools\JemTools`).
3. **Right-click** `AdminTool.exe` and select **Run as Administrator** to ensure all system modules have full access.

---

## 📖 How to Use

### Navigation
- **Infrastructure Nodes**: Use the sidebar to filter tools by category (MAINTENANCE, SYSTEM, ADMIN, SECURITY, UTILITIES).
- **Show All**: Click the **🌐 ALL** button to view the entire library of 30+ modules.
- **Sidebar Toggle**: Click the **≡ Burger Button** or **✕ Close** icon to expand or collapse the navigation menu.

### Tool Execution
- **Search**: Use the top search bar to instantly filter tools by name or description.
- **Launch**: Click any tool card to execute the command. Administrative tools will automatically request elevation if needed.
- **Macros**: Tools marked with a **solid accent border** are high-level administrative macros that execute multiple system commands in sequence.

---

## 💻 Development & Compilation

If you wish to compile the source code (`Program.cs`) manually:

1. Open PowerShell or Command Prompt.
2. Run the following command (assuming .NET Framework path):
   ```bash
   C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /out:AdminTool.exe Program.cs /r:System.dll,System.Drawing.dll,System.Windows.Forms.dll,Microsoft.VisualBasic.dll,System.Core.dll,System.Data.dll
   ```

---

## 🛡️ License & Security
Developed for professional administrative use. Ensure you have the necessary permissions before executing system-level macros.

**JEM TOOLS - Precision System Intelligence.**

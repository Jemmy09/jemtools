using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WindowsSystemToolMenu
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            try {
                if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ModernAdminForm());
            } catch (Exception ex) {
                MessageBox.Show("Infrastructure Error: " + ex.Message);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }

    public class ToolItem
    {
        public string SpecificName { get; set; }
        public string Command { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsMacro { get; set; }
    }

    public class ModernAdminForm : Form
    {
        private Panel sidebar;
        private Panel sidebarContent;
        private Panel contentWrapper;
        private TableLayoutPanel mainLayout;
        private FlowLayoutPanel cardContainer;
        private List<ToolItem> tools;
        private string currentCategory = "ALL";
        private Label cpuLabel;
        private Label ramLabel;
        private Label moduleCountLabel;
        private Timer statsTimer;
        private Timer navTimer;
        private TextBox searchBox;
        private ToolTip toolTip;
        private bool isSidebarExpanded = true;
        private Button mainBurgerBtn;
        private List<Button> categoryButtons = new List<Button>();

        private PerformanceCounter cpuCounter;
        private Microsoft.VisualBasic.Devices.ComputerInfo computerInfo;

        private int sidebarMaxWidth = 320; // Expanded for intelligence features
        private Color accentColor = Color.FromArgb(0, 180, 255);
        private Color darkBg = Color.FromArgb(10, 10, 12);
        private Color cardBg = Color.FromArgb(20, 20, 26);
        private Color sidebarBg = Color.FromArgb(15, 15, 20);
        private Color alertColor = Color.FromArgb(255, 60, 60);

        public ModernAdminForm()
        {
            this.Text = "JEM TOOLS | Admin Edition v1.0.3";
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1200, 800);
            this.BackColor = darkBg;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10);
            this.DoubleBuffered = true;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            toolTip = new ToolTip();

            InitializeCounters();
            InitializeTools();
            BuildUI();
            LoadState();
            UpdateSidebarColors();
            StartStats();
            InitNavAnimation();
        }

        private void InitializeCounters()
        {
            try {
                // Defensive initialization for broad OS compatibility
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue(); // Pre-warm the counter
                computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
            } catch (Exception ex) { 
                LogActivity("Telemetry limited: " + ex.Message);
            }
        }

        private void InitializeTools()
        {
            tools = new List<ToolItem>
            {
                // MAINTENANCE
                new ToolItem { SpecificName = "System Deep Clean", Command = "cleanmgr /sageset:1 & cleanmgr /sagerun:1", Icon = "⚡", Category = "MAINTENANCE", IsMacro = true, Description = "Full administrative system maintenance." },
                new ToolItem { SpecificName = "Network Refresh", Command = "ipconfig /release & ipconfig /renew & ipconfig /flushdns", Icon = "📡", Category = "MAINTENANCE", IsMacro = true, Description = "Reset adapters and flush DNS." },
                new ToolItem { SpecificName = "Security Lockdown", Command = "netsh advfirewall set allprofiles state on", Icon = "🛡️", Category = "MAINTENANCE", IsMacro = true, Description = "Enable all firewall profiles." },
                new ToolItem { SpecificName = "Disk Cleanup", Command = "cleanmgr", Icon = "🧹", Category = "MAINTENANCE", Description = "Remove redundant files." },
                new ToolItem { SpecificName = "Defragment Drives", Command = "dfrgui", Icon = "💿", Category = "MAINTENANCE", Description = "Optimize storage performance." },

                // SYSTEM
                new ToolItem { SpecificName = "Command Prompt", Command = "cmd", Icon = "💻", Category = "SYSTEM", Description = "Standard command-line." },
                new ToolItem { SpecificName = "Control Panel", Command = "control", Icon = "🎛️", Category = "SYSTEM", Description = "Legacy settings." },
                new ToolItem { SpecificName = "System Configuration", Command = "msconfig", Icon = "⚙️", Category = "SYSTEM", Description = "Boot and service config." },
                new ToolItem { SpecificName = "System Information", Command = "msinfo32", Icon = "ℹ️", Category = "SYSTEM", Description = "HW and SW environment details." },
                new ToolItem { SpecificName = "Task Manager", Command = "taskmgr", Icon = "📋", Category = "SYSTEM", Description = "Process governance." },
                new ToolItem { SpecificName = "Resource Monitor", Command = "resmon", Icon = "📊", Category = "SYSTEM", Description = "Resource analytics." },
                new ToolItem { SpecificName = "PowerShell Core", Command = "powershell", Icon = "🐚", Category = "SYSTEM", Description = "Modern system shell." },
                new ToolItem { SpecificName = "PowerShell ISE", Command = "powershell_ise", Icon = "🌀", Category = "SYSTEM", Description = "Integrated Scripting Environment." },
                new ToolItem { SpecificName = "Registry Editor", Command = "regedit", Icon = "🔑", Category = "SYSTEM", Description = "Registry modification." },
                new ToolItem { SpecificName = "Remote Desktop", Command = "mstsc", Icon = "📡", Category = "SYSTEM", Description = "Remote access." },
                new ToolItem { SpecificName = "Run Dialog", Command = "explorer.exe shell:::{2559a1f3-21d7-11d4-bdaf-00c04f60b9f0}", Icon = "🏃", Category = "SYSTEM", Description = "Classic run command." },

                // ADMIN
                new ToolItem { SpecificName = "Computer Management", Command = "compmgmt.msc", Icon = "🖥️", Category = "ADMIN", Description = "Unified admin console." },
                new ToolItem { SpecificName = "Component Services", Command = "dcomcnfg", Icon = "⚙️", Category = "ADMIN", Description = "COM+ and DCOM management." },
                new ToolItem { SpecificName = "Event Viewer", Command = "eventvwr", Icon = "📜", Category = "ADMIN", Description = "System logs." },
                new ToolItem { SpecificName = "Performance Monitor", Command = "perfmon", Icon = "📈", Category = "ADMIN", Description = "Real-time HW monitoring." },
                new ToolItem { SpecificName = "Services", Command = "services.msc", Icon = "🛠️", Category = "ADMIN", Description = "Service management." },
                new ToolItem { SpecificName = "Task Scheduler", Command = "taskschd.msc", Icon = "📅", Category = "ADMIN", Description = "Automated task engine." },
                new ToolItem { SpecificName = "Print Management", Command = "printmanagement.msc", Icon = "🖨️", Category = "ADMIN", Description = "Printer and driver console." },
                new ToolItem { SpecificName = "ODBC Data Sources", Command = "odbcad32.exe", Icon = "🗄️", Category = "ADMIN", Description = "Database connectivity (64-bit)." },

                // SECURITY
                new ToolItem { SpecificName = "Security Policy", Command = "secpol.msc", Icon = "🔒", Category = "SECURITY", Description = "Local security policies." },
                new ToolItem { SpecificName = "Defender Firewall", Command = "wf.msc", Icon = "🧱", Category = "SECURITY", Description = "Network security." },
                new ToolItem { SpecificName = "iSCSI Initiator", Command = "iscsicpl.exe", Icon = "🔗", Category = "SECURITY", Description = "Storage area network config." },
                new ToolItem { SpecificName = "Recovery Drive", Command = "recoverydrive.exe", Icon = "🆘", Category = "SECURITY", Description = "Create system recovery media." },

                // UTILITIES
                new ToolItem { SpecificName = "Character Map", Command = "charmap", Icon = "🔣", Category = "UTILITIES", Description = "System character catalog." },
                new ToolItem { SpecificName = "Steps Recorder", Command = "psr.exe", Icon = "📸", Category = "UTILITIES", Description = "Record UI actions for debugging." },
                new ToolItem { SpecificName = "Memory Diagnostic", Command = "mdsched.exe", Icon = "🧠", Category = "UTILITIES", Description = "Check RAM for errors." },
                new ToolItem { SpecificName = "Media Player Legacy", Command = "wmplayer.exe", Icon = "🎵", Category = "UTILITIES", Description = "Legacy multimedia hub." }
            };
        }

        private void BuildUI()
        {
            contentWrapper = new Panel { Dock = DockStyle.Fill, BackColor = darkBg };
            this.Controls.Add(contentWrapper);

            // Sidebar
            sidebar = new Panel { Width = sidebarMaxWidth, Dock = DockStyle.Left, BackColor = sidebarBg, Padding = new Padding(0) };
            contentWrapper.Controls.Add(sidebar);

            Panel sideHeader = new Panel { Height = 80, Dock = DockStyle.Top, BackColor = Color.FromArgb(20, 20, 25), Padding = new Padding(15, 0, 0, 0) };
            
            FlowLayoutPanel brandContainer = new FlowLayoutPanel {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 16, 0, 0)
            };

            PictureBox logoBox = new PictureBox {
                Size = new Size(48, 48),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                Margin = new Padding(0)
            };
            try { logoBox.Image = Image.FromFile("jem_logo.png"); } catch { }
            
            Label brand = new Label { 
                Text = "JEM TOOLS", 
                Font = new Font("Segoe UI Black", 14), 
                ForeColor = accentColor, 
                Height = 48,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true,
                Margin = new Padding(10, 0, 0, 0)
            };
            
            Button sideClose = new Button { Text = "✕", Size = new Size(50, 80), Dock = DockStyle.Right, FlatStyle = FlatStyle.Flat, ForeColor = Color.White, Cursor = Cursors.Hand };
            sideClose.FlatAppearance.BorderSize = 0;
            sideClose.Click += (s, e) => StartNavToggle();
            
            brandContainer.Controls.Add(logoBox);
            brandContainer.Controls.Add(brand);
            
            sideHeader.Controls.Add(brandContainer);
            sideHeader.Controls.Add(sideClose);
            sidebar.Controls.Add(sideHeader);

            sidebarContent = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            sidebar.Controls.Add(sidebarContent);

            // Infrastructure Nodes (Navigation)
            Label catHeader = new Label { Text = "INFRASTRUCTURE NODES", Dock = DockStyle.Top, Height = 40, ForeColor = Color.DimGray, Font = new Font("Segoe UI Bold", 8), TextAlign = ContentAlignment.BottomLeft, Padding = new Padding(15, 0, 0, 5) };
            sidebarContent.Controls.Add(catHeader);

            var categoryData = new[] {
                new { Name = "ALL", Icon = "🌐" },
                new { Name = "MAINTENANCE", Icon = "⚡" },
                new { Name = "SYSTEM", Icon = "💻" },
                new { Name = "ADMIN", Icon = "⚙️" },
                new { Name = "SECURITY", Icon = "🛡️" },
                new { Name = "UTILITIES", Icon = "🔣" }
            };

            foreach (var cat in categoryData) {
                Button btn = new Button { Text = "    " + cat.Icon + "  " + cat.Name, Height = 50, Dock = DockStyle.Top, FlatStyle = FlatStyle.Flat, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI Semibold", 9), ForeColor = Color.Gray, Cursor = Cursors.Hand };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (s, e) => { currentCategory = cat.Name; UpdateSidebarColors(); RefreshDisplay(); SaveState(); };
                sidebarContent.Controls.Add(btn);
                categoryButtons.Add(btn);
            }

            // Main Area
            mainLayout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, BackColor = darkBg, Padding = new Padding(60, 40, 60, 40) };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130)); 
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));  
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); 
            contentWrapper.Controls.Add(mainLayout);
            mainLayout.BringToFront();

            Panel header = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            mainBurgerBtn = new Button {
                Text = "≡", Font = new Font("Segoe UI Semibold", 18), ForeColor = Color.White,
                Size = new Size(50, 50), Location = new Point(0, 15), FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand, BackColor = accentColor, Visible = false 
            };
            mainBurgerBtn.FlatAppearance.BorderSize = 0;
            mainBurgerBtn.Click += (s, e) => StartNavToggle();
            header.Controls.Add(mainBurgerBtn);

            Label title = new Label { Text = "Admin Tools", Font = new Font("Segoe UI Light", 32), ForeColor = Color.White, Location = new Point(0, 5), Height = 60, AutoSize = true };
            header.Controls.Add(title);

            moduleCountLabel = new Label { Text = "System Admin Active", Font = new Font("Segoe UI", 10), ForeColor = Color.DimGray, Location = new Point(5, 75), AutoSize = true };
            header.Controls.Add(moduleCountLabel);

            Panel stats = new Panel { Dock = DockStyle.Bottom, Height = 40 };
            cpuLabel = new Label { Text = "CPU: 0%", ForeColor = accentColor, Font = new Font("Consolas", 12), Location = new Point(0, 10), AutoSize = true };
            ramLabel = new Label { Text = "RAM: 0%", ForeColor = accentColor, Font = new Font("Consolas", 12), Location = new Point(160, 10), AutoSize = true };
            stats.Controls.Add(cpuLabel); stats.Controls.Add(ramLabel);
            header.Controls.Add(stats);
            mainLayout.Controls.Add(header, 0, 0);

            Panel searchWrap = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 10, 0, 20), BackColor = Color.Transparent };
            searchBox = new TextBox { BackColor = Color.FromArgb(25, 25, 30), ForeColor = Color.White, BorderStyle = BorderStyle.None, Font = new Font("Segoe UI", 14), Text = "Search admin tools...", Dock = DockStyle.Top, Height = 40 };
            searchBox.BackColor = Color.FromArgb(25, 25, 30);
            searchWrap.Controls.Add(searchBox);
            Panel line = new Panel { Height = 1, BackColor = Color.FromArgb(50, 50, 60), Dock = DockStyle.Bottom };
            searchWrap.Controls.Add(line);
            searchBox.Enter += (s, e) => { if (searchBox.Text == "Search admin tools...") searchBox.Text = ""; };
            searchBox.TextChanged += (s, e) => RefreshDisplay();
            mainLayout.Controls.Add(searchWrap, 0, 1);

            Panel cardWrapper = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.Transparent };
            cardContainer = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, WrapContents = true, FlowDirection = FlowDirection.LeftToRight, BackColor = Color.Transparent };
            cardWrapper.Controls.Add(cardContainer);
            mainLayout.Controls.Add(cardWrapper, 0, 2);

            this.Resize += (s, e) => { RefreshDisplay(); SyncHeaderLayout(); };
            RefreshDisplay();
            SetToolTips();
            LogActivity("Admin System Online.");
        }

        private void LogActivity(string msg) { } 

        private void UpdateSidebarColors()
        {
            foreach (var btn in categoryButtons) {
                bool active = btn.Text.Trim() == currentCategory;
                btn.ForeColor = active ? accentColor : Color.Gray;
                btn.BackColor = active ? Color.FromArgb(25, 25, 30) : Color.Transparent;
            }
        }

        private void InitNavAnimation()
        {
            navTimer = new Timer { Interval = 1 };
            navTimer.Tick += (s, e) => {
                if (isSidebarExpanded) {
                    if (sidebar.Width > 0) {
                        sidebar.Width -= 64;
                        if (sidebar.Width <= 0) { sidebar.Width = 0; sidebar.Visible = false; isSidebarExpanded = false; navTimer.Stop(); mainBurgerBtn.Visible = true; SyncHeaderLayout(); }
                    }
                } else {
                    if (sidebar.Width < sidebarMaxWidth) {
                        sidebar.Visible = true; sidebar.Width += 64;
                        if (sidebar.Width >= sidebarMaxWidth) { sidebar.Width = sidebarMaxWidth; isSidebarExpanded = true; navTimer.Stop(); SyncHeaderLayout(); }
                    }
                }
            };
        }

        private void StartNavToggle() { mainBurgerBtn.Visible = false; navTimer.Start(); }

        private void SetToolTips()
        {
            toolTip.SetToolTip(mainBurgerBtn, "Toggle Sidebar Navigation");
            toolTip.SetToolTip(searchBox, "Type to filter administrative modules");
            foreach (var btn in categoryButtons) {
                toolTip.SetToolTip(btn, "Filter by " + btn.Text.Trim());
            }
        }

        private void SyncHeaderLayout()
        {
            foreach (Control ctrl in mainLayout.GetControlFromPosition(0, 0).Controls) {
                if (ctrl is Label && ctrl.Text.Contains("Admin Tools")) ctrl.Left = sidebar.Visible ? 0 : 70;
                if (ctrl is Label && ctrl.Text.Contains("Modules Ready")) ctrl.Left = sidebar.Visible ? 5 : 75;
            }
            RefreshDisplay();
        }


        private void RefreshDisplay()
        {
            cardContainer.SuspendLayout(); cardContainer.Controls.Clear();
            string query = (searchBox.Text == "Search admin tools...") ? "" : searchBox.Text.ToLower();
            var filtered = tools.Where(t => (currentCategory == "ALL" || t.Category == currentCategory) && (t.SpecificName.ToLower().Contains(query) || t.Description.ToLower().Contains(query))).ToList();
            moduleCountLabel.Text = filtered.Count + " Modules Ready";
            foreach (var tool in filtered) {
                Panel card = new Panel { Size = new Size(320, 80), Margin = new Padding(0, 0, 20, 20), BackColor = cardBg, Cursor = Cursors.Hand };
                if (tool.IsMacro) card.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, accentColor, ButtonBorderStyle.Solid);
                Label icon = new Label { Text = tool.Icon, Font = new Font("Segoe UI", 20), Location = new Point(15, 20), AutoSize = true, ForeColor = accentColor }; card.Controls.Add(icon);
                Label name = new Label { Text = tool.SpecificName, Font = new Font("Segoe UI Semibold", 11), Location = new Point(65, 18), Width = 240, ForeColor = Color.White }; card.Controls.Add(name);
                Label desc = new Label { Text = tool.Description, Font = new Font("Segoe UI", 8), Location = new Point(66, 42), Width = 240, Height = 30, ForeColor = Color.Gray }; card.Controls.Add(desc);
                EventHandler click = (s, e) => Launch(tool); card.Click += click; foreach (Control c in card.Controls) c.Click += click;
                cardContainer.Controls.Add(card);
            }
            cardContainer.ResumeLayout();
        }

        private void StartStats()
        {
            statsTimer = new Timer { Interval = 2000 };
            statsTimer.Tick += (s, e) => {
                try {
                    int cpu = 0; if (cpuCounter != null) cpu = (int)cpuCounter.NextValue();
                    cpuLabel.Text = "CPU: " + cpu + "%";
                    cpuLabel.ForeColor = (cpu > 90) ? alertColor : accentColor;
                    if (cpu > 90) LogActivity("CRITICAL: High CPU detected!");

                    if (computerInfo != null) {
                        ulong total = computerInfo.TotalPhysicalMemory; ulong free = computerInfo.AvailablePhysicalMemory;
                        int ram = (int)(((double)(total - free) / total) * 100);
                        ramLabel.Text = "RAM: " + ram + "%";
                        ramLabel.ForeColor = (ram > 90) ? alertColor : accentColor;
                    }
                } catch { }
            };
            statsTimer.Start();
        }

        private void Launch(ToolItem tool)
        {
            try {
                LogActivity("Executing: " + tool.SpecificName);
                
                // Compatibility check for complex shell commands
                string fileName = tool.IsMacro ? "cmd.exe" : tool.Command;
                string arguments = tool.IsMacro ? "/c " + tool.Command : "";

                // Handle space-separated commands safely
                if (!tool.IsMacro && tool.Command.Contains(" ") && !tool.Command.Contains("\\")) {
                    int spaceIdx = tool.Command.IndexOf(' ');
                    fileName = tool.Command.Substring(0, spaceIdx);
                    arguments = tool.Command.Substring(spaceIdx + 1);
                }

                ProcessStartInfo psi = new ProcessStartInfo {
                    FileName = fileName,
                    Arguments = arguments,
                    CreateNoWindow = tool.IsMacro,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                // Elevate if macro or specified system tool
                if (tool.IsMacro || tool.Category == "ADMIN" || tool.Category == "SECURITY") {
                    psi.Verb = "runas"; 
                }

                Process.Start(psi);
            } catch (Exception ex) { 
                LogActivity("Unavailable on this OS: " + tool.SpecificName);
                MessageBox.Show(
                    "This system tool (" + tool.SpecificName + ") could not be launched.\n\n" +
                    "Reason: " + ex.Message + "\n\n" +
                    "Note: Some administrative tools are version-specific or require specific Windows Editions (Pro/Enterprise).",
                    "Compatibility Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveState() { try { File.WriteAllText("prime_state.cfg", currentCategory); } catch { } }
        private void LoadState() { try { if (File.Exists("prime_state.cfg")) currentCategory = File.ReadAllText("prime_state.cfg"); } catch { } }
    }
}

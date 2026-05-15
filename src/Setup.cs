using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using System.Reflection;

[assembly: AssemblyTitle("JEM TOOLS | Setup")]
[assembly: AssemblyDescription("Professional Installer for JEM TOOLS")]
[assembly: AssemblyCompany("JEM TOOLS")]
[assembly: AssemblyProduct("JEM TOOLS Suite")]
[assembly: AssemblyCopyright("Copyright © 2026 Jemmy Francisco")]
[assembly: AssemblyVersion("1.0.8.0")]
[assembly: AssemblyFileVersion("1.0.8.0")]


namespace JEMToolsSetup
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].ToLower() == "/uninstall")
            {
                SetupForm.Uninstall();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupForm());
        }
    }

    public class SetupForm : Form
    {
        private Button btnInstall;
        private Label lblStatus;
        private CheckBox chkShortcut;
        private CheckBox chkLaunch;
        private ProgressBar pbar;

        public SetupForm()
        {
            this.Text = "JEM TOOLS | Setup";
            this.Size = new Size(500, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(20, 20, 25);
            this.ForeColor = Color.White;
            
            Label title = new Label();
            title.Text = "JEM TOOLS - Installation";
            title.Font = new Font("Segoe UI Semibold", 14);
            title.AutoSize = true;
            title.Location = new Point(20, 15);
            this.Controls.Add(title);
            
            TextBox eula = new TextBox();
            eula.Multiline = true;
            eula.ReadOnly = true;
            eula.ScrollBars = ScrollBars.Vertical;
            eula.Location = new Point(20, 50);
            eula.Size = new Size(445, 230);
            eula.BackColor = Color.FromArgb(30, 30, 35);
            eula.ForeColor = Color.LightGray;
            eula.Font = new Font("Segoe UI", 9);
            eula.Text = "END-USER LICENSE AGREEMENT (EULA)\r\n\r\n" +
                        "IMPORTANT - READ CAREFULLY:\r\n" +
                        "This End-User License Agreement is a legal agreement between you and JEM TOOLS. " +
                        "By installing, copying, or otherwise using the software, you agree to be bound by the terms of this EULA.\r\n\r\n" +
                        "1. GRANT OF LICENSE\r\n" +
                        "JEM TOOLS grants you a personal, non-exclusive license to install and use the software.\r\n\r\n" +
                        "2. DESCRIPTION OF OTHER RIGHTS AND LIMITATIONS\r\n" +
                        "- You must not use the software to violate any local, state, national, or international law.\r\n" +
                        "- You are responsible for any actions taken using the administrative tools provided.\r\n\r\n" +
                        "3. DISCLAIMER OF WARRANTY\r\n" +
                        "The software is provided \"AS IS\" without warranty of any kind. The entire risk arising out of use " +
                        "or performance of the software remains with you.";
            this.Controls.Add(eula);
            
            CheckBox chkAccept = new CheckBox();
            chkAccept.Text = "I have read and accept the User Agreement";
            chkAccept.Location = new Point(20, 290);
            chkAccept.AutoSize = true;
            chkAccept.Font = new Font("Segoe UI", 9);
            chkAccept.ForeColor = Color.White;
            this.Controls.Add(chkAccept);
            
            chkShortcut = new CheckBox();
            chkShortcut.Text = "Create a Desktop shortcut";
            chkShortcut.Location = new Point(20, 320);
            chkShortcut.AutoSize = true;
            chkShortcut.Font = new Font("Segoe UI", 9);
            chkShortcut.ForeColor = Color.White;
            chkShortcut.Checked = true;
            this.Controls.Add(chkShortcut);
            
            chkLaunch = new CheckBox();
            chkLaunch.Text = "Launch JEM TOOLS when finished";
            chkLaunch.Location = new Point(20, 350);
            chkLaunch.AutoSize = true;
            chkLaunch.Font = new Font("Segoe UI", 9);
            chkLaunch.ForeColor = Color.White;
            chkLaunch.Checked = true;
            this.Controls.Add(chkLaunch);
            
            pbar = new ProgressBar();
            pbar.Location = new Point(20, 390);
            pbar.Size = new Size(445, 10);
            pbar.Style = ProgressBarStyle.Continuous;
            pbar.Visible = false;
            this.Controls.Add(pbar);
            
            btnInstall = new Button();
            btnInstall.Text = "Install";
            btnInstall.Location = new Point(345, 420);
            btnInstall.Size = new Size(120, 35);
            btnInstall.FlatStyle = FlatStyle.Flat;
            btnInstall.BackColor = Color.Gray;
            btnInstall.ForeColor = Color.White;
            btnInstall.Font = new Font("Segoe UI Semibold", 9);
            btnInstall.Enabled = false;
            btnInstall.Cursor = Cursors.Hand;
            btnInstall.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnInstall);
            
            lblStatus = new Label();
            lblStatus.Text = "Waiting for user agreement...";
            lblStatus.Location = new Point(20, 430);
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9);
            lblStatus.ForeColor = Color.Gray;
            this.Controls.Add(lblStatus);
            
            chkAccept.CheckedChanged += delegate {
                btnInstall.Enabled = chkAccept.Checked;
                btnInstall.BackColor = chkAccept.Checked ? Color.FromArgb(0, 120, 215) : Color.Gray;
            };
            
            btnInstall.Click += delegate {
                chkAccept.Enabled = false;
                chkShortcut.Enabled = false;
                chkLaunch.Enabled = false;
                btnInstall.Enabled = false;
                btnInstall.BackColor = Color.Gray;
                btnInstall.Text = "Installing...";
                
                pbar.Visible = true;
                
                Timer progTimer = new Timer();
                progTimer.Interval = 50;
                int progress = 0;
                progTimer.Tick += delegate {
                    progress += 4;
                    if (progress <= 100) pbar.Value = progress;
                    
                    if (progress == 20) lblStatus.Text = "Preparing extraction...";
                    if (progress == 40) lblStatus.Text = "Extracting JEMTOOLS.exe to AppData...";
                    if (progress == 60) lblStatus.Text = "Configuring system settings...";
                    if (progress == 80) lblStatus.Text = "Finalizing installation...";
                    
                    if (progress >= 100) {
                        progTimer.Stop();
                        // Register EULA Acceptance in Registry
                        try { Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\JEMTOOLS").SetValue("AcceptedEULA", 1); } catch { }
                        Install(chkShortcut.Checked, chkLaunch.Checked);
                    }
                };
                progTimer.Start();
            };
        }

        private void Install(bool createShortcut, bool autoLaunch)
        {
            try
            {
                // Check for Admin Rights
                var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                var principal = new System.Security.Principal.WindowsPrincipal(identity);
                if (!principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                {
                    MessageBox.Show("Please run the installer as Administrator to deploy to Program Files.", "Admin Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    return;
                }

                string targetDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "JEM TOOLS");
                if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);
                string exePath = Path.Combine(targetDir, "JEMTOOLS.exe");
                
                // Ensure existing instances are closed to prevent file lock errors
                foreach (var proc in Process.GetProcessesByName("JEMTOOLS"))
                {
                    try { proc.Kill(); proc.WaitForExit(1000); } catch { }
                }
                
                string base64 = "%%PAYLOAD%%";
                byte[] bytes = Convert.FromBase64String(base64);
                File.WriteAllBytes(exePath, bytes);

                string uninstallBase64 = "%%UNINSTALL_PAYLOAD%%";
                string uninstallPath = Path.Combine(targetDir, "uninstaller.exe");
                if (uninstallBase64.Length > 20) {
                    try { File.WriteAllBytes(uninstallPath, Convert.FromBase64String(uninstallBase64)); } catch { }
                }

                // No longer needed to copy setup file as we have a dedicated uninstaller

                // Register in Programs and Features
                try
                {
                    string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\JEMTOOLS";
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(uninstallKey))
                    {
                        key.SetValue("DisplayName", "JEM TOOLS | Admin Edition");
                        key.SetValue("UninstallString", "\"" + Path.Combine(targetDir, "uninstaller.exe") + "\"");
                        key.SetValue("DisplayIcon", exePath);
                        key.SetValue("Publisher", "Jemmy Francisco");
                        key.SetValue("DisplayVersion", "1.0.8");
                        key.SetValue("InstallLocation", targetDir);
                        key.SetValue("EstimatedSize", bytes.Length / 1024);
                        key.SetValue("NoModify", 1);
                        key.SetValue("NoRepair", 1);
                    }
                } catch { }
                
                if (createShortcut) {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string shortcutPath = Path.Combine(desktop, "JEM TOOLS.lnk");
                    
                    string psCommand = string.Format("$s=(New-Object -COM WScript.Shell).CreateShortcut('{0}');$s.TargetPath='{1}';$s.WorkingDirectory='{2}';$s.Save()", shortcutPath, exePath, targetDir);
                    
                    ProcessStartInfo psi = new ProcessStartInfo("powershell", string.Format("-NoProfile -Command \"{0}\"", psCommand));
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                    Process p = Process.Start(psi);
                    if (p != null) p.WaitForExit();
                }
                
                if (autoLaunch) {
                    ProcessStartInfo launchPsi = new ProcessStartInfo();
                    launchPsi.FileName = exePath;
                    launchPsi.WorkingDirectory = targetDir;
                    Process.Start(launchPsi);
                }
                
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Installation failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public static void Uninstall()
        {
            try
            {
                string targetDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "JEM TOOLS");
                
                // Kill running instances
                foreach (var proc in Process.GetProcessesByName("JEMTOOLS"))
                {
                    try { proc.Kill(); proc.WaitForExit(1000); } catch { }
                }

                // Remove Desktop Shortcut
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string shortcutPath = Path.Combine(desktop, "JEM TOOLS.lnk");
                if (File.Exists(shortcutPath)) File.Delete(shortcutPath);

                // Remove Registry Keys
                try { Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\JEMTOOLS", false); } catch { }
                try { Registry.CurrentUser.DeleteSubKeyTree(@"Software\JEMTOOLS", false); } catch { }

                // Schedule directory deletion (cannot delete self while running)
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = "/C timeout /T 2 & rd /S /Q \"" + targetDir + "\"";
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.CreateNoWindow = true;
                Process.Start(psi);

                MessageBox.Show("JEM TOOLS has been successfully uninstalled.", "Uninstall Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uninstall Error: " + ex.Message, "JEM TOOLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

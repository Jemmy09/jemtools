using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace JEMToolsSetup
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
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

        public SetupForm()
        {
            this.Text = "JEM TOOLS | Setup";
            this.Size = new Size(500, 480);
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
            
            btnInstall = new Button();
            btnInstall.Text = "Install";
            btnInstall.Location = new Point(345, 390);
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
            lblStatus.Location = new Point(20, 400);
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
                lblStatus.Text = "Installing JEM TOOLS...";
                Application.DoEvents();
                Install(chkShortcut.Checked, chkLaunch.Checked);
            };
        }

        private void Install(bool createShortcut, bool autoLaunch)
        {
            try
            {
                string targetDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JEMTOOLS");
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
    }
}

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
        public SetupForm()
        {
            this.Text = "JEM TOOLS Installer";
            this.Size = new Size(400, 150);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(20, 20, 25);
            this.ForeColor = Color.White;
            
            Label lbl = new Label();
            lbl.Text = "Installing JEM TOOLS...";
            lbl.Font = new Font("Segoe UI Semibold", 14);
            lbl.AutoSize = true;
            lbl.Location = new Point(85, 40);
            this.Controls.Add(lbl);
            
            this.Shown += SetupForm_Shown;
        }

        private void SetupForm_Shown(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += delegate {
                t.Stop();
                Install();
            };
            t.Start();
        }

        private void Install()
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
                
                // Create Desktop Shortcut via powershell
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string shortcutPath = Path.Combine(desktop, "JEM TOOLS.lnk");
                
                string psCommand = string.Format("$s=(New-Object -COM WScript.Shell).CreateShortcut('{0}');$s.TargetPath='{1}';$s.WorkingDirectory='{2}';$s.Save()", shortcutPath, exePath, targetDir);
                
                ProcessStartInfo psi = new ProcessStartInfo("powershell", string.Format("-NoProfile -Command \"{0}\"", psCommand));
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process p = Process.Start(psi);
                if (p != null) p.WaitForExit();
                
                // Launch
                ProcessStartInfo launchPsi = new ProcessStartInfo();
                launchPsi.FileName = exePath;
                launchPsi.WorkingDirectory = targetDir;
                Process.Start(launchPsi);
                
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

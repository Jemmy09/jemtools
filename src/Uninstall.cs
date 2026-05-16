using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using System.Reflection;

[assembly: AssemblyTitle("JEM TOOLS | Uninstaller")]
[assembly: AssemblyDescription("Professional Uninstaller for JEM TOOLS")]
[assembly: AssemblyCompany("JEM TOOLS")]
[assembly: AssemblyProduct("JEM TOOLS Suite")]
[assembly: AssemblyCopyright("Copyright © 2026 Jemmy Francisco")]
[assembly: AssemblyVersion("1.2.2.0")]
[assembly: AssemblyFileVersion("1.2.2.0")]

namespace JEMToolsUninstall
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UninstallForm());
        }
    }

    public class UninstallForm : Form
    {
        private string AppName = "Jem Tools";
        private string RegName = "JEMTOOLS";
        private string InstallDir = @"C:\Program Files\Jem Tools";
        private Color ThemeAccent = Color.FromArgb(0, 180, 255);
        private Color ThemeDarkBg = Color.FromArgb(10, 10, 12);
        
        private Panel mainPanel;
        private Panel progressPanel;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Button btnUninstall;
        private Button btnCancel;

        public UninstallForm()
        {
            this.Text = "JEM TOOLS | Maintenance";
            this.Size = new Size(450, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ThemeDarkBg;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10);

            BuildUI();
        }

        private void BuildUI()
        {
            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(mainPanel);

            Label lblTitle = new Label();
            lblTitle.Text = "Uninstall JEM TOOLS?";
            lblTitle.Font = new Font("Segoe UI Bold", 14);
            lblTitle.ForeColor = ThemeAccent;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            Label lblDesc = new Label();
            lblDesc.Text = "This will remove all administrative modules, shortcuts, and registry configurations from your system.";
            lblDesc.Dock = DockStyle.Top;
            lblDesc.Height = 80;
            lblDesc.TextAlign = ContentAlignment.MiddleCenter;
            lblDesc.Padding = new Padding(30, 0, 30, 0);

            Panel btnPanel = new Panel();
            btnPanel.Dock = DockStyle.Bottom;
            btnPanel.Height = 100;

            btnUninstall = new Button();
            btnUninstall.Text = "UNINSTALL NOW";
            btnUninstall.Size = new Size(180, 45);
            btnUninstall.Location = new Point(30, 20);
            btnUninstall.FlatStyle = FlatStyle.Flat;
            btnUninstall.BackColor = Color.FromArgb(40, 20, 20);
            btnUninstall.ForeColor = Color.Salmon;
            btnUninstall.FlatAppearance.BorderSize = 1;
            btnUninstall.Cursor = Cursors.Hand;
            btnUninstall.Click += (s, e) => StartUninstall();

            btnCancel = new Button();
            btnCancel.Text = "CANCEL";
            btnCancel.Size = new Size(180, 45);
            btnCancel.Location = new Point(240, 20);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Color.FromArgb(30, 30, 40);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => this.Close();

            btnPanel.Controls.Add(btnUninstall);
            btnPanel.Controls.Add(btnCancel);

            mainPanel.Controls.Add(lblDesc);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(btnPanel);

            // Progress Panel (Hidden initially)
            progressPanel = new Panel();
            progressPanel.Dock = DockStyle.Fill;
            progressPanel.Visible = false;
            this.Controls.Add(progressPanel);

            Label lblProcessing = new Label();
            lblProcessing.Text = "DE-PROVISIONING SYSTEM";
            lblProcessing.Font = new Font("Segoe UI Bold", 12);
            lblProcessing.ForeColor = Color.White;
            lblProcessing.Dock = DockStyle.Top;
            lblProcessing.Height = 80;
            lblProcessing.TextAlign = ContentAlignment.MiddleCenter;
            progressPanel.Controls.Add(lblProcessing);

            lblStatus = new Label();
            lblStatus.Text = "Preparing...";
            lblStatus.ForeColor = Color.DimGray;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Height = 40;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            progressPanel.Controls.Add(lblStatus);

            progressBar = new ProgressBar();
            progressBar.Width = 350;
            progressBar.Height = 4;
            progressBar.Location = new Point(50, 120);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.BackColor = Color.FromArgb(20, 20, 25);
            progressBar.ForeColor = ThemeAccent;
            progressPanel.Controls.Add(progressBar);
        }

        private async void StartUninstall()
        {
            mainPanel.Visible = false;
            progressPanel.Visible = true;

            try
            {
                await UpdateStatus("Initializing cleanup engine...", 10);
                
                // 1. Check if running
                await UpdateStatus("Stopping active processes...", 25);
                Process[] procs = Process.GetProcessesByName("Jem Tools");
                foreach (var p in procs) { try { p.Kill(); } catch { } }
                await System.Threading.Tasks.Task.Delay(500);

                // 2. Remove Registry Keys
                await UpdateStatus("Cleaning registry artifacts...", 45);
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true))
                {
                    if (key != null) key.DeleteSubKeyTree(RegName, false);
                }
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true))
                {
                    if (key != null) key.DeleteSubKeyTree(RegName, false);
                }
                try { Registry.CurrentUser.DeleteSubKeyTree(@"Software\JEMTOOLS", false); } catch { }
                await System.Threading.Tasks.Task.Delay(800);

                // 3. Remove Shortcuts
                await UpdateStatus("Removing interface links...", 70);
                string desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), AppName + ".lnk");
                if (File.Exists(desktopPath)) File.Delete(desktopPath);

                string startMenuPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms), AppName);
                if (Directory.Exists(startMenuPath)) Directory.Delete(startMenuPath, true);
                await System.Threading.Tasks.Task.Delay(500);

                // 4. Finalizing
                await UpdateStatus("Finalizing system restoration...", 90);
                await System.Threading.Tasks.Task.Delay(1000);
                
                await UpdateStatus("Complete", 100);

                // Self-destruct schedule
                string cmd = "/c timeout /t 2 /nobreak & rd /s /q \"" + InstallDir + "\"";
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", cmd);
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.CreateNoWindow = true;
                Process.Start(psi);

                MessageBox.Show("JEM TOOLS has been successfully removed from your system.", "Uninstall Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during uninstall: " + ex.Message, "Uninstall Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressPanel.Visible = false;
                mainPanel.Visible = true;
            }
        }

        private async System.Threading.Tasks.Task UpdateStatus(string text, int progress)
        {
            lblStatus.Text = text;
            progressBar.Value = progress;
            await System.Threading.Tasks.Task.Delay(200);
        }
    }
}

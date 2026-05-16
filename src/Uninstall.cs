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

        public UninstallForm()
        {
            this.Text = "JEM TOOLS | Maintenance";
            this.Size = new Size(450, 250);
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
            lblDesc.Height = 60;
            lblDesc.TextAlign = ContentAlignment.MiddleCenter;
            lblDesc.Padding = new Padding(20, 0, 20, 0);

            Panel btnPanel = new Panel();
            btnPanel.Dock = DockStyle.Bottom;
            btnPanel.Height = 80;

            Button btnUninstall = new Button();
            btnUninstall.Text = "UNINSTALL NOW";
            btnUninstall.Size = new Size(180, 40);
            btnUninstall.Location = new Point(30, 20);
            btnUninstall.FlatStyle = FlatStyle.Flat;
            btnUninstall.BackColor = Color.FromArgb(40, 20, 20);
            btnUninstall.ForeColor = Color.Salmon;
            btnUninstall.FlatAppearance.BorderSize = 1;
            btnUninstall.Click += (s, e) => RunUninstall();

            Button btnCancel = new Button();
            btnCancel.Text = "CANCEL";
            btnCancel.Size = new Size(180, 40);
            btnCancel.Location = new Point(240, 20);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Color.FromArgb(30, 30, 40);
            btnCancel.Click += (s, e) => this.Close();

            btnPanel.Controls.Add(btnUninstall);
            btnPanel.Controls.Add(btnCancel);

            this.Controls.Add(lblDesc);
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnPanel);
        }

        private void RunUninstall()
        {
            try
            {
                // 1. Check if running
                Process[] procs = Process.GetProcessesByName("Jem Tools");
                if (procs.Length > 0)
                {
                    MessageBox.Show("Please close JEM TOOLS before uninstalling.", "Active Process Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Remove Registry Keys
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true))
                {
                    if (key != null) key.DeleteSubKeyTree(RegName, false);
                }
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true))
                {
                    if (key != null) key.DeleteSubKeyTree(RegName, false);
                }
                try { Registry.CurrentUser.DeleteSubKeyTree(@"Software\JEMTOOLS", false); } catch { }

                // 3. Remove Shortcuts
                string desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), AppName + ".lnk");
                if (File.Exists(desktopPath)) File.Delete(desktopPath);

                string startMenuPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms), AppName);
                if (Directory.Exists(startMenuPath)) Directory.Delete(startMenuPath, true);

                // 4. Self-destruct schedule
                // We can't delete the directory while uninstaller is running inside it.
                // We'll use a CMD trick to delete after exit.
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
            }
        }
    }
}

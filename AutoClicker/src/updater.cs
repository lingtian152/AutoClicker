using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Updater : Form
    {
        private string currentPath = "./";
        private string downloadUrl = "https://github.com/lingtian152/AutoClicker/releases/latest/download/AutoClicker.zip"; // Replace with your actual download URL
        private string tempDownloadPath = Path.Combine(Path.GetTempPath(), "AutoClicker.zip");

        public Updater()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            /*if (!IsRunningAsAdministrator())
            {
                RequestAdminPrivileges();
                return; // Wait until elevated privileges are granted
            }*/
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            try
            {
                if (currentPath.EndsWith("\\"))
                {
                    currentPath = currentPath.Substring(0, currentPath.Length - 1);
                }

                Thread t = new Thread(new ThreadStart(DownloadAndUpgrade))
                {
                    IsBackground = true
                };
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thread error: " + ex.Message, "Thread Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadAndUpgrade()
        {
            try
            {
                DownloadFile(downloadUrl, tempDownloadPath);
                Upgrade(tempDownloadPath);
                CleanUp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download and upgrade error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadFile(string url, string destinationPath)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(url, destinationPath);
            }
        }

        private void Upgrade(string zipFilePath)
        {
            try
            {
                string destinationPath = currentPath;

                using (ZipFile zip = ZipFile.Read(zipFilePath))
                {
                    zip.ExtractAll(destinationPath, ExtractExistingFileAction.OverwriteSilently);
                }

                List<FileInfo> listInfos = FindAllFiles(Path.Combine(currentPath, ".\\AutoClicker"));
                foreach (var file in listInfos)
                {
                    string relativeFilePath = file.FullName.Substring(file.FullName.IndexOf("AutoClicker") + 11);
                    string destinationFile = Path.Combine(currentPath, relativeFilePath);

                    string destinationDirectory = Path.GetDirectoryName(destinationFile);
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    File.Copy(file.FullName, destinationFile, true);
                }

                MessageBox.Show("Upgrade completed successfully.", "Upgrade", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upgrade error: " + ex.Message, "Upgrade Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<FileInfo> FindAllFiles(string directoryPath)
        {
            List<FileInfo> infoList = new List<FileInfo>();

            if (Directory.Exists(directoryPath))
            {
                string[] allFiles = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
                foreach (string file in allFiles)
                {
                    infoList.Add(new FileInfo(file));
                }
            }

            return infoList;
        }

        private void CleanUp()
        {
            try
            {
                string sourcePath = tempDownloadPath;
                if (File.Exists(sourcePath))
                {
                    File.Delete(sourcePath);
                }

                string upgradeDirectory = Path.Combine(".\\AutoClicker");
                if (Directory.Exists(upgradeDirectory))
                {
                    Directory.Delete(upgradeDirectory, true);
                }

                string filename = Path.Combine(".\\AutoClicker.exe");
                if (File.Exists(filename))
                {
                    Process.Start(filename);
                }

                // Instead of killing the current process, you may consider closing the application gracefully.
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clean-up error: " + ex.Message, "Clean-up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool IsRunningAsAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private void RequestAdminPrivileges()
        {
            try
            {
                // Launch itself as administrator
                var processInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase)
                {
                    UseShellExecute = true,
                    Verb = "runas"
                };
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to request admin privileges: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

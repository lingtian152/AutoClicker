using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Updater : Form
    {
        private readonly string currentPath = "./";
        private readonly string downloadUrl = "https://github.com/lingtian152/AutoClicker/releases/latest/download/AutoClicker.zip"; // Replace with your actual download URL
        private readonly string tempDownloadPath = Path.Combine(Path.GetTempPath(), "AutoClicker.zip");

        public Updater()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            try
            {
                Thread downloadThread = new Thread(DownloadAndUpgrade)
                {
                    IsBackground = true
                };
                downloadThread.Start();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Thread error: " + ex.Message, "Thread Error");
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
                ShowErrorMessage("Download and upgrade error: " + ex.Message, "Error");
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
                ExtractZipFile(zipFilePath, currentPath);
                CopyFilesToDestination(Path.Combine(currentPath, ".\\AutoClicker"), currentPath);
                MessageBox.Show("Upgrade completed successfully.", "Upgrade", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Upgrade error: " + ex.Message, "Upgrade Error");
            }
        }

        private void ExtractZipFile(string zipFilePath, string destinationPath)
        {
            using (ZipFile zip = ZipFile.Read(zipFilePath))
            {
                zip.ExtractAll(destinationPath, ExtractExistingFileAction.OverwriteSilently);
            }
        }

        private void CopyFilesToDestination(string sourcePath, string destinationPath)
        {
            List<FileInfo> files = FindAllFiles(sourcePath);
            foreach (var file in files)
            {
                string relativeFilePath = file.FullName.Substring(file.FullName.IndexOf("AutoClicker") + 11);
                string destinationFile = Path.Combine(destinationPath, relativeFilePath);

                string destinationDirectory = Path.GetDirectoryName(destinationFile);
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                File.Copy(file.FullName, destinationFile, true);
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
                DeleteFile(tempDownloadPath);
                DeleteDirectory(Path.Combine(".\\AutoClicker"));
                RestartApplication(Path.Combine(".\\AutoClicker.exe"));
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Clean-up error: " + ex.Message, "Clean-up Error");
            }
        }

        private void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        private void RestartApplication(string applicationPath)
        {
            if (File.Exists(applicationPath))
            {
                Process.Start(applicationPath);
            }

            Application.Exit();
        }

        private void ShowErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
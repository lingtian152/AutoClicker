﻿using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;

namespace Installer
{
    public partial class Installer : Form
    {
        public string currentPath = "./";
        private string downloadUrl = "https://github.com/lingtian152/AutoClicker/releases/latest/download/AutoClicker.zip"; // Replace with your actual download URL
        private string tempDownloadPath = Path.Combine(Path.GetTempPath(), "AutoClicker.zip");
        private bool isDownloading;

        public Installer()
        {
            InitializeComponent();
        }

        private void close_button_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Installer_button_Click(object sender, EventArgs e)
        {
            if (!isDownloading)
            {
                isDownloading = true;
                DownloadFile();
            }
        }

        private void DownloadFile()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                    wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompletedCallback);
                    wc.DownloadFileAsync(new Uri(downloadUrl), tempDownloadPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download and upgrade error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isDownloading = false;
            }
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DownloadFileCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Download error: " + e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isDownloading = false;
                return;
            }

            try
            {
                ExtractFiles(tempDownloadPath, currentPath);
                CleanUp();
                MessageBox.Show("Installation completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Extraction error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isDownloading = false;
            }
        }

        private void ExtractFiles(string zipFilePath, string extractPath)
        {
            try
            {
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        // Construct the full path for the extracted file
                        string destinationPath = Path.Combine(extractPath, entry.FullName);

                        // Ensure the directory for the extracted file exists
                        string destinationDir = Path.GetDirectoryName(destinationPath);
                        if (!Directory.Exists(destinationDir))
                        {
                            Directory.CreateDirectory(destinationDir);
                        }

                        // Extract the file
                        if (entry.Name == "")
                        {
                            // Entry is a directory
                            if (!Directory.Exists(destinationPath))
                            {
                                Directory.CreateDirectory(destinationPath);
                            }
                        }
                        else
                        {
                            // Entry is a file
                            entry.ExtractToFile(destinationPath, overwrite: true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Extraction error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanUp()
        {
            try
            {
                // 启动解压后的主程序
                string filename = currentPath + "\\AutoClicker.exe";
                if (File.Exists(filename))
                {
                    Process.Start(filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cleanup error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}

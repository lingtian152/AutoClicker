﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoClicker
{
    public partial class setting : Form
    {
        static string FileName = "./settings.ini";
        private Form mainForm;


        // 拖动窗体
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        static Action<string, object> SaveSettings = (key, value) => ConfigurationManager.SaveSettings(FileName, key, value);
        static Func<string, Type, object> LoadSettings = (key, type) => ConfigurationManager.LoadSettings(FileName, key, type);

        public setting(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadSetting();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadSetting()
        {
            bool topMost = (bool)LoadSettings("TopMost", typeof(bool));
            TopMost_Button.Checked = topMost;
        }

        private void TopMost_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMost_Button.Checked)
            {
                mainForm.TopMost = true;
                SaveSettings("TopMost", true);
            }
            else
            {
                mainForm.TopMost = false;
                SaveSettings("TopMost", false);
            }
        }

        private void setting_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

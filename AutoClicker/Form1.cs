using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using SharpConfig;
using Microsoft.Win32;


namespace AutoClicker
{
    public partial class Form1 : Form
    {
        static string FileName = "settings.ini";
        int clickInterval = 100; // Default Click CoolDown
        string HotKey = "F6"; // Default HotKey
        bool isClicking = false;

        KeyboardHook keyboardHook;

        


        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;

        public Form1()
        {
            InitializeComponent();
            this.Status.Text = "Status: Off";

            // Load settings
            LoadSettings();

            this.textBox1.Text = clickInterval.ToString();
            this.HotKey_Select.Text = HotKey;
            this.textBox1.TextChanged += new EventHandler(textBox1_TextChanged);

            // 初始化 键盘钩子
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDownEvent += new KeyEventHandler(Hook_KeyDown);
            keyboardHook.Start();
        }

        private void LoadSettings() // 加载设置
        {
            if (!File.Exists(FileName))
            {
                using (File.Create(FileName)) { }
            }

            try
            {
                var configFile = Configuration.LoadFromFile(FileName);
                var section = configFile["Settings"];

                if (section.Contains("ClickInterval"))
                {
                    clickInterval = section["ClickInterval"].IntValue;
                }
                else
                {
                    section["ClickInterval"].IntValue = clickInterval;
                }

                if (section.Contains("HotKey"))
                {
                    HotKey = section["HotKey"].StringValue;
                }
                else
                {
                    section["HotKey"].StringValue = HotKey;
                }

                configFile.SaveToFile(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load settings: {ex.Message}");
            }
        }

        public void SaveSettings(string key, object value) // 保存设置
        {
            try
            {
                var configFile = Configuration.LoadFromFile(FileName);
                var section = configFile["Settings"];

                if (value is string stringValue)
                {
                    section[key].StringValue = stringValue;
                }
                else if (value is int intValue)
                {
                    section[key].IntValue = intValue;
                }
                else
                {
                    throw new ArgumentException("Unsupported value type.");
                }

                configFile.SaveToFile(FileName);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to save settings: {e.Message}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(this.textBox1.Text, out int clickInterval))
            {
                MessageBox.Show("Please enter a number");
                return;
            } else if (clickInterval <= 0)
            {
                MessageBox.Show("Please enter a number greater than 0");
                this.textBox1.Text = 100.ToString();
                return;
            }

            clickInterval = int.Parse(this.textBox1.Text);
            SaveSettings("ClickInterval", clickInterval);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartClicking();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopClicking();
        }

        private void StartClicking()
        {
            if (!isClicking)
            {
                isClicking = true;
                this.Status.Text = "Status: On";
            }
        }

        private void StopClicking()
        {
            if (isClicking)
            {
                isClicking = false;
                this.Status.Text = "Status: Off";
            }
        }

        private void ClickingLoop()
        {
            while (isClicking)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep(clickInterval);
            }
        }

        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == HotKey)
            {
              if (isClicking)
              {
                  StopClicking();
              }
              else
              {
                  StartClicking();
                  Thread clickThread = new Thread(ClickingLoop);
                  clickThread.Start();
              }                
            }
        }

        private void HotKey_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HotKey = this.HotKey_Select.Text;

            SaveSettings("HotKey", HotKey);
        }
    }
}

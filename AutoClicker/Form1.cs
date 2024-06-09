using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using SharpConfig;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        static string FileName = "settings.ini";
        int clickInterval = 100; // Default Click CoolDown
        string HotKey = "F6"; // Default HotKey
        bool isClicking = false;
        Thread clickingThread;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;

        const int HOTKEY_ID = 1; // ID for the hotkey

        public Form1()
        {
            InitializeComponent();
            this.Status.Text = "Status: Off";

            // Load settings
            LoadSettings();

            this.textBox1.Text = clickInterval.ToString();
            this.HotKey_Select.Text = HotKey;

            this.textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.HotKey_Select.SelectedIndexChanged += new EventHandler(HotKey_Select_SelectedIndexChanged);

            RegisterHotKey();
        }

        private void LoadSettings()
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

        public void SaveSettings(string key, object value)
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
            }

            this.clickInterval = clickInterval;
            SaveSettings("ClickInterval", clickInterval);
        }

        private void HotKey_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            HotKey = this.HotKey_Select.Text;
            SaveSettings("HotKey", HotKey);
            RegisterHotKey(); // Re-register the hotkey
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
                clickingThread = new Thread(ClickingLoop);
                clickingThread.Start();
            }
        }

        private void StopClicking()
        {
            if (isClicking)
            {
                isClicking = false;
                clickingThread?.Join();
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

        private void RegisterHotKey()
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID); // Unregister any existing hotkey

            uint vk = (uint)Enum.Parse(typeof(Keys), HotKey, true);
            bool registered = RegisterHotKey(this.Handle, HOTKEY_ID, 0, vk);

            if (!registered)
            {
                MessageBox.Show("Failed to register hotkey.");
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                if (isClicking)
                {
                    StopClicking();
                }
                else
                {
                    StartClicking();
                }
            }

            base.WndProc(ref m);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);
            base.OnFormClosing(e);
        }
    }
}

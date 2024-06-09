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
        
        KeyboardHook keyboardHook; // 键盘钩子

        static string FileName = "settings.ini";
        int clickInterval = 100; // Default Click CoolDown
        string HotKey = "F1"; // Default HotKey
        bool isClicking = false;


        Thread clickThread;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        const int MOUSEEVENTF_LEFTDOWN = 0x0002; // 鼠标左键按下
        const int MOUSEEVENTF_LEFTUP = 0x0004; // 鼠标左键抬起

        public Form1()
        {
            InitializeComponent();
            this.Status.Text = "Status: Off";

            // Load settings
            LoadSettings();

            this.textBox1.Text = clickInterval.ToString();
            this.HotKey_Select.Text = HotKey;
            this.textBox1.TextChanged += new EventHandler(Cooldown_Changed);

            // 初始化 键盘钩子
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDownEvent += new KeyEventHandler(Hook_KeyDown);
            keyboardHook.Start();
        }

        private void Cooldown_Changed(object sender, EventArgs e)
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimiButton_Click(object sender, EventArgs e) // 最小化按钮
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HotkeySelec_Changed(object sender, EventArgs e) // 热键选择
        {
            this.HotKey = this.HotKey_Select.Text;

            SaveSettings("HotKey", HotKey);
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

        private void Hook_KeyDown(object sender, KeyEventArgs e) // 按下热键
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
                  clickThreadStart();         
              }                
            }
        }

        private void clickThreadStart()
        {
            clickThread = new Thread(ClickingLoop);
            clickThread.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) // 关闭窗口
        {
            keyboardHook.Stop();
            if (clickThread != null)
            {
                clickThread.Abort();
            }
            base.OnFormClosing(e);
        }
    }
}

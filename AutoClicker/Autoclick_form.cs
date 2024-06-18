using System;
using System.IO;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Autoclick_form : Form
    {
        // 程序配置
        static string FileName = "settings.ini";
        private int clickInterval = 100;
        private string HotKey = "F1";
        private string ButtonType = "LeftButton";
        private bool isClicking;

        // 实例化类
        AutoClicker autoClicker = new AutoClicker();
        KeyboardHook keyboardHook;

        // 保存和加载设置
        static Action<string, object> SaveSettings = (key, value) => ConfigurationManager.SaveSettings(FileName, key, value);
        static Func<string, Type, object> LoadSettings = (key, type) => ConfigurationManager.LoadSettings(FileName, key, type);

        // 拖动窗体
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // 构造函数
        public Autoclick_form()
        {
            InitializeComponent();

            this.Status.Text = "Status: Off";

            this.Cooldown_Box.TextChanged += new EventHandler(Cooldown_Changed);
            this.HotKey_Select.SelectedIndexChanged += new EventHandler(HotkeySelec_Changed);

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDownEvent += new KeyEventHandler(Hook_KeyDown);
            keyboardHook.Start();

            LoadSetting();

            this.Cooldown_Box.Text = clickInterval.ToString();
            this.HotKey_Select.Text = HotKey;

            if (ButtonType == "LeftButton")
            {
                this.LeftButton_Select.Checked = true;
            }
            else if (ButtonType == "RightButton")
            {
                this.RightButton_Select.Checked = true;
            }
        }

        private void LoadSetting()
        {

            Form_notification form_Nocation = new Form_notification();
            form_Nocation.ShowAlert("Settings loaded", AlertType.Info);

            try
            {
                this.clickInterval = (int)LoadSettings("ClickInterval", typeof(int));
                this.HotKey = (string)LoadSettings("HotKey", typeof(string));
                this.ButtonType = (string)LoadSettings("Button", typeof(string));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load settings: {ex.Message}");
            }
        }

        private void Cooldown_Changed(object sender, EventArgs e)
        {
            if (!int.TryParse(this.Cooldown_Box.Text, out int interval))
            {
                MessageBox.Show("Please enter a valid number");
                this.Cooldown_Box.Text = "100";
                clickInterval = 100;
                return;
            }
            else if (interval <= 0)
            {
                MessageBox.Show("Please enter a number greater than 0");
                this.Cooldown_Box.Text = "100";
                clickInterval = 100;
                return;
            }

            this.clickInterval = interval;
            SaveSettings("ClickInterval", interval);
        }

        private void HotkeySelec_Changed(object sender, EventArgs e)
        {
            HotKey = this.HotKey_Select.Text;
            SaveSettings("HotKey", HotKey);
        }

        private void LeftButton_Select_CheckedChanged(object sender, EventArgs e)
        {
            this.ButtonType = "LeftButton";
            SaveSettings("Button", ButtonType);
        }

        private void RightButton_Select_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("If CoolDown is too low, it may lag your computer");
            this.ButtonType = "RightButton";
            SaveSettings("Button", ButtonType);
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
                }
            }
        }

        private async void StartClicking()
        {
            if (!isClicking)
            {
                isClicking = true;
                this.Status.Text = "Status: On";
                await autoClicker.StartClick(clickInterval, ButtonType);
            }
        }

        private void StopClicking()
        {
            if (isClicking)
            {
                isClicking = false;
                this.Status.Text = "Status: Off";
                autoClicker.StopClick();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            keyboardHook?.Stop();
            autoClicker.StopClick();
            base.OnFormClosing(e);
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void minize_button_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void Autoclick_form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

using System;
using System.IO;
using System.Windows.Forms;
using AutoClicker.src.Utilities;

namespace AutoClicker
{
    public partial class Autoclick_form : Form
    {
        // 程序配置
        private int clickInterval { get; set; } = 100;
        private string HotKey { get; set; } = "F1";
        private string ButtonType { get; set; } = "LeftButton";
        private bool isClicking { get; set; } = false;

        // 实例化类
        private AutoClicker autoClicker = new AutoClicker();
        private KeyboardHook keyboardHook;

        private const string FileName = "./settings.ini";

        // 保存和加载设置
        private static readonly Action<string, object> SaveSettings = (key, value) => ConfigurationManager.SaveSettings(FileName, key, value);
        private static readonly Func<string, Type, object> LoadSettings = (key, type) => ConfigurationManager.LoadSettings(FileName, key, type);

        // 构造函数
        public Autoclick_form()
        {
            InitializeComponent();

            this.Status.Text = "Status: Off";

            this.Cooldown_Box.TextChanged += Cooldown_Changed;
            this.HotKey_Select.SelectedIndexChanged += HotkeySelec_Changed;
            this.LeftButton_Select.CheckedChanged += LeftButton_Select_CheckedChanged;
            this.RightButton_Select.CheckedChanged += RightButton_Select_CheckedChanged;

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDownEvent += Hook_KeyDown;
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

            // 添加窗体拖动事件
            this.MouseDown += new MouseEventHandler(Autoclick_form_MouseDown);
        }

        private void LoadSetting()
        {
            Form_Alert.ShowNotice("Loading settings", MsgType.Info);

            try
            {
                this.clickInterval = (int)LoadSettings("ClickInterval", typeof(int));
                this.HotKey = (string)LoadSettings("HotKey", typeof(string));
                this.ButtonType = (string)LoadSettings("Button", typeof(string));
                Form_Alert.ShowNotice("Settings loaded", MsgType.Success);
            }
            catch (Exception)
            {
                Form_Alert.ShowNotice("Failed to load settings", MsgType.Error);
            }
        }

        private void Cooldown_Changed(object sender, EventArgs e)
        {
            if (!int.TryParse(this.Cooldown_Box.Text, out int interval) || interval <= 0)
            {
                Form_Alert.ShowNotice("Please enter a valid number greater than 0", MsgType.Error);
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
            if (this.LeftButton_Select.Checked)
            {
                Form_Alert.ShowNotice("Left button selected", MsgType.Success);
                this.ButtonType = "LeftButton";
                SaveSettings("Button", ButtonType);
            }
        }

        private void RightButton_Select_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RightButton_Select.Checked)
            {
                Form_Alert.ShowNotice("Right button selected", MsgType.Success);
                this.ButtonType = "RightButton";
                SaveSettings("Button", ButtonType);
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
                }
            }
        }

        private async void StartClicking()
        {
            isClicking = true;
            this.Status.Text = "Status: On";
            Form_Alert.ShowNotice("AutoClicker is started", MsgType.Success);
            await autoClicker.StartClick(clickInterval, ButtonType);
        }

        private void StopClicking()
        {
            isClicking = false;
            this.Status.Text = "Status: Off";
            Form_Alert.ShowNotice("AutoClicker is stopped", MsgType.Warning);
            autoClicker.StopClick();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Minize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Autoclick_form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DragForm.StartDrag(this.Handle);
            }
        }

        private void Setting_button_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is setting)
                {
                    form.BringToFront();
                    return;
                }
            }

            setting settingForm = new setting(this);
            settingForm.Show();
        }

        private void Autoclick_form_Load(object sender, EventArgs e)
        {
            try
            {
                VersionCheck versionCheck = new VersionCheck();
                versionCheck.GetLastVersion();

                string[] pendingOverwriteFiles = Directory.GetFiles("./", "*.PendingOverwrite");

                foreach (string file in pendingOverwriteFiles)
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete pending overwrite file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            keyboardHook?.Stop();
            autoClicker.StopClick();
            base.OnFormClosing(e);
        }
    }
}
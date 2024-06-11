using System;
using System.Drawing.Printing;
using System.IO;
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

        AutoClicker autoClicker = new AutoClicker();
        KeyboardHook keyboardHook;

        static Action<string, object> SaveSettings = (key, value) => ConfigurationManager.SaveSettings(FileName, key, value);

        public Form1()
        {
            InitializeComponent();
            this.Status.Text = "Status: Off";

            // Load settings
            LoadSettings();

            this.textBox1.Text = clickInterval.ToString();
            this.HotKey_Select.Text = HotKey;

            this.textBox1.TextChanged += new EventHandler(Cooldown_Changed);
            this.HotKey_Select.SelectedIndexChanged += new EventHandler(HotkeySelec_Changed);

            // Initialize and start the keyboard hook
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDownEvent += new KeyEventHandler(Hook_KeyDown);
            keyboardHook.Start();
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

        private void Cooldown_Changed(object sender, EventArgs e)
        {
            if (!int.TryParse(this.textBox1.Text, out int interval))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            } else if (clickInterval <= 0 || this.textBox1.Text == "0")
            {
                MessageBox.Show("Please enter a number greater than 0");
                this.textBox1.Text = "100";
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

        private void StartClicking()
        {
            if (!isClicking)
            {
                isClicking = true;
                this.Status.Text = "Status: On";
                autoClicker.StartClick(clickInterval);
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
    }
}

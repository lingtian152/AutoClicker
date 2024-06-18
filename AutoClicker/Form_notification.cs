using System;
using System.Drawing;
using System.Windows.Forms;
using AutoClicker.Properties;

namespace AutoClicker
{
    public enum AlertType
    {
        Success,
        Warning,
        Error,
        Info
    }

    public partial class Form_notification : Form
    {
        private int alertX, alertY;

        public Form_notification()
        {
            InitializeComponent();
            this.Load += Form_Alert_Load;
            InitializeTimer();
        }

        private void Form_Alert_Load(object sender, EventArgs e)
        {
            Position();
        }

        private void InitializeTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 3000; // 3 seconds
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
           for (int i = 0; i < 10; i++)
            {
                this.Opacity -= 0.1;
                this.Refresh();
                System.Threading.Thread.Sleep(60);
            }

           this.Close();
        }

        public void Position()
        {
            int screenX = Screen.PrimaryScreen.WorkingArea.Width;
            int screenY = Screen.PrimaryScreen.WorkingArea.Height;

            alertX = screenX - this.Width - 10;
            alertY = screenY - this.Height - 10;

            this.Location = new Point(alertX, alertY);
        }

        public void ShowAlert(string msg, AlertType type)
        {
            AlertMessage(msg, type);
            timer1.Start();
        }

        public void AlertMessage(string msg, AlertType type)
        {
            switch (type)
            {
                case AlertType.Success:
                    panel1.BackColor = Color.SeaGreen;
                    image_panel.BackgroundImage = Resources.success;
                    break;
                case AlertType.Warning:
                    panel1.BackColor = Color.Orange;
                    image_panel.BackgroundImage = Resources.warning;
                    break;
                case AlertType.Error:
                    panel1.BackColor = Color.DarkRed;
                    image_panel.BackgroundImage = Resources.error;
                    break;
                case AlertType.Info:
                    panel1.BackColor = Color.Blue;
                    image_panel.BackgroundImage = Resources.info;
                    break;
            }

            lblMsg.Text = msg;
            Show();
        }
    }
}

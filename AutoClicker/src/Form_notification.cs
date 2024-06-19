using AutoClicker.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker
{
    public enum MsgType
    {
        Success,
        Warning,
        Error,
        Info
    }

    public partial class Form_Alert : Form
    {
        private int alertX, alertY;

        public Form_Alert()
        {
            InitializeComponent();
            ShowInTaskbar = false;
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
            this.Hide();
        }

        private void AdjustLabelSize()
        {
            lblMsg.AutoSize = true;
            lblMsg.Font = new Font(lblMsg.Font.FontFamily, 12); // 设置初始字体大小

            // 计算标签的大小以适应文本
            using (Graphics g = lblMsg.CreateGraphics())
            {
                SizeF size = g.MeasureString(lblMsg.Text, lblMsg.Font);
                lblMsg.Width = (int)size.Width + 20; // 添加一些填充
                lblMsg.Height = (int)size.Height + 10; // 添加一些填充
            }

            // 限制最大宽度和最小宽度
            if (lblMsg.Width > this.Width - 40) // 如果文本宽度超过窗体宽度
            {
                lblMsg.Width = this.Width - 40; // 限制宽度
                lblMsg.AutoEllipsis = true; // 启用省略号
            }
        }

        public void Position()
        {
            int screenX = Screen.PrimaryScreen.WorkingArea.Width;
            int screenY = Screen.PrimaryScreen.WorkingArea.Height;

            alertX = screenX - this.Width - 10;
            alertY = screenY - this.Height - 10;

            this.Location = new Point(alertX, alertY);
        }

        public void ShowNotice(string msg, MsgType type)
        {
            AlertMessage(msg, type);
            timer1.Start();
        }

        private void Form_Alert_Load_1(object sender, EventArgs e)
        {

        }

        public void AlertMessage(string msg, MsgType type)
        {
            switch (type)
            {
                case MsgType.Success:
                    panel1.BackColor = Color.SeaGreen;
                    image_panel.BackgroundImage = Resources.success;
                    break;
                case MsgType.Warning:
                    panel1.BackColor = Color.Orange;
                    image_panel.BackgroundImage = Resources.warning;
                    break;
                case MsgType.Error:
                    panel1.BackColor = Color.DarkRed;
                    image_panel.BackgroundImage = Resources.error;
                    break;
                case MsgType.Info:
                    panel1.BackColor = Color.Blue;
                    image_panel.BackgroundImage = Resources.info;
                    break;
            }

            lblMsg.Text = msg;
            AdjustLabelSize();
            this.Show();
        }
    }
}
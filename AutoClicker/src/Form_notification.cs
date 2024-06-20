using AutoClicker.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AutoClicker
{
    public enum NotificationFormAction
    {
        start,
        wait,
        close
    }

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
        private static int alertFormNum = Screen.PrimaryScreen.WorkingArea.Height / (75 + 5); // 75为窗体高度
        private NotificationFormAction action = NotificationFormAction.start;
        private static int showTime = 3000; // notification show time

        private static int currentAlertCount = 0; // 当前显示的通知数量

        public Form_Alert(string name)
        {
            InitializeComponent();
            ShowInTaskbar = false;
            this.Load += Form_Alert_Load;
            Name = name;
            InitializeTimer();
        }

        public static int AlertFormNum
        {
            get => alertFormNum;
            set
            {
                if (value <= Screen.PrimaryScreen.WorkingArea.Height / (75 + 5) && value > 0)
                {
                    alertFormNum = value;
                }
            }
        }

        private void Form_Alert_Load(object sender, EventArgs e)
        {
            Position();
        }

        private void InitializeTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 100; // 设置初始计时器间隔
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case NotificationFormAction.wait:
                    timer1.Interval = showTime;
                    action = NotificationFormAction.close;
                    break;
                case NotificationFormAction.start:
                    this.timer1.Interval = 100;
                    this.Opacity += 0.1;
                    if (this.alertX < this.Location.X)
                    {
                        this.Left -= 20; // 移动快点
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = NotificationFormAction.wait;
                        }
                    }
                    break;
                case NotificationFormAction.close:
                    timer1.Interval = 100;
                    this.Opacity -= 0.1;
                    this.Left -= 20;
                    if (base.Opacity == 0.0)
                    {
                        timer1.Stop();
                        base.Close();
                        currentAlertCount--; // 减少当前显示的通知数量
                    }
                    break;
            }
            // tag记录下次执行的时间，用于后续的替换
            timer1.Tag = DateTime.Now.AddMilliseconds(timer1.Interval);
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
            alertY = screenY - this.Height - 10 - (this.Height + 5) * currentAlertCount;

            this.Location = new Point(alertX, alertY);
        }

        public static void ShowNotice(string msg, MsgType msgType)
        {
            if (currentAlertCount < alertFormNum)
            {
                currentAlertCount++;
                Form_Alert alert = new Form_Alert("alert" + currentAlertCount.ToString());
                alert.AlertMessage(msg, msgType);
            }
            else
            {
                // 替换最早的通知
                var earliestAlert = Application.OpenForms.OfType<Form_Alert>().OrderBy(f => f.timer1.Tag).FirstOrDefault();
                if (earliestAlert != null)
                {
                    earliestAlert.Close();
                    currentAlertCount--; // 减少当前显示的通知数量
                    ShowNotice(msg, msgType); // 递归调用以显示新的通知
                }
            }
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
            timer1.Start();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt+Tab
                return cp;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using AutoClicker.Properties;


namespace CustomAlertBoxDemo
{
    public enum AlertType
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
            this.Load += Form_Alert_Load;
        }

        private void Form_Alert_Load(object sender, EventArgs e)
        {
            Position();
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
         }


        public void AlertMessage(string msg, AlertType type)
        {
            

            switch (type)
            {
                case AlertType.Success:
                    this.BackColor = Color.SeaGreen;
                    pictureBox1.Image = Resources.success; // Ensure you have the success image in your resources
                    break;
                case AlertType.Warning:
                    this.BackColor = Color.DarkOrange;
                    pictureBox1.Image = Resources.warning; // Ensure you have the warning image in your resources
                    break;
                case AlertType.Error:
                    this.BackColor = Color.DarkRed;
                    pictureBox1.Image = Resources.error; // Ensure you have the error image in your resources
                    break;
            }
            
            lblMsg.Text = msg;
            Show();
        }
    }
}

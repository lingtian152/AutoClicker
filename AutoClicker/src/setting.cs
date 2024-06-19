using System;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }

        private void close_button_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void check_for_update_click(object sender, EventArgs e)
        {
            Updater updater = new Updater();
            updater.Show();
        }
    }
}

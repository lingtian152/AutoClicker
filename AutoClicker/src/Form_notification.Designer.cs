namespace AutoClicker
{
    partial class Form_Alert
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMsg;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.image_panel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblMsg.Location = new System.Drawing.Point(136, 40);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(133, 29);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "{message}";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 110);
            this.panel1.TabIndex = 2;
            // 
            // image_panel
            // 
            this.image_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image_panel.Location = new System.Drawing.Point(17, 13);
            this.image_panel.Name = "image_panel";
            this.image_panel.Size = new System.Drawing.Size(90, 77);
            this.image_panel.TabIndex = 3;
            // 
            // Form_Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 102);
            this.Controls.Add(this.image_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form_Alert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Alert";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_Alert_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel image_panel;
        private System.Windows.Forms.Timer timer1;
    }
}

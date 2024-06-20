namespace AutoClicker
{
    partial class setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.close_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close_button.Location = new System.Drawing.Point(378, 12);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(26, 30);
            this.close_button.TabIndex = 1;
            this.close_button.Text = "X";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click_1);
            // 
            // update_button
            // 
            this.update_button.Font = new System.Drawing.Font("宋体", 12F);
            this.update_button.Location = new System.Drawing.Point(93, 151);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(223, 34);
            this.update_button.TabIndex = 2;
            this.update_button.Text = "Check For Update";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.check_for_update_click);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 238);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.close_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "setting";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button update_button;
    }
}
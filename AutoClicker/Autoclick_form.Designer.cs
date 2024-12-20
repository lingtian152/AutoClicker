namespace AutoClicker
{
    partial class Autoclick_form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.Cooldown_Label = new System.Windows.Forms.Label();
            this.HotKey_Label = new System.Windows.Forms.Label();
            this.Cooldown_Box = new System.Windows.Forms.TextBox();
            this.HotKey_Select = new System.Windows.Forms.ComboBox();
            this.Status = new System.Windows.Forms.Label();
            this.LeftButton_Select = new System.Windows.Forms.RadioButton();
            this.RightButton_Select = new System.Windows.Forms.RadioButton();
            this.Close_button = new System.Windows.Forms.Button();
            this.minize_button = new System.Windows.Forms.Button();
            this.setting_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cooldown_Label
            // 
            this.Cooldown_Label.AutoSize = true;
            this.Cooldown_Label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cooldown_Label.ForeColor = System.Drawing.Color.White;
            this.Cooldown_Label.Location = new System.Drawing.Point(21, 63);
            this.Cooldown_Label.Name = "Cooldown_Label";
            this.Cooldown_Label.Size = new System.Drawing.Size(141, 38);
            this.Cooldown_Label.TabIndex = 0;
            this.Cooldown_Label.Text = "Cooldown";
            this.Cooldown_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HotKey_Label
            // 
            this.HotKey_Label.AutoSize = true;
            this.HotKey_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HotKey_Label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HotKey_Label.ForeColor = System.Drawing.Color.White;
            this.HotKey_Label.Location = new System.Drawing.Point(21, 140);
            this.HotKey_Label.Name = "HotKey_Label";
            this.HotKey_Label.Size = new System.Drawing.Size(115, 38);
            this.HotKey_Label.TabIndex = 1;
            this.HotKey_Label.Text = "Hot Key";
            this.HotKey_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cooldown_Box
            // 
            this.Cooldown_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Cooldown_Box.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Cooldown_Box.ForeColor = System.Drawing.Color.Black;
            this.Cooldown_Box.Location = new System.Drawing.Point(163, 65);
            this.Cooldown_Box.Name = "Cooldown_Box";
            this.Cooldown_Box.Size = new System.Drawing.Size(177, 41);
            this.Cooldown_Box.TabIndex = 2;
            this.Cooldown_Box.Text = "1000";
            this.Cooldown_Box.TextChanged += new System.EventHandler(this.Cooldown_Changed);
            // 
            // HotKey_Select
            // 
            this.HotKey_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HotKey_Select.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.HotKey_Select.ForeColor = System.Drawing.Color.Black;
            this.HotKey_Select.FormattingEnabled = true;
            this.HotKey_Select.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.HotKey_Select.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10"});
            this.HotKey_Select.Location = new System.Drawing.Point(163, 140);
            this.HotKey_Select.Name = "HotKey_Select";
            this.HotKey_Select.Size = new System.Drawing.Size(177, 43);
            this.HotKey_Select.TabIndex = 4;
            this.HotKey_Select.TabStop = false;
            this.HotKey_Select.SelectedIndexChanged += new System.EventHandler(this.HotkeySelec_Changed);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Status.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.White;
            this.Status.Location = new System.Drawing.Point(88, 267);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(211, 41);
            this.Status.TabIndex = 6;
            this.Status.Text = "Status: {Status}";
            // 
            // LeftButton_Select
            // 
            this.LeftButton_Select.AutoSize = true;
            this.LeftButton_Select.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.LeftButton_Select.ForeColor = System.Drawing.Color.White;
            this.LeftButton_Select.Location = new System.Drawing.Point(9, 214);
            this.LeftButton_Select.Name = "LeftButton_Select";
            this.LeftButton_Select.Size = new System.Drawing.Size(154, 36);
            this.LeftButton_Select.TabIndex = 7;
            this.LeftButton_Select.TabStop = true;
            this.LeftButton_Select.Text = "Left Button";
            this.LeftButton_Select.UseVisualStyleBackColor = true;
            // 
            // RightButton_Select
            // 
            this.RightButton_Select.AutoSize = true;
            this.RightButton_Select.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.RightButton_Select.ForeColor = System.Drawing.Color.White;
            this.RightButton_Select.Location = new System.Drawing.Point(179, 214);
            this.RightButton_Select.Name = "RightButton_Select";
            this.RightButton_Select.Size = new System.Drawing.Size(170, 36);
            this.RightButton_Select.TabIndex = 8;
            this.RightButton_Select.TabStop = true;
            this.RightButton_Select.Text = "Right Button";
            this.RightButton_Select.UseVisualStyleBackColor = true;
            // 
            // Close_button
            // 
            this.Close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Close_button.ForeColor = System.Drawing.Color.White;
            this.Close_button.Location = new System.Drawing.Point(350, 9);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(40, 38);
            this.Close_button.TabIndex = 9;
            this.Close_button.Text = "X";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // minize_button
            // 
            this.minize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minize_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.minize_button.ForeColor = System.Drawing.Color.White;
            this.minize_button.Location = new System.Drawing.Point(300, 9);
            this.minize_button.Name = "minize_button";
            this.minize_button.Size = new System.Drawing.Size(40, 38);
            this.minize_button.TabIndex = 10;
            this.minize_button.Text = "-";
            this.minize_button.UseVisualStyleBackColor = true;
            this.minize_button.Click += new System.EventHandler(this.Minize_button_Click);
            // 
            // setting_button
            // 
            this.setting_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setting_button.ForeColor = System.Drawing.Color.White;
            this.setting_button.Location = new System.Drawing.Point(250, 9);
            this.setting_button.Name = "setting_button";
            this.setting_button.Size = new System.Drawing.Size(40, 38);
            this.setting_button.TabIndex = 12;
            this.setting_button.Text = "⚙";
            this.setting_button.UseVisualStyleBackColor = true;
            this.setting_button.Click += new System.EventHandler(this.Setting_button_Click);
            // 
            // Autoclick_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(400, 328);
            this.Controls.Add(this.setting_button);
            this.Controls.Add(this.minize_button);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.RightButton_Select);
            this.Controls.Add(this.LeftButton_Select);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.HotKey_Select);
            this.Controls.Add(this.Cooldown_Box);
            this.Controls.Add(this.HotKey_Label);
            this.Controls.Add(this.Cooldown_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Autoclick_form";
            this.Text = "AutoClicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Cooldown_Label;
        private System.Windows.Forms.Label HotKey_Label;
        private System.Windows.Forms.TextBox Cooldown_Box;
        private System.Windows.Forms.ComboBox HotKey_Select;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.RadioButton LeftButton_Select;
        private System.Windows.Forms.RadioButton RightButton_Select;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Button minize_button;
        private System.Windows.Forms.Button setting_button;
    }
}
namespace AutoClicker
{
    partial class Autoclick_form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
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
            this.Cooldown_Label.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cooldown_Label.Location = new System.Drawing.Point(59, 75);
            this.Cooldown_Label.Name = "Cooldown_Label";
            this.Cooldown_Label.Size = new System.Drawing.Size(124, 28);
            this.Cooldown_Label.TabIndex = 0;
            this.Cooldown_Label.Text = "Cooldown";
            this.Cooldown_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HotKey_Label
            // 
            this.HotKey_Label.AutoSize = true;
            this.HotKey_Label.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HotKey_Label.Location = new System.Drawing.Point(59, 158);
            this.HotKey_Label.Name = "HotKey_Label";
            this.HotKey_Label.Size = new System.Drawing.Size(110, 28);
            this.HotKey_Label.TabIndex = 1;
            this.HotKey_Label.Text = "Hot Key\r\n";
            this.HotKey_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cooldown_Box
            // 
            this.Cooldown_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Cooldown_Box.Font = new System.Drawing.Font("宋体", 15F);
            this.Cooldown_Box.Location = new System.Drawing.Point(201, 78);
            this.Cooldown_Box.Name = "Cooldown_Box";
            this.Cooldown_Box.Size = new System.Drawing.Size(177, 36);
            this.Cooldown_Box.TabIndex = 2;
            this.Cooldown_Box.TextChanged += new System.EventHandler(this.Cooldown_Changed);
            // 
            // HotKey_Select
            // 
            this.HotKey_Select.Font = new System.Drawing.Font("宋体", 15F);
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
            this.HotKey_Select.Location = new System.Drawing.Point(201, 158);
            this.HotKey_Select.Name = "HotKey_Select";
            this.HotKey_Select.Size = new System.Drawing.Size(177, 33);
            this.HotKey_Select.TabIndex = 4;
            this.HotKey_Select.TabStop = false;
            this.HotKey_Select.SelectedIndexChanged += new System.EventHandler(this.HotkeySelec_Changed);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Status.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Status.Location = new System.Drawing.Point(106, 303);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(253, 30);
            this.Status.TabIndex = 6;
            this.Status.Text = "Status: {Status}";
            // 
            // LeftButton_Select
            // 
            this.LeftButton_Select.AutoSize = true;
            this.LeftButton_Select.Font = new System.Drawing.Font("宋体", 14F);
            this.LeftButton_Select.Location = new System.Drawing.Point(47, 237);
            this.LeftButton_Select.Name = "LeftButton_Select";
            this.LeftButton_Select.Size = new System.Drawing.Size(163, 28);
            this.LeftButton_Select.TabIndex = 7;
            this.LeftButton_Select.TabStop = true;
            this.LeftButton_Select.Text = "Left Button";
            this.LeftButton_Select.UseVisualStyleBackColor = true;
            this.LeftButton_Select.CheckedChanged += new System.EventHandler(this.LeftButton_Select_CheckedChanged);
            // 
            // RightButton_Select
            // 
            this.RightButton_Select.AutoSize = true;
            this.RightButton_Select.Font = new System.Drawing.Font("宋体", 14F);
            this.RightButton_Select.Location = new System.Drawing.Point(240, 237);
            this.RightButton_Select.Name = "RightButton_Select";
            this.RightButton_Select.Size = new System.Drawing.Size(175, 28);
            this.RightButton_Select.TabIndex = 8;
            this.RightButton_Select.TabStop = true;
            this.RightButton_Select.Text = "Right Button";
            this.RightButton_Select.UseVisualStyleBackColor = true;
            this.RightButton_Select.CheckedChanged += new System.EventHandler(this.RightButton_Select_CheckedChanged);
            // 
            // Close_button
            // 
            this.Close_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_button.BackColor = System.Drawing.SystemColors.Control;
            this.Close_button.FlatAppearance.BorderSize = 0;
            this.Close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.Close_button.ForeColor = System.Drawing.Color.Black;
            this.Close_button.Location = new System.Drawing.Point(481, 12);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(31, 34);
            this.Close_button.TabIndex = 9;
            this.Close_button.Text = "X";
            this.Close_button.UseVisualStyleBackColor = false;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // minize_button
            // 
            this.minize_button.BackColor = System.Drawing.SystemColors.Control;
            this.minize_button.FlatAppearance.BorderSize = 0;
            this.minize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minize_button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.minize_button.Location = new System.Drawing.Point(441, 12);
            this.minize_button.Name = "minize_button";
            this.minize_button.Size = new System.Drawing.Size(31, 34);
            this.minize_button.TabIndex = 10;
            this.minize_button.Text = "_";
            this.minize_button.UseVisualStyleBackColor = false;
            this.minize_button.Click += new System.EventHandler(this.minize_button_Click);
            // 
            // setting_button
            // 
            this.setting_button.BackgroundImage = global::AutoClicker.Properties.Resources.setting;
            this.setting_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setting_button.FlatAppearance.BorderSize = 0;
            this.setting_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting_button.Location = new System.Drawing.Point(388, 13);
            this.setting_button.Name = "setting_button";
            this.setting_button.Size = new System.Drawing.Size(36, 34);
            this.setting_button.TabIndex = 11;
            this.setting_button.UseVisualStyleBackColor = true;
            this.setting_button.Click += new System.EventHandler(this.setting_button_click);
            // 
            // Autoclick_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(524, 352);
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
            this.MaximizeBox = false;
            this.Name = "Autoclick_form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Clicker";
            this.Load += new System.EventHandler(this.Autoclick_form_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Autoclick_form_MouseDown);
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


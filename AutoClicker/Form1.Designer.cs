﻿namespace AutoClicker
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.HotKey_Select = new System.Windows.Forms.ComboBox();
            this.Status = new System.Windows.Forms.Label();
            this.LeftButton_Select = new System.Windows.Forms.RadioButton();
            this.RightButton_Select = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Cooldown_Label
            // 
            this.Cooldown_Label.AutoSize = true;
            this.Cooldown_Label.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cooldown_Label.Location = new System.Drawing.Point(76, 46);
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
            this.HotKey_Label.Location = new System.Drawing.Point(76, 129);
            this.HotKey_Label.Name = "HotKey_Label";
            this.HotKey_Label.Size = new System.Drawing.Size(110, 28);
            this.HotKey_Label.TabIndex = 1;
            this.HotKey_Label.Text = "Hot Key\r\n";
            this.HotKey_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox1.Location = new System.Drawing.Point(218, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 36);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.Cooldown_Changed);
            // 
            // HotKey_Select
            // 
            this.HotKey_Select.Font = new System.Drawing.Font("宋体", 12F);
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
            this.HotKey_Select.Location = new System.Drawing.Point(218, 133);
            this.HotKey_Select.Name = "HotKey_Select";
            this.HotKey_Select.Size = new System.Drawing.Size(177, 28);
            this.HotKey_Select.TabIndex = 4;
            this.HotKey_Select.TabStop = false;
            this.HotKey_Select.SelectedIndexChanged += new System.EventHandler(this.HotkeySelec_Changed);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Status.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Status.Location = new System.Drawing.Point(107, 261);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(253, 30);
            this.Status.TabIndex = 6;
            this.Status.Text = "Status: {Status}";
            // 
            // LeftButton_Select
            // 
            this.LeftButton_Select.AutoSize = true;
            this.LeftButton_Select.Font = new System.Drawing.Font("宋体", 14F);
            this.LeftButton_Select.Location = new System.Drawing.Point(81, 192);
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
            this.RightButton_Select.Location = new System.Drawing.Point(270, 192);
            this.RightButton_Select.Name = "RightButton_Select";
            this.RightButton_Select.Size = new System.Drawing.Size(175, 28);
            this.RightButton_Select.TabIndex = 8;
            this.RightButton_Select.TabStop = true;
            this.RightButton_Select.Text = "Right Button";
            this.RightButton_Select.UseVisualStyleBackColor = true;
            this.RightButton_Select.CheckedChanged += new System.EventHandler(this.RightButton_Select_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 351);
            this.Controls.Add(this.RightButton_Select);
            this.Controls.Add(this.LeftButton_Select);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.HotKey_Select);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.HotKey_Label);
            this.Controls.Add(this.Cooldown_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Clicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Cooldown_Label;
        private System.Windows.Forms.Label HotKey_Label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox HotKey_Select;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.RadioButton LeftButton_Select;
        private System.Windows.Forms.RadioButton RightButton_Select;
    }
}


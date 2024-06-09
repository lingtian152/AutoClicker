namespace AutoClicker
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.MinimiButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cooldown_Label
            // 
            this.Cooldown_Label.AutoSize = true;
            this.Cooldown_Label.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cooldown_Label.Location = new System.Drawing.Point(75, 96);
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
            this.HotKey_Label.Location = new System.Drawing.Point(75, 179);
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
            this.textBox1.Location = new System.Drawing.Point(217, 99);
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
            this.HotKey_Select.Location = new System.Drawing.Point(217, 183);
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
            this.Status.Location = new System.Drawing.Point(106, 253);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(253, 30);
            this.Status.TabIndex = 6;
            this.Status.Text = "Status: {Status}";
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Red;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("极影毁片圆 Medium", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(475, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(37, 40);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MinimiButton
            // 
            this.MinimiButton.BackColor = System.Drawing.Color.Green;
            this.MinimiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimiButton.Font = new System.Drawing.Font("极影毁片圆 Medium", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinimiButton.ForeColor = System.Drawing.Color.White;
            this.MinimiButton.Location = new System.Drawing.Point(432, 12);
            this.MinimiButton.Name = "MinimiButton";
            this.MinimiButton.Size = new System.Drawing.Size(37, 40);
            this.MinimiButton.TabIndex = 8;
            this.MinimiButton.Text = "-";
            this.MinimiButton.UseVisualStyleBackColor = false;
            this.MinimiButton.Click += new System.EventHandler(this.MinimiButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("宋体", 20F);
            this.Title.Location = new System.Drawing.Point(12, 18);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(219, 34);
            this.Title.TabIndex = 9;
            this.Title.Text = "Auto Clicker";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 351);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.MinimiButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.HotKey_Select);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.HotKey_Label);
            this.Controls.Add(this.Cooldown_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Cooldown_Label;
        private System.Windows.Forms.Label HotKey_Label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox HotKey_Select;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MinimiButton;
        private System.Windows.Forms.Label Title;
    }
}


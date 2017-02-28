namespace LinkLab {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.panel_output = new System.Windows.Forms.Panel();
            this.pictureBox_output = new System.Windows.Forms.PictureBox();
            this.panel_cmd = new System.Windows.Forms.Panel();
            this.richTextBox_cmd = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.调试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMDSTructToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cAnvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_output)).BeginInit();
            this.panel_cmd.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_output
            // 
            this.panel_output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_output.Controls.Add(this.pictureBox_output);
            this.panel_output.Location = new System.Drawing.Point(13, 27);
            this.panel_output.Name = "panel_output";
            this.panel_output.Size = new System.Drawing.Size(259, 86);
            this.panel_output.TabIndex = 0;
            // 
            // pictureBox_output
            // 
            this.pictureBox_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_output.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_output.Name = "pictureBox_output";
            this.pictureBox_output.Size = new System.Drawing.Size(259, 86);
            this.pictureBox_output.TabIndex = 0;
            this.pictureBox_output.TabStop = false;
            // 
            // panel_cmd
            // 
            this.panel_cmd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_cmd.Controls.Add(this.richTextBox_cmd);
            this.panel_cmd.Location = new System.Drawing.Point(13, 119);
            this.panel_cmd.Name = "panel_cmd";
            this.panel_cmd.Size = new System.Drawing.Size(259, 131);
            this.panel_cmd.TabIndex = 1;
            // 
            // richTextBox_cmd
            // 
            this.richTextBox_cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_cmd.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_cmd.Name = "richTextBox_cmd";
            this.richTextBox_cmd.Size = new System.Drawing.Size(259, 131);
            this.richTextBox_cmd.TabIndex = 0;
            this.richTextBox_cmd.Text = "";
            this.richTextBox_cmd.WordWrap = false;
            this.richTextBox_cmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_cmd_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.调试ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 调试ToolStripMenuItem
            // 
            this.调试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMDToolStripMenuItem,
            this.cMDSTructToolStripMenuItem,
            this.cAnvasToolStripMenuItem,
            this.sizeToolStripMenuItem});
            this.调试ToolStripMenuItem.Name = "调试ToolStripMenuItem";
            this.调试ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.调试ToolStripMenuItem.Text = "调试";
            // 
            // cMDToolStripMenuItem
            // 
            this.cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
            this.cMDToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cMDToolStripMenuItem.Text = "CMDHistory";
            this.cMDToolStripMenuItem.Click += new System.EventHandler(this.cMDToolStripMenuItem_Click);
            // 
            // cMDSTructToolStripMenuItem
            // 
            this.cMDSTructToolStripMenuItem.Name = "cMDSTructToolStripMenuItem";
            this.cMDSTructToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cMDSTructToolStripMenuItem.Text = "CMDSTruct";
            this.cMDSTructToolStripMenuItem.Click += new System.EventHandler(this.cMDSTructToolStripMenuItem_Click);
            // 
            // cAnvasToolStripMenuItem
            // 
            this.cAnvasToolStripMenuItem.Name = "cAnvasToolStripMenuItem";
            this.cAnvasToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cAnvasToolStripMenuItem.Text = "Canvas";
            this.cAnvasToolStripMenuItem.Click += new System.EventHandler(this.cAnvasToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel_cmd);
            this.Controls.Add(this.panel_output);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_output.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_output)).EndInit();
            this.panel_cmd.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_output;
        private System.Windows.Forms.Panel panel_cmd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox richTextBox_cmd;
        private System.Windows.Forms.ToolStripMenuItem 调试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cMDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cMDSTructToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox_output;
        private System.Windows.Forms.ToolStripMenuItem cAnvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
    }
}


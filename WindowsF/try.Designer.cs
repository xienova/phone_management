namespace PhoneSystem
{
    partial class try1
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
            this.cbb = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.assadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb
            // 
            this.cbb.FormattingEnabled = true;
            this.cbb.Location = new System.Drawing.Point(317, 69);
            this.cbb.Margin = new System.Windows.Forms.Padding(2);
            this.cbb.Name = "cbb";
            this.cbb.Size = new System.Drawing.Size(82, 20);
            this.cbb.TabIndex = 0;
            this.cbb.SelectedIndexChanged += new System.EventHandler(this.cbb_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // assadToolStripMenuItem
            // 
            this.assadToolStripMenuItem.Name = "assadToolStripMenuItem";
            this.assadToolStripMenuItem.Size = new System.Drawing.Size(54, 21);
            this.assadToolStripMenuItem.Text = "assad";
            this.assadToolStripMenuItem.Click += new System.EventHandler(this.assadToolStripMenuItem_Click);
            // 
            // try1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::PhoneSystem.Properties.Resources.ss;
            this.ClientSize = new System.Drawing.Size(532, 323);
            this.Controls.Add(this.cbb);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "try1";
            this.Text = "try";
            this.Load += new System.EventHandler(this.try_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem assadToolStripMenuItem;
    }
}
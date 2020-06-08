namespace PhoneSystem
{
    partial class AdminForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.个人中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhoneInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.样机输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXCEL打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单次输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.样机查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询样机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借还机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借阅查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人中心ToolStripMenuItem,
            this.PhoneInfoToolStripMenuItem,
            this.查询样机ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 个人中心ToolStripMenuItem
            // 
            this.个人中心ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统说明ToolStripMenuItem,
            this.密码修改ToolStripMenuItem});
            this.个人中心ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.个人中心ToolStripMenuItem.Name = "个人中心ToolStripMenuItem";
            this.个人中心ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.个人中心ToolStripMenuItem.Text = "系统管理";
            // 
            // 系统说明ToolStripMenuItem
            // 
            this.系统说明ToolStripMenuItem.Name = "系统说明ToolStripMenuItem";
            this.系统说明ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.系统说明ToolStripMenuItem.Text = "系统说明";
            this.系统说明ToolStripMenuItem.Click += new System.EventHandler(this.系统说明ToolStripMenuItem_Click);
            // 
            // 密码修改ToolStripMenuItem
            // 
            this.密码修改ToolStripMenuItem.Name = "密码修改ToolStripMenuItem";
            this.密码修改ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.密码修改ToolStripMenuItem.Text = "密码修改";
            this.密码修改ToolStripMenuItem.Click += new System.EventHandler(this.密码修改ToolStripMenuItem_Click);
            // 
            // PhoneInfoToolStripMenuItem
            // 
            this.PhoneInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.样机输入ToolStripMenuItem,
            this.eXCEL打印ToolStripMenuItem,
            this.单次输入ToolStripMenuItem,
            this.样机查询ToolStripMenuItem});
            this.PhoneInfoToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PhoneInfoToolStripMenuItem.Name = "PhoneInfoToolStripMenuItem";
            this.PhoneInfoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.PhoneInfoToolStripMenuItem.Text = "样机信息";
            // 
            // 样机输入ToolStripMenuItem
            // 
            this.样机输入ToolStripMenuItem.Name = "样机输入ToolStripMenuItem";
            this.样机输入ToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.样机输入ToolStripMenuItem.Text = "EXCEL导入";
            this.样机输入ToolStripMenuItem.Click += new System.EventHandler(this.样机输入ToolStripMenuItem_Click);
            // 
            // eXCEL打印ToolStripMenuItem
            // 
            this.eXCEL打印ToolStripMenuItem.Name = "eXCEL打印ToolStripMenuItem";
            this.eXCEL打印ToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.eXCEL打印ToolStripMenuItem.Text = "EXCEL打印";
            this.eXCEL打印ToolStripMenuItem.Click += new System.EventHandler(this.eXCEL打印ToolStripMenuItem_Click);
            // 
            // 单次输入ToolStripMenuItem
            // 
            this.单次输入ToolStripMenuItem.Name = "单次输入ToolStripMenuItem";
            this.单次输入ToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.单次输入ToolStripMenuItem.Text = "单次输入";
            this.单次输入ToolStripMenuItem.Click += new System.EventHandler(this.单次输入ToolStripMenuItem_Click);
            // 
            // 样机查询ToolStripMenuItem
            // 
            this.样机查询ToolStripMenuItem.Name = "样机查询ToolStripMenuItem";
            this.样机查询ToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.样机查询ToolStripMenuItem.Text = "样机查询";
            this.样机查询ToolStripMenuItem.Click += new System.EventHandler(this.样机查询ToolStripMenuItem_Click);
            // 
            // 查询样机ToolStripMenuItem
            // 
            this.查询样机ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借还机ToolStripMenuItem,
            this.借阅查询ToolStripMenuItem});
            this.查询样机ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.查询样机ToolStripMenuItem.Name = "查询样机ToolStripMenuItem";
            this.查询样机ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.查询样机ToolStripMenuItem.Text = "借阅信息";
            // 
            // 借还机ToolStripMenuItem
            // 
            this.借还机ToolStripMenuItem.Name = "借还机ToolStripMenuItem";
            this.借还机ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.借还机ToolStripMenuItem.Text = "借还机";
            this.借还机ToolStripMenuItem.Click += new System.EventHandler(this.借还机ToolStripMenuItem_Click);
            // 
            // 借阅查询ToolStripMenuItem
            // 
            this.借阅查询ToolStripMenuItem.Name = "借阅查询ToolStripMenuItem";
            this.借阅查询ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.借阅查询ToolStripMenuItem.Text = "借阅查询";
            this.借阅查询ToolStripMenuItem.Click += new System.EventHandler(this.借阅查询ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblTime
            // 
            this.slblTime.Name = "slblTime";
            this.slblTime.Size = new System.Drawing.Size(68, 17);
            this.slblTime.Text = "当前时间：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::PhoneSystem.Properties.Resources.timg__3_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 379);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人中心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PhoneInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询样机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 样机输入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 样机查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借还机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借阅查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单次输入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXCEL打印ToolStripMenuItem;

    }
}
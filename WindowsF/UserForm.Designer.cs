namespace PhoneSystem
{
    partial class UserForm
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
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.样机查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借阅信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借还机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借阅查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.可靠性测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.我的借阅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCP分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进度一览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.还样机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统管理ToolStripMenuItem,
            this.样机查询ToolStripMenuItem,
            this.借阅信息ToolStripMenuItem,
            this.我的借阅ToolStripMenuItem,
            this.tCP分析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1003, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统说明ToolStripMenuItem,
            this.密码修改ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
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
            // 样机查询ToolStripMenuItem
            // 
            this.样机查询ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.样机查询ToolStripMenuItem.Name = "样机查询ToolStripMenuItem";
            this.样机查询ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.样机查询ToolStripMenuItem.Text = "样机查询";
            this.样机查询ToolStripMenuItem.Click += new System.EventHandler(this.样机查询ToolStripMenuItem_Click);
            // 
            // 借阅信息ToolStripMenuItem
            // 
            this.借阅信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借还机ToolStripMenuItem,
            this.还样机ToolStripMenuItem,
            this.借阅查询ToolStripMenuItem,
            this.可靠性测试ToolStripMenuItem});
            this.借阅信息ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.借阅信息ToolStripMenuItem.Name = "借阅信息ToolStripMenuItem";
            this.借阅信息ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.借阅信息ToolStripMenuItem.Text = "借阅信息";
            // 
            // 借还机ToolStripMenuItem
            // 
            this.借还机ToolStripMenuItem.Name = "借还机ToolStripMenuItem";
            this.借还机ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.借还机ToolStripMenuItem.Text = "借样机";
            this.借还机ToolStripMenuItem.Click += new System.EventHandler(this.借还机ToolStripMenuItem_Click);
            // 
            // 借阅查询ToolStripMenuItem
            // 
            this.借阅查询ToolStripMenuItem.Name = "借阅查询ToolStripMenuItem";
            this.借阅查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.借阅查询ToolStripMenuItem.Text = "借阅查询";
            this.借阅查询ToolStripMenuItem.Click += new System.EventHandler(this.借阅查询ToolStripMenuItem_Click);
            // 
            // 可靠性测试ToolStripMenuItem
            // 
            this.可靠性测试ToolStripMenuItem.Name = "可靠性测试ToolStripMenuItem";
            this.可靠性测试ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.可靠性测试ToolStripMenuItem.Text = "可靠性测试";
            this.可靠性测试ToolStripMenuItem.Click += new System.EventHandler(this.可靠性测试ToolStripMenuItem_Click);
            // 
            // 我的借阅ToolStripMenuItem
            // 
            this.我的借阅ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.我的借阅ToolStripMenuItem.Name = "我的借阅ToolStripMenuItem";
            this.我的借阅ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.我的借阅ToolStripMenuItem.Text = "我的借阅";
            this.我的借阅ToolStripMenuItem.Click += new System.EventHandler(this.我的借阅ToolStripMenuItem_Click);
            // 
            // tCP分析ToolStripMenuItem
            // 
            this.tCP分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.进度一览ToolStripMenuItem,
            this.信息输入ToolStripMenuItem});
            this.tCP分析ToolStripMenuItem.Name = "tCP分析ToolStripMenuItem";
            this.tCP分析ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.tCP分析ToolStripMenuItem.Text = "TCP分析";
            // 
            // 进度一览ToolStripMenuItem
            // 
            this.进度一览ToolStripMenuItem.Name = "进度一览ToolStripMenuItem";
            this.进度一览ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.进度一览ToolStripMenuItem.Text = "进度一览";
            this.进度一览ToolStripMenuItem.Click += new System.EventHandler(this.进度一览ToolStripMenuItem_Click);
            // 
            // 信息输入ToolStripMenuItem
            // 
            this.信息输入ToolStripMenuItem.Name = "信息输入ToolStripMenuItem";
            this.信息输入ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.信息输入ToolStripMenuItem.Text = "信息输入";
            this.信息输入ToolStripMenuItem.Click += new System.EventHandler(this.信息输入ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1003, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblTime
            // 
            this.slblTime.BackColor = System.Drawing.SystemColors.Control;
            this.slblTime.Name = "slblTime";
            this.slblTime.Size = new System.Drawing.Size(59, 17);
            this.slblTime.Text = "当前时间:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 还样机ToolStripMenuItem
            // 
            this.还样机ToolStripMenuItem.Name = "还样机ToolStripMenuItem";
            this.还样机ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.还样机ToolStripMenuItem.Text = "还样机";
            this.还样机ToolStripMenuItem.Click += new System.EventHandler(this.还样机ToolStripMenuItem_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1003, 514);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserForm_FormClosed);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 样机查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借阅信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借还机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借阅查询ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 我的借阅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 可靠性测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCP分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进度一览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息输入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还样机ToolStripMenuItem;
    }
}
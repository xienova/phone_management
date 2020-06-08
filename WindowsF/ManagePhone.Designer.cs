namespace PhoneSystem
{
    partial class ManagePhone
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
            this.lblPrj = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblStage = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblMgr = new System.Windows.Forms.Label();
            this.txtPrj = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtStage = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtMgr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPrj
            // 
            this.lblPrj.AutoSize = true;
            this.lblPrj.Location = new System.Drawing.Point(12, 27);
            this.lblPrj.Name = "lblPrj";
            this.lblPrj.Size = new System.Drawing.Size(53, 12);
            this.lblPrj.TabIndex = 0;
            this.lblPrj.Text = "项目名称";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(12, 75);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(53, 12);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "样机数量";
            // 
            // lblStage
            // 
            this.lblStage.AutoSize = true;
            this.lblStage.Location = new System.Drawing.Point(219, 27);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(53, 12);
            this.lblStage.TabIndex = 0;
            this.lblStage.Text = "项目阶段";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(219, 75);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 12);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "提供日期";
            // 
            // lblMgr
            // 
            this.lblMgr.AutoSize = true;
            this.lblMgr.Location = new System.Drawing.Point(12, 123);
            this.lblMgr.Name = "lblMgr";
            this.lblMgr.Size = new System.Drawing.Size(53, 12);
            this.lblMgr.TabIndex = 0;
            this.lblMgr.Text = "测试主管";
            this.lblMgr.Click += new System.EventHandler(this.lblMgr_Click);
            // 
            // txtPrj
            // 
            this.txtPrj.Location = new System.Drawing.Point(71, 24);
            this.txtPrj.Name = "txtPrj";
            this.txtPrj.Size = new System.Drawing.Size(100, 21);
            this.txtPrj.TabIndex = 1;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(71, 72);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 21);
            this.txtNum.TabIndex = 1;
            // 
            // txtStage
            // 
            this.txtStage.Location = new System.Drawing.Point(278, 24);
            this.txtStage.Name = "txtStage";
            this.txtStage.Size = new System.Drawing.Size(100, 21);
            this.txtStage.TabIndex = 1;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(279, 72);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 21);
            this.txtDate.TabIndex = 1;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // txtMgr
            // 
            this.txtMgr.Location = new System.Drawing.Point(71, 120);
            this.txtMgr.Name = "txtMgr";
            this.txtMgr.Size = new System.Drawing.Size(100, 21);
            this.txtMgr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "备注信息";
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(71, 202);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(238, 63);
            this.txtNotice.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(71, 334);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "创建项目";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // ManagePhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 419);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotice);
            this.Controls.Add(this.txtMgr);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtStage);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtPrj);
            this.Controls.Add(this.lblMgr);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblPrj);
            this.Name = "ManagePhone";
            this.Text = "ManagePhone";
            this.Load += new System.EventHandler(this.ManagePhone_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrj;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMgr;
        private System.Windows.Forms.TextBox txtPrj;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtStage;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtMgr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Button btnCreate;
    }
}
namespace PhoneSystem
{
    partial class PhoneQueryForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhoneNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneCode = new System.Windows.Forms.TextBox();
            this.cbbPhoneStatus = new System.Windows.Forms.ComboBox();
            this.cbbPhoneName = new System.Windows.Forms.ComboBox();
            this.cbbPhoneStage = new System.Windows.Forms.ComboBox();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.TestDataGrid = new System.Windows.Forms.DataGridView();
            this.phoneDataGrid = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.ESNDataGrid = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ESNDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPhoneNote);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPhoneCode);
            this.groupBox1.Controls.Add(this.cbbPhoneStatus);
            this.groupBox1.Controls.Add(this.cbbPhoneName);
            this.groupBox1.Controls.Add(this.cbbPhoneStage);
            this.groupBox1.Controls.Add(this.txtPhoneNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Location = new System.Drawing.Point(78, 490);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(886, 112);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(767, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 27);
            this.button3.TabIndex = 29;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(188, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "备注：";
            // 
            // txtPhoneNote
            // 
            this.txtPhoneNote.Location = new System.Drawing.Point(231, 72);
            this.txtPhoneNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhoneNote.Name = "txtPhoneNote";
            this.txtPhoneNote.Size = new System.Drawing.Size(309, 21);
            this.txtPhoneNote.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Phone ID:";
            // 
            // txtPhoneCode
            // 
            this.txtPhoneCode.Location = new System.Drawing.Point(81, 24);
            this.txtPhoneCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhoneCode.Name = "txtPhoneCode";
            this.txtPhoneCode.Size = new System.Drawing.Size(98, 21);
            this.txtPhoneCode.TabIndex = 25;
            // 
            // cbbPhoneStatus
            // 
            this.cbbPhoneStatus.FormattingEnabled = true;
            this.cbbPhoneStatus.Items.AddRange(new object[] {
            "",
            "在库",
            "借出"});
            this.cbbPhoneStatus.Location = new System.Drawing.Point(618, 24);
            this.cbbPhoneStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbbPhoneStatus.Name = "cbbPhoneStatus";
            this.cbbPhoneStatus.Size = new System.Drawing.Size(97, 20);
            this.cbbPhoneStatus.TabIndex = 23;
            // 
            // cbbPhoneName
            // 
            this.cbbPhoneName.FormattingEnabled = true;
            this.cbbPhoneName.Location = new System.Drawing.Point(257, 25);
            this.cbbPhoneName.Margin = new System.Windows.Forms.Padding(2);
            this.cbbPhoneName.Name = "cbbPhoneName";
            this.cbbPhoneName.Size = new System.Drawing.Size(100, 20);
            this.cbbPhoneName.TabIndex = 24;
            this.cbbPhoneName.SelectedIndexChanged += new System.EventHandler(this.cbbPhoneName_SelectedIndexChanged);
            // 
            // cbbPhoneStage
            // 
            this.cbbPhoneStage.FormattingEnabled = true;
            this.cbbPhoneStage.Location = new System.Drawing.Point(440, 25);
            this.cbbPhoneStage.Margin = new System.Windows.Forms.Padding(2);
            this.cbbPhoneStage.Name = "cbbPhoneStage";
            this.cbbPhoneStage.Size = new System.Drawing.Size(100, 20);
            this.cbbPhoneStage.TabIndex = 24;
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(80, 72);
            this.txtPhoneNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(100, 21);
            this.txtPhoneNum.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(544, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 18;
            this.label4.Tag = "";
            this.label4.Text = "样机状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(370, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 17;
            this.label3.Tag = "";
            this.label3.Text = "样机阶段：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(188, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "样机名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "样机编号：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(741, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "显示所有样机";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(666, 71);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 27);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // TestDataGrid
            // 
            this.TestDataGrid.AllowUserToAddRows = false;
            this.TestDataGrid.AllowUserToDeleteRows = false;
            this.TestDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestDataGrid.Location = new System.Drawing.Point(21, 252);
            this.TestDataGrid.Name = "TestDataGrid";
            this.TestDataGrid.ReadOnly = true;
            this.TestDataGrid.RowTemplate.Height = 23;
            this.TestDataGrid.Size = new System.Drawing.Size(970, 144);
            this.TestDataGrid.TabIndex = 8;
            this.TestDataGrid.Visible = false;
            // 
            // phoneDataGrid
            // 
            this.phoneDataGrid.Location = new System.Drawing.Point(21, 12);
            this.phoneDataGrid.Name = "phoneDataGrid";
            this.phoneDataGrid.RowTemplate.Height = 23;
            this.phoneDataGrid.Size = new System.Drawing.Size(970, 384);
            this.phoneDataGrid.TabIndex = 7;
            this.phoneDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.phoneDataGrid_RowPostPaint);
            this.phoneDataGrid.SelectionChanged += new System.EventHandler(this.phoneDataGrid_SelectionChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(-3, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 143);
            this.label7.TabIndex = 9;
            this.label7.Text = "写号、无线信息";
            this.label7.Visible = false;
            // 
            // ESNDataGrid
            // 
            this.ESNDataGrid.AllowUserToAddRows = false;
            this.ESNDataGrid.AllowUserToDeleteRows = false;
            this.ESNDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ESNDataGrid.Location = new System.Drawing.Point(21, 402);
            this.ESNDataGrid.Name = "ESNDataGrid";
            this.ESNDataGrid.ReadOnly = true;
            this.ESNDataGrid.RowTemplate.Height = 23;
            this.ESNDataGrid.Size = new System.Drawing.Size(970, 142);
            this.ESNDataGrid.TabIndex = 10;
            this.ESNDataGrid.Visible = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(-3, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 123);
            this.label8.TabIndex = 9;
            this.label8.Text = "有线信息";
            this.label8.Visible = false;
            // 
            // PhoneQueryForm
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 693);
            this.Controls.Add(this.ESNDataGrid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TestDataGrid);
            this.Controls.Add(this.phoneDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PhoneQueryForm";
            this.Text = "PhoneQueryFrom";
            this.Load += new System.EventHandler(this.PhoneQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ESNDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhoneCode;
        private System.Windows.Forms.ComboBox cbbPhoneStatus;
        private System.Windows.Forms.ComboBox cbbPhoneStage;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhoneNote;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView phoneDataGrid;
        private System.Windows.Forms.ComboBox cbbPhoneName;
        private System.Windows.Forms.DataGridView TestDataGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView ESNDataGrid;
        private System.Windows.Forms.Label label8;
    }
}
namespace PhoneSystem
{
    partial class StaffInfoForm
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
            this.staffDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStaffCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbbStaffDept = new System.Windows.Forms.ComboBox();
            this.cbbStaffSex = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.staffDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // staffDataGrid
            // 
            this.staffDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staffDataGrid.Location = new System.Drawing.Point(12, 12);
            this.staffDataGrid.Name = "staffDataGrid";
            this.staffDataGrid.RowTemplate.Height = 23;
            this.staffDataGrid.Size = new System.Drawing.Size(949, 371);
            this.staffDataGrid.TabIndex = 0;
            this.staffDataGrid.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.staffDataGrid_RowStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStaffCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.cbbStaffDept);
            this.groupBox1.Controls.Add(this.cbbStaffSex);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtStaffName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(144, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtStaffCode
            // 
            this.txtStaffCode.Location = new System.Drawing.Point(134, 148);
            this.txtStaffCode.Name = "txtStaffCode";
            this.txtStaffCode.Size = new System.Drawing.Size(88, 21);
            this.txtStaffCode.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "员工编号:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(325, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbbStaffDept
            // 
            this.cbbStaffDept.FormattingEnabled = true;
            this.cbbStaffDept.Location = new System.Drawing.Point(134, 111);
            this.cbbStaffDept.Name = "cbbStaffDept";
            this.cbbStaffDept.Size = new System.Drawing.Size(88, 20);
            this.cbbStaffDept.TabIndex = 4;
            // 
            // cbbStaffSex
            // 
            this.cbbStaffSex.FormattingEnabled = true;
            this.cbbStaffSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbbStaffSex.Location = new System.Drawing.Point(134, 74);
            this.cbbStaffSex.Name = "cbbStaffSex";
            this.cbbStaffSex.Size = new System.Drawing.Size(88, 20);
            this.cbbStaffSex.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(134, 35);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(88, 21);
            this.txtStaffName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "员工权限：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "员工性别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "员工姓名：";
            // 
            // StaffInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 592);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.staffDataGrid);
            this.Name = "StaffInfoForm";
            this.Text = "StaffInfoForm";
            this.Load += new System.EventHandler(this.StaffInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staffDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView staffDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbStaffSex;
        private System.Windows.Forms.ComboBox cbbStaffDept;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtStaffCode;
        private System.Windows.Forms.Label label1;
    }
}
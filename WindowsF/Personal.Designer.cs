namespace PhoneSystem
{
    partial class Personal
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
            this.userDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // userDataGrid
            // 
            this.userDataGrid.Location = new System.Drawing.Point(12, 26);
            this.userDataGrid.Name = "userDataGrid";
            this.userDataGrid.RowTemplate.Height = 23;
            this.userDataGrid.Size = new System.Drawing.Size(566, 240);
            this.userDataGrid.TabIndex = 0;
            this.userDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.userDataGrid_RowPostPaint);
            // 
            // Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 388);
            this.Controls.Add(this.userDataGrid);
            this.Name = "Personal";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.Personal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView userDataGrid;

    }
}
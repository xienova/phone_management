using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;


namespace PhoneSystem
{
    public partial class StaffQueryForm : Form
    {
        private string sql;

        public StaffQueryForm()
        {
            InitializeComponent();

        }

        IList<StaffInfo> staffs;

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "select * from PmStaff where 1=1";

            if (txtStaffName.Text == "" && cbbStaffSex.Text =="")
            {
                MessageBox.Show("请选择查询条件","提示");
                return;
            }

            //if (txtStaffID.Text != "")
            //{
            //    sql = sql + "and StaffID ='" + txtStaffID.Text + "'";
            //}
            if (txtStaffName.Text != "")
            {
                sql = sql + " and StaffName like'%" + txtStaffName.Text + "%'";
            }
            if (cbbStaffSex.Text != "")
            {
                sql = sql + " and StaffSex ='" + cbbStaffSex.Text + "'";
            }

            StaffBLL staffbll = new StaffBLL();
            staffs = staffbll.selByCondition(sql);
            staffDataGrid.DataSource = staffs;

            //this.txtStaffID.Clear();
            this.txtStaffName.Clear();
            this.cbbStaffSex.Text = "";

        }

        private void StaffQueryForm_Load(object sender, EventArgs e)        //加载窗体时显示所有员工
        {

            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;  
            
            StaffBLL staffbll = new StaffBLL();
            staffs = staffbll.getAllStaff();
            staffDataGrid.DataSource = staffs;

            staffDataGrid.ReadOnly = true;
            staffDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            staffDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            staffDataGrid.Width = Fuctions.dataGridViewWidth;
            staffDataGrid.Height = Fuctions.dataGridViewHeight;
            staffDataGrid.Location = new Point(Fuctions.dataGridViewLocationX, Fuctions.dataGridViewLocationY);



            staffDataGrid.Columns[0].HeaderText = "主键";   //修改显示的列名
            staffDataGrid.Columns[0].Visible = false;
            staffDataGrid.Columns[1].HeaderText = "员工";
            staffDataGrid.Columns[2].HeaderText = "性别";
            staffDataGrid.Columns[3].HeaderText = "权限";
            staffDataGrid.Columns[3].Visible = false;
            staffDataGrid.Columns[4].HeaderText = "密码";
            staffDataGrid.Columns[4].Visible = false;
            staffDataGrid.Columns[5].HeaderText = "编号";

            Fuctions.AutoSize(staffDataGrid);

        }

        private void staffDataGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void button2_Click(object sender, EventArgs e)                           //显示所有员工
        {
            StaffBLL staffbll = new StaffBLL(); 
            staffs = staffbll.getAllStaff();
            staffDataGrid.DataSource = staffs;

            //this.txtStaffID.Clear();
            this.txtStaffName.Clear();
            this.cbbStaffSex.Text = "";  
            
        }

        private void button4_Click(object sender, EventArgs e)                          //退出
        {
            this.Dispose();
        }


    }
}

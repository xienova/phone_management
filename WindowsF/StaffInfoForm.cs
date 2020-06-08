using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using DAL;
//using MySql.Data.MySqlClient;


namespace PhoneSystem
{
    public partial class StaffInfoForm : Form
    {
        public StaffInfoForm()
        {
            InitializeComponent();
        }

        IList<StaffInfo> staffs;

        private void StaffInfoForm_Load(object sender, EventArgs e)
        {

            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;

            StaffBLL staffbll = new StaffBLL();
            staffs = staffbll.getAllStaff();
            staffDataGrid.DataSource = staffs;                              //将数据库中的数据提到列表中，再通过 DataGrid控件显示；

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
            staffDataGrid.Columns[4].HeaderText = "密码";
            staffDataGrid.Columns[4].Visible = false;
            staffDataGrid.Columns[5].HeaderText = "编号";

            Fuctions.AutoSize(staffDataGrid);


            DataTable dt = new DataTable();                                 //表中cbb权限内容加载
            DataColumn dc1 = new DataColumn("id");
            DataColumn dc2 = new DataColumn("name");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            DataRow dr1 = dt.NewRow();
            dr1["id"] = "1";
            dr1["name"] = "管理员";
            DataRow dr2 = dt.NewRow();
            dr2["id"] = "2";
            dr2["name"] = "员工";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);

            cbbStaffDept.DisplayMember = "name";
            cbbStaffDept.ValueMember = "id";
            cbbStaffDept.DataSource = dt;
            cbbStaffDept.Text = "";

        }

        private void staffDataGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }


        private void button1_Click(object sender, EventArgs e)              //添加员工信息
        {
            if (this.txtStaffName.Text == "" || this.cbbStaffSex.Text == "" ||this.cbbStaffDept.Text=="" )
            {
                MessageBox.Show("请输入除员工编码外的所有信息", "提示");
                return;
            }

            string txtStaffName = this.txtStaffName.Text;
            string cbbStaffSex = this.cbbStaffSex.Text;
            string cbbStaffDept = this.cbbStaffDept.Text;
            string txtStaffCode = this.txtStaffCode.Text;

            StaffBLL staffbll = new StaffBLL();

            if(staffbll.addStaff(txtStaffName,cbbStaffSex,cbbStaffDept,txtStaffCode))
            {
                MessageBox.Show("保存成功！");
            }


            staffs = staffbll.getAllStaff();
            staffDataGrid.DataSource=staffs;

   
            this.txtStaffName.Clear();
            this.cbbStaffDept.Text="";
            this.cbbStaffSex.Text = "";
            this.txtStaffCode.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            string staffName = this.txtStaffName.Text;

            StaffBLL staffbll = new StaffBLL();
            if (txtStaffName.Text == "")
            {
                MessageBox.Show("请通过输入员工姓名进行样机删除", "提示");
                return;
            }

            if (MessageBox.Show("确定要删除该条员工信息吗？", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (staffbll.delByStaffName(staffName))
                {
                    MessageBox.Show("删除成功！", "提示");
                }
                else
                {
                    MessageBox.Show("请检查员工姓名是否输入正确", "提示");
                }

                staffs = staffbll.getAllStaff();
                staffDataGrid.DataSource = staffs;

                this.txtStaffName.Clear();
                this.cbbStaffDept.Text = "";
                this.cbbStaffSex.Text = "";
            }
            else
            {
                //不执行任务
            }
        }







    }
}

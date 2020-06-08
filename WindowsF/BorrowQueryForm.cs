using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using DAL;
using BLL;
using MySql.Data.MySqlClient;


namespace PhoneSystem
{
    public partial class BorrowQueryForm : Form
    {
        IList<BorrowInfo> borrows;

        MySqlConnection conn = new MySqlConnection(GetConn.connection);                 //显示所有借阅信息

        public BorrowQueryForm()
        {
            InitializeComponent();
        }

        private void BorrowQueryForm_Load(object sender, EventArgs e)
        {
            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;
            

            BorrowBLL borrowbll = new BorrowBLL();
            borrows = borrowbll.GetNoneBorrow();
            borrowQDataGrid.DataSource = borrows;

            borrowQDataGrid.ReadOnly = true;
            borrowQDataGrid.Width = Fuctions.dataGridViewWidth;
            borrowQDataGrid.Height = Fuctions.dataGridViewHeight;
            borrowQDataGrid.Location = new Point(Fuctions.dataGridViewLocationX, Fuctions.dataGridViewLocationY);

            borrowQDataGrid.Columns[0].HeaderText = "主键";   //修改显示的列名
            borrowQDataGrid.Columns[0].Visible = false;
            borrowQDataGrid.Columns[1].HeaderText = "员工";
            borrowQDataGrid.Columns[2].HeaderText = "名称";
            borrowQDataGrid.Columns[3].HeaderText = "阶段";
            borrowQDataGrid.Columns[4].HeaderText = "编号";
            borrowQDataGrid.Columns[5].HeaderText = "借用日期";
            borrowQDataGrid.Columns[6].HeaderText = "归还日期";
            borrowQDataGrid.Columns[7].HeaderText = "是否归还";
            borrowQDataGrid.Columns[7].Visible = false;
            borrowQDataGrid.Columns[8].HeaderText = "试验项目";
            borrowQDataGrid.Columns[9].HeaderText = "状态";
            borrowQDataGrid.Columns[10].HeaderText = "备注";
            borrowQDataGrid.Columns[11].HeaderText = "操作人";


            borrowQDataGrid.Columns[1].Width = 50;
            borrowQDataGrid.Columns[2].Width = Fuctions.dataGridViewPhoneName;
            borrowQDataGrid.Columns[3].Width = 90;
            borrowQDataGrid.Columns[4].Width = Fuctions.dataGridViewPhoneNum; 
            borrowQDataGrid.Columns[5].Width = 120;
            borrowQDataGrid.Columns[6].Width = 120;
            borrowQDataGrid.Columns[8].Width = 120;
            borrowQDataGrid.Columns[9].Width = 50;
            borrowQDataGrid.Columns[10].Width = Fuctions.dataGridViewNote;
            borrowQDataGrid.Columns[11].Width = 50;

            Fuctions.AutoSize(borrowQDataGrid);


            //**********************************************************还机相关内容更新
            string strSql = "select distinct StaffName from PmBorrow";                               //--还员工姓名combobox内容更新
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbStaffName.DisplayMember = "StaffName";
            cbbStaffName.ValueMember = "StaffName";
            cbbStaffName.DataSource = ds.Tables["PmBorrow"];
            cbbStaffName.Text = "";

            //只显示让显示的
            strSql = "SELECT DISTINCT pmborrow.PhoneName FROM pmborrow,pmphone WHERE pmborrow.PhoneName = pmphone.PhoneName AND pmphone.PhoneDisplay = 'TRUE' ";                               //还样机名称combobox内容加载
            cmd = new MySqlCommand(strSql, conn);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneName.DisplayMember = "PhoneName";
            cbbPhoneName.ValueMember = "PhoneName";
            cbbPhoneName.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneName.Text = "";
                                             
            strSql = "select distinct HGroupName from PmGroup";                               //还员工小组名combobox内容加载
            cmd = new MySqlCommand(strSql, conn);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmGroup");
            conn.Close();
            cbbHGroupName.DisplayMember = "HGroupName";
            cbbHGroupName.ValueMember = "HGroupName";
            cbbHGroupName.DataSource = ds.Tables["PmGroup"];
            cbbHGroupName.Text = "";


            DataTable dt = new DataTable();                                                   //还样机状态IsNormal内容加载
            DataColumn dc1 = new DataColumn("text");
            DataColumn dc2 = new DataColumn("value");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr1 = dt.NewRow();
            dr1["text"] = "正常";
            dr1["value"] = "hello 正常";
            DataRow dr2 = dt.NewRow();
            dr2["text"] = "故障";
            dr2["value"] = "hello 故障";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);

            cbbIsNormal.DisplayMember = "text";
            cbbIsNormal.ValueMember = "value";
            cbbIsNormal.DataSource = dt;
            cbbIsNormal.Text = "";

        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            string strSql = "select * from PmBorrow where 1=1";
            string strSqlNum = "select * from PmPhone where 1 = 1";
            string strSqlNumOut = "select * from PmPhone where 1 = 1 and PhoneStatus = '借出'";
            string num = "";
            string numOut = "";

            txtNum.Text = "";
            txtNumOut.Text = "";

            if ( cbbStaffName.Text == "" && cbbPhoneName.Text == "" && cbbPhoneStage.Text == "" && cbbPhoneNum.Text == "" &&
                 cbbHGroupTest.Text == "" && cbbIsNormal.Text == "" && cbbIsReturn.Text == "" )
            {
                MessageBox.Show("请选择查询条件", "提示");
                return;
            }

            if (cbbStaffName.Text != "")
            {
                strSql = strSql + " and StaffName ='" + cbbStaffName.Text + "'";
            }
            if (cbbPhoneName.Text != "")
            {
                strSql = strSql + " and PhoneName ='" + cbbPhoneName.Text + "'";
            }
            if (cbbPhoneStage.Text != "")
            {
                strSql = strSql + " and PhoneStage ='" + cbbPhoneStage.Text + "'";
            }
            if (cbbPhoneNum.Text != "")
            {
                strSql = strSql + " and PhoneNum ='" + cbbPhoneNum.Text + "'";
            }
            if (cbbHGroupTest.Text != "")
            {
                strSql = strSql + " and Test ='" + cbbHGroupTest.Text + "'";
            }
            if (cbbIsNormal.Text != "")
            {
                strSql = strSql + " and IsNormal ='" + cbbIsNormal.Text + "'";
            }
            if (cbbIsReturn.Text != "")
            {
                strSql = strSql + " and IsReturn ='" + cbbIsReturn.Text + "'";
            }

            strSql = strSql + " order by BorrowID desc";

            BorrowBLL borrowbll = new BorrowBLL();
            borrows = borrowbll.selByCondition(strSql);
            borrowQDataGrid.DataSource = borrows;

            PhoneBLL phonebll = new PhoneBLL();
            

            if (cbbPhoneName.Text != "")
            {
                strSqlNum = strSqlNum + " and PhoneName ='" + cbbPhoneName.Text + "'";
                strSqlNumOut = strSqlNumOut + " and PhoneName ='" + cbbPhoneName.Text + "'";

                if (cbbPhoneStage.Text != "")
                {
                    strSqlNum = strSqlNum + " and PhoneStage ='" + cbbPhoneStage.Text + "'";
                    strSqlNumOut = strSqlNumOut + " and PhoneStage ='" + cbbPhoneStage.Text + "'";
                }

                num = phonebll.selByConditionNum(strSqlNum);
                numOut = phonebll.selByConditionNum(strSqlNumOut);
                txtNum.Text = num;
                txtNumOut.Text = numOut;
            }



        }


        private void cbbHGroupName_SelectedIndexChanged(object sender, EventArgs e)         //小组名字改变时，小组实验内容也会改变
        {
            //MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
            string strSql = "select HGroupTest from PmGroup where HGroupName = '" + cbbHGroupName.Text + "'";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmGroup");
            conn.Close();
            cbbHGroupTest.DisplayMember = "HGroupTest";
            cbbHGroupTest.ValueMember = "HGroupTest";
            cbbHGroupTest.DataSource = ds.Tables["PmGroup"];
            cbbHGroupTest.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void borrowQDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.borrowQDataGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.borrowQDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 10);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbbPhoneStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSql = "select distinct PhoneNum from pmborrow where PhoneStage= '" + cbbPhoneStage.Text + "'" + " and PhoneName ='" + cbbPhoneName.Text + "'";                                          //还样机编号cbb内容加载
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneNum.DisplayMember = "PhoneNum";
            cbbPhoneNum.ValueMember = "PhoneNum";
            cbbPhoneNum.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneNum.Text = "";
        }

        private void cbbPhoneName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSql = "select Distinct PhoneStage from pmborrow where PhoneName = '" + cbbPhoneName.Text + "'";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmbrwStage");
            conn.Close();
            cbbPhoneStage.DisplayMember = "PhoneStage";
            cbbPhoneStage.ValueMember = "PhoneStage";
            cbbPhoneStage.DataSource = ds.Tables["PmbrwStage"];
            cbbPhoneStage.Text = "";
        }

        //硬件测试组 未还样机按钮
        private void button1_Click(object sender, EventArgs e)
        {

            string strsqla = "select pmborrow.BorrowID, pmborrow.StaffName, pmborrow.PhoneName, pmborrow.PhoneStage, pmborrow.PhoneNum, pmborrow.BorrowDate,pmborrow.ReturnDate, pmborrow.IsReturn, pmborrow.Test, pmborrow.IsNormal, pmborrow.Remark, pmborrow.Operator";
            string strSqlb = " FROM pmstaff, pmborrow WHERE pmstaff.StaffCode='Y' AND pmborrow.StaffName=pmstaff.StaffName and pmborrow.isreturn='false'";
            string strSql = strsqla + strSqlb;


            if (cbbPhoneName.Text != "")
            {
                strSql = strSql + " and PhoneName ='" + cbbPhoneName.Text + "'";
                if (cbbPhoneStage.Text != "")
                {
                    strSql = strSql + " and PhoneStage ='" + cbbPhoneStage.Text + "'";
                }

                strSql = strSql + " order by BorrowID desc";
                BorrowBLL borrowbll = new BorrowBLL();
                borrows = borrowbll.selByCondition(strSql);
                borrowQDataGrid.DataSource = borrows;

            }
        }
    }
}

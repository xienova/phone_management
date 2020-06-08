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
using BLL;
using DAL;
using MySql.Data.MySqlClient;

namespace PhoneSystem
{
    public partial class UserBorrowInfoForm : Form
    {

        IList<BorrowInfo> borrows;                                                              //全局变量，在datagridview中会用到，现下的staff.
        MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
        string IPADRESS = "fe80::fd81:73ef:be0c:3fcc%12";                                        //设为可靠性电脑的IP地址即可;


        public UserBorrowInfoForm()
        {
            InitializeComponent();
        }

        private void BorrowInfoForm_Load(object sender, EventArgs e)            //加载窗体时执行操作
        {
            //string strSql = "select * from PmBorrow where StaffName = '" + LoginForm.usrName + "' order by BorrowID desc";
            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;


            //BorrowBLL borrowbll = new BorrowBLL();                              //DataGrid 内容加载
            //borrows = borrowbll.selByCondition(strSql);
            //borrowDataGrid.DataSource = borrows;

            BorrowBLL borrowbll = new BorrowBLL();                              //DataGrid 内容加载
            borrows = borrowbll.GetAllBorrow();
            borrowDataGrid.DataSource = borrows;

            borrowDataGrid.ReadOnly = true;
            borrowDataGrid.Width = Fuctions.dataGridViewWidth;
            borrowDataGrid.Height = Fuctions.dataGridViewHeight;
            borrowDataGrid.Location = new Point(Fuctions.dataGridViewLocationX, Fuctions.dataGridViewLocationY);

            borrowDataGrid.Columns[0].HeaderText = "主键";   //修改显示的列名
            borrowDataGrid.Columns[0].Visible = false;
            borrowDataGrid.Columns[1].HeaderText = "员工";
            borrowDataGrid.Columns[2].HeaderText = "名称";
            borrowDataGrid.Columns[3].HeaderText = "阶段";
            borrowDataGrid.Columns[4].HeaderText = "编号";
            borrowDataGrid.Columns[5].HeaderText = "借用日期";
            borrowDataGrid.Columns[6].HeaderText = "归还日期";
            borrowDataGrid.Columns[7].HeaderText = "是否归还";
            borrowDataGrid.Columns[7].Visible = false;
            borrowDataGrid.Columns[8].HeaderText = "试验项目";
            borrowDataGrid.Columns[9].HeaderText = "状态";
            borrowDataGrid.Columns[10].HeaderText = "备注";
            borrowDataGrid.Columns[11].HeaderText = "备用";
            borrowDataGrid.Columns[11].Visible = false;


            borrowDataGrid.Columns[1].Width = 50;
            borrowDataGrid.Columns[2].Width = 50;
            borrowDataGrid.Columns[3].Width = 80;
            borrowDataGrid.Columns[4].Width = 80;
            borrowDataGrid.Columns[5].Width = 120;
            borrowDataGrid.Columns[6].Width = 120;
            borrowDataGrid.Columns[8].Width = 120;
            borrowDataGrid.Columns[9].Width = 50;
            borrowDataGrid.Columns[10].Width = Fuctions.dataGridViewNote;

            Fuctions.AutoSize(borrowDataGrid);


            //借机相关内容加载**********************************************************
            string strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'"; //样机名称combobox内容加载
            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmPhone");

            cbbPhoneName.DisplayMember = "PhoneName";
            cbbPhoneName.ValueMember = "PhoneName";
            cbbPhoneName.DataSource = ds.Tables["PmPhone"];
            cbbPhoneName.Text = "";  
            conn.Close();

            //**********************************************************还机相关内容加载

            strSql = "select distinct PhoneName from PmBorrow where IsReturn = 'false' and StaffName = '" + LoginForm.usrName + "'";        //还样机名称combobox内容加载
            cmd = new MySqlCommand(strSql, conn);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneName1.DisplayMember = "PhoneName";
            cbbPhoneName1.ValueMember = "PhoneName";
            cbbPhoneName1.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneName1.Text = "";



            strSql = "select distinct HGroupName from PmGroup";                       //还员工小组名combobox内容加载--cbbHGroupTest
            cmd = new MySqlCommand(strSql, conn);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmGroup");
            conn.Close();
            cbbHGroupName1.DisplayMember = "HGroupName";
            cbbHGroupName1.ValueMember = "HGroupName";
            cbbHGroupName1.DataSource = ds.Tables["PmGroup"];
            cbbHGroupName1.Text = "";


            DataTable dt = new DataTable();                                           //还样机状态IsNormal内容加载
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

            cbbIsNormal1.DisplayMember = "text";
            cbbIsNormal1.ValueMember = "value";
            cbbIsNormal1.DataSource = dt;
            cbbIsNormal1.Text = "";

        }


        //借样机cbb更新
        private void cbbPhoneName_SelectedIndexChanged(object sender, EventArgs e)                      //借样机名称改变时,样机状态cbb自动更新
        {

            string strSql = "select distinct PhoneStage from PmPhone where PhoneStatus ='在库' and PhoneDisplay = 'TRUE' and PhoneName = '" + cbbPhoneName.Text + "'";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmPhone");
            conn.Close();
            cbbPhoneStage.DisplayMember = "PhoneStage";
            cbbPhoneStage.ValueMember = "PhoneStage";
            cbbPhoneStage.DataSource = ds.Tables["PmPhone"];
            cbbPhoneStage.Text = "";
        }

        private void cbbPhoneStage_SelectedIndexChanged(object sender, EventArgs e)                     //借样机状态名称更改时,样机编号cbb自动更新
        {

            string strSql = "select PhoneNum from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE' and PhoneName = '" + cbbPhoneName.Text + "' and PhoneStage = '" + cbbPhoneStage.Text + "' and StaffName = '" + LoginForm.usrName + "'" ;
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmPhone");
            conn.Close();
            cbbPhoneNum.DisplayMember = "PhoneNum";
            cbbPhoneNum.ValueMember = "PhoneNum";
            cbbPhoneNum.DataSource = ds.Tables["PmPhone"];
            cbbPhoneNum.Text = "";

            cbbPhoneNumL1.DisplayMember = "PhoneNum";
            cbbPhoneNumL1.ValueMember = "PhoneNum";
            cbbPhoneNumL1.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNumL1.Text = "";

            cbbPhoneNumL2.DisplayMember = "PhoneNum";
            cbbPhoneNumL2.ValueMember = "PhoneNum";
            cbbPhoneNumL2.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNumL2.Text = "";

            cbbPhoneNumL3.DisplayMember = "PhoneNum";
            cbbPhoneNumL3.ValueMember = "PhoneNum";
            cbbPhoneNumL3.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNumL3.Text = "";

            cbbPhoneNumL4.DisplayMember = "PhoneNum";
            cbbPhoneNumL4.ValueMember = "PhoneNum";
            cbbPhoneNumL4.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNumL4.Text = "";

        }


        //还样机cbb更新

        //private void cbbStaffName1_SelectedIndexChanged(object sender, EventArgs e)                //还样机员工姓名改变时，样机名称自动更新
        //{
        //    MySqlConnection conn = new MySqlConnection(GetConn.connection);

        //    string strSql = "select distinct PhoneName from PmBorrow where IsReturn = 'false' and StaffName = '" + cbbStaffName1.Text + "'";                               //还样机名称combobox内容加载
        //    MySqlCommand cmd = new MySqlCommand(strSql, conn);

        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    conn.Open();
        //    da.Fill(ds, "PmBorrow");
        //    conn.Close();
        //    cbbPhoneName1.DisplayMember = "PhoneName";
        //    cbbPhoneName1.ValueMember = "PhoneName";
        //    cbbPhoneName1.DataSource = ds.Tables["PmBorrow"];
        //    cbbPhoneName1.Text = "";
        //}


        private void cbbPhoneName1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string strSql = "select distinct PhoneStage from PmBorrow where IsReturn = 'false' and PhoneName = '" + cbbPhoneName1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneStage1.DisplayMember = "PhoneStage";
            cbbPhoneStage1.ValueMember = "PhoneStage";
            cbbPhoneStage1.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneStage1.Text = "";
        }

        private void cbbPhoneStage1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string strSql = "select PhoneNum from PmBorrow where IsReturn = 'false' and PhoneName = '" + cbbPhoneName1.Text + "'and PhoneStage = '" + cbbPhoneStage1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneNum1.DisplayMember = "PhoneNum";
            cbbPhoneNum1.ValueMember = "PhoneNum";
            cbbPhoneNum1.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneNum1.Text = "";
        }

        private void cbbHGroupName1_SelectedIndexChanged(object sender, EventArgs e)                            //样机小组在 PmGroup中更新时,自动更新HGroupTest cbb.
        {
            string strSql = "select HGroupTest from PmGroup where HGroupName = '" + cbbHGroupName1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmGroup");
            conn.Close();
            cbbHGroupTest1.DisplayMember = "HGroupTest";
            cbbHGroupTest1.ValueMember = "HGroupTest";
            cbbHGroupTest1.DataSource = ds.Tables["PmGroup"];
            cbbHGroupTest1.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)                                   //借样机按钮
        {

            string ip = Fuctions.GetIpAddress();

            if (LoginForm.admin == 0)
            {
                if (ip != IPADRESS)
                {
                    MessageBox.Show("请去指定电脑进行样机借阅","提示");
                    return;
                }
            }

            BorrowBLL borrowbll = new BorrowBLL();
            PhoneBLL phonebll = new PhoneBLL();

            if (cbbPhoneName.Text == "" || cbbPhoneStage.Text == "" || cbbPhoneNum.Text == "")
            {
                MessageBox.Show("请输入所有信息");
                return;
            }
            else
            {
                if (cbbPhoneNum.Text != "")
                {
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum.Text))
                    {
                        //MessageBox.Show("借阅成功");
                    }
                    if (phonebll.updatePhoneStatusOut(cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum.Text))                            //更新数据库 PmPhone 中的信息
                    {
                        //MessageBox.Show("借阅成功");
                    }
                }

                if (cbbPhoneNumL1.Text != "")
                {
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL1.Text))
                    {
                        //MessageBox.Show("借阅成功");
                    }
                    if (phonebll.updatePhoneStatusOut(cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNumL1.Text))                            //更新数据库 PmPhone 中的信息
                    {
                        //MessageBox.Show("借阅成功");
                    }

                }

                if (cbbPhoneNumL2.Text != "")
                {
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL2.Text))
                    {
                        //MessageBox.Show("借阅成功");
                    }
                    if (phonebll.updatePhoneStatusOut(cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNumL2.Text))                            //更新数据库 PmPhone 中的信息
                    {
                        //MessageBox.Show("借阅成功");
                    }
                }

                if (cbbPhoneNumL3.Text != "")
                {
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL3.Text))
                    {
                        //MessageBox.Show("借阅成功");
                    }
                    if (phonebll.updatePhoneStatusOut(cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNumL3.Text))                            //更新数据库 PmPhone 中的信息
                    {
                        //MessageBox.Show("借阅成功");
                    }
                }

                if (cbbPhoneNumL4.Text != "")
                {
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL4.Text))
                    {
                        //MessageBox.Show("借阅成功");
                    }
                    if (phonebll.updatePhoneStatusOut(cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNumL4.Text))                            //更新数据库 PmPhone 中的信息
                    {
                        //MessageBox.Show("借阅成功");
                    }
                }

                MessageBox.Show("借阅成功");

            }

            borrows = borrowbll.GetAllBorrow();                                                 //DataGridView显示所借样机
            borrowDataGrid.DataSource = borrows;

            //借机相关内容更新**********************************************************
            string strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库'and PhoneDisplay = 'TRUE'";  //更新借样机cbb中样机信息  
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmPhone");
            conn.Close();
            cbbPhoneName.DisplayMember = "PhoneName";
            cbbPhoneName.ValueMember = "PhoneName";
            cbbPhoneName.DataSource = ds.Tables["PmPhone"];
            cbbPhoneName.Text = "";

            //还机相关内容更新**********************************************************
            strSql = "select distinct PhoneName from PmBorrow where IsReturn = 'false' and StaffName = '" + LoginForm.usrName + "'";        //还样机名称combobox内容加载
            cmd = new MySqlCommand(strSql, conn);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneName1.DisplayMember = "PhoneName";
            cbbPhoneName1.ValueMember = "PhoneName";
            cbbPhoneName1.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneName1.Text = "";



        }



        private void btnReturn_Click(object sender, EventArgs e)                                    //还样机按钮
        {

            string ip = Fuctions.GetIpAddress();

            if (LoginForm.admin == 0)
            {
                if (ip != IPADRESS)
                {
                    MessageBox.Show("请去指定电脑进行样机借阅");
                    return;
                }
            }

            BorrowBLL borrowbll = new BorrowBLL();
            PhoneBLL phonebll = new PhoneBLL();

            if (cbbPhoneName1.Text == "" || cbbPhoneStage1.Text == "" || cbbPhoneNum1.Text == "" || cbbHGroupName1.Text == "" || cbbHGroupTest1.Text == "" || cbbIsNormal1.Text == "")
            {
                MessageBox.Show("请输入除备注以外的所有信息","提示");
                return;
            }
            else if (cbbIsNormal1.Text == "故障" && txtRemark.Text == "")
            {
                MessageBox.Show("样机故障，请输入故障信息","提示");
                return;
            }
            else
            {
                if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum1.Text, cbbHGroupTest1.Text, cbbIsNormal1.Text, txtRemark.Text))
                {
                    MessageBox.Show("样机归还成功","提示");
                }
                if (phonebll.updatePhoneStatusIn(cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum1.Text))
                {
                    MessageBox.Show("样机状态更新成功","提示");
                }
                else
                {
                    MessageBox.Show("样机状态未成功更新,请检查信息是否输入正确","提示");
                }
            }

            borrows = borrowbll.GetAllBorrow();
            borrowDataGrid.DataSource = borrows;


            //借机相关内容更新**********************************************************
            string strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'";                //更新样机cbb信息  
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmPhone");
            conn.Close();
            cbbPhoneName.DisplayMember = "PhoneName";
            cbbPhoneName.ValueMember = "PhoneName";
            cbbPhoneName.DataSource = ds.Tables["PmPhone"];
            cbbPhoneName.Text = "";

            //**********************************************************还机相关内容更新

            strSql = "select distinct PhoneName from PmBorrow where IsReturn = 'false' and StaffName = '" + LoginForm.usrName + "'";        //还样机名称combobox内容加载
            cmd = new MySqlCommand(strSql, conn);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneName1.DisplayMember = "PhoneName";
            cbbPhoneName1.ValueMember = "PhoneName";
            cbbPhoneName1.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneName1.Text = "";


            cbbHGroupName1.Text = "";                                                              //--其余的清空
            cbbHGroupTest1.Text = "";
            cbbIsNormal1.Text = "";
            txtRemark.Text = "";

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            cbbPhoneName.DataSource = null;
            cbbPhoneStage.DataSource = null;
            cbbPhoneNum.DataSource = null;
            this.Dispose();
        }

        private void borrowDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.borrowDataGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.borrowDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 10);
        }















    }
}

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
    public partial class AdminBorrowInfoForm : Form
    {

        IList<BorrowInfo> borrows;                                                              //全局变量，在datagridview中会用到，现下的staff.
        IList<StaffInfo> staffs;
        MySqlConnection conn = new MySqlConnection(GetConn.connection);     //连接对象

        //string IPADRESS = "fe80::5ac:9b5d:b2de:a747%11";                    //王鹏 与 张辉 电脑IP
        //string IPADDRESS1 = "fe80::a8db:228f:f55:4fd%10";
        //string IPADRESS2 = "fe80::fd81:73ef:be0c:3fcc%12";                                        //解春辉 电脑IP


        string IPADRESS = "10.16.99.22";
        string IPADDRESS1 = "10.16.99.73";
        string IPADRESS2 = "10.16.99.94";
        string IPADRESS3 = "10.18.98.240";


        public AdminBorrowInfoForm()
        {
            InitializeComponent();
        }

        private void BorrowInfoForm_Load(object sender, EventArgs e)            //加载窗体时执行操作
        {

            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;


            BorrowBLL borrowbll = new BorrowBLL();                              //DataGrid 内容加载
            borrows = borrowbll.GetAllBorrow();
            borrowDataGrid.DataSource = borrows;

            borrowDataGrid.ReadOnly = true;
            borrowDataGrid.Width = Fuctions.dataGridViewWidth;
            borrowDataGrid.Height = 335;
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
            borrowDataGrid.Columns[11].HeaderText = "操作人";

            borrowDataGrid.Columns[1].Width = 50;
            borrowDataGrid.Columns[2].Width = Fuctions.dataGridViewPhoneName;
            borrowDataGrid.Columns[3].Width = 80;
            borrowDataGrid.Columns[4].Width = Fuctions.dataGridViewPhoneNum; ;
            borrowDataGrid.Columns[5].Width = 120;
            borrowDataGrid.Columns[6].Width = 120;
            borrowDataGrid.Columns[8].Width = Fuctions.dataGridViewTest; 
            borrowDataGrid.Columns[9].Width = 50;
            borrowDataGrid.Columns[10].Width = Fuctions.dataGridViewNote;
            borrowDataGrid.Columns[11].Width = 50;

            Fuctions.AutoSize(borrowDataGrid);

            //**********************************************************借机相关内容加载
            StaffBLL staffbll = new StaffBLL();                                              //员工姓名combobox内容加载
            staffs = staffbll.getAllStaff();
            cbbStaffName.DisplayMember = "StaffName";
            cbbStaffName.ValueMember = "StaffName";
            cbbStaffName.DataSource = staffs;
            cbbStaffName.Text = "";

            string strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'"; //样机名称combobox内容加载
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


            //**********************************************************还机相关内容加载
            strSql = "select distinct StaffName from PmBorrow where IsReturn='false' order by convert(StaffName USING gbk) asc";                      //还员工姓名combobox内容加载--cbbPhoneName1--cbbPhoneStage1--cbbPhoneNum1
            cmd = new MySqlCommand(strSql, conn);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbStaffName1.DisplayMember = "StaffName";
            cbbStaffName1.ValueMember = "StaffName";
            cbbStaffName1.DataSource = ds.Tables["PmBorrow"];
            cbbStaffName1.Text = "";  


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

            cbbIsNormal2.DisplayMember = "text";
            cbbIsNormal2.ValueMember = "value";
            cbbIsNormal2.DataSource = dt.Copy();
            cbbIsNormal2.Text = "";

            cbbIsNormal3.DisplayMember = "text";
            cbbIsNormal3.ValueMember = "value";
            cbbIsNormal3.DataSource = dt.Copy();
            cbbIsNormal3.Text = "";

            cbbIsNormal4.DisplayMember = "text";
            cbbIsNormal4.ValueMember = "value";
            cbbIsNormal4.DataSource = dt.Copy();
            cbbIsNormal4.Text = "";

            cbbIsNormal5.DisplayMember = "text";
            cbbIsNormal5.ValueMember = "value";
            cbbIsNormal5.DataSource = dt.Copy();
            cbbIsNormal5.Text = "";

        }


        //借样机cbb更新
        private void cbbPhoneName_SelectedIndexChanged(object sender, EventArgs e)                      //借样机名称改变时,样机状态cbb自动更新
        {
//            MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
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
            //MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
            string strSql = "select PhoneNum from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'and PhoneName = '" + cbbPhoneName.Text + "' and PhoneStage = '" + cbbPhoneStage.Text + "'";
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

        private void cbbStaffName1_SelectedIndexChanged(object sender, EventArgs e)                //还样机员工姓名改变时，样机名称自动更新
        {
            //MySqlConnection conn = new MySqlConnection(GetConn.connection);

            string strSql = "select distinct PhoneName from PmBorrow where IsReturn = 'false' and StaffName = '" + cbbStaffName1.Text + "'";                               //还样机名称combobox内容加载
            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbPhoneName1.DisplayMember = "PhoneName";
            cbbPhoneName1.ValueMember = "PhoneName";
            cbbPhoneName1.DataSource = ds.Tables["PmBorrow"];
            cbbPhoneName1.Text = "";
        }

        private void cbbPhoneName1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
            string strSql = "select distinct PhoneStage from PmBorrow where IsReturn = 'false' and PhoneName = '" + cbbPhoneName1.Text + "' and StaffName = '" + cbbStaffName1.Text + "'";
            //string strSql = "select distinct PhoneStage from PmBorrow where PhoneName = '" + cbbPhoneName1.Text + "'";
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

        private void cbbPhoneStage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
            string strSql = "select distinct PhoneNum from PmBorrow where IsReturn = 'false' and PhoneName = '" + cbbPhoneName1.Text + "'and PhoneStage = '" + cbbPhoneStage1.Text + "' and StaffName = '" + cbbStaffName1.Text + "'";
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

            cbbPhoneNum2.DisplayMember = "PhoneNum";
            cbbPhoneNum2.ValueMember = "PhoneNum";
            cbbPhoneNum2.DataSource = ds.Tables["PmBorrow"].Copy();
            cbbPhoneNum2.Text = "";

            cbbPhoneNum3.DisplayMember = "PhoneNum";
            cbbPhoneNum3.ValueMember = "PhoneNum";
            cbbPhoneNum3.DataSource = ds.Tables["PmBorrow"].Copy();
            cbbPhoneNum3.Text = "";

            cbbPhoneNum4.DisplayMember = "PhoneNum";
            cbbPhoneNum4.ValueMember = "PhoneNum";
            cbbPhoneNum4.DataSource = ds.Tables["PmBorrow"].Copy();
            cbbPhoneNum4.Text = "";

            cbbPhoneNum5.DisplayMember = "PhoneNum";
            cbbPhoneNum5.ValueMember = "PhoneNum";
            cbbPhoneNum5.DataSource = ds.Tables["PmBorrow"].Copy();
            cbbPhoneNum5.Text = "";
        }


        private void cbbHGroupName1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
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
                if (ip != IPADRESS && ip != IPADDRESS1 && ip != IPADRESS2 && ip != IPADRESS3)
                {
                    MessageBox.Show("请去指定电脑进行样机借阅","提示");
                    return;
                }
            }


            //MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
            BorrowBLL borrowbll = new BorrowBLL();
            PhoneBLL phonebll = new PhoneBLL();

            if (cbbStaffName.Text == "" || cbbPhoneName.Text == "" || cbbPhoneStage.Text == "" || ((cbbPhoneNum.Text == "") && (cbbPhoneNumL1.Text == "") && (cbbPhoneNumL2.Text == "") && (cbbPhoneNumL3.Text == "") && (cbbPhoneNumL4.Text == "")))
            {
                MessageBox.Show("请输入样机信息");
                return;
            }
            else
            {

                if (cbbPhoneNum.Text != "")
                {
                    if (cbbPhoneNum.Text == cbbPhoneNumL1.Text || cbbPhoneNum.Text == cbbPhoneNumL2.Text || cbbPhoneNum.Text == cbbPhoneNumL3.Text || cbbPhoneNum.Text == cbbPhoneNumL4.Text)
                    {
                        MessageBox.Show("借阅样机编号重复，请检查编号");
                        return;
                    }


                    if (borrowbll.addBorrow(this.cbbStaffName.Text, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum.Text, LoginForm.usrName))
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

                    if (cbbPhoneNumL1.Text == cbbPhoneNum.Text || cbbPhoneNumL1.Text == cbbPhoneNumL2.Text || cbbPhoneNumL1.Text == cbbPhoneNumL3.Text || cbbPhoneNumL1.Text == cbbPhoneNumL4.Text)
                    {
                        MessageBox.Show("借阅样机编号重复，请检查编号");
                        return;
                    }

                    if (borrowbll.addBorrow(this.cbbStaffName.Text, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL1.Text, LoginForm.usrName))
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
                    if (cbbPhoneNumL2.Text == cbbPhoneNum.Text || cbbPhoneNumL2.Text == cbbPhoneNumL1.Text || cbbPhoneNumL2.Text == cbbPhoneNumL3.Text || cbbPhoneNumL2.Text == cbbPhoneNumL4.Text)
                    {
                        MessageBox.Show("借阅样机编号重复，请检查编号");
                        return;
                    }

                    if (borrowbll.addBorrow(this.cbbStaffName.Text, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL2.Text, LoginForm.usrName))
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
                    if (cbbPhoneNumL3.Text == cbbPhoneNum.Text || cbbPhoneNumL3.Text == cbbPhoneNumL1.Text || cbbPhoneNumL3.Text == cbbPhoneNumL2.Text || cbbPhoneNumL3.Text == cbbPhoneNumL4.Text)
                    {
                        MessageBox.Show("借阅样机编号重复，请检查编号");
                        return;
                    }


                    if (borrowbll.addBorrow(this.cbbStaffName.Text, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL3.Text, LoginForm.usrName))
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

                    if (cbbPhoneNumL4.Text == cbbPhoneNum.Text || cbbPhoneNumL4.Text == cbbPhoneNumL1.Text || cbbPhoneNumL4.Text == cbbPhoneNumL2.Text || cbbPhoneNumL4.Text == cbbPhoneNumL3.Text)
                    {
                        MessageBox.Show("借阅样机编号重复，请检查编号");
                        return;
                    }

                    if (borrowbll.addBorrow(this.cbbStaffName.Text, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL4.Text, LoginForm.usrName))
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

            //**************************************************借样机相关内容更新
            string strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'";  //更新cbb中样机信息  
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

            //**************************************************还样机相关内容更新
            //strSql = "select distinct StaffName from PmStaff";                      //还员工姓名combobox内容加载--cbbPhoneName1--cbbPhoneStage1--cbbPhoneNum1
            strSql = "select distinct StaffName from PmBorrow where IsReturn='false' order by convert(StaffName USING gbk) asc"; 

            cmd = new MySqlCommand(strSql, conn);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmStaff");
            conn.Close();
            cbbStaffName1.DisplayMember = "StaffName";
            cbbStaffName1.ValueMember = "StaffName";
            cbbStaffName1.DataSource = ds.Tables["PmStaff"];
            cbbStaffName1.Text = "";  
        }


        private void btnReturn_Click(object sender, EventArgs e)                                    //还样机按钮
        {

            string ip = Fuctions.GetIpAddress();

            if (LoginForm.admin == 0)
            {
                if (ip != IPADRESS && ip != IPADDRESS1 && ip != IPADRESS2)
                {
                    MessageBox.Show("请去指定电脑进行样机借阅");
                    return;
                }
            }

            //MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
            BorrowBLL borrowbll = new BorrowBLL();
            PhoneBLL phonebll = new PhoneBLL();

            // 若是第一行的五个中有一个为空，则给出提示
            if (cbbStaffName1.Text =="" || cbbPhoneName1.Text == "" || cbbPhoneStage1.Text == "" || cbbHGroupName1.Text == "" || cbbHGroupTest1.Text == "")
            {
                MessageBox.Show("请输入除备注以外的所有信息", "提示");
                return;
            }

            //若是五行中的 样机编号没有选，给出提示
            if (cbbPhoneNum1.Text == "" && cbbPhoneNum2.Text == "" && cbbPhoneNum3.Text == "" && cbbPhoneNum4.Text == "" && cbbPhoneNum5.Text == "")
            {
                MessageBox.Show("请输入归还的样机编号");
            }

            //样机归还时第一行的信息是否完整
            if (cbbPhoneNum1.Text != "")
            {
                if (cbbPhoneNum1.Text == cbbPhoneNum2.Text || cbbPhoneNum1.Text == cbbPhoneNum3.Text || cbbPhoneNum1.Text == cbbPhoneNum4.Text || cbbPhoneNum1.Text == cbbPhoneNum5.Text)
                {
                    MessageBox.Show("归还样机编号重复，请检查编号");
                    return;
                }

                if (cbbIsNormal1.Text == "")
                {
                    MessageBox.Show("请输入样机状态");
                    return;
                }

                if (cbbIsNormal1.Text == "故障" && txtRemark1.Text == "")
                {
                    MessageBox.Show("样机故障，请输入故障信息", "提示");
                    return;
                }
                else
                {
                    if (borrowbll.returnPhone(cbbStaffName1.Text, cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum1.Text, cbbHGroupTest1.Text, cbbIsNormal1.Text, txtRemark1.Text)
                        && phonebll.updatePhoneStatusIn(cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum1.Text))
                    {
                        // MessageBox.Show("样机归还成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show("样机状态未成功更新,请检查信息是否输入正确", "提示");
                    }

                }
            }

            //样机归还时第二行的信息是否完整
            if (cbbPhoneNum2.Text != "")
            {
                if (cbbPhoneNum2.Text == cbbPhoneNum1.Text || cbbPhoneNum2.Text == cbbPhoneNum3.Text || cbbPhoneNum2.Text == cbbPhoneNum4.Text || cbbPhoneNum2.Text == cbbPhoneNum5.Text)
                {
                    MessageBox.Show("归还样机编号重复，请检查编号");
                    return;
                }

                if (cbbIsNormal2.Text == "")
                {
                    MessageBox.Show("请输入样机状态");
                    return;
                }

                if (cbbIsNormal2.Text == "故障" && txtRemark2.Text == "")
                {
                    MessageBox.Show("样机故障，请输入故障信息", "提示");
                    return;
                }
                else
                {
                    if (borrowbll.returnPhone(cbbStaffName1.Text, cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum2.Text, cbbHGroupTest1.Text, cbbIsNormal2.Text, txtRemark2.Text)
                        && phonebll.updatePhoneStatusIn(cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum2.Text))
                    {
                        // MessageBox.Show("样机归还成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show("样机状态未成功更新,请检查信息是否输入正确", "提示");
                    }

                }
            }

            //样机归还时第三行的信息是否完整
            if (cbbPhoneNum3.Text != "")
            {
                if (cbbPhoneNum3.Text == cbbPhoneNum1.Text || cbbPhoneNum3.Text == cbbPhoneNum2.Text || cbbPhoneNum3.Text == cbbPhoneNum4.Text || cbbPhoneNum3.Text == cbbPhoneNum5.Text)
                {
                    MessageBox.Show("归还样机编号重复，请检查编号");
                    return;
                }

                if (cbbIsNormal3.Text == "")
                {
                    MessageBox.Show("请输入样机状态");
                    return;
                }

                if (cbbIsNormal3.Text == "故障" && txtRemark3.Text == "")
                {
                    MessageBox.Show("样机故障，请输入故障信息", "提示");
                    return;
                }
                else
                {
                    if (borrowbll.returnPhone(cbbStaffName1.Text, cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum3.Text, cbbHGroupTest1.Text, cbbIsNormal3.Text, txtRemark3.Text)
                        && phonebll.updatePhoneStatusIn(cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum3.Text))
                    {
                        //MessageBox.Show("样机归还成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show("样机状态未成功更新,请检查信息是否输入正确", "提示");
                    }

                }
            }

            //样机归还时第四行的信息是否完整
            if (cbbPhoneNum4.Text != "")
            {
                if (cbbPhoneNum4.Text == cbbPhoneNum1.Text || cbbPhoneNum4.Text == cbbPhoneNum2.Text || cbbPhoneNum4.Text == cbbPhoneNum3.Text || cbbPhoneNum4.Text == cbbPhoneNum5.Text)
                {
                    MessageBox.Show("归还样机编号重复，请检查编号");
                    return;
                }

                if (cbbIsNormal4.Text == "")
                {
                    MessageBox.Show("请输入样机状态");
                    return;
                }

                if (cbbIsNormal4.Text == "故障" && txtRemark4.Text == "")
                {
                    MessageBox.Show("样机故障，请输入故障信息", "提示");
                    return;
                }
                else
                {
                    if (borrowbll.returnPhone(cbbStaffName1.Text, cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum4.Text, cbbHGroupTest1.Text, cbbIsNormal4.Text, txtRemark4.Text)
                        && phonebll.updatePhoneStatusIn(cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum4.Text))
                    {
                        //MessageBox.Show("样机归还成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show("样机状态未成功更新,请检查信息是否输入正确", "提示");
                    }

                }
            }


            //样机归还时第五行的信息是否完整
            if (cbbPhoneNum5.Text != "")
            {
                if (cbbPhoneNum5.Text == cbbPhoneNum1.Text || cbbPhoneNum5.Text == cbbPhoneNum2.Text || cbbPhoneNum5.Text == cbbPhoneNum3.Text || cbbPhoneNum5.Text == cbbPhoneNum4.Text)
                {
                    MessageBox.Show("归还样机编号重复，请检查编号");
                    return;
                }

                if (cbbIsNormal5.Text == "")
                {
                    MessageBox.Show("请输入样机状态");
                    return;
                }

                if (cbbIsNormal5.Text == "故障" && txtRemark5.Text == "")
                {
                    MessageBox.Show("样机故障，请输入故障信息", "提示");
                    return;
                }
                else
                {
                    if (borrowbll.returnPhone(cbbStaffName1.Text, cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum5.Text, cbbHGroupTest1.Text, cbbIsNormal5.Text, txtRemark5.Text)
                        && phonebll.updatePhoneStatusIn(cbbPhoneName1.Text, cbbPhoneStage1.Text, cbbPhoneNum5.Text))
                    {
                        //MessageBox.Show("样机归还成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show("样机状态未成功更新,请检查信息是否输入正确", "提示");
                    }

                }
            }

            borrows = borrowbll.GetAllBorrow();
            borrowDataGrid.DataSource = borrows;


            //**********************************************************借机相关内容更新
            string strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'";  //更新cbb中样机信息  
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
            //strSql = "select distinct StaffName from PmBorrow";                               //--还员工姓名combobox内容更新
            strSql = "select distinct StaffName from PmBorrow where IsReturn='false' order by convert(StaffName USING gbk) asc"; 
            cmd = new MySqlCommand(strSql, conn);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmBorrow");
            conn.Close();
            cbbStaffName1.DisplayMember = "StaffName";
            cbbStaffName1.ValueMember = "StaffName";
            cbbStaffName1.DataSource = ds.Tables["PmBorrow"];
            cbbStaffName1.Text = "";

            //cbbHGroupName1.Text = "";                                                              //--其余的清空
            //cbbHGroupTest1.Text = "";
            cbbIsNormal1.Text = "";
            txtRemark1.Text = "";

            cbbIsNormal2.Text = "";
            txtRemark2.Text = "";

            cbbIsNormal3.Text = "";
            txtRemark3.Text = "";

            cbbIsNormal4.Text = "";
            txtRemark4.Text = "";

            cbbIsNormal5.Text = "";
            txtRemark5.Text = "";

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            cbbStaffName.DataSource = null;
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

        private void cbbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





















    }
}

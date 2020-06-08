using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;  //sql server使用

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
        //IList<StaffInfo> staffs;
        MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
        //string IPADRESS2 = "fe80::fd81:73ef:be0c:3fcc%12";                                        //我的电脑的IP地址;
        //string IPADRESS = "fe80::e51c:aa02:2b49:af21%11";
        //string IPADDRESS1 = "fe80::a8db:228f:f55:4fd%10";

        string IPADRESS = "10.16.99.22";    //张辉IP
        string IPADDRESS1 = "10.16.99.73";  //王鹏IP
        string IPADRESS2 = "10.16.99.94";   //me
        string IPADRESS3 = "10.18.98.240";   //lab室


        //sql server 连接
        SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象 无线库 数据库使用
        SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);       //有线库 数据库使用



        public UserBorrowInfoForm()
        {
            InitializeComponent();
        }

        private void BorrowInfoForm_Load(object sender, EventArgs e)            //加载窗体时执行操作
        {


            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;

            string strSql = "select * from PmBorrow where StaffName = '" + LoginForm.usrName + "' and IsReturn = 'false' order by BorrowID DESC"; //样机名称combobox内容加载
            BorrowBLL borrowbll = new BorrowBLL();                              //DataGrid 内容加载
            borrows = borrowbll.selByCondition(strSql);
            borrowDataGrid.DataSource = borrows;


            borrowDataGrid.ReadOnly = true;
            borrowDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            borrowDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            borrowDataGrid.Width = Fuctions.dataGridViewWidth;
            //borrowDataGrid.Height = 300;
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


            //借机相关内容加载**********************************************************
            strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'"; //样机名称combobox内容加载
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
           

            
        }


        //借样机cbb更新
        private void cbbPhoneName_SelectedIndexChanged(object sender, EventArgs e)                      //借样机名称改变时,样机状态cbb自动更新
        {

            string strSql = "select distinct PhoneStage from PmPhone where PhoneStatus ='在库' and PhoneDisplay = 'TRUE'and PhoneName = '" + cbbPhoneName.Text + "'";
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
            //cbbPhoneNum.SelectedIndex = -1;

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


        private void button1_Click(object sender, EventArgs e)                                   //借样机按钮
        {

            string ip = Fuctions.GetIpAddress();

            //if (LoginForm.admin == 0)
            //{
            //    if (ip != IPADRESS && ip != IPADDRESS1 && ip != IPADRESS2 && ip != IPADRESS3)
            //    {
            //        MessageBox.Show("请去指定电脑进行样机借阅","提示");
            //        return;
            //    }
            //}

            BorrowBLL borrowbll = new BorrowBLL();
            PhoneBLL phonebll = new PhoneBLL();

            if (cbbPhoneName.Text == "" || cbbPhoneStage.Text == "" || ((cbbPhoneNum.Text == "")&&(cbbPhoneNumL1.Text == "")&&(cbbPhoneNumL2.Text == "")&&(cbbPhoneNumL3.Text == "")&&(cbbPhoneNumL4.Text == "")))
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

                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum.Text,LoginForm.usrName))
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
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL1.Text,LoginForm.usrName))
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

                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL2.Text, LoginForm.usrName))
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
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL3.Text, LoginForm.usrName))
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
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNumL4.Text, LoginForm.usrName))
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


            string strSql = "select * from PmBorrow where StaffName = '" + LoginForm.usrName + "' and IsReturn = 'false' order by BorrowID DESC"; //样机名称combobox内容加载
            borrows = borrowbll.selByCondition(strSql);                 //DataGrid 内容加载
            borrowDataGrid.DataSource = borrows;

            //借机相关内容更新**********************************************************
            strSql = "select distinct PhoneName from PmPhone where PhoneStatus = '在库'and PhoneDisplay = 'TRUE'";  //更新借样机cbb中样机信息  
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

        private void cbbPhoneNum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        #region read string操作模板
        /// <summary>
        /// 获取一个 字符串
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public string getString(string strSql)
        {
            string StringOut = "";
            MySqlDataReader dr = null;
            try
            {
                conn.Open();
                //新建mysql命令
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //每读一次,将读到的信息整合成tcpInfo类
                    StringOut = dr.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();
            }
            return StringOut;
        }

        #endregion

        private void cbbPhoneNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //string try1;
            //string phoneName;
            //string phoneStage;
            //string phoneNum;


            //phoneName = this.cbbPhoneName.Text;
            //phoneStage = this.cbbPhoneStage.Text;
            //phoneNum = this.cbbPhoneNum.Text;

            //string sqlstr = "select PhoneID from pmphone where PhoneName = '" + phoneName + "' and PhoneStage='" + phoneStage + "' and PhoneNum = '" + phoneNum + "'";
            //try1 = getString(sqlstr);

            //MessageBox.Show(try1);
        }

        private void cbbPhoneNum_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //string try1;
            //string phoneName;
            //string phoneStage;
            //string phoneNum;


            //phoneName = this.cbbPhoneName.Text;
            //phoneStage = this.cbbPhoneStage.Text;
            //phoneNum = this.cbbPhoneNum.Text;

            ////查询样机的 PHONEID，这是在mysql数据库中进行的查询
            //string sqlstr = "select PhoneCode from pmphone where PhoneName = '" + phoneName + "' and PhoneStage='" + phoneStage + "' and PhoneNum = '" + phoneNum + "'";
            //try1 = getString(sqlstr);
            //if (try1 == "")
            //{
            //    //当Phoneid为空时，设为一个不可以被查到的Phoneid
            //    try1 = "xiechunhui";
            //}

            ////以下是在sql server数据库中进行查询

            //SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            //SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);


            ////测试用 sql server数据库 通过datatable获取数据;数据库为 无线功检工位
            //string strSqlTest = "SELECT [dbo].[ESNRecord].PhoneId,[dbo].[ESNRECORD].IMEI,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
            //    + "'" + try1 + "'"; //样机名称combobox内容加载
            //SqlCommand cmdTest = new SqlCommand(strSqlTest, connSql);

            //SqlDataAdapter daTest = new SqlDataAdapter(cmdTest);
            //DataSet dsTry = new DataSet();
            ////当不能访问产线数据库时，在此弹出
            //try
            //{
            //    connSql.Open();
            //    daTest.Fill(dsTry, "TestReport");
            //    connSql.Close();

            //    TestDataGrid.DataSource = dsTry.Tables["TestReport"];
            //    TestDataGrid.Columns[3].Width = 50;
            //    TestDataGrid.Columns[4].Width = 300;
            //    TestDataGrid.Columns[5].Width = 250;
            //    TestDataGrid.Columns[6].Width = 300;

            //    //制动精工 sql server数据库
            //    string strSqlConduct = "SELECT [dbo].[TestReport].PhoneId,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[TestReport] where [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdConduct = new SqlCommand(strSqlConduct, connSqlConduct);

            //    SqlDataAdapter daConduct = new SqlDataAdapter(cmdConduct);
            //    //DataSet dsTry = new DataSet();
            //    connSqlConduct.Open();
            //    daConduct.Fill(dsTry, "Conduct");
            //    connSqlConduct.Close();

            //    ESNDataGrid.DataSource = dsTry.Tables["Conduct"];
            //    ESNDataGrid.Columns[2].Width = 50;
            //    ESNDataGrid.Columns[3].Width = 300;
            //    ESNDataGrid.Columns[4].Width = 250;
            //    ESNDataGrid.Columns[5].Width = 300;

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}

            //finally
            //{
            //    connSql.Close();
            //}

        }

        private void cbbPhoneNumL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string try1;
            //string phoneName;
            //string phoneStage;
            //string phoneNum;


            //phoneName = this.cbbPhoneName.Text;
            //phoneStage = this.cbbPhoneStage.Text;
            //phoneNum = this.cbbPhoneNumL1.Text;

            //string sqlstr = "select PhoneCode from pmphone where PhoneName = '" + phoneName + "' and PhoneStage='" + phoneStage + "' and PhoneNum = '" + phoneNum + "'";
            //try1 = getString(sqlstr);

            //if (try1 == "")
            //{
            //    //当Phoneid为空时，设为一个不可以被查到的Phoneid
            //    try1 = "xiechunhui";
            //}

            //SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            //SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);

            //try
            //{
            //    //测试用 sql server数据库 通过datatable获取数据;数据库为 无线功检工位
            //    string strSqlTest = "SELECT [dbo].[ESNRecord].PhoneId,[dbo].[ESNRECORD].IMEI,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdTest = new SqlCommand(strSqlTest, connSql);

            //    SqlDataAdapter daTest = new SqlDataAdapter(cmdTest);
            //    DataSet dsTry = new DataSet();
            //    connSql.Open();
            //    daTest.Fill(dsTry, "TestReport");
            //    connSql.Close();

            //    TestDataGrid.DataSource = dsTry.Tables["TestReport"];
            //    TestDataGrid.Columns[3].Width = 50;
            //    TestDataGrid.Columns[4].Width = 300;
            //    TestDataGrid.Columns[5].Width = 250;
            //    TestDataGrid.Columns[6].Width = 300;



            //    //制动精工 sql server数据库
            //    string strSqlConduct = "SELECT [dbo].[TestReport].PhoneId,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[TestReport] where [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdConduct = new SqlCommand(strSqlConduct, connSqlConduct);

            //    SqlDataAdapter daConduct = new SqlDataAdapter(cmdConduct);
            //    //DataSet dsTry = new DataSet();
            //    connSqlConduct.Open();
            //    daConduct.Fill(dsTry, "Conduct");
            //    connSqlConduct.Close();

            //    ESNDataGrid.DataSource = dsTry.Tables["Conduct"];
            //    ESNDataGrid.Columns[2].Width = 50;
            //    ESNDataGrid.Columns[3].Width = 300;
            //    ESNDataGrid.Columns[4].Width = 250;
            //    ESNDataGrid.Columns[5].Width = 300;
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}

            //finally
            //{
            //    connSql.Close();
            //}


        }

        private void cbbPhoneNumL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string try1;
            //string phoneName;
            //string phoneStage;
            //string phoneNum;


            //phoneName = this.cbbPhoneName.Text;
            //phoneStage = this.cbbPhoneStage.Text;
            //phoneNum = this.cbbPhoneNumL2.Text;

            //string sqlstr = "select PhoneCode from pmphone where PhoneName = '" + phoneName + "' and PhoneStage='" + phoneStage + "' and PhoneNum = '" + phoneNum + "'";
            //try1 = getString(sqlstr);

            //if (try1 == "")
            //{
            //    //当Phoneid为空时，设为一个不可以被查到的Phoneid
            //    try1 = "xiechunhui";
            //}

            //SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            //SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);

            //try
            //{
            //    //测试用 sql server数据库 通过datatable获取数据;数据库为 无线功检工位
            //    string strSqlTest = "SELECT [dbo].[ESNRecord].PhoneId,[dbo].[ESNRECORD].IMEI,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdTest = new SqlCommand(strSqlTest, connSql);

            //    SqlDataAdapter daTest = new SqlDataAdapter(cmdTest);
            //    DataSet dsTry = new DataSet();
            //    connSql.Open();
            //    daTest.Fill(dsTry, "TestReport");
            //    connSql.Close();

            //    TestDataGrid.DataSource = dsTry.Tables["TestReport"];
            //    TestDataGrid.Columns[3].Width = 50;
            //    TestDataGrid.Columns[4].Width = 300;
            //    TestDataGrid.Columns[5].Width = 250;
            //    TestDataGrid.Columns[6].Width = 300;



            //    //制动精工 sql server数据库
            //    string strSqlConduct = "SELECT [dbo].[TestReport].PhoneId,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[TestReport] where [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdConduct = new SqlCommand(strSqlConduct, connSqlConduct);

            //    SqlDataAdapter daConduct = new SqlDataAdapter(cmdConduct);
            //    //DataSet dsTry = new DataSet();
            //    connSqlConduct.Open();
            //    daConduct.Fill(dsTry, "Conduct");
            //    connSqlConduct.Close();

            //    ESNDataGrid.DataSource = dsTry.Tables["Conduct"];
            //    ESNDataGrid.Columns[2].Width = 50;
            //    ESNDataGrid.Columns[3].Width = 300;
            //    ESNDataGrid.Columns[4].Width = 250;
            //    ESNDataGrid.Columns[5].Width = 300;
            //}

            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}

            //finally
            //{
            //    connSql.Close();
            //}
        }

        private void cbbPhoneNumL3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string try1;
            //string phoneName;
            //string phoneStage;
            //string phoneNum;


            //phoneName = this.cbbPhoneName.Text;
            //phoneStage = this.cbbPhoneStage.Text;
            //phoneNum = this.cbbPhoneNumL3.Text;

            //string sqlstr = "select PhoneCode from pmphone where PhoneName = '" + phoneName + "' and PhoneStage='" + phoneStage + "' and PhoneNum = '" + phoneNum + "'";
            //try1 = getString(sqlstr);

            //if (try1 == "")
            //{
            //    //当Phoneid为空时，设为一个不可以被查到的Phoneid
            //    try1 = "xiechunhui";
            //}

            //SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            //SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);

            //try
            //{
            //    //测试用 sql server数据库 通过datatable获取数据;数据库为 无线功检工位
            //    string strSqlTest = "SELECT [dbo].[ESNRecord].PhoneId,[dbo].[ESNRECORD].IMEI,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdTest = new SqlCommand(strSqlTest, connSql);

            //    SqlDataAdapter daTest = new SqlDataAdapter(cmdTest);
            //    DataSet dsTry = new DataSet();
            //    connSql.Open();
            //    daTest.Fill(dsTry, "TestReport");
            //    connSql.Close();

            //    TestDataGrid.DataSource = dsTry.Tables["TestReport"];
            //    TestDataGrid.Columns[3].Width = 50;
            //    TestDataGrid.Columns[4].Width = 300;
            //    TestDataGrid.Columns[5].Width = 250;
            //    TestDataGrid.Columns[6].Width = 300;



            //    //制动精工 sql server数据库
            //    string strSqlConduct = "SELECT [dbo].[TestReport].PhoneId,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[TestReport] where [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdConduct = new SqlCommand(strSqlConduct, connSqlConduct);

            //    SqlDataAdapter daConduct = new SqlDataAdapter(cmdConduct);
            //    //DataSet dsTry = new DataSet();
            //    connSqlConduct.Open();
            //    daConduct.Fill(dsTry, "Conduct");
            //    connSqlConduct.Close();

            //    ESNDataGrid.DataSource = dsTry.Tables["Conduct"];
            //    ESNDataGrid.Columns[2].Width = 50;
            //    ESNDataGrid.Columns[3].Width = 300;
            //    ESNDataGrid.Columns[4].Width = 250;
            //    ESNDataGrid.Columns[5].Width = 300;
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}

            //finally
            //{
            //    connSql.Close();
            //}
        }

        private void TestDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbbPhoneNumL4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string try1;
            //string phoneName;
            //string phoneStage;
            //string phoneNum;


            //phoneName = this.cbbPhoneName.Text;
            //phoneStage = this.cbbPhoneStage.Text;
            //phoneNum = this.cbbPhoneNumL4.Text;

            //string sqlstr = "select PhoneCode from pmphone where PhoneName = '" + phoneName + "' and PhoneStage='" + phoneStage + "' and PhoneNum = '" + phoneNum + "'";
            //try1 = getString(sqlstr);

            //if (try1 == "")
            //{
            //    //当Phoneid为空时，设为一个不可以被查到的Phoneid
            //    try1 = "xiechunhui";
            //}

            //SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            //SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);

            //try
            //{
            //    //测试用 sql server数据库 通过datatable获取数据;数据库为 无线功检工位
            //    string strSqlTest = "SELECT [dbo].[ESNRecord].PhoneId,[dbo].[ESNRECORD].IMEI,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdTest = new SqlCommand(strSqlTest, connSql);

            //    SqlDataAdapter daTest = new SqlDataAdapter(cmdTest);
            //    DataSet dsTry = new DataSet();
            //    connSql.Open();
            //    daTest.Fill(dsTry, "TestReport");
            //    connSql.Close();

            //    TestDataGrid.DataSource = dsTry.Tables["TestReport"];
            //    TestDataGrid.Columns[3].Width = 50;
            //    TestDataGrid.Columns[4].Width = 300;
            //    TestDataGrid.Columns[5].Width = 250;
            //    TestDataGrid.Columns[6].Width = 300;

            //    //制动精工 sql server数据库
            //    string strSqlConduct = "SELECT [dbo].[TestReport].PhoneId,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[TestReport] where [dbo].[TestReport].PhoneId = "
            //        + "'" + try1 + "'"; //样机名称combobox内容加载
            //    SqlCommand cmdConduct = new SqlCommand(strSqlConduct, connSqlConduct);

            //    SqlDataAdapter daConduct = new SqlDataAdapter(cmdConduct);
            //    //DataSet dsTry = new DataSet();
            //    connSqlConduct.Open();
            //    daConduct.Fill(dsTry, "Conduct");
            //    connSqlConduct.Close();

            //    ESNDataGrid.DataSource = dsTry.Tables["Conduct"];
            //    ESNDataGrid.Columns[2].Width = 50;
            //    ESNDataGrid.Columns[3].Width = 300;
            //    ESNDataGrid.Columns[4].Width = 250;
            //    ESNDataGrid.Columns[5].Width = 300;
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}

            //finally
            //{
            //    connSql.Close();
            //}


        }


    }
}

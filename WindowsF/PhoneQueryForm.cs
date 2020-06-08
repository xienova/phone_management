using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using DAL;
using BLL;
//mysql 引用
using MySql.Data.MySqlClient;
//sql server 引用
using System.Data.SqlClient;




namespace PhoneSystem
{
    public partial class PhoneQueryForm : Form
    {
        public PhoneQueryForm()
        {
            InitializeComponent();
        }

        IList<PhoneInfo> phones;
        IList<StageInfo> stages;
        private string sql;
        MySqlConnection conn = new MySqlConnection(GetConn.connection);     //连接对象

        private void PhoneQueryForm_Load(object sender, EventArgs e)        //窗体出现时加载所有样机
        {


            this.Width = 1070;
            this.Height = 760;

            //通过列表方法获取数据，有点不方便
            PhoneBLL phonebll = new PhoneBLL();
            phones = phonebll.getAllPhones();
            phoneDataGrid.DataSource = phones;

            phoneDataGrid.ClearSelection();


            phoneDataGrid.ReadOnly = true;
            //phoneDataGrid.Width = Fuctions.dataGridViewWidth;
            //phoneDataGrid.Height = Fuctions.dataGridViewHeight;
            //phoneDataGrid.Location = new Point(43, 12);

            phoneDataGrid.Columns[0].HeaderText = "主键";   //修改显示的列名
            phoneDataGrid.Columns[0].Visible = false;
            phoneDataGrid.Columns[1].HeaderText = "序列号";
            phoneDataGrid.Columns[2].HeaderText = "名称";
            phoneDataGrid.Columns[3].HeaderText = "阶段";
            phoneDataGrid.Columns[4].HeaderText = "编号";
            phoneDataGrid.Columns[5].HeaderText = "状态";
            phoneDataGrid.Columns[6].HeaderText = "备注";
            phoneDataGrid.Columns[7].HeaderText = "接口人";
            phoneDataGrid.Columns[8].HeaderText = "显示";
            phoneDataGrid.Columns[8].Visible = false;
            phoneDataGrid.Columns[9].HeaderText = "主管";
            phoneDataGrid.Columns[10].HeaderText = "启用时间";


            phoneDataGrid.Columns[1].Width = 80;
            phoneDataGrid.Columns[2].Width = Fuctions.dataGridViewPhoneName;
            phoneDataGrid.Columns[3].Width = 80;
            phoneDataGrid.Columns[4].Width = Fuctions.dataGridViewPhoneNum;
            phoneDataGrid.Columns[5].Width = 50;
            phoneDataGrid.Columns[6].Width = Fuctions.dataGridViewNote;
            phoneDataGrid.Columns[7].Width = 50;
            phoneDataGrid.Columns[8].Width = 50;
            phoneDataGrid.Columns[9].Width = 50;
            phoneDataGrid.Columns[10].Width = 120;

            //Fuctions.AutoSize(phoneDataGrid);

            //获取数据库中 pmstage表中的 值，但是后来没在用，因为其中的数据不全，测试主管一直在改
            //StageBLL stagebll = new StageBLL();
            //stages = stagebll.getAllStages();
            //cbbPhoneStage.DataSource = stages;
            //cbbPhoneStage.DisplayMember = "StageName";
            //cbbPhoneStage.ValueMember = "StageName";
            //cbbPhoneStage.Text = "";


            //说明：一个dataSet中可以放多个dataTable。
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


            /****************************************************************************************************************************
             * 目的：显示产线数据库中数据信息
             * 方法：将mysql中样机的Phoneid作为条件向产线sql server数据库申请数据，两个数据显示于一个datagridview中
             * 结果：失败
             * 原因分析：从两个数据库中获取的信息各存放于一个datatable中，这两个datatable无法实现拼接
            try
            {
                //测试用的datagridview  测试用 此数据库使用 mysql
                string strSqlTry = "select PhoneId from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'"; //样机名称combobox内容加载
                MySqlCommand cmdTry = new MySqlCommand(strSqlTry, conn);

                MySqlDataAdapter daTry = new MySqlDataAdapter(cmdTry);
                DataSet dsTry = new DataSet();
                conn.Open();
                daTry.Fill(dsTry, "PmPhoneTry");

                conn.Close();

                DataTable dtsource = new DataTable();

                SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
                for (int i = 0; i < dsTry.Tables["PmPhoneTry"].Rows.Count; i++)
                {
                    string id = dsTry.Tables["PmPhoneTry"].Rows[i]["PhoneId"].ToString();


                    //测试用 sql server数据库 通过datatable获取数据

                    string strSqlTry1 = "SELECT distinct PhoneID FROM [Hts2007].[dbo].[ESNRecord] where PhoneID= "+ "'"+id+"'"; //样机名称combobox内容加载
                    SqlCommand cmdTry1 = new SqlCommand(strSqlTry1, connSql);

                    SqlDataAdapter daTry1 = new SqlDataAdapter(cmdTry1);

                    connSql.Open();
                    daTry1.Fill(dsTry, "PmPhoneTry1");
                    connSql.Close();

                    dtsource.Merge(dsTry.Tables["PmPhoneTry1"]);

                }


                TryDataGrid.DataSource = dtsource;


                //测试用的datagridview
                string strSqlTry1 = "select PhoneName from PmPhone where PhoneStatus = '在库' and PhoneDisplay = 'TRUE'"; //样机名称combobox内容加载
                MySqlCommand cmdTry1 = new MySqlCommand(strSqlTry1, conn);

                MySqlDataAdapter daTry1 = new MySqlDataAdapter(cmdTry1);
                conn.Open();

                daTry1.Fill(dsTry, "PmPhoneTry1");

                conn.Close();


                DataTable dtLast = new DataTable();
                dtLast.Columns.Add("phoneNa", typeof(string));
                dtLast.Columns.Add("PhoneNa1", typeof(string));

                var results = (from d1 in dsTry.Tables[0].AsEnumerable() 
                                    join d2 in dsTry.Tables[1].AsEnumerable()
                                        on d1.Field<string>("PhoneName") equals d2.Field<string>("PhoneName")
                                            select dtLast.LoadDataRow(new object[] {d1.Field<string>("PhoneName"),d2.Field<string>("PhoneName")},true));

                dtLast = results.CopyToDataTable<DataRow>();


                ////绑定数据源
                TryDataGrid.DataSource = dtLast;


                //测试用 sql server数据库 通过datatable获取数据
                SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
                string strSqlTry1 = "SELECT distinct PhoneID FROM [Hts2007].[dbo].[ESNRecord] "; //样机名称combobox内容加载
                SqlCommand cmdTry1 = new SqlCommand(strSqlTry1, connSql);

                SqlDataAdapter daTry1 = new SqlDataAdapter(cmdTry1);

                connSql.Open();
                daTry1.Fill(dsTry, "PmPhoneTry1");
                connSql.Close();

                TryDataGrid.DataSource = dsTry.Tables["PmPhoneTry1"];
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           */

            //方法2：分别将mysql数据库 与 sql server数据库提取的信息放于两个datagridview中。





        }

        private void btnQuery_Click(object sender, EventArgs e)                         //查询可以根据多个条件进行查询
        {
            sql = "select * from PmPhone where 1=1 and PhoneDisplay = 'TRUE'";

            if (txtPhoneNum.Text == "" && cbbPhoneName.Text == "" && cbbPhoneStage.Text == "" && cbbPhoneStatus.Text == "" && txtPhoneCode.Text=="" && txtPhoneNote.Text=="")
            {
                MessageBox.Show("请选择查询条件", "提示");
                return;
            }

            try
            {
                if (txtPhoneNum.Text != "")
                {
                    sql = sql + " and PhoneNum = '" + txtPhoneNum.Text +"'" ;
                }
                if (cbbPhoneName.Text != "")
                {
                    sql = sql + " and PhoneName like'%" + cbbPhoneName.Text + "%'";
                }
                if (cbbPhoneStage.Text != "")
                {
                    sql = sql + " and PhoneStage ='" + cbbPhoneStage.Text + "'";
                }
                if (cbbPhoneStatus.Text != "")
                {
                    sql = sql + " and PhoneStatus ='" + cbbPhoneStatus.Text + "'";
                }
                if (txtPhoneCode.Text != "")
                {
                    sql = sql + " and PhoneCode ='" + txtPhoneCode.Text + "'";
                }
                if (txtPhoneNote.Text != "")
                {
                    sql = sql + " and PhoneNote like'%" + txtPhoneNote.Text + "%'";
                }

                sql = sql + " order by PhoneID DESC";

                PhoneBLL Phonebll = new PhoneBLL();
                phones = Phonebll.selByCondition(sql);
                phoneDataGrid.DataSource = phones;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            this.txtPhoneNum.Clear();
            this.cbbPhoneName.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)                              //显示全部
        {
            PhoneBLL phonebll = new PhoneBLL();
            phones = phonebll.getAllPhones();
            phoneDataGrid.DataSource = phones;

            this.txtPhoneNum.Clear();
            this.cbbPhoneName.Text = "";
            this.cbbPhoneStage.Text = "";
            this.cbbPhoneStatus.Text = "";


        }

        //private void phoneDataGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        //}

        private void button3_Click(object sender, EventArgs e)                              //退出界面
        {
            this.Dispose();
        }

        private void phoneDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.phoneDataGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.phoneDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 10 );
        }

        private void cbbPhoneName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSql = "select distinct PhoneStage from PmPhone where PhoneName = '" + cbbPhoneName.Text + "'";
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

        private void phoneDataGrid_SelectionChanged(object sender, EventArgs e)
        {

            ////当前选中的行号
            //int rowNum = phoneDataGrid.CurrentCell.RowIndex;
            //String selectedPhoneId = phoneDataGrid.Rows[rowNum].Cells[1].Value.ToString();

            //if (selectedPhoneId == "")
            //{
            //    //当Phoneid为空时，设为一个不可以被查到的Phoneid
            //    selectedPhoneId = "xiechunhui";
            //}

            //SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            //SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);


            //try
            //{
            //    //测试用 sql server数据库 通过datatable获取数据;数据库为 无线功检工位
            //    string strSqlTest = "SELECT [dbo].[ESNRecord].PhoneId,[dbo].[ESNRECORD].IMEI,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
            //        + "'" + selectedPhoneId + "'"; //样机名称combobox内容加载
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
            //        + "'" + selectedPhoneId + "'"; //样机名称combobox内容加载
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


            //测试用 sql server数据库 通过datatable获取数据;数据库为 写号工位信息
            //string strSqlESN = "SELECT * FROM [Hts2007].[dbo].[ESNRecord] where PhoneId= " + "'" + selectedPhoneId + "'"; 
            //SqlCommand cmdESN = new SqlCommand(strSqlESN, connSql);

            //SqlDataAdapter daESN = new SqlDataAdapter(cmdESN);
            ////DataSet dsTry = new DataSet();
            //connSql.Open();
            //daESN.Fill(dsTry, "ESNRecord");
            //connSql.Close();

            //ESNDataGrid.DataSource = dsTry.Tables["ESNRecord"];



        }


    }
}

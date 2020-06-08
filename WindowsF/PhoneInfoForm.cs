using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using BLL;
using Model;
using MySql.Data.MySqlClient;
//sql server 引用
using System.Data.SqlClient;




namespace PhoneSystem
{
    public partial class PhoneInfoForm : Form
    {
        public PhoneInfoForm()
        {
            InitializeComponent();
        }

        IList<PhoneInfo> phones;                                            //Model中的定义，在列表中用到了；
        //IList<StageInfo> stages;
        MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象


        private void button1_Click_1(object sender, EventArgs e)              //添加样机按钮
        {
            string PhoneStatus = "在库";
            string PhoneCode = this.txtPhoneCode.Text;                                                                            //PhoneID作为主键，可以在程序中自动生成，此处无需添加
            string PhoneName = this.txtPhoneName.Text;
            string PhoneStage = this.cbbPhoneStage.Text;
            string PhoneNum = this.txtPhoneNum.Value.ToString();
            string PhoneOwner = this.cbbPhoneOwner.Text;
            string PhoneInf1 = this.cbbInf1.Text;
            string PhoneInf2 = this.cbbInf2.Text;
            string PhoneInf3 = this.cbbInf3.Text;
            string PhoneInf4 = this.cbbInf4.Text;
            string PhoneNote = PhoneInf1 + "_" + PhoneInf2 + "_" + PhoneInf3 +"_"+ PhoneInf4;

            PhoneBLL phonebll = new PhoneBLL();                             //建立对象

            if (this.txtPhoneName.Text == "" || this.cbbPhoneStage.Text == "" || this.txtPhoneNum.Value.ToString() == "" || this.cbbPhoneOwner.Text == "")
            {
                MessageBox.Show("样机名称，样机阶段，接口人信息必填", "提示");
                return;
            }
            else if (phonebll.AddPhone(PhoneCode, PhoneName, PhoneStage, PhoneNum, PhoneStatus, PhoneNote, PhoneOwner, LoginForm.usrName))
            {
                MessageBox.Show("数据上传成功！");
            }

            phones = phonebll.getAllPhones();                                   //刷新选项内容
            PhoneDataGrid.DataSource = phones;

            this.txtPhoneCode.Clear();


        }

        private void BtnPrt_Click(object sender, EventArgs e)           //打印按钮
        {
            string PhoneCode = this.txtPhoneCode.Text;                   //PhoneID作为主键，可以在程序中自动生成，此处无需添加
            string PhoneName = this.txtPhoneName.Text;
            string PhoneNum = this.txtPhoneNum.Value.ToString();
            string PhoneStage = this.cbbPhoneStage.Text;
            string PhoneInf1 = this.cbbInf1.Text;
            string PhoneInf2 = this.cbbInf2.Text;
            string PhoneInf3 = this.cbbInf3.Text;
            string PhoneInf4 = this.cbbInf4.Text;
            string PhoneStagePrint = PhoneStage + "_" + PhoneNum;
            //要打印的IMEI号
            string IMEIPrint = txtPhoneid.Text;
            try
            {

                ////IMEI信息 无线功检工位数据库,因已经自动产生了,所以这一步可以省略.
                //SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
                //List<string> IMEIList = new List<string>();       //IMEI号列表

                //string strSqlTest = "SELECT [dbo].[ESNRecord].IMEI FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
                //    + "'" + PhoneCode + "'"; //样机名称combobox内容加载
                ////打开连接
                //connSql.Open();
                ////新建mysql命令
                //SqlCommand cmdTest = new SqlCommand(strSqlTest, connSql);
                ////执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                //SqlDataReader dr = cmdTest.ExecuteReader(CommandBehavior.CloseConnection);
                //while (dr.Read())
                //{
                //    IMEIList.Add((dr.IsDBNull(0)) ? "" : dr.GetString(0));         //当PHONEID为NULL时的处理办法 
                //}
                ////关闭DataReader对象
                //dr.Close();
                //dr.Dispose();


                ////需要打印的IMEI号
                ////当查询不到此PHONEID对应的IMEI号时列表中的值为空时，设其为空字符串
                //if (IMEIList.Count == 0)
                //{
                //    IMEIPrint = "未写号";
                //}
                //else
                //{
                //    IMEIPrint = IMEIList[0];
                //}


                /*打印标贴的程序如下*/

                //打开打印端口
                TSCLIB_DLL.openport("Deli DL-888F(NEW)");
                //设计打印纸的大小与间距
                TSCLIB_DLL.setup("30", "20", "3", "10", "0", "2", "0");    //宽度、高度、速度寸/秒、浓度0-15、。 长度30 20 OK,倒数间距2 OK
                //清空下缓存
                TSCLIB_DLL.clearbuffer();
                //打印文字
                TSCLIB_DLL.windowsfont(1, 15, 23, 0, 2, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                TSCLIB_DLL.windowsfont(1, 40, 23, 0, 2, 0, "標楷體", PhoneStagePrint);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                TSCLIB_DLL.windowsfont(1, 65, 23, 0, 2, 0, "標楷體", PhoneInf1);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                TSCLIB_DLL.windowsfont(1, 90, 22, 0, 2, 0, "標楷體", PhoneInf2);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                TSCLIB_DLL.windowsfont(1, 115, 23, 0, 2, 0, "標楷體", PhoneInf3);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                TSCLIB_DLL.windowsfont(1, 138, 23, 0, 2, 0, "標楷體", PhoneInf4);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容

                //打印份数
                TSCLIB_DLL.printlabel("1", "1");
                //关闭打印端口
                TSCLIB_DLL.closeport();

                //样机编号，自动加1
                this.txtPhoneNum.Value++;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("something is wrong, please contact 解chunhui");
            }
            finally
            {

            }

            this.txtPhoneCode.Clear();
            //this.txtPhoneName.Clear();
            //this.txtPhoneNum.Clear();
            //this.cbbPhoneStage.Text = "";
            //this.cbbInf1.Text = "";
            //this.cbbInf2.Text = "";
            //this.cbbInf3.Text = "";
            //this.cbbInf4.Text = "";
            //this.cbbPhoneOwner.Text = "";


        }

        private void btnDelete_Click(object sender, EventArgs e)                //根据样机码删除样机
        {

            string phoneCode = this.txtPhoneCode.Text;
            PhoneBLL phonebll = new PhoneBLL();

            if (txtPhoneCode.Text == "")
            {
                MessageBox.Show("请通过输入样机码进行样机删除","提示");
                return;
            }

            if (MessageBox.Show("确定要删除该条样机信息吗？", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                if (phonebll.delByPhoneCode(phoneCode))
                {
                    MessageBox.Show("删除成功！","提示");
                }
                else
                {
                    MessageBox.Show("删除失败，请检查信息是否正确","提示");
                }
                
            }
            else
            {
                //不执行任务
            }

            phones = phonebll.getAllPhones();
            PhoneDataGrid.DataSource = phones;

            this.txtPhoneCode.Clear();
            this.txtPhoneName.Clear();
            this.cbbPhoneStage.Text = "";
            this.cbbInf1.Text = "";
            this.cbbInf2.Text = "";
            this.cbbInf3.Text = "";
            this.cbbInf4.Text = "";
            this.cbbPhoneOwner.Text = "";
        }


        private void PhoneInfoForm_Load(object sender, EventArgs e)
        {

            cbbPhoneDisplay.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbPhoneNameD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbPhoneStageD.DropDownStyle = ComboBoxStyle.DropDownList;

            cbbPhoneOwner.DropDownStyle = ComboBoxStyle.DropDown;
            cbbPhoneStage.DropDownStyle = ComboBoxStyle.DropDown;


            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;

            PhoneBLL phonebll = new PhoneBLL();
            phones = phonebll.getAllPhones();
            PhoneDataGrid.DataSource = phones;                  //将数据库中的数据提到列表中，再通过 DataGrid控件显示；

            PhoneDataGrid.ReadOnly = true;
            PhoneDataGrid.Width = Fuctions.dataGridViewWidth;
            //PhoneDataGrid.Height = 300;
            PhoneDataGrid.Location = new Point(Fuctions.dataGridViewLocationX, Fuctions.dataGridViewLocationY);


            PhoneDataGrid.Columns[0].HeaderText = "主键";   //修改显示的列名
            PhoneDataGrid.Columns[0].Visible = false;
            PhoneDataGrid.Columns[1].HeaderText = "Phone ID";
            PhoneDataGrid.Columns[2].HeaderText = "名称";
            PhoneDataGrid.Columns[3].HeaderText = "阶段";
            PhoneDataGrid.Columns[4].HeaderText = "编号";
            PhoneDataGrid.Columns[5].HeaderText = "状态";
            PhoneDataGrid.Columns[6].HeaderText = "备注";
            PhoneDataGrid.Columns[7].HeaderText = "接口人";
            PhoneDataGrid.Columns[8].HeaderText = "显示";
            PhoneDataGrid.Columns[8].Visible = false;
            PhoneDataGrid.Columns[9].HeaderText = "主管";
            PhoneDataGrid.Columns[10].HeaderText = "启用时间";            



            PhoneDataGrid.Columns[1].Width = 80;
            PhoneDataGrid.Columns[2].Width = Fuctions.dataGridViewPhoneName;
            PhoneDataGrid.Columns[3].Width = 80;
            PhoneDataGrid.Columns[4].Width = Fuctions.dataGridViewPhoneNum; ;
            PhoneDataGrid.Columns[5].Width = 50;
            PhoneDataGrid.Columns[6].Width = Fuctions.dataGridViewNote;
            PhoneDataGrid.Columns[7].Width = 50;
            PhoneDataGrid.Columns[8].Width = 50;
            PhoneDataGrid.Columns[9].Width = 50;
            PhoneDataGrid.Columns[10].Width = 120;

            Fuctions.AutoSize(PhoneDataGrid);

            //StageBLL stagebll = new StageBLL();                 //从数据库中读出状态信息，显示于CBB中。
            //stages = stagebll.getAllStages();
            //cbbPhoneStage.DataSource = stages;
            //cbbPhoneStage.DisplayMember = "StageName";
            //cbbPhoneStage.ValueMember = "StageName";
            //cbbPhoneStage.SelectedIndex = -1;
            //cbbPhoneStage.Text = "";


            //***********************************************样机是否显示 cbb内容更新
            string strSql = "select distinct PhoneName from PmPhone order by PhoneName asc"; //样机名称cbbD内容加载
            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmPhone");
            conn.Close();
            cbbPhoneNameD.DisplayMember = "PhoneName";
            cbbPhoneNameD.ValueMember = "PhoneName";
            cbbPhoneNameD.DataSource = ds.Tables["PmPhone"];
            cbbPhoneNameD.SelectedIndex = -1;
            //cbbPhoneNameD.Text = "";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*打印标贴的程序如下*/

            string PhoneName = "hello world";
            //打开打印端口
            TSCLIB_DLL.openport("Deli DL-888F(NEW)");
            //设计打印纸的大小与间距
            TSCLIB_DLL.setup("30", "20", "3", "10", "0", "2", "0");    //宽度、高度、速度寸/秒、浓度0-15、。 长度30 20 OK,倒数间距2 OK
            //清空下缓存
            TSCLIB_DLL.clearbuffer();
            //打印文字
            TSCLIB_DLL.windowsfont(1, 15, 23, 0, 2, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
            TSCLIB_DLL.windowsfont(1, 40, 23, 0, 2, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
            TSCLIB_DLL.windowsfont(1, 65, 23, 0, 2, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
            TSCLIB_DLL.windowsfont(1, 90, 22, 0, 2, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
            TSCLIB_DLL.windowsfont(1, 115, 23, 0, 2, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
            TSCLIB_DLL.windowsfont(1, 138, 23, 0, 2, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容


            //打印份数
            TSCLIB_DLL.printlabel("1", "1");
            //关闭打印端口
            TSCLIB_DLL.closeport();
            MessageBox.Show("hello");
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)                          //将不需要显示的样机字段改变
        {


            PhoneBLL phonebll = new PhoneBLL();
            string PhoneNameD = this.cbbPhoneNameD.Text;
            string PhoneStageD = this.cbbPhoneStageD.Text;
            string PhoneDisplay = this.cbbPhoneDisplay.Text;

            if (cbbPhoneNameD.Text == "" || cbbPhoneStageD.Text== "" || cbbPhoneDisplay.Text == "")
            {
                MessageBox.Show("请通过样机名称 与 样机阶段 进行选择", "提示");
                return;
            }

            if (MessageBox.Show("确定对选中的样机名称与样机阶段进行操作?", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (phonebll.updatePhoneDisplay(PhoneNameD,PhoneStageD,PhoneDisplay))
                {
                    MessageBox.Show("更新样机状态成功", "提示");
                }
                else
                {
                    MessageBox.Show("更新失败，请检查信息是否正确", "提示");
                }

            }
            else
            {
                //不执行任务
            }

            phones = phonebll.getAllPhones();
            PhoneDataGrid.DataSource = phones;                  //将数据库中的数据提到列表中，再通过 DataGrid控件显示；



        }



        private void cbbPhoneNameD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string strSql = "select distinct PhoneStage from PmPhone where PhoneName = '" + cbbPhoneNameD.Text + "'";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmPhone");
            conn.Close();
            cbbPhoneStageD.DisplayMember = "PhoneStage";
            cbbPhoneStageD.ValueMember = "PhoneStage";
            cbbPhoneStageD.DataSource = ds.Tables["PmPhone"];
            cbbPhoneStageD.Text = "";
        }

        private void PhoneDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
            {
                SolidBrush b = new SolidBrush(this.PhoneDataGrid.RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.PhoneDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 10);
            }

        private void cbbPhoneNameD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Phoneid change, action start
        private void txtPhoneCode_TextChanged(object sender, EventArgs e)
        {
            //样机PHONEID
            string PhoneCode = this.txtPhoneCode.Text;
            //如果没有PhoneCode时，就设为myname
            if (PhoneCode == "")
            {
                PhoneCode = "xiechunhui";
            }


            SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            SqlConnection connSqlConduct = new SqlConnection(GetConn.sqlConnConduct);

            try
            {  
                ////测试用 sql server数据库 通过datatable获取数据;数据库为 无线功检工位     不显示这两个数据库的信息呢。
                string strSqlTest = "SELECT [dbo].[ESNRecord].PhoneId,[dbo].[ESNRECORD].IMEI,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
                    + "'" + PhoneCode + "'"; //样机名称combobox内容加载
                SqlCommand cmdTest = new SqlCommand(strSqlTest, connSql);

                //SqlDataAdapter daTest = new SqlDataAdapter(cmdTest);
                //DataSet dsTry = new DataSet();
                //connSql.Open();
                //daTest.Fill(dsTry, "TestReport");
                //connSql.Close();

                //TestDataGrid.DataSource = dsTry.Tables["TestReport"];
                //TestDataGrid.Columns[3].Width = 50;
                //TestDataGrid.Columns[4].Width = 300;
                //TestDataGrid.Columns[5].Width = 250;
                //TestDataGrid.Columns[6].Width = 300;


                ////制动精工 sql server数据库
                //string strSqlConduct = "SELECT [dbo].[TestReport].PhoneId,[dbo].[TestReport].StartTM,[dbo].[TestReport].Result,[dbo].[TestReport].PlanFile,[dbo].[TestReport].FailItem,[dbo].[TestReport].LastErr FROM [dbo].[TestReport] where [dbo].[TestReport].PhoneId = "
                //    + "'" + PhoneCode + "'"; //样机名称combobox内容加载
                //SqlCommand cmdConduct = new SqlCommand(strSqlConduct, connSqlConduct);

                //SqlDataAdapter daConduct = new SqlDataAdapter(cmdConduct);
                ////DataSet dsTry = new DataSet();
                //connSqlConduct.Open();
                //daConduct.Fill(dsTry, "Conduct");
                //connSqlConduct.Close();

                //ESNDataGrid.DataSource = dsTry.Tables["Conduct"];
                //ESNDataGrid.Columns[2].Width = 50;
                //ESNDataGrid.Columns[3].Width = 300;
                //ESNDataGrid.Columns[4].Width = 250;
                //ESNDataGrid.Columns[5].Width = 300;


                //IMEI信息 无线功检工位数据库

                List<string> IMEIList = new List<string>();       //IMEI号列表

                strSqlTest = "SELECT [dbo].[ESNRecord].IMEI FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
                    + "'" + PhoneCode + "'"; //样机名称combobox内容加载
                //打开连接
                connSql.Open();
                //新建mysql命令
                cmdTest = new SqlCommand(strSqlTest, connSql);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                SqlDataReader dr = cmdTest.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    IMEIList.Add((dr.IsDBNull(0)) ? "xiechunhui" : dr.GetString(0));         //当PHONEID为NULL时的处理办法 
                }
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();

                //当查询不到此PHONEID对应的IMEI号时列表中的值为空时，设其为空字符串
                if (IMEIList.Count == 0)
                {
                    txtPhoneid.Text = "未写号";
                }
                else
                {
                    txtPhoneid.Text = IMEIList[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("本电脑IP可能不支持产线数据库,请换个电脑重试");
            }

            finally
            {
                connSql.Close();
            }

        }

        private void PhoneDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





    }
}

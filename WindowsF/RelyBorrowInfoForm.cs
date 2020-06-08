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
    public partial class RelyBorrowInfoForm : Form
    {

        IList<BorrowInfo> borrows;                                                              //全局变量，在datagridview中会用到，现下的staff.
        //IList<StaffInfo> staffs;
        MySqlConnection conn = new MySqlConnection(GetConn.connection);                             //连接对象
        string IPADRESS2 = "fe80::fd81:73ef:be0c:3fcc%12";                                        //我的电脑的IP地址;
        string IPADRESS = "fe80::e51c:aa02:2b49:af21%11";
        string IPADDRESS1 = "fe80::a8db:228f:f55:4fd%10";

        public RelyBorrowInfoForm()
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


            /*
             * 样机相关内容加载
             *
             */

            //样机名称加载
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


            //实验名称加载
            strSql = "select distinct HGroupTest from PmGroup where HGroupName = '可靠性'";        
            cmd = new MySqlCommand(strSql, conn);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmTest");
            conn.Close();
            cbbHGroupTest.DisplayMember = "HGroupTest";
            cbbHGroupTest.ValueMember = "HGroupTest";
            cbbHGroupTest.DataSource = ds.Tables["PmTest"];
            cbbHGroupTest.Text = "";


            //还样机状态IsNormal内容加载 
            DataTable dt = new DataTable();                                           
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

            //cbb中内容加载
            cbbIsNormal.DisplayMember = "text";
            cbbIsNormal.ValueMember = "value";
            cbbIsNormal.DataSource = dt.Copy();
            cbbIsNormal.Text = "正常";

            cbbIsNormal1.DisplayMember = "text";
            cbbIsNormal1.ValueMember = "value";
            cbbIsNormal1.DataSource = dt.Copy();
            cbbIsNormal1.Text = "正常";

            cbbIsNormal2.DisplayMember = "text";
            cbbIsNormal2.ValueMember = "value";
            cbbIsNormal2.DataSource = dt.Copy();
            cbbIsNormal2.Text = "正常";

            cbbIsNormal3.DisplayMember = "text";
            cbbIsNormal3.ValueMember = "value";
            cbbIsNormal3.DataSource = dt.Copy();
            cbbIsNormal3.Text = "正常";

            cbbIsNormal4.DisplayMember = "text";
            cbbIsNormal4.ValueMember = "value";
            cbbIsNormal4.DataSource = dt.Copy();
            cbbIsNormal4.Text = "正常";

            cbbIsNormal5.DisplayMember = "text";
            cbbIsNormal5.ValueMember = "value";
            cbbIsNormal5.DataSource = dt.Copy();
            cbbIsNormal5.Text = "正常";

            cbbIsNormal6.DisplayMember = "text";
            cbbIsNormal6.ValueMember = "value";
            cbbIsNormal6.DataSource = dt.Copy();
            cbbIsNormal6.Text = "正常";

            cbbIsNormal9.DisplayMember = "text";
            cbbIsNormal9.ValueMember = "value";
            cbbIsNormal9.DataSource = dt.Copy();
            cbbIsNormal9.Text = "正常";

            cbbIsNormal7.DisplayMember = "text";
            cbbIsNormal7.ValueMember = "value";
            cbbIsNormal7.DataSource = dt.Copy();
            cbbIsNormal7.Text = "正常";

            cbbIsNormal8.DisplayMember = "text";
            cbbIsNormal8.ValueMember = "value";
            cbbIsNormal8.DataSource = dt.Copy();
            cbbIsNormal8.Text = "正常";
        }


        //选样机cbb名称时，更换样机状态cbb
        private void cbbPhoneName_SelectedIndexChanged(object sender, EventArgs e)                      
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

        //借样机状态名称更改时,样机编号cbb自动更新
        private void cbbPhoneStage_SelectedIndexChanged(object sender, EventArgs e)                     
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

            cbbPhoneNum1.DisplayMember = "PhoneNum";
            cbbPhoneNum1.ValueMember = "PhoneNum";
            cbbPhoneNum1.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum1.Text = "";

            cbbPhoneNum2.DisplayMember = "PhoneNum";
            cbbPhoneNum2.ValueMember = "PhoneNum";
            cbbPhoneNum2.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum2.Text = "";

            cbbPhoneNum3.DisplayMember = "PhoneNum";
            cbbPhoneNum3.ValueMember = "PhoneNum";
            cbbPhoneNum3.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum3.Text = "";

            cbbPhoneNum4.DisplayMember = "PhoneNum";
            cbbPhoneNum4.ValueMember = "PhoneNum";
            cbbPhoneNum4.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum4.Text = "";

            cbbPhoneNum5.DisplayMember = "PhoneNum";
            cbbPhoneNum5.ValueMember = "PhoneNum";
            cbbPhoneNum5.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum5.Text = "";

            cbbPhoneNum6.DisplayMember = "PhoneNum";
            cbbPhoneNum6.ValueMember = "PhoneNum";
            cbbPhoneNum6.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum6.Text = "";

            cbbPhoneNum7.DisplayMember = "PhoneNum";
            cbbPhoneNum7.ValueMember = "PhoneNum";
            cbbPhoneNum7.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum7.Text = "";

            cbbPhoneNum8.DisplayMember = "PhoneNum";
            cbbPhoneNum8.ValueMember = "PhoneNum";
            cbbPhoneNum8.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum8.Text = "";

            cbbPhoneNum9.DisplayMember = "PhoneNum";
            cbbPhoneNum9.ValueMember = "PhoneNum";
            cbbPhoneNum9.DataSource = ds.Tables["PmPhone"].Copy();
            cbbPhoneNum9.Text = "";
        }


        /*
         *需求：通过按键实现样机 借还一起，主要是为了记录做过的实验，及实验后的状态 
         *思路：先借 后还
         */

        private void button1_Click(object sender, EventArgs e)                                  
        {

            string ip = Fuctions.GetIpAddress();

            if (LoginForm.admin == 0)
            {
                if (ip != IPADRESS && ip != IPADDRESS1 && ip != IPADRESS2)
                {
                    MessageBox.Show("请去指定电脑进行样机借阅","提示");
                    return;
                }
            }

            BorrowBLL borrowbll = new BorrowBLL();
            PhoneBLL phonebll = new PhoneBLL();

             //若是五行中的 样机编号没有选，给出提示
            if (cbbPhoneNum1.Text == "" && cbbPhoneNum2.Text == "" && cbbPhoneNum3.Text == "" && cbbPhoneNum4.Text == "" && cbbPhoneNum.Text == ""&cbbPhoneNum5.Text == "" && cbbPhoneNum6.Text == "" && cbbPhoneNum7.Text == "" && cbbPhoneNum8.Text == "" && cbbPhoneNum9.Text == "")
            {
                MessageBox.Show("请输入样机编号");
                return;
            }

            if (cbbPhoneName.Text == "" || cbbPhoneStage.Text == "" )
            {
                MessageBox.Show("请输入样机信息");
                return;
            }
            else
            {

                //判断样机状态是否选择
                if (cbbPhoneNum.Text != "")
                {
                    if (cbbIsNormal.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注
                    if (cbbIsNormal.Text == "故障" && txtRemark.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum1.Text != "")
                {
                    if (cbbIsNormal1.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal1.Text == "故障" && txtRemark1.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum2.Text != "")
                {
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal2.Text == "故障" && txtRemark2.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                    if (cbbIsNormal2.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                }
                if (cbbPhoneNum3.Text != "")
                {
                    if (cbbIsNormal3.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注
                    if (cbbIsNormal3.Text == "故障" && txtRemark3.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum4.Text != "")
                {
                    if (cbbIsNormal4.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal4.Text == "故障" && txtRemark4.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum5.Text != "")
                {
                    if (cbbIsNormal5.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal5.Text == "故障" && txtRemark5.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum6.Text != "")
                {
                    if (cbbIsNormal6.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal6.Text == "故障" && txtRemark6.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum7.Text != "")
                {
                    if (cbbIsNormal7.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal7.Text == "故障" && txtRemark7.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum8.Text != "")
                {
                    if (cbbIsNormal8.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal8.Text == "故障" && txtRemark8.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }
                if (cbbPhoneNum9.Text != "")
                {
                    if (cbbIsNormal9.Text == "")
                    {
                        MessageBox.Show("请输入样机状态");
                        return;
                    }
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal9.Text == "故障" && txtRemark9.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }
                }


                //借机操作
                if (cbbPhoneNum.Text != "")
                {
                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum.Text,LoginForm.usrName))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum.Text + "借", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum.Text, cbbHGroupTest.Text, cbbIsNormal.Text, txtRemark.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum.Text + "还", "提示");
                    }
                }


                //借机操作2
                if (cbbPhoneNum1.Text != "")
                {
                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum1.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum1.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum1.Text, cbbHGroupTest.Text, cbbIsNormal1.Text, txtRemark1.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum1.Text + "还错误", "提示");
                    }
                }

                //操作3
                if (cbbPhoneNum2.Text != "")
                {
                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum2.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum2.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum2.Text, cbbHGroupTest.Text, cbbIsNormal2.Text, txtRemark2.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum2.Text + "还错误", "提示");
                    }
                }


                //操作4
                if (cbbPhoneNum3.Text != "")
                {
                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum3.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum3.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum3.Text, cbbHGroupTest.Text, cbbIsNormal3.Text, txtRemark3.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum3.Text + "还错误", "提示");
                    }
                }


                //操作5
                if (cbbPhoneNum4.Text != "")
                {
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal4.Text == "故障" && txtRemark4.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }

                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum4.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum4.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum4.Text, cbbHGroupTest.Text, cbbIsNormal4.Text, txtRemark4.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum4.Text + "还错误", "提示");
                    }
                }


                //操作6
                if (cbbPhoneNum5.Text != "")
                {
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal5.Text == "故障" && txtRemark5.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }

                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum5.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum5.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum5.Text, cbbHGroupTest.Text, cbbIsNormal5.Text, txtRemark5.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum5.Text + "还错误", "提示");
                    }
                }


                //操作7
                if (cbbPhoneNum6.Text != "")
                {
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal6.Text == "故障" && txtRemark6.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }

                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum6.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum6.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum6.Text, cbbHGroupTest.Text, cbbIsNormal6.Text, txtRemark6.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum6.Text + "还错误", "提示");
                    }
                }


                //操作8
                if (cbbPhoneNum7.Text != "")
                {
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal7.Text == "故障" && txtRemark7.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }

                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum7.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum7.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum7.Text, cbbHGroupTest.Text, cbbIsNormal7.Text, txtRemark7.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum7.Text + "还错误", "提示");
                    }
                }


                //操作9
                if (cbbPhoneNum8.Text != "")
                {
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal8.Text == "故障" && txtRemark8.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }

                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum8.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum8.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum8.Text, cbbHGroupTest.Text, cbbIsNormal8.Text, txtRemark8.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum8.Text + "还错误", "提示");
                    }
                }


                //操作10
                if (cbbPhoneNum9.Text != "")
                {
                    //样机状态是否正常，若是故障时需要输入备注

                    if (cbbIsNormal9.Text == "故障" && txtRemark9.Text == "")
                    {
                        MessageBox.Show("样机故障，请输入故障信息", "提示");
                        return;
                    }

                    //借与还操作
                    if (borrowbll.addBorrow(LoginForm.usrName, this.cbbPhoneName.Text, this.cbbPhoneStage.Text, this.cbbPhoneNum9.Text, LoginForm.usrName))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum9.Text + "借错误", "提示");
                    }
                    if (borrowbll.returnPhone(LoginForm.usrName, cbbPhoneName.Text, cbbPhoneStage.Text, cbbPhoneNum9.Text, cbbHGroupTest.Text, cbbIsNormal9.Text, txtRemark9.Text))
                    {
                        //MessageBox.Show("操作成功", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this.cbbPhoneNum9.Text + "还错误", "提示");
                    }
                }
                MessageBox.Show("操作成功");

            }

            string strSql = "select * from PmBorrow where StaffName = '" + LoginForm.usrName + "' order by BorrowID DESC"; //样机名称combobox内容加载
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

            //收尾工作：清空无关信息

            txtRemark.Text = "";
            txtRemark1.Text = "";
            txtRemark2.Text = "";
            txtRemark3.Text = "";
            txtRemark4.Text = "";
            txtRemark5.Text = "";
            txtRemark6.Text = "";
            txtRemark7.Text = "";
            txtRemark8.Text = "";
            txtRemark9.Text = "";

            //默认正常
            cbbIsNormal.Text = "正常";
            cbbIsNormal1.Text = "正常";
            cbbIsNormal2.Text = "正常";
            cbbIsNormal3.Text = "正常";
            cbbIsNormal4.Text = "正常";
            cbbIsNormal5.Text = "正常";
            cbbIsNormal6.Text = "正常";
            cbbIsNormal7.Text = "正常";
            cbbIsNormal8.Text = "正常";
            cbbIsNormal9.Text = "正常";


        }


        //返回键，这里有点鸡肋了
        private void button1_Click_2(object sender, EventArgs e)
        {
            cbbPhoneName.DataSource = null;
            cbbPhoneStage.DataSource = null;
            cbbPhoneNum.DataSource = null;
            this.Dispose();
        }

        //datagridview 加载行号
        private void borrowDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.borrowDataGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.borrowDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 10);
        }

















    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.IO;
using MExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Reflection;

//sql server使用
using System.Data.SqlClient;
using DAL;

namespace PhoneSystem
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }


        private void 系统说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            about.MdiParent = this;
            about.WindowState = FormWindowState.Maximized;                          //最大化显示当前窗口
            about.Show();

        }


        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form pwdChange = new PwdChange();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            pwdChange.MdiParent = this;
            pwdChange.WindowState = FormWindowState.Maximized;
            pwdChange.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.Text = LoginForm.usrName + "---欢迎使用样机管理系统";
            slblTime.Text = slblTime.Text + DateTime.Now.ToString();

            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;

            //MessageBox.Show(Fuctions.GetIpAddress());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slblTime.Text = "当前时间：" + DateTime.Now.ToString();      //时间动起来
        }

        private void 样机输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string excelFilePath = "";
            //excelFilePath = @"C:\Users\user\Desktop\EXCEL\TRY.xlsx";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = "Excel(*.xlsm)|*.xlsm|Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            dialog.Multiselect = false;      //确定是否可以选择多个文件
            //dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //dialog.InitialDirectory = Application.StartupPath ;
            dialog.InitialDirectory = @"\\version1\测试二所\样机管理系统\样机信息";


            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                excelFilePath = dialog.FileName;
            }
            else
            {
                return;
            }


            MExcel.Application app = new MExcel.Application();
            MExcel.Sheets sheets;
            MExcel.Workbook workbook = null;
            object oMissing = System.Reflection.Missing.Value;
            //app.Visible = true;
            DataTable dt = new DataTable();

            try
            {
                workbook = app.Workbooks.Open(excelFilePath, oMissing, oMissing, oMissing, oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                sheets = workbook.Worksheets;
                MExcel.Worksheet worksheet = (MExcel.Worksheet)sheets.get_Item(1);          //用的是 worksheets 这一大类的
                //MExcel.Worksheet worksheet = (MExcel.Worksheet)workbook.Worksheets[1];

                int iRowCount = worksheet.get_Range("B65535", oMissing).get_End(MExcel.XlDirection.xlUp).Row;
                int iColCount = worksheet.UsedRange.Columns.Count;

                if (iRowCount < 4)
                {
                    MessageBox.Show("请在文档中输入样机信息！");
                    return;
                }

                string PhoneCode;                                                                          //PhoneID作为主键，可以在程序中自动生成，此处无需添加
                string PhoneName;
                string PhoneStage;
                string PhoneStagePrint;
                string PhoneNum;
                string PhoneStatus = "在库";
                //string PhoneNoteAll;
                string PhoneNote;
                string PhoneNote1;
                string PhoneNote2;
                string PhoneNote3;
                string PhoneNote4;

                string PhoneOwner;

                string log1, log2, log3, log4;

                MExcel.Range rngName = (MExcel.Range)worksheet.Cells[1, 2];
                MExcel.Range rngStage = (MExcel.Range)worksheet.Cells[2, 2];
                //MExcel.Range rngNoteAll = (MExcel.Range)worksheet.Cells[3, 2];
                PhoneName = Convert.ToString(rngName.Value2) ;                                          //STRING 用来将内容变为字符串
                PhoneStage = Convert.ToString(rngStage.Value2);
                //PhoneNoteAll = Convert.ToString(rngNoteAll.Value2);

                MExcel.Range log1R = (MExcel.Range)worksheet.Cells[3, 1];
                MExcel.Range log2R = (MExcel.Range)worksheet.Cells[3, 5];
                MExcel.Range log3R = (MExcel.Range)worksheet.Cells[3, 6];
                MExcel.Range log4R = (MExcel.Range)worksheet.Cells[3, 7];
                log1 = Convert.ToString(log1R.Value2) ;                                          //STRING 用来将内容变为字符串
                log2 = Convert.ToString(log2R.Value2);
                log3 = Convert.ToString(log3R.Value2);
                log4 = Convert.ToString(log4R.Value2);

                if (PhoneName == null || PhoneStage == null || log1 == null || log2 == null || log3 == null || log4 == null)
                {
                    MessageBox.Show("'型号' 与 '测试阶段' 是必填内容 或 使用最新模板");
                    return;
                }


                PhoneBLL phonebll = new PhoneBLL();
                for (int i = 4; i <= iRowCount; i++)
                {
                    MExcel.Range rngCode = (MExcel.Range)worksheet.Cells[i, 1];
                    MExcel.Range rngNum = (MExcel.Range)worksheet.Cells[i, 2];
                    //MExcel.Range rngNote = (MExcel.Range)worksheet.Cells[i, 4];
                    MExcel.Range rngOwner = (MExcel.Range)worksheet.Cells[i, 3];
                    MExcel.Range rngNote1 = (MExcel.Range)worksheet.Cells[i, 4];
                    MExcel.Range rngNote2 = (MExcel.Range)worksheet.Cells[i, 5];
                    MExcel.Range rngNote3 = (MExcel.Range)worksheet.Cells[i, 6];
                    MExcel.Range rngNote4 = (MExcel.Range)worksheet.Cells[i, 7];

                    PhoneCode = Convert.ToString(rngCode.Value2) + "";                                      //入库使用，PHONEID
                    PhoneNum = Convert.ToString(rngNum.Value2)+ "";
                    
                    PhoneOwner = Convert.ToString(rngOwner.Value2) + "";                                    //入库使用，接口人
                    PhoneNote1 = Convert.ToString(rngNote1.Value2) + "";        //打印信息使用
                    PhoneNote2 = Convert.ToString(rngNote2.Value2) + "";        //打印信息使用
                    PhoneNote3 = Convert.ToString(rngNote3.Value2) + "";        //打印信息使用
                    PhoneNote4 = Convert.ToString(rngNote4.Value2) + "";        //打印信息使用
                    PhoneNote = PhoneNote1 + "_" + PhoneNote2 + "_" + PhoneNote3 + "_"+PhoneNote4;        //入库使用，备注信息

                    PhoneStagePrint = PhoneStage + "_" + PhoneNum;              //打印信息使用

                    ////打印开始******************************************************************************
                    ////打开打印端口
                    //TSCLIB_DLL.openport("Deli DL-888F(NEW)");
                    ////设计打印纸的大小与间距
                    //TSCLIB_DLL.setup("30", "20", "3", "10", "0", "2", "0");    //宽度、高度、速度寸/秒、浓度0-15、。 长度30 20 OK,倒数间距2 OK
                    ////清空下缓存
                    //TSCLIB_DLL.clearbuffer();
                    ////打印文字
                    //TSCLIB_DLL.windowsfont(1, 15, 23, 0, 0, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    //TSCLIB_DLL.windowsfont(1, 40, 23, 0, 0, 0, "標楷體", PhoneStagePrint);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    //TSCLIB_DLL.windowsfont(1, 65, 23, 0, 0, 0, "標楷體", PhoneNote1);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    //TSCLIB_DLL.windowsfont(1, 90, 23, 0, 0, 0, "標楷體", PhoneNote2);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    //TSCLIB_DLL.windowsfont(1, 115, 23, 0, 0, 0, "標楷體", PhoneNote3);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    //TSCLIB_DLL.windowsfont(1, 138, 23, 0, 0, 0, "標楷體", PhoneNote4);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容


                    ////打印份数
                    //TSCLIB_DLL.printlabel("1", "1");
                    ////关闭打印端口
                    //TSCLIB_DLL.closeport();
                    ////打印结束********************************************************************************

                    if (phonebll.AddPhone(PhoneCode, PhoneName, PhoneStage, PhoneNum, PhoneStatus, PhoneNote, PhoneOwner, LoginForm.usrName))
                    {
                        //MessageBox.Show("ok");
                    }

                }

                MessageBox.Show("样机信息导入成功^_^");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
            finally
            {
                workbook.Close(false, oMissing, oMissing);                          //关闭 工作表
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;

                app.Workbooks.Close();                                              //关闭应用
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;

            }
            //COM组件方式读取 EXCEL中的数值
        }

        private void 样机查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form phoneQueryForm = new PhoneQueryForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            phoneQueryForm.MdiParent = this;
            phoneQueryForm.WindowState = FormWindowState.Maximized;
            phoneQueryForm.Show();
        }

        private void 员工输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form staffInfoForm = new StaffInfoForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            staffInfoForm.MdiParent = this;
            staffInfoForm.WindowState = FormWindowState.Maximized;
            staffInfoForm.Show();
        }

        private void 员工查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form staffQueryForm = new StaffQueryForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            staffQueryForm.MdiParent = this;
            staffQueryForm.WindowState = FormWindowState.Maximized;
            staffQueryForm.Show();

        }

        private void 借还机ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form borrowInfoForm = new AdminBorrowInfoForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            borrowInfoForm.MdiParent = this;
            borrowInfoForm.WindowState = FormWindowState.Maximized;
            borrowInfoForm.Show();


        }


        private void 借阅查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form borrowQueryForm = new BorrowQueryForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            borrowQueryForm.MdiParent = this;
            borrowQueryForm.WindowState = FormWindowState.Maximized;
            borrowQueryForm.Show();
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 单次输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form phoneInfoForm = new PhoneInfoForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            phoneInfoForm.MdiParent = this;
            phoneInfoForm.WindowState = FormWindowState.Maximized;
            phoneInfoForm.Show();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            LoginForm loginform = new LoginForm();
            loginform.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void eXCEL打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string excelFilePath = "";
            //excelFilePath = @"C:\Users\user\Desktop\EXCEL\TRY.xlsx";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = "Excel(*.xlsm)|*.xlsm|Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            dialog.Multiselect = false;      //确定是否可以选择多个文件
            //dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //dialog.InitialDirectory = Application.StartupPath ;
            dialog.InitialDirectory = @"\\version1\测试二所\样机管理系统\样机信息";


            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                excelFilePath = dialog.FileName;
            }
            else
            {
                return;
            }


            MExcel.Application app = new MExcel.Application();
            MExcel.Sheets sheets;
            MExcel.Workbook workbook = null;
            object oMissing = System.Reflection.Missing.Value;
            //app.Visible = true;
            DataTable dt = new DataTable();

            //查询产线数据库需要
            //IMEI信息 无线功检工位数据库
            SqlConnection connSql = new SqlConnection(GetConn.sqlConn);     //连接对象
            List<string> IMEIList = new List<string>();       //IMEI号列表


            try
            {
                workbook = app.Workbooks.Open(excelFilePath, oMissing, oMissing, oMissing, oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                sheets = workbook.Worksheets;
                MExcel.Worksheet worksheet = (MExcel.Worksheet)sheets.get_Item(1);          //用的是 worksheets 这一大类的
                //MExcel.Worksheet worksheet = (MExcel.Worksheet)workbook.Worksheets[1];

                int iRowCount = worksheet.get_Range("B65535", oMissing).get_End(MExcel.XlDirection.xlUp).Row;
                int iColCount = worksheet.UsedRange.Columns.Count;

                if (iRowCount < 4)
                {
                    MessageBox.Show("请在文档中输入样机信息！");
                    return;
                }


                //查询产线数据库，使用的sql命令. IMEI号获取
                //string strSqlTest;
                //SqlCommand cmdTest = null;
                //SqlDataReader dr = null;
                string IMEIPrint = "";

                string PhoneCode;                                                                          //PhoneID作为主键，可以在程序中自动生成，此处无需添加
                string PhoneName;
                string PhoneStage;
                string PhoneStagePrint;
                string PhoneNum;
                //string PhoneStatus = "在库";
                //string PhoneNoteAll;
                string PhoneNote;
                string PhoneNote1;
                string PhoneNote2;
                string PhoneNote3;
                string PhoneNote4;
                //string PhoneNote5;

                string PhoneOwner;

                string log1, log2, log3, log4;

                MExcel.Range rngName = (MExcel.Range)worksheet.Cells[1, 2];
                MExcel.Range rngStage = (MExcel.Range)worksheet.Cells[2, 2];
                //MExcel.Range rngNoteAll = (MExcel.Range)worksheet.Cells[3, 2];
                PhoneName = Convert.ToString(rngName.Value2);                                          //STRING 用来将内容变为字符串
                PhoneStage = Convert.ToString(rngStage.Value2);
                //PhoneNoteAll = Convert.ToString(rngNoteAll.Value2);

                MExcel.Range log1R = (MExcel.Range)worksheet.Cells[3, 1];
                MExcel.Range log2R = (MExcel.Range)worksheet.Cells[3, 5];
                MExcel.Range log3R = (MExcel.Range)worksheet.Cells[3, 6];
                MExcel.Range log4R = (MExcel.Range)worksheet.Cells[3, 7];

                log1 = Convert.ToString(log1R.Value2);                                          //STRING 用来将内容变为字符串
                log2 = Convert.ToString(log2R.Value2);
                log3 = Convert.ToString(log3R.Value2);
                log4 = Convert.ToString(log4R.Value2);

                if (PhoneName == null || PhoneStage == null || log1 == null || log2 == null || log3 == null || log4 == null)
                {
                    MessageBox.Show("'型号' 与 '测试阶段' 是必填内容 或 使用最新模板");
                    return;
                }


                PhoneBLL phonebll = new PhoneBLL();

                //循环打印开始
                for (int i = 4; i <= iRowCount; i++)
                {
                    MExcel.Range rngCode = (MExcel.Range)worksheet.Cells[i, 1];
                    MExcel.Range rngNum = (MExcel.Range)worksheet.Cells[i, 2];
                    //MExcel.Range rngNote = (MExcel.Range)worksheet.Cells[i, 4];
                    MExcel.Range rngOwner = (MExcel.Range)worksheet.Cells[i, 3];
                    MExcel.Range rngNote1 = (MExcel.Range)worksheet.Cells[i, 4];
                    MExcel.Range rngNote2 = (MExcel.Range)worksheet.Cells[i, 5];
                    MExcel.Range rngNote3 = (MExcel.Range)worksheet.Cells[i, 6];
                    MExcel.Range rngNote4 = (MExcel.Range)worksheet.Cells[i, 7];
                    //MExcel.Range rngNote5 = (MExcel.Range)worksheet.Cells[i, 8];

                    PhoneCode = Convert.ToString(rngCode.Value2) + "";
                    PhoneNum = Convert.ToString(rngNum.Value2) + "";

                    PhoneOwner = Convert.ToString(rngOwner.Value2) + "";
                    PhoneNote1 = Convert.ToString(rngNote1.Value2) + "";
                    PhoneNote2 = Convert.ToString(rngNote2.Value2) + "";
                    PhoneNote3 = Convert.ToString(rngNote3.Value2) + "";
                    PhoneNote4 = Convert.ToString(rngNote4.Value2) + "";
                    //PhoneNote5 = Convert.ToString(rngNote5.Value2) + "";
                    PhoneNote = PhoneNote1 + PhoneNote2 + PhoneNote3 + PhoneNote4;

                    PhoneStagePrint = PhoneStage + "_" + PhoneNum;

                    //如果没有PhoneCode时，就设为myname
                    //if (PhoneCode=="")
                    //{
                    //    PhoneCode = "xiechunhui";
                    //}

                    ////////////////////////////////////////////////////////连接产线数据库，查询是否有IMEI号，暂时不打印了。
                    //strSqlTest = "SELECT [dbo].[ESNRecord].IMEI FROM [dbo].[ESNRECORD] INNER JOIN [dbo].[TestReport] on [dbo].[TestReport].PhoneId=[dbo].[ESNRecord].PhoneId and [dbo].[TestReport].PhoneId = "
                    //               + "'" + PhoneCode + "'"; //样机名称combobox内容加载
                    ////打开连接
                    //connSql.Open();
                    ////新建mysql命令
                    //cmdTest = new SqlCommand(strSqlTest, connSql);
                    ////执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                    //dr = cmdTest.ExecuteReader(CommandBehavior.CloseConnection);
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

                    //打印开始******************************************************************************
                    //打开打印端口
                    TSCLIB_DLL.openport("Deli DL-888F(NEW)");
                    //设计打印纸的大小与间距
                    TSCLIB_DLL.setup("30", "20", "3", "10", "0", "2", "0");    //宽度、高度、速度寸/秒、浓度0-15、。 长度30 20 OK,倒数间距2 OK
                    //清空下缓存
                    TSCLIB_DLL.clearbuffer();
                    //打印文字
                    TSCLIB_DLL.windowsfont(1, 15, 22, 0, 0, 0, "標楷體", PhoneName);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    TSCLIB_DLL.windowsfont(1, 38, 22, 0, 0, 0, "標楷體", PhoneStagePrint);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    TSCLIB_DLL.windowsfont(1, 61, 22, 0, 0, 0, "標楷體", PhoneNote1);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    TSCLIB_DLL.windowsfont(1, 84, 22, 0, 0, 0, "標楷體", PhoneNote2);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    TSCLIB_DLL.windowsfont(1, 107, 22, 0, 0, 0, "標楷體", PhoneNote3);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    TSCLIB_DLL.windowsfont(1, 130, 15, 0, 0, 0, "標楷體", PhoneNote4);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容
                    //TSCLIB_DLL.windowsfont(1, 146, 15, 0, 0, 0, "標楷體", PhoneNote5);  //用windowsTTF字型列印文字 X、Y、字体高度、角度、字体外形、有无底线、字体名称、打印内容


                    //打印份数
                    TSCLIB_DLL.printlabel("1", "1");
                    //关闭打印端口
                    TSCLIB_DLL.closeport();
                    //打印结束********************************************************************************


                    //IMEIList.Clear();//IMEI查询时使用，在此不用
                }

                MessageBox.Show("样机信息打印成功^_^");
            }
            catch
            {
                MessageBox.Show("本机电脑可能不能访问产线数据库,有问题请联系 解chunhui");
            }
            finally
            {
                workbook.Close(false, oMissing, oMissing);                          //关闭 工作表
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;

                app.Workbooks.Close();                                              //关闭应用
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;


                //关闭连接
                connSql.Close();


            }
            //COM组件方式读取 EXCEL中的数值
        }

        //private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();

        //    ofd.Title = "打开excel文件";
        //    ofd.Filter = "(*.xlsx),(*.xls)|*.xls*";
        //    //ofd.InitialDirectory = @"";
        //    ofd.RestoreDirectory = true;

        //    string cur_path = Directory.GetCurrentDirectory();          //获取当前路径


        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {

        //        string path = ofd.FileName;     //获取选中文件的名称
        //        string path_filename = DialogResult.ToString();
        //        textBox1.Text = path_filename;


        //        DirectoryInfo dir = Directory.GetParent(ofd.FileName);      //获取选中的文件上一级目录名称
        //        textBox2.Text = dir.ToString() + "\\";


        //        DirectoryInfo TheFolder = new DirectoryInfo(cur_path);              //将当前目录下的所有文件与文件夹列出
        //        foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
        //        {
        //            this.listBox1.Items.Add(NextFolder.Name);
        //        }
        //        foreach (FileInfo nextFile in TheFolder.GetFiles())
        //        {
        //            this.listBox2.Items.Add(nextFile.Name);
        //        }


        //        //ExcelEdit excelEdit = new ExcelEdit();
        //        //excelEdit.Open(path);




        //    }

 



        //}


    }
}

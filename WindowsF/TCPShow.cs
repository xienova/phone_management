using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;   //mysql需要的连接库
using DAL;                      //获取数据库相关信息需要其内部的函数
using Model;

using System.Net.Mail;          //邮件相关
using System.Net;


namespace PhoneSystem
{
    public partial class TCPShow : Form
    {

        public TCPShow()
        {
            InitializeComponent();
        }

        //全局变量设置
        string lP = LoginForm.usrName;      //login Person
        IList<tcpInfo> dstcpDoGrid;             //tcpDoGrid的数据源 datasource

        //完成进度相关显示
        int timeDone = 0;           //已经完成的项目所需要的时间
        int timeScale = 0;          //已经完成的百分比
        int timeAll = 0;            //完成项目所需要的总时间


        int prjAll = 0;             //测试项目的总数
        int prjDone = 0;

        private void cmbprj_SelectedIndexChanged(object sender, EventArgs e)
        {

            timeAll = 0;    //清除所有时间  但在 转给其他同事时也会用到
            timeDone = 0;
            timeScale = 0;
            prjAll = 0;                 //All在下面的 转给其他同事时也会使用到
            prjDone = 0;

            //功能:显示目前已有的测试记录
            string tcpName = cbbPrj.Text.Trim();    //测试项目名称

            //tcpDoGrid的数据源获取
            tcpDAL tcpdal = new tcpDAL();
            dstcpDoGrid = tcpdal.getTcpDo(tcpName);
            tcpDoGrid.DataSource = dstcpDoGrid;

            //tcpDoGrid的属性设置
            tcpDoGrid.ReadOnly = true;
            tcpDoGrid.Columns[0].HeaderText = "员工";   //修改显示的列名
            tcpDoGrid.Columns[1].HeaderText = "开始时间";
            tcpDoGrid.Columns[2].HeaderText = "结束时间";
            tcpDoGrid.Columns[3].HeaderText = "完成";
            tcpDoGrid.Columns[4].HeaderText = "单次用时";

            tcpDoGrid.Columns[0].Width = 55;                   //datagrid 单元格的大小设置
            tcpDoGrid.Columns[1].Width = 120;                   //datagrid 单元格的大小设置
            tcpDoGrid.Columns[2].Width = 120;                   //datagrid 单元格的大小设置
            tcpDoGrid.Columns[3].Width = 40;                   //datagrid 单元格的大小设置
            tcpDoGrid.Columns[4].Width = 100;


            //测试用例的读取
            string tcp_tsk = "";        //获取读自数据库的任务是否选中的信息 字符串
            string[] sig;               //将读到的字符串分割为数组
            int sig_len;                //数组的长度

            //预订信息的读取
            string bookinf = "";   //
            List<string> booklst = new List<string>();      //预订列表 

            //功能1：从数据库中获取各测试项目是否选中信息,及 需要的总时间
            //mysql 连接
 
            string strSql = "select tcp_tsk from tcpprj where tcp_prjname ='" + cbbPrj.Text + "'";
            MySqlConnection conn = new MySqlConnection(GetConn.connection); 

            //打开连接
            conn.Open();
            //新建mysql命令
            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                //将数据库中的 字段tcp_tsk 读出到 字符串tcp_tsk
                tcp_tsk = dr.GetString(0);  //4列为测试项目名称的相关信息
            }
            //关闭DataReader对象
            dr.Close();
            dr.Dispose();


            //功能2:获取项目对应的说明信息
            strSql = "select tcp_prjinf from tcpprj where tcp_prjname = '"+ cbbPrj.Text + "'";
            //打开连接
            conn.Open();
            //新建mysql命令
            cmd = new MySqlCommand(strSql, conn);
            //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                //将数据库中的 字段tcp_tsk 读出到 字符串tcp_tsk
                txtInf.Text = dr.GetString(0);  //测试项目名称的相关信息
            }
            //关闭DataReader对象
            dr.Close();
            dr.Dispose();


            //功能3:获取哪些测试项已经被测试
            List<string> tsklst = new List<string>();       //个人对应的任务列表
            List<int> tsktime = new List<int>();            //任务对应的时间表
            strSql = "select distinct tcp_tskname, tcp_tsktime from tcpshow where tcp_person in(select distinct tcp_person from tcpdo where tcp_prjname ='"+ tcpName + "' and tcp_done = 'true')";

            //打开连接
            conn.Open();
            //新建mysql命令
            cmd = new MySqlCommand(strSql, conn);
            //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                tsklst.Add(dr.GetString(0));
                tsktime.Add(dr.GetInt32(1));            //将已经测试过的测试项目对应的时间在此统计出来 这两个数组的长度是一致的
            }
            //关闭DataReader对象
            dr.Close();
            dr.Dispose();


            //功能4：查寻出预订信息
            strSql = "select tcp_person, tcp_booktm from tcpbook where tcp_prjname = '"+ tcpName +"' and tcp_bookon = 'true'";
            //打开连接
            conn.Open();
            cmd = new MySqlCommand(strSql, conn);
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                bookinf = dr.GetString(0) + "    " + dr.GetString(1);
                booklst.Add(bookinf);

            }
            //关闭DataReader对象
            dr.Close();
            dr.Dispose();


            //功能5：提示样机目前在谁处
            string tcpStm = "";            //最近一次开始的时间
            string tcpPsn = "";            //样机目前在谁处
            //最近一次开始的纪录
            strSql = "select tcp_person,tcp_stm from tcpdo where tcp_doing = 'true' and tcp_prjname = '" + tcpName + "'";
            conn.Open();
            //新建mysql命令
            cmd = new MySqlCommand(strSql, conn);
            //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            txtdoing.Text = "";
            while (dr.Read())
            {
                tcpPsn = dr.GetString(0);
                txtdoing.Text = tcpPsn;
                tcpStm = dr.GetString(1);
            }
            //关闭DataReader对象
            dr.Close();
            dr.Dispose();


            //功能：之前N次使用的时间统计
            DateTime dateTimestm;            //之前每次使用的 初始时间
            DateTime dateTimetm;            //之前每次使用的 结束时间
            TimeSpan timeSpanBefore = new TimeSpan(0);    //初始化timeSpanBefore

            strSql = "select tcp_stm,tcp_etm from tcpdo where tcp_doing = 'false' and tcp_prjname = '" + tcpName + "' and tcp_person= '"+ tcpPsn + "'";
            conn.Open();
            //新建mysql命令
            cmd = new MySqlCommand(strSql, conn);
            //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                dateTimestm = Convert.ToDateTime(dr.GetString(0));
                dateTimetm = Convert.ToDateTime(dr.GetString(1));
                TimeSpan timeSpanBuf =dateTimetm.Subtract(dateTimestm).Duration();
                timeSpanBefore = timeSpanBefore.Add(timeSpanBuf);
            }
            //关闭DataReader对象
            dr.Close();
            dr.Dispose();


            //功能：显示一共进行了多长时间
            TimeSpan timeSpanAll = new TimeSpan(0);         //timespan所有的
            DateTime dateTimeStart = Convert.ToDateTime(tcpStm);    //最近一次的开始时间
            TimeSpan timeSpanNow = DateTime.Now.Subtract(dateTimeStart).Duration();            //最近一次的时间间隔
            timeSpanAll = timeSpanNow.Add(timeSpanBefore);      //所有的时间间隔
            // 向文本框中赋值
            txtShow.Text = timeSpanAll.Days.ToString() + "天" + timeSpanAll.Hours.ToString() + "小时" + timeSpanAll.Minutes.ToString() + "分钟";



        //*****界面相关操作如下***************************************************************************************************************
            //功能1a：显示已选中的测试项目。

            sig = tcp_tsk.Split(',');   //分割字符串到数组
            sig_len = sig.Length;       //获取数组的长度

            //先清除
            foreach (CheckBox c in grpL.Controls)
            {
                c.Checked = false;
                c.Visible = false;          //先让所有的不可见
            }



            //将数组中的选项 对应回 winform
            for (int i = 0; i < sig_len; i++)
            {
                foreach (CheckBox c in grpL.Controls)
                {
                    if (c.Name == sig[i])
                    {
                        c.Checked = true;
                        c.Visible = true;
                        prjAll = prjAll + 1;       //所有测试项目 个数
                    }
                }
            }


            //所有测试项目对应的时间
            foreach (CheckBox c in grpL.Controls)
            {
                if (c.Checked ==true)
                {
                    strSql = "select tcp_tsktime from tcpshow where tcp_tskname = '" + c.Name + "'";
                    timeAll += tcpdal.getInt(strSql);
                }
            }


            //功能3a：显示已经完成的测试项目 及 已经完成的用时
            //先清除
            foreach (CheckBox c in grpL.Controls)
            {
                c.ForeColor = System.Drawing.Color.Black;
                c.Enabled = true;
            }
            //本项目已完成的项目信息
            for (int i = 0; i < tsklst.Count; i++)
            {
                foreach (CheckBox c in grpL.Controls)
                {
                    if ((c.Name == tsklst[i])&& (c.Checked==true))          //当控件名称与已完成的测试项目对应名称相同; 且 它需要做;
                    {
                        c.ForeColor = System.Drawing.Color.Blue;
                        c.Enabled = false;

                        timeDone += tsktime[i];
                        prjDone = prjDone+1;                                 //已经完成的测试项目个数

                    }
                }
            }


            //功能4a:提示已经预约的情况
            txtBook.Text = "";
            for (int i = 0; i < booklst.Count; i++)
            {
                txtBook.Text += (i + 1).ToString() + ": " + booklst[i] + Environment.NewLine;       //格式：序号：   
            }

            //功能5： 清除无关信息 设置有关信息 changed事件
            cbbPsn.Text = "";
            cbbDone.Text = "";

            if(timeAll==0)
            {
                timeScale=0;
            }
            else
            {
                timeScale = timeDone*100/timeAll;
            }
            pgb.Value = timeScale;

            txtAll.Text = prjAll.ToString();
            txtDone.Text = prjDone.ToString();

        }

        //功能: 获取已有样机的信息
        private void TCPShow_Load(object sender, EventArgs e)
        {
            // 获取数据库连接
            MySqlConnection conn = new MySqlConnection(GetConn.connection);
            string strSql = "";

            try
            {
                //功能1: 获取所有项目名称
                //mysql语句
                strSql = "select distinct tcp_prjname from tcpprj where tcp_prjon = 'true'";
                //新建mysql命令
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                //新建dataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                //新建dataSet
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds, "tcpprj");
                conn.Close();

                //去除委托
                cbbPrj.SelectedIndexChanged -= new EventHandler(cmbprj_SelectedIndexChanged);
                //valuemember: 表中字段给程序员使用
                cbbPrj.ValueMember = "tcp_prjname";
                //datasource: 绑定的数据库中的数据源
                cbbPrj.DataSource = ds.Tables["tcpprj"];

                //添加委托
                cbbPrj.SelectedIndexChanged += new EventHandler(cmbprj_SelectedIndexChanged);
                //displaymember：表中字段给用户使用,必须于添加委托后面使用才行
                cbbPrj.DisplayMember = "tcp_prjname";

                //cbbPrj.Text = "";  


                //功能2: 获取所有同事姓名
                //mysql语句
                strSql = "select distinct tcp_person from tcpshow";
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //新建dataAdapter
                da = new MySqlDataAdapter(cmd);

                //新建dataSet
                ds = new DataSet();
                conn.Open();
                da.Fill(ds, "tcppsn");
                conn.Close();


                //displaymember：表中字段给用户使用
                cbbPsn.DisplayMember = "tcp_person";
                //valuemember: 表中字段给程序员使用
                cbbPsn.ValueMember = "tcp_person";
                //datasource: 绑定的数据库中的数据源
                cbbPsn.DataSource = ds.Tables["tcppsn"];

                //清空选项
                cbbPsn.Text = "";  

                //检验连接是否关闭
                //String drState = dr.IsClosed.ToString();
                //String connState = conn.State.ToString();
               // MessageBox.Show(drState + connState);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            /*********************界面实现相关操作******************/


            //功能：界面信息清空
            txtInf.Text = "";
            cbbDone.Text = "";
            txtBook.Text = "";
            txtdoing.Text = "";
            txtShow.Text = "";
            cbbPrj.Text = "";
            cbbPsn.Text = "";
            //清除所有的完成项目
            foreach (CheckBox c in grpL.Controls)
            {
                c.Checked = false;
            }
            foreach (CheckBox c in grpL.Controls)
            {
                c.ForeColor = System.Drawing.Color.Black;
            }

        }

        //预订按钮功能实现 
        private void btnBook_Click(object sender, EventArgs e)
        {

            //界面内容读取
            string tcpName = cbbPrj.Text.Trim();    //测试项目名称
            if (tcpName == "")
            {
                MessageBox.Show("请先选择测试项目");
                return;
            }


            if (MessageBox.Show("确定要预约此样机吗?", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string strSql = "";

                //刷新预订信息时需要用到
                string bookinf = "";   //字符串 用已记录预订信息
                List<string> booklst = new List<string>();      //从数据库中读出的预订列表

                //功能: 获取数据库连接
                MySqlConnection conn = new MySqlConnection(GetConn.connection);   
                try
                {
                    //判断是否已经进行过预约
                    strSql = "select tcp_person from tcpbook where tcp_prjname = '" + tcpName + "' and tcp_bookon = 'true' and tcp_person = '" + lP + "'";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSql, conn);
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        MessageBox.Show("您已经预订过此样机");
                        return;
                    }

                    //关闭DataReader对象
                    dr.Close();
                    dr.Dispose();


                    //预约内容写入数据库
                    strSql = "insert into tcpbook (tcp_person, tcp_prjname, tcp_booktm, tcp_bookon) values ('" + lP  + "','" + tcpName + "','" + DateTime.Now.ToString() + "', 'true')";
                    conn.Open();
                    cmd = new MySqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("预约成功");
                    }
                    conn.Close();
                    //检验是否关闭
                    //String connState = conn.State.ToString();
                    //MessageBox.Show(connState);		
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    //MessageBox.Show(ex.Message);
                }


                //刷新界面显示
                try
                {
                    //功能：查寻出已经预定的相关人信息
                    strSql = "select tcp_person, tcp_booktm from tcpbook where tcp_prjname = '" + tcpName + "' and tcp_bookon = 'true'";
                    //打开连接
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSql, conn);
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        bookinf = dr.GetString(0) + "    " + dr.GetString(1);
                        booklst.Add(bookinf);

                    }

                    //关闭DataReader对象
                    dr.Close();
                    dr.Dispose();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    //MessageBox.Show(ex.Message);
                }
                //提示已经预约的情况
                txtBook.Text = "";
                for (int i = 0; i < booklst.Count; i++)
                {
                    txtBook.Text += (i+1).ToString() + ": " + booklst[i] + Environment.NewLine;
                }


            }
        }

        //功能:取消样机预约
        private void btnCnl_Click(object sender, EventArgs e)
        {

            string tcpName = cbbPrj.Text.Trim();    //测试项目名称
            //刷新预订信息时需要用到
            string bookinf = "";   //字符串 用已记录预订信息
            List<string> booklst = new List<string>();      //从数据库中读出的预订列表

            if (tcpName == "")
            {
                MessageBox.Show("请先选择测试项目");
                return;
            }

            if (MessageBox.Show("确定要取消预约此样机吗?", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                MySqlConnection conn = new MySqlConnection(GetConn.connection);
                string strSql = "";
                try
                {
                    //mysql语句
                    strSql = "update tcpbook set tcp_bookon = 'false' where tcp_person = '" + lP + "' and tcp_prjname='"+ tcpName +"' and tcp_bookon = 'true'";
                    //using的使用可以在程序结束时自动关闭conn;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("取消成功");
                    }
                    else
                    {
                        MessageBox.Show("您没有预约过此样机，或已经取消了预约，请进行确认");
                    }
                    conn.Close(); ;

                    //检验是否关闭
                    //String connState = conn.State.ToString();
                    //MessageBox.Show(connState);		
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    MessageBox.Show(ex.Message);
                }


                //刷新预约界面显示
                try
                {
                    //功能：查寻出已经预定的相关人信息
                    strSql = "select tcp_person, tcp_booktm from tcpbook where tcp_prjname = '" + tcpName + "' and tcp_bookon = 'true'";
                    //打开连接
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSql, conn);
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        bookinf = dr.GetString(0) + "    " + dr.GetString(1);
                        booklst.Add(bookinf);
                    }

                    //关闭DataReader对象
                    dr.Close();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    //MessageBox.Show(ex.Message);
                }
                //提示已经预约的情况
                txtBook.Text = "";
                for (int i = 0; i < booklst.Count; i++)
                {
                    txtBook.Text += (i + 1).ToString() + ": " + booklst[i] + Environment.NewLine;
                }

            }

        }

        //功能:将样机转给下个同事
        private void btnNxt_Click(object sender, EventArgs e)
        {

            string lP = LoginForm.usrName;          //登录同事的姓名
            string tcpName = cbbPrj.Text.Trim();    //测试项目名称
            string tcpPsn = cbbPsn.Text.Trim();     //下一个同事的名字
            string tcpDoneBuf = cbbDone.Text.Trim();

            string tcpDone = "";                    //转义为数据库中的信息

            //总时间与已用时间清零
            timeDone = 0;
            timeScale = 0;
            prjDone = 0;

            if (tcpDoneBuf == "")
            {
                MessageBox.Show("请先选择测试项目是否完成");
                return;
            }
            else
            {
                if (tcpDoneBuf == "是")
                {
                    tcpDone = "true";
                }
                else
                {
                    tcpDone = "false";
                }

            }

            //测试项目为空时,不能转到下一个同事
            if (tcpName == "")
            {
                MessageBox.Show("请先选择测试项目");
                return;
            }

            //下一个同事为空时，不能转到下一同事
            if (tcpPsn == "")
            {
                MessageBox.Show("请先选择要转出到的同事");
                return;

            }


            //功能: 获取数据库连接
            MySqlConnection conn = new MySqlConnection(GetConn.connection);
            string strSql = "";

            //功能:样机只有在同事手中才可以执行此功能,所以先进行判断
            strSql = "select tcp_person from tcpdo where tcp_doing = 'true' and tcp_prjname = '"+ tcpName +"'";
            conn.Open();
            //新建mysql命令
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read() == true)
            {

                if (lP != dr.GetString(0))
                {
                    MessageBox.Show("样机不在您手中,不能执行此功能");
                    return;
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("此样机未在测试，请联系负责人");
                return;
            }
            //关闭DataReader对象
            dr.Close();
            dr.Dispose();


            //确定要转出样机吗？提示
            if (MessageBox.Show("确定要转出吗?", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                //每一次时间间隔变量定义
                DateTime dateTimeBegin;                         //该次使用的 初始时间
                DateTime dateTimeEnd;                           //该次使用的 结束时间
                TimeSpan timeSpanThis = new TimeSpan(0);        //初始化timeSpanThis
                string strTimeSpan = "";


                strSql = "select tcp_stm from tcpdo where tcp_doing = 'true' and tcp_prjname = '" + tcpName + "'";
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    dateTimeBegin = Convert.ToDateTime(dr.GetString(0));      //将字符串转化为DateTime类型,用以实现时间相减操作
                    dateTimeEnd = DateTime.Now;
                    timeSpanThis = dateTimeEnd.Subtract(dateTimeBegin).Duration();

                }
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();
                //获取想要得到的字符串
                strTimeSpan = timeSpanThis.Days.ToString() + "天" + timeSpanThis.Hours.ToString() + "小时" + timeSpanThis.Minutes.ToString() + "分钟";


                try
                {
                    //功能1: 完成自身的信息录入;   tcpdo表
                    //第0次执行操作 用以将 测试用的时间间隔 写入数据表
                    strSql = "update tcpdo set tcp_span = '" + strTimeSpan + "' where tcp_prjname = '" + tcpName + "' and tcp_doing = 'true'";
                    conn.Open();
                    cmd = new MySqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //MessageBox.Show("转让成功");
                    }


                    //第一次执行操作 用以将自身的完成时间与正在执行的 状态修改
                    strSql = "update tcpdo set tcp_etm = '" + DateTime.Now.ToString() + "', tcp_doing = 'false', tcp_done = '"+ tcpDone+ "' where tcp_person = '" + lP + "'and tcp_prjname = '" + tcpName + "' and tcp_doing = 'true'";
                    cmd = new MySqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //MessageBox.Show("转让成功");
                    }
                    //第二次执行操作 用以实现测试项目是否完成的 状态信息的修改(所有的)
                    strSql = "update tcpdo set tcp_done = '" + tcpDone + "' where tcp_person = '" + lP + "'and tcp_prjname = '" + tcpName + "'";
                    cmd = new MySqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //MessageBox.Show("转让成功");
                    }
                    conn.Close();
		
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    //MessageBox.Show(ex.Message);
                }

                //功能2: 替他人进行信息录入   tcpdo表
                try
                {
                    strSql = "insert into tcpdo (tcp_person, tcp_prjname, tcp_stm,tcp_doing) values ('" + tcpPsn + "','" + tcpName + "','" + DateTime.Now.ToString() + "', 'true')";

                    conn.Open();
                    cmd = new MySqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("转让成功");
                    }
                    conn.Close();
                    //检验是否关闭
                    //String connState = conn.State.ToString();
                    //MessageBox.Show(connState);		
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    //MessageBox.Show(ex.Message);
                }


                //功能4：高亮显示已经完成的测试项
                List<string> tsklst = new List<string>();       //个人对应的任务列表
                List<int> tsktime = new List<int>();            //任务对应的时间表
                strSql = "select distinct tcp_tskname, tcp_tsktime from tcpshow where tcp_person in(select distinct tcp_person from tcpdo where tcp_prjname ='" + tcpName + "' and tcp_done = 'true')";

                //打开连接
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    tsklst.Add(dr.GetString(0));
                    tsktime.Add(dr.GetInt32(1));
                }
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();


                //功能4a：显示已经完成的测试项目 及 已经完成的用时
                //先清除
                foreach (CheckBox c in grpL.Controls)
                {
                    c.ForeColor = System.Drawing.Color.Black;
                    c.Enabled = true;
                }

                //本项目已完成的项目信息
                for (int i = 0; i < tsklst.Count; i++)
                {
                    foreach (CheckBox c in grpL.Controls)
                    {
                        if ((c.Name == tsklst[i]) && (c.Checked == true))          //当控件名称与已完成的测试项目对应名称相同; 且 它需要做;
                        {
                            c.ForeColor = System.Drawing.Color.Blue;
                            c.Enabled = false;

                            timeDone += tsktime[i];
                            prjDone = prjDone +1;
                        }
                    }
                }


                //功能5：提示样机目前在谁处
                string tcpStm = "";     //最近一次使用的开始时间
                strSql = "select tcp_person,tcp_stm from tcpdo where tcp_doing = 'true' and tcp_prjname = '" + tcpName + "'";
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                txtdoing.Text = "";
                while (dr.Read())
                {
                    txtdoing.Text = dr.GetString(0);
                    tcpStm = dr.GetString(1);
                }
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();


                //刷新预订信息时需要用到
                string bookinf = "";   //字符串 用已记录预订信息
                List<string> booklst = new List<string>();      //从数据库中读出的预订列表

                //功能5.1: 取消已经预约的个人信息
                try
                {
                    strSql = "update tcpbook set tcp_bookon = 'false' where tcp_person = '" + tcpPsn + "' and tcp_prjname='" + tcpName + "' and tcp_bookon = 'true'";

                    conn.Open();
                    cmd = new MySqlCommand(strSql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //MessageBox.Show("转让成功");
                    }
                    conn.Close();
                    //检验是否关闭
                    //String connState = conn.State.ToString();
                    //MessageBox.Show(connState);		
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    //MessageBox.Show(ex.Message);
                }

                //功能5.1a:实现显示目前的预约信息
                try
                {
                    //功能：查寻出已经预定的相关人信息
                    strSql = "select tcp_person, tcp_booktm from tcpbook where tcp_prjname = '" + tcpName + "' and tcp_bookon = 'true'";
                    //打开连接
                    conn.Open();
                    cmd = new MySqlCommand(strSql, conn);
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        bookinf = dr.GetString(0) + "    " + dr.GetString(1);
                        booklst.Add(bookinf);

                    }

                    //关闭DataReader对象
                    dr.Close();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据写入失败，请联系管理员");
                    //MessageBox.Show(ex.Message);
                }
                //提示已经预约的情况
                txtBook.Text = "";
                for (int i = 0; i < booklst.Count; i++)
                {
                    txtBook.Text += (i + 1).ToString() + ": " + booklst[i] + Environment.NewLine;
                }

                //功能6：样机一共被该同事使用了多长时间
                
                //之前N次使用的时间统计
                DateTime dateTimestm;            //之前每次使用的 初始时间
                DateTime dateTimetm;            //之前每次使用的 结束时间
                TimeSpan timeSpanBefore = new TimeSpan(0);    //初始化timeSpanBefore

                strSql = "select tcp_stm,tcp_etm from tcpdo where tcp_doing = 'false' and tcp_prjname = '" + tcpName + "' and tcp_person= '" + tcpPsn + "'";
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    dateTimestm = Convert.ToDateTime(dr.GetString(0));      //将字符串转化为DateTime类型,用以实现时间相减操作
                    dateTimetm = Convert.ToDateTime(dr.GetString(1));
                    TimeSpan timeSpanBuf = dateTimetm.Subtract(dateTimestm).Duration();
                    timeSpanBefore = timeSpanBefore.Add(timeSpanBuf);
                }
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();


                //最近一次使用了多长时间 与 之前 进行相加得到 最终结果
                TimeSpan timeSpanAll = new TimeSpan(0);         //timespan所有的
                DateTime dateTimeStart = Convert.ToDateTime(tcpStm);    //最近一次的开始时间
                TimeSpan timeSpanNow = DateTime.Now.Subtract(dateTimeStart).Duration();            //最近一次的时间间隔
                timeSpanAll = timeSpanNow.Add(timeSpanBefore);      //所有的时间间隔
                // 向文本框中赋值
                txtShow.Text = timeSpanAll.Days.ToString() + "天" + timeSpanAll.Hours.ToString() + "小时" + timeSpanAll.Minutes.ToString() + "分钟";



                //功能7：样机流转图更新
                //tcpDoGrid的数据源获取
                tcpDAL tcpdal = new tcpDAL();
                dstcpDoGrid = tcpdal.getTcpDo(tcpName);
                tcpDoGrid.DataSource = dstcpDoGrid;


                //测试进度条         转给下一同事事件
                if (timeAll == 0)
                {
                    timeScale = 0;
                }
                else
                {
                    timeScale = timeDone * 100 / timeAll;
                }
                pgb.Value = timeScale;

                txtAll.Text = prjAll.ToString();
                txtDone.Text = prjDone.ToString();


                //功能8: 发邮件功能
                //string tcpEmail = "";                           //邮件地址
                //strSql = "select distinct tcp_email from tcpshow where tcp_person = '"+tcpPsn +"'";
                //tcpEmail = tcpdal.getString(strSql);
                //tcpdal.sendEmail(tcpEmail);                     //发邮件了



            }

        }


        //功能：实现列表最前列的编号功能
        private void tcpDoGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.tcpDoGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.tcpDoGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 10);
        
        }

        private void tsk16_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}

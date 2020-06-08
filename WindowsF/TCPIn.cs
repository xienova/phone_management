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



namespace PhoneSystem
{
    public partial class TCPIn : Form
    {
        
        //第一个同事的名字
        string fP = "孙永萍";
        //登陆同事的名字
        string lP = LoginForm.usrName;
        //lP = LoginForm.usrName;

        //此对象用于获取新的对象 
        tcpDAL tcpdal = new tcpDAL();            

        public TCPIn()
        {
            InitializeComponent();

            //功能：grpL/grpR中的任一个checkbox的checkedChanged事件都绑定为自定义的函数，用以实现功能A/B.
            foreach (CheckBox chk in grpL.Controls)
            {
                chk.CheckedChanged += chkL_changed;
            }
            foreach (CheckBox chk in grpR.Controls)
            {
                chk.CheckedChanged += chkR_changed;
            }

        }

        //当单击chkL(不拆机项的全选)按钮时，全选不拆机项。grpL：为左边不拆机的group组
        private void chkL_Click(object sender, EventArgs e)
        {

            if (chkL.CheckState == CheckState.Checked)
            {
                foreach (CheckBox chk in grpL.Controls)
                    chk.Checked = true;
                chkL.Text = "反选";
            }
            else
            {
                foreach (CheckBox chk in grpL.Controls)
                    chk.Checked = false;
                chkL.Text = "全选";
            }

        }

        //功能：当单击chkR(拆机项的全选)按钮时，全选拆机项。grpR：为右边拆机的group组
        private void chkR_Click(object sender, EventArgs e)
        {

            if (chkR.CheckState == CheckState.Checked)
            {
                foreach (CheckBox chk in grpR.Controls)
                    chk.Checked = true;
                chkR.Text = "反选";
            }
            else
            {
                foreach (CheckBox chk in grpR.Controls)
                    chk.Checked = false;
                chkR.Text = "全选";
            }

        }

        //功能A：定义一个事件，当grpL中的所有chk都选中时，将全选按钮chkL选中；同理也会全不选。
        private void chkL_changed(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked == true)
            {




                foreach (CheckBox c in grpL.Controls)
                {
                    if (c.Checked == false)
                        return;
                }
                chkL.Checked = true;
                chkL.Text = "反选";
            }
            else
            {
                chkL.Checked = false;
                chkL.Text = "全选";
            }
        }

        //功能B：定义一个事件，当grpR中的所有chk都选中时，将全选按钮chkL选中；同理也会全不选。
        private void chkR_changed(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            
            if (chk.Checked == true)
            {
                foreach (CheckBox c in grpR.Controls)
                {
                    if (c.Checked == false)
                        return;
                }
                chkR.Checked = true;
                chkR.Text = "反选";
            }
            else
            {
                chkR.Checked = false;
                chkR.Text = "全选";
            }
        }

        //功能：将项目名称、信息及测试项目写入数据库
        private void btnOK_Click(object sender, EventArgs e)
        {

            //基本变量定义如下:
            //录入项目的名字
            string tcpName = txtName.Text.Trim();
            string tcpInf = txtInf.Text.Trim();
            string strSql = "";

            //判断是否满足录入条件
            //判断是不是负责人进行的录入;
            if (lP != fP)
            {
                MessageBox.Show("您无权创建项目,请联系负责同事");
                return;
            }
            //判断是否录入了信息
            if (tcpName == "" || tcpInf=="") 
            {
                MessageBox.Show("您未录入项目名称或相关说明,请先录入");
                return;
            }


            //功能：将所有的项目信息写入一个变量中，然后读出来
            //所有tsk组成的字符串
            string tcp_tsk="";
            foreach (CheckBox c in grpL.Controls)
            {
                if(c.Checked==true)
                {
                    tcp_tsk += c.Name + ",";
                }
            }
            foreach (CheckBox c in grpR.Controls)
            {
                if (c.Checked == true)
                {
                    tcp_tsk += c.Name + ",";
                }
            }


            //数据库相关操作
            MySqlConnection conn = new MySqlConnection(GetConn.connection);  //获取 数据连接
            try
            {
                //功能1： 判断是否已经录入过该项目，若已经录入只能执行更新操作
                strSql = "select * from tcpprj where tcp_prjname = '" + tcpName + "'";
                //打开连接
                conn.Open();
                //新建mysql命令
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == true)  //为True说明 已经录入过了，不需要重复录入
                {
                    MessageBox.Show("已经录入过该项目信息。想要修改请执行楼下的更新操作");
                    //关闭DataReader对象
                    dr.Close();
                    dr.Dispose();
                    return;
                }

                //关闭DataReader对象
                dr.Close();
                dr.Dispose();


                //功能2:将项目信息 写入 表tcpprj;
                strSql = "insert into tcpprj (tcp_prjname,tcp_prjon,tcp_prjinf,tcp_tsk) values ('"+ tcpName + "','true','"+ tcpInf + "','"+ tcp_tsk + "')";
                conn.Open();    //打开连接
                cmd = new MySqlCommand(strSql, conn);  //新建 执行命令
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //MessageBox.Show("数据写入成功");
                }


                //功能3:将第一个使用同事的信息录入 表tcpdo, 负责人成为第一个正在测试的同事
                strSql = "insert into tcpdo (tcp_person, tcp_prjname, tcp_stm,tcp_doing) values ('" + fP + "','" + tcpName + "','" + DateTime.Now.ToString() + "', 'true')";
                cmd = new MySqlCommand(strSql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("数据录入成功");
                }
                conn.Close();

                //清空界面各选项
                txtInf.Text = "";
                txtName.Text = "";
                foreach (CheckBox chk in grpL.Controls)
                    chk.Checked = false;
                foreach (CheckBox chk in grpR.Controls)
                    chk.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据写入失败，请联系管理员");
            }

        }

        //功能：更新测试项目信息到数据库
        private void btnUp_Click(object sender, EventArgs e)
        {
            //第一个同事的名字
            string fP = "孙永萍";
            //登陆同事的名字
            string lP = LoginForm.usrName;
            //lP = LoginForm.usrName;
            //录入项目的名字
            string tcpName = txtName.Text.Trim();
            string tcpInf = txtInf.Text.Trim();
            string strSql = "";

            //判断是否满足录入条件
            //判断是不是负责人进行的录入;
            if (lP != fP)
            {
                MessageBox.Show("您无权创建项目,请联系负责同事");
                return;
            }
            //判断是否录入了信息
            if (tcpName == "")
            {
                MessageBox.Show("您未录入项目名称或相关说明,请先录入");
                return;
            }



            //功能：将所有的项目信息写入一个变量中，然后读出来
            //所有tsk组成的字符串
            string tcp_tsk = "";
            foreach (CheckBox c in grpL.Controls)
            {
                if (c.Checked == true)
                {
                    tcp_tsk += c.Name + ",";
                }
            }
            foreach (CheckBox c in grpR.Controls)
            {
                if (c.Checked == true)
                {
                    tcp_tsk += c.Name + ",";
                }
            }


            //数据库相关操作
            MySqlConnection conn = new MySqlConnection(GetConn.connection);  //获取 数据连接
            try
            {

                //功能：判断选择的项目是否存在，只有存在时才可以进行更新操作


                strSql = "select * from tcpprj where tcp_prjname = '" + tcpName + "'";
                //打开连接
                conn.Open();
                //新建mysql命令
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == false)   //为False说明之前没有录入过，不能进行更新操作
                {
                    MessageBox.Show("数据库中没有此项目，请检查项目名称");
                    dr.Close();
                    dr.Dispose();
                    return;

                }

                //关闭DataReader对象
                dr.Close();
                dr.Dispose();


                //功能:更新已有tcpprj已有项目的信息;
                strSql = "update tcpprj set tcp_tsk = '" + tcp_tsk + "' where tcp_prjname='" + tcpName + "'";
                conn.Open();    //打开连接
                cmd = new MySqlCommand(strSql, conn);  //新建 执行命令
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("数据更新成功");
                }
                conn.Close();


                //清空界面各选项
                txtInf.Text = "";
                txtName.Text = "";
                foreach (CheckBox chk in grpL.Controls)
                    chk.Checked = false;
                foreach (CheckBox chk in grpR.Controls)
                    chk.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据写入失败，请联系管理员");
            }
            finally
            {

            }

        }

        private void TCPIn_Load(object sender, EventArgs e)
        {

            //功能1:样机信息获取
            //变量定义
            string strSql = "select tcp_prjname from tcpprj ";
            string strTable = "tcpprj";
            DataSet ds = null;

            //执行查询程序
            ds = tcpdal.exeDs(strSql,strTable);

            //却除委托
            cbbName.SelectedIndexChanged -= new EventHandler(cbbName_SelectedIndexChanged);
            //表中字段给程序员使用
            cbbName.ValueMember = "tcp_prjname";
            //dataSource绑定的数据库中的数据源
            cbbName.DataSource = ds.Tables[strTable];

            //添加委托
            cbbName.SelectedIndexChanged += new EventHandler(cbbName_SelectedIndexChanged);
            //表中字段给用户使用，必须于添加委托后面使用
            cbbName.DisplayMember = "tcp_prjname";
            cbbName.Text = "";

            

        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("change");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {

            //tcpDAL tcpdal = new tcpDAL();            //新建对象
            string tcpName = cbbName.Text.Trim();   //样机名称
            string tcpState = cbbState.Text.Trim(); //样机状态
            string strSql = "update tcpprj set tcp_prjon ='" + tcpState + "'where tcp_prjname= '" + tcpName + "'";      //sql语句
            MySqlConnection conn = new MySqlConnection(GetConn.connection);     //新建连接
            //判断是不是负责人进行的录入;
            if (lP != fP)
            {
                MessageBox.Show("您无此权限,请联系负责同事");
                return;
            }
            //判断是否录入了信息
            if (tcpName == "" || tcpState == "")
            {
                MessageBox.Show("请选择特定信息");
                return;
            }

            //执行SQL语句
            //新建对象，执行查询语句
            tcpdal = new tcpDAL();
            if (tcpdal.exeSql(strSql))
            {
                MessageBox.Show("信息更新成功");
            }

            cbbName.Text = "";
            cbbState.Text = "";


        }

        private void btnUpInfo_Click(object sender, EventArgs e)
        {
            //第一个同事的名字
            string fP = "孙永萍";
            //登陆同事的名字
            string lP = LoginForm.usrName;
            //lP = LoginForm.usrName;
            //录入项目的名字
            string tcpName = txtName.Text.Trim();
            string tcpInf = txtInf.Text.Trim();
            string strSql = "";

            //判断是否满足录入条件
            //判断是不是负责人进行的录入;
            if (lP != fP)
            {
                MessageBox.Show("您无权创建项目,请联系负责同事");
                return;
            }
            //判断是否录入了信息
            if (tcpName == "" || tcpInf == "")
            {
                MessageBox.Show("您未录入项目名称或相关说明,请先录入");
                return;
            }



            //功能：将所有的项目信息写入一个变量中，然后读出来
            //所有tsk组成的字符串
            string tcp_tsk = "";
            foreach (CheckBox c in grpL.Controls)
            {
                if (c.Checked == true)
                {
                    tcp_tsk += c.Name + ",";
                }
            }
            foreach (CheckBox c in grpR.Controls)
            {
                if (c.Checked == true)
                {
                    tcp_tsk += c.Name + ",";
                }
            }


            //数据库相关操作
            MySqlConnection conn = new MySqlConnection(GetConn.connection);  //获取 数据连接
            try
            {

                //功能：判断选择的项目是否存在，只有存在时才可以进行更新操作
                strSql = "select * from tcpprj where tcp_prjname = '" + tcpName + "'";
                //打开连接
                conn.Open();
                //新建mysql命令
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == false)   //为False说明之前没有录入过，不能进行更新操作
                {
                    MessageBox.Show("数据库中没有此项目，请检查项目名称");
                    dr.Close();
                    dr.Dispose();
                    return;

                }

                //关闭DataReader对象
                dr.Close();
                dr.Dispose();


                //功能:更新已有tcpprj已有项目的信息;
                strSql = "update tcpprj set tcp_prjinf = '" + tcpInf + "' where tcp_prjname='" + tcpName + "'";
                conn.Open();    //打开连接
                cmd = new MySqlCommand(strSql, conn);  //新建 执行命令
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("数据更新成功");
                }
                conn.Close();


                //清空界面各选项
                txtInf.Text = "";
                txtName.Text = "";
                foreach (CheckBox chk in grpL.Controls)
                    chk.Checked = false;
                foreach (CheckBox chk in grpR.Controls)
                    chk.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据写入失败，请联系管理员");
            }
            finally
            {

            }


        }
    }
}

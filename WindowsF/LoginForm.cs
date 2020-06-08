/*
1、V6.11 
 * 添加了 新的用户名

 * V7.20 
 * 添加了TCP单独更新样机说明功能. 孙
 * 
 * V7.30
 * 添加同事名称
 * 
 * V8.14
 * 还机器时，测试项目的个数可以进行多选
 * 
 * V9.5
 * 借机人增加了 秦婉
 * 
 * V10.24
 * 1、将借还机分开
 * 2、增加产线样机信息
 * 
 * V4.17_19
 * 1、IP地址获取又成了 ip v4
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BLL;
using DAL;
using Model;
using MySql.Data.MySqlClient;



namespace PhoneSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }

        public static string usrName;
        public static string usrPwd;
        public static int usrID;

        public static int admin = 0;                                                    //用于表征是 管理员还是普通用户,普通用户为0,管理员为1
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            usrName = this.cmbName.Text.Trim();

            if (this.cmbName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbName.Focus();
                return;
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(GetConn.connection);
                string str = "select * from PmStaff where StaffName = '" + this.cmbName.Text.Trim() + "'";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                conn.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())                        //若用户名在数据库中存在
                {
                    if (txtPwd.Text.Trim() == "")
                    {
                        this.Hide();
                        UserForm fm = new UserForm();
                        admin = 0;
                                                      //此时进入的是普通员工

                        fm.StartPosition = FormStartPosition.CenterScreen;
                        fm.Show();
                        this.Dispose(false);
                    }
                    else if (txtPwd.Text.Trim() == read["StaffPwd"].ToString().Trim())           //若密码输入正确
                    {

                        if (read["StaffDept"].ToString().Trim() == "管理员")
                        {
                            this.Hide();
                            AdminForm fm = new AdminForm();
                            admin = 1;                                                      //此时进入的管理员
                            //fm.userid.Text = this.cmbName.Text;
                            fm.StartPosition = FormStartPosition.CenterScreen;
                            fm.Show();
                            this.Dispose(false);                                            //清理所有正在使用的资源，这样在关闭主窗体后，才可以对其进行复制与移动。
                        }
                        else if (read["StaffDept"].ToString().Trim() == "员工")
                        {
                            this.Hide();
                            UserForm fm = new UserForm();
                            admin = 0;                                                      //此时进入的是普通员工
                            //fm.userid.Text = this.cmbName.Text;
                            fm.StartPosition = FormStartPosition.CenterScreen;
                            fm.Show();
                            this.Dispose(false);
                        }

                    }
                    else
                    {
                        MessageBox.Show("密码错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPwd.Clear();
                        txtPwd.Focus();
                    }

                    //if (txtPwd.Text.Trim() == read["StaffPwd"].ToString().Trim())           //若密码输入正确
                    //{

                    //    if (read["StaffDept"].ToString().Trim() == "管理员")
                    //    {
                    //        this.Hide();
                    //        AdminForm fm = new AdminForm();
                    //        admin = 1;                                                      //此时进入的管理员
                    //        //fm.userid.Text = this.cmbName.Text;
                    //        fm.Show();
                    //        this.Dispose(false);                                            //清理所有正在使用的资源，这样在关闭主窗体后，才可以对其进行复制与移动。
                    //    }
                    //    else if (read["StaffDept"].ToString().Trim() == "员工")
                    //    {
                    //        this.Hide();
                    //        UserForm fm = new UserForm();
                    //        admin = 0;                                                      //此时进入的是普通员工
                    //        //fm.userid.Text = this.cmbName.Text;
                    //        fm.Show();
                    //        this.Dispose(false);
                    //    }

                    //}
                    //else
                    //{
                    //    MessageBox.Show("密码错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txtPwd.Clear();
                    //    txtPwd.Focus();
                    //}

                }
                else
                {
                    MessageBox.Show("不存在该用户");
                }

                read.Close();       //关闭read对象
                conn.Close();       //关闭连接通道

            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            cmbName.Text = "";
            txtPwd.Text = "";
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        // 测试登陆界面的 Sql server 相关信息
        //private void btn1_Click(object sender, EventArgs e)
        //{

        //    string workname = "";
        //    //sql语句定义
        //    string sql = "select xingming from dbo.yuangong where xingbie = 'nan'";
        //    //定义链接
        //    using (SqlConnection conn = new SqlConnection(GetConn.sqlconn))
        //    {
        //        //定义命令
        //        SqlCommand command = new SqlCommand(sql, conn);
        //        //打开连接
        //        conn.Open();
        //        //执行读取
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            workname = String.Format("{0}", reader[0]);
        //        }

        //        txt1.Text = workname;
        //    }
        //}



    }
}
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
using MySql.Data.MySqlClient;
//using System.Runtime.InteropServices;




namespace PhoneSystem
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        //[DllImport("user32")]
        //public static extern int SetParent(int hWndChild, int hWndNewParent);



        private void UserForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            this.Text = LoginForm.usrName + "---欢迎使用样机管理系统";
            slblTime.Text = slblTime.Text + DateTime.Now.ToString();

            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;


            Form userBorrowInfo = new UserBorrowInfoForm();
            userBorrowInfo.MdiParent = this;
            userBorrowInfo.WindowState = FormWindowState.Maximized;
            userBorrowInfo.Show();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slblTime.Text = "当前时间:" + DateTime.Now.ToString();                          //时间动起来
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
            about.Show();
            //about.TopMost = true;
            //SetParent((int)about.Handle, (int)this.Handle);
            about.WindowState = FormWindowState.Maximized;                          //最大化显示当前窗口

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

        private void 借还机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form userBorrowInfoForm = new UserBorrowInfoForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            userBorrowInfoForm.MdiParent = this;
            userBorrowInfoForm.WindowState = FormWindowState.Maximized;
            userBorrowInfoForm.Show();
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

        private void 我的借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form personal = new Personal();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            personal.MdiParent = this;
            personal.WindowState = FormWindowState.Maximized;
            personal.Show();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoginForm lg = new LoginForm();
            lg.Show();

            this.Dispose(false);


        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginform = new LoginForm();
            loginform.Show();
            //Application.Exit();
        }

        private void 可靠性测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form relyBorrowInfoForm = new RelyBorrowInfoForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            relyBorrowInfoForm.MdiParent = this;
            relyBorrowInfoForm.WindowState = FormWindowState.Maximized;
            relyBorrowInfoForm.Show();
        }

        private void 进度一览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tcpShowForm = new TCPShow();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            tcpShowForm.MdiParent = this;
            tcpShowForm.WindowState = FormWindowState.Maximized;
            tcpShowForm.Show();
        }

        private void 信息输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tcpInForm = new TCPIn();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            tcpInForm.MdiParent = this;
            tcpInForm.WindowState = FormWindowState.Maximized;
            tcpInForm.Show();
        }

        private void 还样机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form userReturnInfoForm = new UserReturnInfoForm();
            for (int x = 0; x < MdiChildren.Length; x++)
            {
                Form tempChild = (Form)MdiChildren[x];
                tempChild.Close();
            }

            userReturnInfoForm.MdiParent = this;
            userReturnInfoForm.WindowState = FormWindowState.Maximized;
            userReturnInfoForm.Show();
        }

    }


}

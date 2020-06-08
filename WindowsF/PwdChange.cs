using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;




namespace PhoneSystem
{
    public partial class PwdChange : Form
    {
        public PwdChange()
        {
            InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            StaffBLL sbl = new StaffBLL();
            string staffName = LoginForm.usrName;

            if (this.txtOldPwd.Text == ""||this.txtNewPwd.Text == "" || this.txtNewPwdAgain.Text=="")           //密码输入不完整
            {
                MessageBox.Show("请输入原密码或新密码");
                return;
            }
            else if (sbl.isStaff(staffName, this.txtOldPwd.Text))           //旧密码正确
            {
                if (this.txtNewPwd.Text == this.txtNewPwdAgain.Text)
                {

                    sbl.changePwd(staffName, this.txtNewPwd.Text);
                    MessageBox.Show("密码修改成功");
                    txtOldPwd.Clear();
                    txtNewPwd.Clear();
                    txtNewPwdAgain.Clear();
                    this.Dispose();

                    
                }
                else
                {
                    MessageBox.Show("两次密码不一致，请重新输入");
                    txtNewPwd.Clear();
                    txtNewPwdAgain.Clear();
                    txtNewPwd.Focus();
                }

            }
            else
            {
                MessageBox.Show("密码错误请重新输入");
                txtOldPwd.Clear();
                txtOldPwd.Focus();
            }


       
        }

        private void PwdChange_Load(object sender, EventArgs e)
        {

        }
    }
}

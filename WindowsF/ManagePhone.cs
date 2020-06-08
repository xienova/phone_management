using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace PhoneSystem
{
    public partial class ManagePhone : Form
    {
        public ManagePhone()
        {
            InitializeComponent();
        }

        private void lblMgr_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            /**************************************判断空项***********************************/
            if (txtPrj.Text == "")
            {
                MessageBox.Show("请输入项目名称");
                return;
            }
            if (txtStage.Text == "")
            {
                MessageBox.Show("请输入项目阶段");
                return;
            }
            if (txtMgr.Text == "")
            {
                MessageBox.Show("请输入测试主管");
                return;
            }


            /*********************************数据库连接**********************************/
            string connStr = "data source=localhost;Initial Catalog=yangji;User ID=root;Password=901230";
            //string cmdStr = "CREATE TABLE F11 (ph_id varchar(20) not null primary key,ph_stage varchar(20))";
            string cmdStr = "CREATE TABLE " + txtPrj.Text + txtStage.Text + "(ph_id varchar(20) primary key, ph_num varchar(20),ph_mgr varchar(20))";
            using(MySqlConnection conn = new MySqlConnection(connStr))
            {
                
                if (conn.State.ToString() != "Open")
                {
                    conn.Open(); 
                }

                using (MySqlCommand cmd = new MySqlCommand(cmdStr, conn))
                {
                    cmd.ExecuteNonQuery();          //
                }
            }
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManagePhone_Load(object sender, EventArgs e)
        {

        }
    }
}

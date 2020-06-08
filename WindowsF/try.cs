using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using BLL;
using Model;
using MySql.Data.MySqlClient;



namespace PhoneSystem
{
    public partial class try1 : Form
    {
       // IList<HGroupInfo> hgroups;


        public try1()
        {
            InitializeComponent();
        }




        private void try_Load(object sender, EventArgs e)
        {
            //HGroupBLL hgroupbll = new HGroupBLL();
            //hgroups = hgroupbll.getAllHgroupNames();

            //cbb.DataSource = hgroups;
            //cbb.DisplayMember = "HGroupName";
            //cbb.ValueMember = "HGroupName";


            MySqlConnection conn = new MySqlConnection(GetConn.connection);         //get HGroupName from DataBase

            string strSql = "select distinct HGroupName from PmGroup";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PmGroup");
            conn.Close();
            cbb.DataSource = ds.Tables["PmGroup"];
            cbb.DisplayMember = "HGroupName";
            cbb.ValueMember = "HGroupName";
            cbb.Text = "";



        }

        private void cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hello world");
        }

        private void assadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

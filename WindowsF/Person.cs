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


namespace PhoneSystem
{
    public partial class Father_son : Form
    {
        public Father_son()
        {
            InitializeComponent();
        }

        string strSql;
        IList<BorrowInfo> borrows;

        private void Father_son_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;

            strSql = "select * from PmBorrow where StaffName = '" + LoginForm.usrName + "' and IsReturn = 'false'";
            MySqlConnection conn = new MySqlConnection(GetConn.connection);                 //显示所有借阅信息
            BorrowBLL borrowbll = new BorrowBLL();
            borrows = borrowbll.selByCondition(strSql);
            userDataGrid.DataSource = borrows;

            userDataGrid.ReadOnly = true;
            userDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            userDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userDataGrid.Width = Fuctions.dataGridViewWidth;
            userDataGrid.Height = Fuctions.dataGridViewHeight;


            userDataGrid.Columns[0].HeaderText = "主键";   //修改显示的列名
            userDataGrid.Columns[0].Visible = false;
            userDataGrid.Columns[1].HeaderText = "员工";
            userDataGrid.Columns[2].HeaderText = "样机名称";
            userDataGrid.Columns[3].HeaderText = "样机阶段";
            userDataGrid.Columns[4].HeaderText = "样机编号";
            userDataGrid.Columns[5].HeaderText = "借用日期";
            userDataGrid.Columns[6].HeaderText = "归还日期";
            userDataGrid.Columns[7].HeaderText = "是否归还";
            userDataGrid.Columns[8].HeaderText = "试验项目";
            userDataGrid.Columns[9].HeaderText = "是否正常";
            userDataGrid.Columns[10].HeaderText = "备注";
            userDataGrid.Columns[11].HeaderText = "备用";
            userDataGrid.Columns[11].Visible = false;

            Fuctions.AutoSizeColumn(userDataGrid);

        }
    }
}

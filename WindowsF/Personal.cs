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



namespace PhoneSystem
{
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
        }

        string strSql;
        IList<BorrowInfo> borrows;


        private void Personal_Load(object sender, EventArgs e)
        {
            this.Width = Fuctions.winFormWidth;
            this.Height = Fuctions.winFormHeight;

            strSql = "select * from PmBorrow where StaffName = '" + LoginForm.usrName + "' and IsReturn = 'false' order by BorrowID DESC";
            BorrowBLL borrowbll = new BorrowBLL();
            borrows = borrowbll.selByCondition(strSql);
            userDataGrid.DataSource = borrows;

            userDataGrid.ReadOnly = true;
            userDataGrid.Width = Fuctions.dataGridViewWidth;
            userDataGrid.Height = Fuctions.dataGridViewHeight;
            userDataGrid.Location = new Point(Fuctions.dataGridViewLocationX, Fuctions.dataGridViewLocationY);

            userDataGrid.Columns[0].HeaderText = "主键";   //修改显示的列名
            userDataGrid.Columns[0].Visible = false;
            userDataGrid.Columns[1].HeaderText = "员工";
            userDataGrid.Columns[2].HeaderText = "名称";
            userDataGrid.Columns[3].HeaderText = "阶段";
            userDataGrid.Columns[4].HeaderText = "编号";
            userDataGrid.Columns[5].HeaderText = "借用日期";
            userDataGrid.Columns[6].HeaderText = "归还日期";
            userDataGrid.Columns[7].HeaderText = "是否归还";
            userDataGrid.Columns[7].Visible = false;
            userDataGrid.Columns[8].HeaderText = "试验项目";
            userDataGrid.Columns[9].HeaderText = "状态";
            userDataGrid.Columns[10].HeaderText = "备注";
            userDataGrid.Columns[11].HeaderText = "操作人";


            userDataGrid.Columns[1].Width = 50;
            userDataGrid.Columns[2].Width = Fuctions.dataGridViewPhoneName;
            userDataGrid.Columns[3].Width = 80;
            userDataGrid.Columns[4].Width = 80;
            userDataGrid.Columns[5].Width = 120;
            userDataGrid.Columns[6].Width = 120;
            userDataGrid.Columns[8].Width = Fuctions.dataGridViewTest; ;
            userDataGrid.Columns[9].Width = 50;
            userDataGrid.Columns[10].Width = 150;
            userDataGrid.Columns[11].Width = 50;

            Fuctions.AutoSize(userDataGrid);




        }

        //功能：实现列表最前列的编号功能
        private void userDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.userDataGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.userDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 10);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.SqlClient;
using System.Windows.Forms;
using Model;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class StaffDAL
    {
 //       private MySqlConnection conn = null;
        private MySqlCommand cmd = null;
        private string sql = null;
        public StaffDAL()
        {
 //           this.conn = new MySqlConnection(GetConn.connection);
            this.cmd = new MySqlCommand();
            this.cmd.CommandType = CommandType.Text;
 //           this.cmd.Connection = this.conn;

            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region 样机管理-查询所有员工信息

        public IList<StaffInfo> getAllStaffs()
        {
            List<StaffInfo> staffs = new List<StaffInfo>();

            //sql = "select * from PmStaff order by CONVERT(staffname USING gbk)";
            sql = "select * from PmStaff ";
            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    staffs.Add(new StaffInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        (dr.IsDBNull(5)) ? " " : dr.GetString(5)
                       ));
                }
                dr.Close();
            }

            return staffs;
        }
        #endregion


        #region 样机管理-增加员工信息

        public bool addStaff(string StaffName, string StaffSex, string StaffDept, string StaffCode)
        {
            bool b = false;
            this.sql = "insert into PmStaff (StaffName,StaffSex,StaffDept,StaffCode) values('" + StaffName + "','" + StaffSex + "','" + StaffDept + "','" + StaffCode +"')";

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    b = true;
                }
                cmd.Dispose();
            }
            return b;
        }
        #endregion


        #region 样机管理-通过StaffName删除员工

        public bool delByStaffName(string staffName)
        {
            bool b = false;

            this.sql = "delete from PmStaff where StaffName = '" + staffName + "'";

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    b = true;
                }

            }
            return b;
        }
        #endregion


        #region 样机管理-通过条件查询读者信息

        public IList<StaffInfo> selByCondition(string Sql)
        {
            List<StaffInfo> staffs = new List<StaffInfo>();

            this.sql = Sql;

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    staffs.Add(new StaffInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        (dr.IsDBNull(5)) ? " " : dr.GetString(5)

                       ));
                }
            }
            return staffs;

        }
        #endregion


        #region 公开的方法（匹配员工姓名 和 密码）

        public bool isStaff(string StaffName, string StaffPwd)
        {
            bool b = false;

            this.sql = "select * from PmStaff where StaffName = '" + StaffName + "' and StaffPwd = '" + StaffPwd + "'";

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                if (dr.Read() )
                {
                    b = true;
                }

            }
            return b;
        }
        #endregion


        #region 样机管理-更改员工密码
        public bool changePwd(string StaffName, string StaffPwd)
        {
            bool b = false;
            this.sql = "update PmStaff set StaffPwd = '" + StaffPwd + "'where StaffName = '" +StaffName+ "'";


            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
                {

                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        b = true;
                    }
                }
                return b;
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return b;
            }
 





        }


        #endregion

    }
}

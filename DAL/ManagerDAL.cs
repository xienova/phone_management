using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Model;



namespace DAL
{
    public class ManagerDAL
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string sql = null;

        public ManagerDAL()
        {
            this.conn = new SqlConnection(GetConn.connection);
            this.cmd = new SqlCommand();
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Connection = this.conn;
        }


        #region 公开的方法（通过id获得管理员信息）

        public List<ManagerInfo> getManagerByID(string id)
        {
            List<ManagerInfo> managers = new List<ManagerInfo>();

            sql = "select * from Manager";
            using (SqlConnection conn = new SqlConnection(GetConn.connection))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    managers.Add(new ManagerInfo(
                        dr.GetString(0),
                        dr.GetString(1)
                       ));
                }
            }
            return managers;
        }
        #endregion


        #region 公开的方法（通过id判断管理员是否存在）

        public bool isExistByID(string id)
        {
            bool b = false;

            this.sql = "select * from Manager where id = " + "'" + id + "'";

            using (SqlConnection conn = new SqlConnection(GetConn.connection))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    b = true;
                }

            }

            return b;
        }
        #endregion


        #region 公开的方法（通过id查询管理员的密码）

        public string getPwdByID(string id)
        {
            this.sql = "select pwd from Manager where id = " + "'" + id + "'";
            string pwd = null;

            using (SqlConnection conn = new SqlConnection(GetConn.connection))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                pwd = cmd.ExecuteScalar().ToString();
            }

            return pwd;
        }
        #endregion


        #region 公开的方法（匹配管理员id和密码）

        public bool isManager(string id, string pwd)
        {
            bool b = false;

            this.sql = "select * from Manager where id = '" + id + "' and pwd = '" + pwd + "'";

            using (SqlConnection conn = new SqlConnection(GetConn.connection))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    b = true;
                }

            }

            return b;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Model;


namespace DAL
{
    public class HGroupDAL
    {
        private string sql = null;

        #region  获取所有实验
        public IList<HGroupInfo> getAllHGroupTests()
        {
            List<HGroupInfo> hgroups = new List<HGroupInfo>();
            sql = "select * from PmGroup";

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    hgroups.Add(new HGroupInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2)
                        ));
                }
                dr.Close();
            }
            return hgroups;
        }

        #endregion 


        #region  获取所有小组名称
        public IList<HGroupInfo> getAllHGroupNames()
        {
            List<HGroupInfo> hgroups = new List<HGroupInfo>();
            sql = "select distinct HGroupName from PmGroup";

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    hgroups.Add(new HGroupInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2)
                        ));
                }
                dr.Close();
            }
            return hgroups;
        }

        #endregion 


    }
}





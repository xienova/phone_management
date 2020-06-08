using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.SqlClient;
using Model;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class StageDAL
    {
        private string sql = null;

        #region 样机管理-查询所有状态

        public IList<StageInfo> getAllStages()
        {
            List<StageInfo> stages = new List<StageInfo>();
            sql = "select * from PmStage ";

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    stages.Add(new StageInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1)
                       ));
                }
            }

            return stages;
        }
        #endregion
    }
}

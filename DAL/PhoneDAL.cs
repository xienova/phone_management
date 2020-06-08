using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
//using System.Data.SqlClient;     sql操作需要
using Model;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class PhoneDAL
    {
        private MySqlConnection conn = null;
        private MySqlCommand cmd = null;
        private string sql = null;

        public PhoneDAL()
        {
            this.conn = new MySqlConnection(GetConn.connection);
            this.cmd = new MySqlCommand();
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Connection = this.conn;
        }


        #region 样机管理-增加样机

        public bool addPhone(string PhoneCode,string PhoneName, string PhoneStage, string PhoneNum,  string PhoneStatus, string PhoneNote, string PhoneOwner, string PhoneCreater)
        {
            bool b = false;
            //DateTime DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            this.sql = "insert into PmPhone (PhoneCode,PhoneName,PhoneStage,PhoneNum,PhoneStatus,PhoneNote,PhoneOwner,PhoneCreater,PhoneBirthday) values ('" + PhoneCode + "','" + PhoneName + "','" + PhoneStage + "','" + PhoneNum + "','"+ PhoneStatus + "','"+ PhoneNote + "','" + PhoneOwner + "','" + PhoneCreater + "','" + DateTime.Now.ToString() + "')";

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


        #region 样机管理-通过PhoneCode删除样机信息

        public bool delByPhoneCode(string PhoneCode)
        {
            bool b = false;

            this.sql = "delete from PmPhone where PhoneDisplay = 'TRUE' and  PhoneCode= '" + PhoneCode + "'";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        b = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return b;
        }

        #endregion


        #region 样机管理-查询无样机

        public IList<PhoneInfo> getNonePhones()
        {
            //phones是一个列表，这里存放了多个phone类的对象， 
            List<PhoneInfo> phones = new List<PhoneInfo>();

            sql = "select * from PmPhone where 1 = 0";
            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    phones.Add(new PhoneInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetString(7),
                        dr.GetString(8),
                        (dr.IsDBNull(9)) ? "" : dr.GetString(9),
                        (dr.IsDBNull(10)) ? "" : dr.GetString(10)
                        ));
                }
                dr.Close();             //读完之后 关闭
            }
            return phones;
        }

        #endregion


        #region 样机管理-查询所有样机

        public IList<PhoneInfo> getAllPhones()
        {
            List<PhoneInfo> phones = new List<PhoneInfo>();

            sql = "select * from PmPhone where PhoneDisplay = 'TRUE' order by PhoneID desc";
            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    phones.Add(new PhoneInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetString(7),
                        dr.GetString(8),
                        (dr.IsDBNull(9)) ? "" : dr.GetString(9),
                        (dr.IsDBNull(10)) ? "" : dr.GetString(10)
                        ));
                }
                dr.Close();             //读完之后 关闭
            }
            return phones;
        }

        #endregion


        #region 样机管理（根据条件查询样机信息）

        public IList<PhoneInfo> selByCondition(string Sql)
        {
            List<PhoneInfo> phones = new List<PhoneInfo>();

            this.sql = Sql;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        phones.Add(new PhoneInfo(
                            dr.GetInt32(0).ToString(),
                            dr.GetString(1),
                            dr.GetString(2),
                            dr.GetString(3),
                            dr.GetString(4),
                            dr.GetString(5),
                            dr.GetString(6),
                            dr.GetString(7),
                            dr.GetString(8),
                            (dr.IsDBNull(9)) ? "" : dr.GetString(9),
                            (dr.IsDBNull(10)) ? "" : dr.GetString(10)
                           ));
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return phones;
        }
        #endregion


        #region 样机管理（根据条件查询样机个数）

        public string selByConditionNum(string Sql)
        {
            List<PhoneInfo> phones = new List<PhoneInfo>();
            int num = 0;
            string phonenum = "";
            this.sql = Sql;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        num += 1;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            phonenum = num.ToString();
            return phonenum;
        }
        #endregion

        #region 样机管理_查询所有在库样机信息

        public IList<PhoneInfo> getAllPhonesInLibrary()
        {
            List<PhoneInfo> phones = new List<PhoneInfo>();

            sql = "select * from PmPhone where Status = '在库' and PhoneDisplay = 'TRUE'";
            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    phones.Add(new PhoneInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetString(7),
                        dr.GetString(8),
                        (dr.IsDBNull(9)) ? "" : dr.GetString(9),
                        (dr.IsDBNull(10)) ? "" : dr.GetString(10)
                       ));
                }
            }
            return phones;
        }
        #endregion


        #region 样机管理-查询所有借出样机信息
        public IList<PhoneInfo> getAllPhonesBorrowed()
        {
            List<PhoneInfo> phones = new List<PhoneInfo>();

            sql = "select * from PmPhone where Status = '借出' and PhoneDisplay = 'TRUE'";
            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    phones.Add(new PhoneInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetString(7),
                        dr.GetString(8),
                        (dr.IsDBNull(9)) ? "" : dr.GetString(9),
                        (dr.IsDBNull(10)) ? "" : dr.GetString(10)
                       ));
                }
            }
            return phones;
        }
        #endregion


        #region 样机管理-查询员工已借的样机信息

        public IList<PhoneInfo> getBorrowedPhones(string StaffName)
        {
            List<PhoneInfo> phones = new List<PhoneInfo>();

            sql = "select * from PmPhone where PhoneDisplay = 'TRUE' and PhoneID in (select PhoneID from PmBorrow where StaffName = '" + StaffName + "')";
            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    phones.Add(new PhoneInfo(
                        dr.GetInt32(0).ToString(),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetString(7),
                        dr.GetString(8),
                        (dr.IsDBNull(9)) ? "" : dr.GetString(9),
                        (dr.IsDBNull(10)) ? "" : dr.GetString(10)
                       ));
                }
            }
            return phones;
        }
        #endregion


        #region 样机管理-更新借出的样机状态为借出

        public bool updatePhoneStatusOut(string PhoneName, string PhoneStage, string PhoneNum)
        {

            bool b = false;
            this.sql = "update PmPhone set PhoneStatus = '借出' where PhoneDisplay = 'TRUE' and PhoneName = '" + PhoneName + "'and PhoneStage = '" + PhoneStage + "' and PhoneNum = '" + PhoneNum + "'";
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


        #region 样机管理-公开的方法（更新归还的样机状态为在库）
        public bool updatePhoneStatusIn(string PhoneName, string PhoneStage, string PhoneNum)
        {
            bool b = false;
            this.sql = "update PmPhone set PhoneStatus = '在库' where PhoneName = '" + PhoneName + "'and PhoneStage = '" + PhoneStage + "' and PhoneNum = '" + PhoneNum + "'";
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


        #region 样机管理-更新样机不许显示

        public bool updatePhoneDisplay(string PhoneName, string PhoneStage, string PhoneDisplay)
        {

            bool b = false;
            this.sql = "update PmPhone set PhoneDisplay = '" + PhoneDisplay + "' where  PhoneName = '" + PhoneName + "'and PhoneStage = '" + PhoneStage + "'";
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



    }

}
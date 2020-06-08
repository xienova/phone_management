using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.SqlClient;
using Model;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class BorrowDAL
    {
        private MySqlConnection conn = null;
        private MySqlCommand cmd = null;
        private string sql = null;


        public BorrowDAL()
        {
            this.conn = new MySqlConnection(GetConn.connection);
            this.cmd = new MySqlCommand();
            this.cmd.CommandType = CommandType.Text;
            this.cmd.Connection = this.conn;

            // TODO: 在此处添加构造函数逻辑
            //
        }



        #region 样机管理-查询所有借阅信息-try catch

        public IList<BorrowInfo> getNoneBorrow()
        {
            List<BorrowInfo> borrows = new List<BorrowInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
                {
                    sql = "select * from PmBorrow where 1 = 0";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        borrows.Add(new BorrowInfo(
                            dr.GetInt32(0).ToString(),
                            dr.GetString(1),
                            dr.GetString(2),
                            dr.GetString(3),
                            dr.GetString(4),
                            dr.GetString(5),
                            (dr.IsDBNull(6)) ? " " : dr.GetString(6),
                            dr.GetString(7),
                            (dr.IsDBNull(8)) ? " " : dr.GetString(8),
                            (dr.IsDBNull(9)) ? " " : dr.GetString(9),
                            (dr.IsDBNull(10)) ? " " : dr.GetString(10),
                            (dr.IsDBNull(11)) ? " " : dr.GetString(11)
                            ));
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return borrows;
        }
        #endregion


        #region 样机管理-查询所有借阅信息-try catch

        public IList<BorrowInfo> getAllBorrow()
        {
            List<BorrowInfo> borrows = new List<BorrowInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
                {
                    sql = "select * from PmBorrow order by BorrowID DESC";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );
                    while (dr.Read())
                    {
                        borrows.Add(new BorrowInfo(
                            dr.GetInt32(0).ToString(),
                            dr.GetString(1),
                            dr.GetString(2),
                            dr.GetString(3),
                            dr.GetString(4),
                            dr.GetString(5),
                            (dr.IsDBNull(6)) ? " " : dr.GetString(6),
                            dr.GetString(7),
                            (dr.IsDBNull(8)) ? " " : dr.GetString(8),
                            (dr.IsDBNull(9)) ? " " : dr.GetString(9),
                            (dr.IsDBNull(10)) ? " " : dr.GetString(10),
                            (dr.IsDBNull(11)) ? " " : dr.GetString(11)
                            ));
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return borrows;
        }
        #endregion


        #region 样机管理-增加一次借阅样机记录-try catch
        //模板： 用以实现数据插入。
        public bool addBorrow(string StaffName, string PhoneName, string PhoneStage, string PhoneNum, string Operator)           //传入4个参数，写入时也将日期写入。
        {
            bool b = false;
            try
            {
                this.sql = "insert into PmBorrow (StaffName, PhoneName, PhoneStage, PhoneNum,BorrowDate,Operator) values ('" + StaffName + "','" + PhoneName + "','" + PhoneStage +"','"+ PhoneNum +"','"+ DateTime.Now.ToString() + "','"+ Operator + "')";

                using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        b = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return b;
        }
        #endregion


        //#region 样机管理-增加多次借阅样机记录-try catch

        //public bool addBorrowT(string StaffName, string PhoneName, string PhoneStage, string PhoneNum)           //传入4个参数，写入时也将日期写入。
        //{
        //    bool b = false;
        //    try
        //    {
        //        this.sql = "insert into PmBorrow (StaffName, PhoneName, PhoneStage, PhoneNum,BorrowDate) values ('" + StaffName + "','" + PhoneName + "','" + PhoneStage + "','" + PhoneNum + "','" + DateTime.Now.ToString() + "')";

        //        using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
        //        {
        //            conn.Open();
        //            MySqlCommand cmd = new MySqlCommand(sql, conn);
        //            if (cmd.ExecuteNonQuery() > 0)
        //            {
        //                b = true;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }
        //    return b;
        //}
        //#endregion

        #region 样机管理-更新借阅样机记录中的归还信息-try catch

        public bool returnPhone(string StaffName, string PhoneName,string PhoneStage,string PhoneNum,string Test,string IsNormal,string Remark)
        {
            bool b = false;
            try
            {
                this.sql = "update PmBorrow set ReturnDate = '" + DateTime.Now.ToString() + "',IsReturn = 'TRUE',Test = '" + Test + "',IsNormal= '" + IsNormal + "',Remark = '" + Remark + "' where StaffName = '" + StaffName + "' and PhoneName = '" + PhoneName + "'and PhoneStage = '"+ PhoneStage +"' and PhoneNum ='" + PhoneNum+ "'";
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return b;
        }
        #endregion


        #region 公开的方法（删除借阅信息）

        public bool delByStaffName(string StaffName, string PhoneName)
        {
            bool b = false;

            this.sql = "delete from PmBorrow where StaffName = " + "'" + StaffName + "' and PhoneName = '" + PhoneName + "'";

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


        #region 样机管理-通过条件查询借阅信息

        public IList<BorrowInfo> selByCondition(string Sql)
        {
            List<BorrowInfo> borrows = new List<BorrowInfo>();

            this.sql = Sql;


            try
            {
                
            }
            catch (Exception ex)
            {

            }

            using (MySqlConnection conn = new MySqlConnection(GetConn.connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );
                while (dr.Read())
                {
                    borrows.Add(new BorrowInfo(
                            dr.GetInt32(0).ToString(),
                            dr.GetString(1),
                            dr.GetString(2),
                            dr.GetString(3),
                            dr.GetString(4),
                            dr.GetString(5),
                            (dr.IsDBNull(6))?"":dr.GetString(6),
                            dr.GetString(7),
                            (dr.IsDBNull(8)) ? "" : dr.GetString(8),
                            (dr.IsDBNull(9)) ? "" : dr.GetString(9),
                            (dr.IsDBNull(10)) ? "" : dr.GetString(10),
                            (dr.IsDBNull(11)) ? "" : dr.GetString(11)
                       ));
                }

            }
            return borrows;

        }
        #endregion


        #region 公开的方法（判断图书是否已经借出）

        public bool isBorrowed(string PhoneName)
        {
            bool b = false;

            this.sql = "select * from PmBorrow where PhoneName = " + "'" + PhoneName + "'";

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

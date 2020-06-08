using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//以下的为自己手动添加的类库文件
using Model;                        //引入自建的数据模型
using System.Windows.Forms;         //引入winform库文件
using MySql.Data.MySqlClient;       //引入mysql的库文件
using System.Data;                  //引入CommandBehavior对象时需要
using System.Net.Mail;          //邮件相关
using System.Net;

namespace DAL
{
    //功能:构建一个tcpDAL的类,用以实现数据的操作功能
    public class tcpDAL
    {
        //基本变量定义 
        MySqlConnection conn = new MySqlConnection(GetConn.connection);     //新建连接
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter da = null;
        private DataSet ds = null;
        private string strSql = "";


        //功能:该类的构造函数,用以构建基本的变量
        public tcpDAL()
        {
            this.cmd = new MySqlCommand();                          //数据库命令变量
        }


        #region tcpdo表相关信息获取
        public IList<tcpInfo> getTcpDo(string tcpName)
        {
            List<tcpInfo> lstTcpDo = new List<tcpInfo>();       //新建一个列表,用以存储tcpInfo类的信息
            strSql = "select tcp_person,tcp_stm,tcp_etm,tcp_done,tcp_span from tcpdo where tcp_prjname ='"+tcpName +"' order by tcp_doid DESC";
            try
            {
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //每读一次,将读到的信息整合成tcpInfo类
                    lstTcpDo.Add(new tcpInfo(
                        (dr.IsDBNull(0)) ? "" : dr.GetString(0),
                        (dr.IsDBNull(1)) ? "" : dr.GetString(1),                //获取字符串的方法
                        (dr.IsDBNull(2)) ? "" : dr.GetString(2),
                        (dr.IsDBNull(3)) ? "" : dr.GetString(3),
                        (dr.IsDBNull(4)) ? "" : dr.GetString(4)
                        ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();
            }
            return lstTcpDo;
        }
        #endregion

        #region read int操作模板
        /// <summary>
        /// 读出一个值 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int getInt(string strSql)
        {
            int IntOut = 0;
            try
            {
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //每读一次,将读到的信息整合成tcpInfo类
                    IntOut = dr.GetInt32(0);
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();
            }
            return IntOut;
        }

        #endregion

        #region read string操作模板
        /// <summary>
        /// 获取一个 字符串
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public string getString(string strSql)
        {
            string StringOut = "";
            try
            {
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //每读一次,将读到的信息整合成tcpInfo类
                    StringOut = dr.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //关闭DataReader对象
                dr.Close();
                dr.Dispose();
            }
            return StringOut;
        }

        #endregion

        #region cud操作模板
        /// <summary>
        /// 执行cud操作
        /// </summary>
        /// <param name="strSql">传入的sql语言</param>
        /// <returns></returns>
        public bool exeSql(string strSql)
        {
            bool b = false;
            try
            {
                conn.Open();
                //新建mysql命令
                cmd = new MySqlCommand(strSql, conn);
                //执行查寻; ExecuteReader() 方法的 CommandBehavior.CloseConnection 参数,会在DataReader对象关闭时也同时关闭Connection对象
                if (cmd.ExecuteNonQuery() > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return b;

        }
        #endregion

        #region dataset获取
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="strSql">Sql语言</param>
        /// <param name="strTable"></param>
        /// <returns>表的名称</returns>
        public DataSet exeDs(string strSql,string strTable)
        {
            try
            {
                cmd = new MySqlCommand(strSql, conn);
                //新建DataAdapter对象
                da = new MySqlDataAdapter(cmd);
                //新建DataSet对象
                ds = new DataSet();
                conn.Open();
                da.Fill(ds, strTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;

        }
        #endregion

        #region Email发送
            
        public void sendEmail(string strEmail)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = "mailcn.hisense.com";
            smtpClient.Credentials = new System.Net.NetworkCredential("xiechunhui@hisense.com", "2016HISENSExie");

            MailMessage mailMessage = new MailMessage("xiechunhui@hisense.com", strEmail);
            mailMessage.Subject = "测试样机目前转到您手中,测试完成后请及时转出,谢谢!";
            mailMessage.Body = "From: \\\\version1\\测试二所 \n\n       测试完后请访问以上路径转出，谢谢！";
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
            //mailMessage.IsBodyHtml = true;//设置为HTML格式　　　　　
            mailMessage.Priority = MailPriority.High;//优先级


            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }


        #endregion

    }


}

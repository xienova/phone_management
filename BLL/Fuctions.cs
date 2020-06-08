using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace BLL
{
    public class Fuctions
    {
        /******************************************************************

         借还机时的字体：微软雅黑：五；
         
         * Combox里的字体：微软雅黑：小五
         
         
         
         *****************************************************************/



        public static int dataGridViewWidth = 950;
        public static int dataGridViewHeight = 370;
        public static int dataGridViewLocationX = 12;
        public static int dataGridViewLocationY = 12;

        public static int winFormWidth = 1010;
        public static int winFormHeight = 720;

        public static int groupBoxWidth = 700;
        public static int groupBoxHeight = 150;

        public static int Admin = 1;

        public static int dataGridViewNote = 339;           //原始为220
        public static int dataGridViewPhoneName = 120;
        public static int dataGridViewPhoneNum = 93;
        public static int dataGridViewTest = 145;



        /// <summary>
        /// 自动调整列宽
        /// </summary>
        /// <param name="dgViewFiles"></param>
        //public static void AutoSizeColumn(DataGridView dgViewFiles)
        //{
        //    int width = 0;
        //    //使列自使用宽度
        //    //对于DataGridView的每一个列都调整
        //    for (int i = 0; i < dgViewFiles.Columns.Count; i++)
        //    {
        //        //将每一列都调整为自动适应模式
        //        dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
        //        //记录整个DataGridView的宽度
        //        width += dgViewFiles.Columns[i].Width;
        //    }
        //    //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
        //    //则将DataGridView的列自动调整模式设置为显示的列即可，
        //    //如果是小于原来设定的宽度，将模式改为填充。
        //    if (width > dgViewFiles.Size.Width)
        //    {
        //        dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        //        dgViewFiles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        //    }
        //    else
        //    {
        //        dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        //        dgViewFiles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        //        //dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //    }
        //    //冻结某列 从左开始 0，1，2
        //    // dgViewFiles.Columns[1].Frozen = true;
        //}
        /// <summary>
        /// 自动列宽
        /// </summary>
        /// <param name="dgViewFiles"></param>
        public static void AutoSize(DataGridView dgViewFiles)
        {

            //dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgViewFiles.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        public static void ShowIndex(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

        }



        /// <summary>
        /// 获取本机的IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIpAddress()
        {
            string hostName = Dns.GetHostName();   //获取本机名
            //IPHostEntry localhost = Dns.GetHostEntry(hostName);    //方法已过期，可以获取IPv4的地址
            IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            IPAddress localaddr = localhost.AddressList[0];

            return localaddr.ToString();
        }

    }
}

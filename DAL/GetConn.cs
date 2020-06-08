using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GetConn
    {
        public static string connection
        {
            //get { return "data source=(local);initial catalog=yangji;integrated security=SSPI";}               //SQL SERVER
           // get { return "data source=(local)\\SQLEXPRESS;Initial Catalog=yangji;Integrated Security=True;"; }   //SQL SERVER
          //  get { return "server = 10.18.205.21; uid = zlb; pwd = 123; database = zhiliangbutest"; }          // Another MYSQL
          //  get { return "Data Source = 10.18.205.21; Initial Catalog = zhiliangbutest; User ID = zlb; PassWord = 123;";}   //工艺部MYSQL
          //get { return "Data Source = localhost; Initial Catalog = tcpdata; User ID = root; PassWord = 901230;"; }        //本地MYSQL
          //get { return "Data Source = 10.19.32.221; Initial Catalog = xiechunhui_nodelete; User ID = root; PassWord = xmgl;";}   //集团MYSQL
         // get { return "Data Source = localhost; Initial Catalog = xiechunhui_nodelete; User ID = root; PassWord =hisense ;"; }        //本地xienodelete
            get { return "Data Source = 172.16.64.53; Initial Catalog =xiechunhui_nodelete;User Id= root;port=3306;Charset=utf8;"; }   // testlink MYSQL

        }



        public static string sqlConn
        {
        //    get { return "data source=(local)\\SQLEXPRESS;Initial Catalog=yichengqiang;Integrated Security=True;"; }   //SQL SERVER   实验室电脑本地数据库
            get { return "data source=172.16.117.5; Initial Catalog = Hts2007; User ID = sa; Password = Hts2007"; }     //SQL SERVER    通信公司数据库

        }

        public static string sqlConnConduct
        {
            //    get { return "data source=(local)\\SQLEXPRESS;Initial Catalog=yichengqiang;Integrated Security=True;"; }   //SQL SERVER   实验室电脑本地数据库
            get { return "data source=172.16.123.88; Initial Catalog = Hts2007; User ID = Hts2007; Password = Hts2007"; }     //SQL SERVER    通信公司数据库

        }



    }
}

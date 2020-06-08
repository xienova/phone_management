using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    // tcpdo表的信息 构建成类.
    public class tcpInfo    //public 是必须的,这样才可以被其他程序调用
    {
        #region 借阅属性 
        public string tcp_person { get; set; }      //借阅人
        public string tcp_stm { get; set; }         //借阅时间
        public string tcp_etm { get; set; }         //归还时间
        public string tcp_done { get; set; }        //是否完成 
        public string tcp_span { get; set; }        //单次使用时间

        #endregion


        #region 构造方法
        public tcpInfo()
        {
            this.tcp_person = null;
            this.tcp_stm = null;
            this.tcp_etm = null;
            this.tcp_done = null;
            this.tcp_span = null;
        }

        #endregion        


        #region 带参数构造方法
        public tcpInfo(string tcp_person, string tcp_stm, string tcp_etm, string tcp_done,string tcp_span)
        {
            this.tcp_person = tcp_person;
            this.tcp_stm = tcp_stm;
            this.tcp_etm = tcp_etm;
            this.tcp_done = tcp_done;
            this.tcp_span = tcp_span;
        }

        #endregion

    }
}

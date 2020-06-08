using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ManagerInfo
    {
        #region 管理员属性

        public string id { get; set; }
        public string pwd { get; set; }
        #endregion


        #region 构造函数

        public ManagerInfo()
        {
            this.id = null;
            this.pwd = null;
        }
        #endregion


        #region 带参数构造函数

        public ManagerInfo(string id,string pwd)
        {
            this.id = id;
            this.pwd = pwd;
        }
        #endregion



    }
}

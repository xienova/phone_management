using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StaffInfo
    {
        #region 读者属性

        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffSex { get; set; }
        public string StaffDept { get; set; }
        public string StaffPwd { get; set; }
        public string StaffCode { get; set; }

        #endregion

        #region 构造方法

        public StaffInfo()
        {
            this.StaffID = null;
            
            this.StaffName = null;
            this.StaffSex = null;
            this.StaffDept = null;
            this.StaffPwd = null;
            this.StaffCode = null;

        }
        #endregion


        #region 带参数构造方法

        public StaffInfo(string StaffID,string StaffName,string StaffSex,string StaffDept,string StaffPwd,string StaffCode)
        {
            this.StaffID = StaffID;
            this.StaffName = StaffName;
            this.StaffSex = StaffSex;
            this.StaffDept = StaffDept;
            this.StaffPwd = StaffPwd;
            this.StaffCode = StaffCode;

        }
        #endregion




    }
}

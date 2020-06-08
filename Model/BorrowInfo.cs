using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class BorrowInfo
    {
        #region 借阅属性
        public string BorrowID { get; set; }
        public string StaffName { get; set; }
        public string PhoneName { get; set; }
        public string PhoneStage { get; set; }
        public string PhoneNum { get; set; }
        public string BorrowDate { get; set; }
        public string ReturnDate { get; set; }
        public string IsReturn { get; set; }
        public string Test { get; set; }
        public string IsNormal { get; set; }
        public string Remark { get; set; }
        public string Pre { get; set; }


        #endregion


        #region 构造方法

        public BorrowInfo()
        {
            this.BorrowID = null;
            this.StaffName = null;
            this.PhoneName = null;
            this.PhoneStage = null;
            this.PhoneNum = null;
            this.BorrowDate = null;
            this.ReturnDate = null;
            this.IsReturn = null;
            this.Test= null;
            this.IsNormal = null;
            this.Remark = null;
            this.Pre = null;

        }

        #endregion        


        #region 带参数构造方法

        public BorrowInfo(string BorrowID,string StaffName, string PhoneName, string PhoneStage, string PhoneNum, 
            string BorrowDate, string ReturnDate, string IsReturn, string Test, string IsNormal, string Remark,string Pre )
        {
            this.BorrowID = BorrowID;
            this.StaffName = StaffName;
            this.PhoneName = PhoneName;
            this.PhoneStage = PhoneStage;
            this.PhoneNum = PhoneNum;
            this.BorrowDate = BorrowDate;
            this.ReturnDate = ReturnDate;
            this.IsReturn = IsReturn;
            this.Test = Test;
            this.IsNormal = IsNormal;
            this.Remark = Remark;
            this.Pre = Pre;
        }

        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PhoneInfo
    {
        #region 样机属性

        public string PhoneID { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneName { get; set; }
        public string PhoneStage { get; set; }
        public string PhoneNum { get; set; }
        public string PhoneStatus { get; set; }
        public string PhoneNote { get; set; }
        public string PhoneOwner { get; set; }
        public string PhoneDisplay { get; set; }
        public string PhoneCreater { get; set; }
        public string PhoneBirthday { get; set; }


        #endregion


        #region 构造函数

        public PhoneInfo()
        {
            this.PhoneID = null;
            this.PhoneCode = null;
            this.PhoneName = null;
            this.PhoneStage = null;
            this.PhoneNum = null;
            this.PhoneStatus = null;
            this.PhoneNote = null;
            this.PhoneOwner = null;
            this.PhoneDisplay = null;
            this.PhoneCreater = null;
            this.PhoneBirthday = null;

        }

        #endregion


        #region 带参数构造函数

        public PhoneInfo(string PhoneID, string PhoneCode,string PhoneName, string PhoneStage, string PhoneNum,  string PhoneStatus, string PhoneNote, string PhoneOwner, string PhoneDisplay,string PhoneCreater,string PhoneBirthday)
        {
            this.PhoneID = PhoneID;
            this.PhoneCode = PhoneCode;
            this.PhoneName = PhoneName;
            this.PhoneStage = PhoneStage;
            this.PhoneNum = PhoneNum;
            this.PhoneStatus = PhoneStatus;
            this.PhoneNote = PhoneNote;
            this.PhoneOwner = PhoneOwner;
            this.PhoneDisplay = PhoneDisplay;
            this.PhoneCreater = PhoneCreater;
            this.PhoneBirthday = PhoneBirthday;

        }

        #endregion

    }
}

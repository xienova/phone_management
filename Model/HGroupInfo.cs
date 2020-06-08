using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Model
{
    public class HGroupInfo
    {
        #region 样机附件属性

        public string HGroupID { get; set; }
        public string HGroupName { get; set; }
        public string HGruopTest {get;set;}

        #endregion

        #region 构造方法

        public HGroupInfo()
        {
            this.HGroupID = null;
            this.HGroupName = null;
            this.HGruopTest = null;
        }
        #endregion


        #region 带参数构造方法

        public HGroupInfo(string HGroupID,string HGroupName,string HGroupTest)
        {
            this.HGroupID = HGroupID;
            this.HGroupName = HGroupName;
            this.HGruopTest = HGruopTest;
        }
        #endregion



    }
}

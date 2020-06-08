using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StageInfo
    {
        #region 样机附件属性

        public string StageID { get; set; }
        public string StageName { get; set; }

        #endregion

        #region 构造方法

        public StageInfo()
        {
            this.StageID = null;
            this.StageName = null;
        }
        #endregion


        #region 带参数构造方法

        public StageInfo(string StageID,string StageName)
        {
            this.StageID = StageID;
            this.StageName = StageName;
        }
        #endregion



    }
}

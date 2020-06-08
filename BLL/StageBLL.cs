using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;


namespace BLL
{
    public class StageBLL
    {
        #region 查询所有状态

        public IList<StageInfo> getAllStages()
        {
            StageDAL stagedal = new StageDAL();
            return stagedal.getAllStages();
        }

        #endregion 




    }
}

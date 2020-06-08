using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;


namespace BLL
{
    public class HGroupBLL
    {

        #region 查询所有实验
        public IList<HGroupInfo> getAllHgroupTests()
        {
            HGroupDAL hgroupdal = new HGroupDAL();
            return hgroupdal.getAllHGroupTests();
        }
        #endregion

        #region 查询所有小组
        public IList<HGroupInfo> getAllHgroupNames()
        {
            HGroupDAL hgroupdal = new HGroupDAL();
            return hgroupdal.getAllHGroupNames();
        }
        #endregion





    }
}

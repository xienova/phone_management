using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;





namespace BLL
{
    public class ManagerBLL
    {

        #region 通过id获得管理员信息

        public List<ManagerInfo> GetManagerByID(string id)
        {
            ManagerDAL mdl = new ManagerDAL();
            return mdl.getManagerByID(id);
        }
        #endregion


        #region 通过id判断管理员是否存在

        public bool isExistByID(string id)
        {
            ManagerDAL md = new ManagerDAL();
            return md.isExistByID(id);
        }
        #endregion


        #region 通过id查询管理员的密码

        public string GetPwdByID(string id)
        {
            ManagerDAL md = new ManagerDAL();
            return md.getPwdByID(id);
        }
        #endregion


        #region 匹配管理员id和密码

        public bool isManager(string id, string pwd)
        {
            ManagerDAL md = new ManagerDAL();
            return md.isManager(id, pwd);
        }
        #endregion



    }
}

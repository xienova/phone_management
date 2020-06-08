using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;


namespace BLL
{
    public class StaffBLL
    {
        #region 样机管理-查询所有读者信息

        public IList<StaffInfo> getAllStaff()
        {
            StaffDAL staffdal = new StaffDAL();
            return staffdal.getAllStaffs();
        }
        #endregion


        #region 样机管理-增加读者信息

        public bool addStaff(string StaffName, string StaffSex, string StaffDept, string StaffCode)
        {
            StaffDAL staffdal = new StaffDAL();

            return staffdal.addStaff(StaffName, StaffSex, StaffDept, StaffCode);
        }
        #endregion


        #region 样机管理-通过StaffName删除读者信息

        public bool delByStaffName(string staffName)
        {
            StaffDAL staffdal = new StaffDAL();
            return staffdal.delByStaffName(staffName);
        }

        #endregion


        #region 通过条件查询读者信息

        public IList<StaffInfo> selByCondition(string Sql)
        {
            StaffDAL staffdal = new StaffDAL();
            return staffdal.selByCondition(Sql);
        }
        #endregion


        #region 匹配员工和密码

        public bool isStaff(string StaffName, string StaffPwd)
        {
            StaffDAL sd = new StaffDAL();
            return sd.isStaff(StaffName, StaffPwd);
        }
        #endregion


        #region 修改员工密码

        public bool changePwd(string StaffName, string StaffPwd)
        {
            StaffDAL sd = new StaffDAL();
            return sd.changePwd(StaffName, StaffPwd);
        }
        #endregion



    }
}

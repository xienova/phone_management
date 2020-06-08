using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;


namespace BLL
{
    public class PhoneBLL
    {
        #region 样机管理-查询所有样机信息

        public IList<PhoneInfo> getAllPhones()
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.getAllPhones();
        }

        #endregion

        #region 样机管理-查询无样机信息

        public IList<PhoneInfo> getNonePhones()
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.getNonePhones();
        }

        #endregion
        #region 样机管理-增加样机信息

        public bool AddPhone(string PhoneCode, string PhoneName, string PhoneStage, string PhoneNum, string PhoneStatus,string PhoneNote,string PhoneOwner, string PhoneCreater)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.addPhone(PhoneCode,PhoneName,PhoneStage,PhoneNum,PhoneStatus,PhoneNote,PhoneOwner,PhoneCreater);
        }
        #endregion


        #region 样机管理-通过PhoneCode删除样机信息

        public bool delByPhoneCode(string PhoneCode)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.delByPhoneCode(PhoneCode);
        }
        #endregion


        #region 通过条件查询样机信息

        public IList<PhoneInfo> selByCondition(string Sql)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.selByCondition(Sql);
        }
        #endregion

        #region 通过条件查询样机数量

        public string selByConditionNum(string Sql)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.selByConditionNum(Sql);
        }
        #endregion
        #region 样机管理-查询所有在库样机

        public IList<PhoneInfo> getAllPhonesInLibrary()
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.getAllPhonesInLibrary();
        }

        #endregion


        #region 样机管理-查询所有借出样机信息

        public IList<PhoneInfo> GetAllPhonesBorrowed()
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.getAllPhonesBorrowed();
        }
        #endregion


        #region 样机管理-查询读者已借样机信息
        public IList<PhoneInfo> GetBorrowedPhones(string StaffID)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.getBorrowedPhones(StaffID);
        }

        #endregion


        #region 样机管理-更新借出的样机状态为借出

        public bool updatePhoneStatusOut(string PhoneName, string PhoneStage, string PhoneNum)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.updatePhoneStatusOut(PhoneName,PhoneStage,PhoneNum);
        }
        #endregion


        #region 样机管理-更新归还的样机状态为在库

        public bool updatePhoneStatusIn(string PhoneName,string PhoneStage,string PhoneNum)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.updatePhoneStatusIn(PhoneName,PhoneStage,PhoneNum);
        }
        #endregion


        #region 样机管理-更新样机不许显示

        public bool updatePhoneDisplay(string PhoneName,string PhoneStage, string PhoneDisplay)
        {
            PhoneDAL phonedal = new PhoneDAL();
            return phonedal.updatePhoneDisplay(PhoneName,PhoneStage,PhoneDisplay);
        }
        #endregion

    }
}

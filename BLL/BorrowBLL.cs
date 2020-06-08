using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class BorrowBLL
    {
        #region 样机管理-查询所有借阅信息

        public IList<BorrowInfo> GetAllBorrow()
        {
            BorrowDAL borrowdal = new BorrowDAL();
            return borrowdal.getAllBorrow();
        }
        #endregion


        #region 样机管理-查询无借阅信息

        public IList<BorrowInfo> GetNoneBorrow()
        {
            BorrowDAL borrowdal = new BorrowDAL();
            return borrowdal.getNoneBorrow();
        }
        #endregion

        #region 样机管理-增加借阅信息

        public bool addBorrow(string StaffName, string PhoneName,string PhoneStage, string PhoneNum, string Operator)
        {
            BorrowDAL borrowdal = new BorrowDAL();

            return borrowdal.addBorrow(StaffName, PhoneName, PhoneStage, PhoneNum, Operator);
        }
        #endregion

        #region 通过StaffName删除借阅信息
        public bool delByStaffName(string StaffName, string PhoneID)
        {
            BorrowDAL borrowdal = new BorrowDAL();
            return borrowdal.delByStaffName(StaffName, PhoneID);
        }

        #endregion

        #region 样机管理-通过条件查询借阅信息

        public IList<BorrowInfo> selByCondition(string strSql)
        {
            BorrowDAL borrowdal = new BorrowDAL();
            return borrowdal.selByCondition(strSql);
        }
        #endregion

        #region 判断图书是否已经借出

        public bool isBorrowed(string PhoneID)
        {
            BorrowDAL borrowdal = new BorrowDAL();
            return borrowdal.isBorrowed(PhoneID);
        }
        #endregion

        #region 样机管理-更新借阅信息中的归还信息

        public bool returnPhone(string StaffName, string PhoneName, string PhoneStage, string PhoneNum, string Test, string IsNormal, string Remark)
        {
            BorrowDAL borrowdal = new BorrowDAL();

            return borrowdal.returnPhone(StaffName, PhoneName,PhoneStage,PhoneNum,Test,IsNormal,Remark);
        }
        #endregion




    }
}

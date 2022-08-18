using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserListBLL
    {
        UserListDAL objClassDAL = new UserListDAL();
        public int UserListBLLSp_InsertUpdateDeleteinfo(int Action, string UserName, DateTime LoginTime, string UserType, int UserID)
        {
            int ret = 0;
            ret = objClassDAL.UserListSp_InsertUpdateDelete(Action, UserName, LoginTime, UserType, UserID);
            return ret;
        }
        
        public DataTable LoadUserList()
        {
            DataTable dt = new DataTable();
            dt = objClassDAL.Get_User_List();
            return dt;
        }
        
    }
}

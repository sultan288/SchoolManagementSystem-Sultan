using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserListDAL
    {
        public int UserListSp_InsertUpdateDelete(int Action,string UserName, DateTime LoginTime, string UserType, int UserID)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("ClassSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "UserName", DbType.String, UserName);
            db.AddInParameter(dbcmd, "LoginTime", DbType.DateTime, LoginTime);
            db.AddInParameter(dbcmd, "UserType", DbType.Int32, UserType);
            db.AddInParameter(dbcmd, "UserID", DbType.Int32, UserID);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }


        public DataTable Get_User_List()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_User_List");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }       

    }
}

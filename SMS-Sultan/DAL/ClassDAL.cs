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
    public class ClassDAL
    {
        public int ClassSp_InsertUpdateDelete(int Action,string ClassName, int EntryBy, int ClassId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Class_Setup_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "ClassName", DbType.String, ClassName);         
            db.AddInParameter(dbcmd, "ClassId", DbType.Int32, ClassId);
            db.AddInParameter(dbcmd, "EntryBy", DbType.Int32, EntryBy);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }


        public DataTable LoadClass()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetSchoolClass");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }       

    }
}

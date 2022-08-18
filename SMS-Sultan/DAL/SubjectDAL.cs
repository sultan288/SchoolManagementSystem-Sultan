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
    public class SubjectDAL
    {
        public int SubjectSp_InsertUpdateDelete(int Action,string SubjectName, int UserId, int SubjectId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SubjectSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "SubjectName", DbType.String, SubjectName);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "SubjectId", DbType.Int32, SubjectId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }


        public DataTable LoadSubject()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetSubject");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }       

    }
}

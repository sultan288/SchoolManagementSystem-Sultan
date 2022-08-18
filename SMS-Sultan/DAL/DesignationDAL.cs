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
    public class DesignationDAL
    {
        public int DesignationSp_InsertUpdateDelete(int Action,string DesignationName,int Position, int UserId, int DesignationId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("DesignationSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DesignationName", DbType.String, DesignationName);
            db.AddInParameter(dbcmd, "Position", DbType.Int32, Position); 
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "DesignationId", DbType.Int32, DesignationId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }


        public DataTable LoadDesignation()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetDesignation");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }       

    }
}

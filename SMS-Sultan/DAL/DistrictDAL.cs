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
    public class DistrictDAL
    {
        public int DistrictSp_InsertUpdateDelete(int Action,string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupDistrict_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DistrictName", DbType.String, DistrictName);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, DistrictId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }


        public DataTable LoadDistrict()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetDistrict");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }       

    }
}

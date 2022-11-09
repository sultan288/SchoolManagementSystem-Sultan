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
    public class SchoolProfileDAL
    {      
        public int School_InsertUpdateDelete_dal(Entity.ESchoolProfile objESchoolProf)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SchoolProfile_InsertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, objESchoolProf.Action);
            db.AddInParameter(dbcmd, "SchoolId", DbType.Int32, objESchoolProf.SchoolId);
            db.AddInParameter(dbcmd, "RegNo", DbType.String, objESchoolProf.RegNo);
            db.AddInParameter(dbcmd, "SchoolName", DbType.String, objESchoolProf.SchoolName);
            db.AddInParameter(dbcmd, "Email", DbType.String, objESchoolProf.Email);
            db.AddInParameter(dbcmd, "Phone", DbType.String, objESchoolProf.Phone);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, objESchoolProf.DistrictId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, objESchoolProf.UpazilaId);
            db.AddInParameter(dbcmd, "Address", DbType.String, objESchoolProf.Address);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, objESchoolProf.EntryBy);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;

        }

        public DataTable Get_SchoolProfile_dal(int schoolid =0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Get_SchoolProfile");

            db.AddInParameter(dbcmd, "SchoolId", DbType.Int32, schoolid);

            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
    }
}

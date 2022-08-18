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
    public class UpazilaDAL
    {
        //public int UpazilaSp_InsertUpdateDelete(int Action,string Category, int UserId, int CategoryId=0)
        //{
        //    int ret = 0;
        //    Database db;
        //    DbCommand dbcmd;
        //    db = DatabaseFactory.CreateDatabase("cnn");
        //    dbcmd = db.GetStoredProcCommand("SetupSp_insertUpdateDelete");

        //    db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
        //    db.AddInParameter(dbcmd, "Cetegory", DbType.String, Category);
        //    db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
        //    db.AddInParameter(dbcmd, "CategoryId", DbType.Int32, CategoryId);

        //    ret = db.ExecuteNonQuery(dbcmd);

        //    return ret;
        //}

        public int UpazilaSp_InsertUpdateDelete(int Action, int DistrictId, string UpazilaName, int UserId, int UpazilaId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupUpazilaSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, DistrictId);
            db.AddInParameter(dbcmd, "UpazilaName", DbType.String, UpazilaName);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, UpazilaId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        //public DataTable LoadCategory()
        //{
        //    DataTable dt = new DataTable();
        //    Database db;
        //    DbCommand dbcmd;
        //    db = DatabaseFactory.CreateDatabase("cnn");
        //    dbcmd = db.GetStoredProcCommand("SetupSp_GetCategory");
        //    dt = db.ExecuteDataSet(dbcmd).Tables[0];

        //    return dt;
        //}
        public DataTable LoadUpazila()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetUpazila");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }


    }
}

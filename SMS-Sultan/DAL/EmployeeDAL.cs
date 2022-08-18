using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class EmployeeDAL
    {
        public int InsertUpdateDelete_Employee(Entity.EEmployee objEEmp)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("EmployeeSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.String, objEEmp.Action);
            db.AddInParameter(dbcmd, "EmployeeId", DbType.String, objEEmp.EmployeeId);
            db.AddInParameter(dbcmd, "FirstName", DbType.String, objEEmp.FirstName);
            db.AddInParameter(dbcmd, "LastName", DbType.String, objEEmp.LastName);
            db.AddInParameter(dbcmd, "EmployeeType", DbType.String, objEEmp.EmployeeType);
            db.AddInParameter(dbcmd, "DesignationId", DbType.Int32, objEEmp.DesignationId);
            db.AddInParameter(dbcmd, "StartingSalary", DbType.Double, objEEmp.StartingSalary);
            db.AddInParameter(dbcmd, "Nationality", DbType.String, objEEmp.Nationality);
            db.AddInParameter(dbcmd, "NID", DbType.String, objEEmp.NID);
            db.AddInParameter(dbcmd, "DOB", DbType.String, objEEmp.DOB);
            db.AddInParameter(dbcmd, "JoiningDate", DbType.String, objEEmp.JoiningDate);
            db.AddInParameter(dbcmd, "ReligionId", DbType.Int32, objEEmp.ReligionId);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, objEEmp.DistrictId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, objEEmp.UpazilaId);
            db.AddInParameter(dbcmd, "Address", DbType.String, objEEmp.Address);
            db.AddInParameter(dbcmd, "Email", DbType.String, objEEmp.Email);
            db.AddInParameter(dbcmd, "ContactNo", DbType.String, objEEmp.ContactNo);
            db.AddInParameter(dbcmd, "Gender", DbType.String, objEEmp.Gender);
            db.AddInParameter(dbcmd, "BloodGroup", DbType.String, objEEmp.BloodGroup);
            db.AddInParameter(dbcmd, "EntryBy", DbType.Int32, objEEmp.EntryBy);          
           


            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable SetupSp_GetEmployee(int EmployeeId)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetEmployee");
            db.AddInParameter(dbcmd, "EmployeeId", DbType.Int32, EmployeeId);
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
    

    }
}

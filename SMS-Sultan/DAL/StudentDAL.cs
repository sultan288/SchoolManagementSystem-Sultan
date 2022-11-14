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
    public class StudentDAL
    {
        public int InsertUpdateDelete_Student(Entity.EStudent objEStu)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("[SetupStudentProfile_insertUpdateDelete]");          

            db.AddInParameter(dbcmd, "Action", DbType.Int32, objEStu.Action);
            db.AddInParameter(dbcmd, "StudentId", DbType.Int32, objEStu.StudentId);
            db.AddInParameter(dbcmd, "RegistrationNo", DbType.String, objEStu.RegistrationNo);
            db.AddInParameter(dbcmd, "FirstName", DbType.String, objEStu.FirstName);
            db.AddInParameter(dbcmd, "LastName", DbType.String, objEStu.LastName);
            db.AddInParameter(dbcmd, "ContactNo", DbType.String, objEStu.ContactNo);
            db.AddInParameter(dbcmd, "FatherName", DbType.String, objEStu.FatherName);
            db.AddInParameter(dbcmd, "FatherContactNo", DbType.String, objEStu.FatherContactNo);
            db.AddInParameter(dbcmd, "FatherOccupation", DbType.String, objEStu.FatherOccupation);
            db.AddInParameter(dbcmd, "MotherName", DbType.String, objEStu.MotherName);
            db.AddInParameter(dbcmd, "MotherContactNo", DbType.String, objEStu.MotherContactNo);
            db.AddInParameter(dbcmd, "MotherOcupation", DbType.String, objEStu.MotherOcupation);
            db.AddInParameter(dbcmd, "GurdianName", DbType.String, objEStu.GurdianName);
            db.AddInParameter(dbcmd, "GurdianName", DbType.String, objEStu.Relation);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, objEStu.DistrictId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, objEStu.UpazilaId);
            db.AddInParameter(dbcmd, "Address", DbType.String, objEStu.Address);            
            db.AddInParameter(dbcmd, "ReligionId", DbType.Int32, objEStu.ReligionId);
            db.AddInParameter(dbcmd, "StuPic", DbType.String, objEStu.StuPic);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, objEStu.EntryBy);

            //db.AddInParameter(dbcmd, "Action", DbType.Int32, objEIns.Action);
            //db.AddInParameter(dbcmd, "InstituteId", DbType.Int32, objEIns.InstituteId);
            //db.AddInParameter(dbcmd, "EIIN_RegistrationNo", DbType.String, objEIns.EIIN_RegistrationNo);
            //db.AddInParameter(dbcmd, "InstituteName", DbType.String, objEIns.InstituteName);
            //db.AddInParameter(dbcmd, "Email", DbType.String, objEIns.Email);
            //db.AddInParameter(dbcmd, "Phone", DbType.String, objEIns.Phone);
            //db.AddInParameter(dbcmd, "Fax", DbType.String, objEIns.Fax);
            //db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, objEIns.DistrictId);
            //db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, objEIns.UpazilaId);
            //db.AddInParameter(dbcmd, "Address", DbType.String, objEIns.Address);
            //db.AddInParameter(dbcmd, "SchoolType", DbType.String, objEIns.SchoolType);
            //db.AddInParameter(dbcmd, "EntryBy", DbType.Int32, objEIns.EntryBy);


            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable SetupSp_GetStudent()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetStudentProfile");           
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        //public DataTable LoadUserReg(int ReligionId, int Gender, int UserID)
        //{
        //    DataTable dt = new DataTable();
        //    Database db;
        //    DbCommand dbcmd;
        //    db = DatabaseFactory.CreateDatabase("cnn");
        //    dbcmd = db.GetStoredProcCommand("AuthSp_GetUserReg");
        //    db.AddInParameter(dbcmd, "ReligionId", DbType.Int32, ReligionId);
        //    db.AddInParameter(dbcmd, "Gender", DbType.Int32, Gender);
        //    db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserID);
        //    dt = db.ExecuteDataSet(dbcmd).Tables[0];

        //    return dt;
        //}

    }
}

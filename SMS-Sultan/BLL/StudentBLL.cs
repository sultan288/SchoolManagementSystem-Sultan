using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity; 
using System.Data;

namespace BLL
{
    
    public class StudentBLL
    {
        StudentDAL objStuDAL = new StudentDAL();
        
        public int InsertUpdateDelete_StudentInfo(EStudent objEStu)
        {
            int ret = 0;
            ret = objStuDAL.InsertUpdateDelete_Student(objEStu);
            return ret;
        }

        public DataTable SetupSp_GetStudentDT()
        {
            DataTable dt = new DataTable();
            dt = objStuDAL.SetupSp_GetStudent();
            return dt;
        }


    }
}

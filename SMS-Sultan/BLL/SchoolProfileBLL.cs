using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace BLL
{
    public class SchoolProfileBLL
    {
        SchoolProfileDAL objSchooldal = new SchoolProfileDAL();
        public int School_InsertUpdateDelete_bll(ESchoolProfile objESchool)
        {
            int ret = 0;
            ret = objSchooldal.School_InsertUpdateDelete_dal(objESchool);

            return ret;
        }

        public DataTable Get_SchoolProfile_bll(int schoolid = 0)
        {
            DataTable dt = new DataTable();
            dt = objSchooldal.Get_SchoolProfile_dal(schoolid);
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SubjectBLL
    {
        SubjectDAL objSubjectDAL = new SubjectDAL();
        public int SubjectSp_InsertUpdateDelete(int Action, string SubjectName, int UserId, int SubjectId = 0)
        {
            int ret = 0;
            ret = objSubjectDAL.SubjectSp_InsertUpdateDelete(Action, SubjectName, UserId, SubjectId);
            return ret;
        }
        
        public DataTable LoadSubjectList()
        {
            DataTable dt = new DataTable();
            dt = objSubjectDAL.LoadSubject();
            return dt;
        }
        
    }
}

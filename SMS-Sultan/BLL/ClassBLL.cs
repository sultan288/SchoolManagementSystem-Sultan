using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ClassBLL
    {
        ClassDAL objClassDAL = new ClassDAL();
        public int ClassSp_InsertUpdateDelete(int Action, string ClassName, int UserId, int ClassId = 0)
        {
            int ret = 0;
            ret = objClassDAL.ClassSp_InsertUpdateDelete(Action, ClassName, UserId, ClassId);
            return ret;
        }
        
        public DataTable LoadClassList()
        {
            DataTable dt = new DataTable();
            dt = objClassDAL.LoadClass();
            return dt;
        }
        
    }
}

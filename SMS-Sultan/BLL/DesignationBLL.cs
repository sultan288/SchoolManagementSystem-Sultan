using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DesignationBLL
    {
        DesignationDAL objDesignationDAL = new DesignationDAL();
        public int DesignationSp_InsertUpdateDeleteInfo(int Action, string DesignationName, int Position, int UserId, int DesignationId = 0)
        {
            int ret = 0;
            ret = objDesignationDAL.DesignationSp_InsertUpdateDelete(Action, DesignationName, Position, UserId, DesignationId);
            return ret;
        }
        
        public DataTable LoadDesignationList()
        {
            DataTable dt = new DataTable();
            dt = objDesignationDAL.LoadDesignation();
            return dt;
        }
        
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UpazilaBLL
    {
        UpazilaDAL objUpazilaDAL = new UpazilaDAL();

        //public int Setup_InsertUpdateDelete(int Action, string Category, int UserId, int CategoryId = 0)
        //{
        //    int ret = 0;
        //    ret = objUpazilaDAL.Setup_InsertUpdateDelete(Action,Category,UserId,CategoryId);
        //    return ret;
        //}
        public int UpazilaSp_InsertUpdateDeleteInfo(int Action, int DistrictId, string UpazilaName, int UserId, int UpazilaId = 0)
        {
            int ret = 0;
            ret = objUpazilaDAL.UpazilaSp_InsertUpdateDelete(Action, DistrictId, UpazilaName, UserId, UpazilaId);
            return ret;
        }
      
        public DataTable LoadUpazila()
        {
            DataTable dt = new DataTable();
            dt = objUpazilaDAL.LoadUpazila();
            return dt;
        }
    }
}

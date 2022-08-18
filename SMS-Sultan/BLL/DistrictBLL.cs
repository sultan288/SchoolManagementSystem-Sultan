using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DistrictBLL
    {
        DistrictDAL objDistrictDAL = new DistrictDAL();
        public int DistrictSp_InsertUpdateDelete(int Action, string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;
            ret = objDistrictDAL.DistrictSp_InsertUpdateDelete(Action, DistrictName, UserId, DistrictId);
            return ret;
        }
        
        public DataTable LoadDistrictList()
        {
            DataTable dt = new DataTable();
            dt = objDistrictDAL.LoadDistrict();
            return dt;
        }
        
    }
}

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
    
    public class EmployeeBLL
    {
        EmployeeDAL objEmpDAL = new EmployeeDAL();
        
        
        public int InsertUpdateDelete_EmployeeInfo(EEmployee objEEmp)
        {
            int ret = 0;
            ret = objEmpDAL.InsertUpdateDelete_Employee(objEEmp);
            return ret;
        }

        public DataTable SetupSp_GetEmployee(int EmployeeId = 0)
        {
            DataTable dt = new DataTable();
            dt = objEmpDAL.SetupSp_GetEmployee(EmployeeId);
            return dt;
        }


    }
}

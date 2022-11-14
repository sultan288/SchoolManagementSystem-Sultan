using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementSystem
{
    public partial class PhoneBook : System.Web.UI.Page
    {
        string ConStr = @"Data Source=DESKTOP-36V5R2R;Initial Catalog=SchoolManagementSystem-Sultan;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("Select * from PhoneBook", ConStr);
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                gvPhone.DataSource = dt;
                gvPhone.DataBind();

            };
                
                
                

        }
    }
}
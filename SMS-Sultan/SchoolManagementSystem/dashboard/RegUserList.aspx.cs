using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.dashboard
{   
    public partial class RegUserList : System.Web.UI.Page
    {
        string ConStr = @"Data Source=DESKTOP-36V5R2R;Initial Catalog=SchoolManagementSystem-Sultan;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }

        public void PopulateGridView()
        {
            DataTable dt = new DataTable();
            using (SqlConnection SqlCon = new SqlConnection(ConStr))
            {
                SqlCon.Open();
                SqlDataAdapter SqlDA = new SqlDataAdapter("SELECT FirstName, LastName, UserName, ContactNo, Email, Address FROM Register", ConStr);
                SqlDA.Fill(dt);              
            }
            gvRegList.DataSource = dt;
            gvRegList.DataBind();
        }

        protected void gvRegList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void gvRegList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRegList.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvRegList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRegList.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvRegList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SchoolManagementSystem.dashboard
{
    public partial class User_List : System.Web.UI.Page
    {
         UserListBLL ulBLL = new UserListBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = ulBLL.LoadUserList();
            if (dt.Rows.Count > 0)
            {
                gvUserList.DataSource = dt;
                gvUserList.DataBind();
            }
            else
            {
                gvUserList.DataSource = null;
                gvUserList.DataBind();
            }
        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                //save = ulBLL.UserListBLLSp_InsertUpdateDeleteinfo(1, txtUserName.Text, DateTime.Parse(txtLoginTime.Text), txtUserType.SelectedValue, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmUlist.SuccessMessage = "Save done";
                    LoadGrid();
                    txtUserName.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
               // save = ulBLL.UserListBLLSp_InsertUpdateDeleteinfo(2, txtUserName.Text, DateTime.Parse(txtLoginTime.Text), txtUserType.SelectedValue, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateULId.Value));
                if (save > 0)
                {
                    rmUlist.SuccessMessage = "Update done";
                    LoadGrid();
                    txtUserName.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvClass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnClassId = (HiddenField)gvUserList.Rows[rowindex].FindControl("hdnClassId");
            Label lblClass = (Label)gvUserList.Rows[rowindex].FindControl("lblClass");

            if (e.CommandName == "editc")
            {
                hdnUpdateULId.Value = hdnClassId.Value;
                txtUserName.Text = lblClass.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {

                //int save = ulBLL.ClassSp_InsertUpdateDelete(3, txtUserName.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnClassId.Value));
                //if (save > 0)
                {
                    rmUlist.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtUserName.Text = "";
                }
            }
        }
    }
}
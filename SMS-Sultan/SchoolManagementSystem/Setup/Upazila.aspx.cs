using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SchoolManagementSystem.Setup
{
    public partial class Upazila : System.Web.UI.Page
    {
        UpazilaBLL objUpazilaBLL = new UpazilaBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId, DistrictName FROM Conf_District ORDER BY DistrictName", "DistrictName", "DistrictId");
            }
        }
        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objUpazilaBLL.LoadUpazila();
            if (dt.Rows.Count > 0)
            {
                gvDistrict.DataSource = dt;
                gvDistrict.DataBind();
            }
            else
            {
                gvDistrict.DataSource = null;
                gvDistrict.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;
            if (ddlDistrict.SelectedValue != "0" && txtUpazila.Text != "")
            {

                if (btnSave.Text == "Save")
                {
                    save = objUpazilaBLL.UpazilaSp_InsertUpdateDeleteInfo(1, int.Parse(ddlDistrict.SelectedValue), txtUpazila.Text, int.Parse(Session["UserId"].ToString()), 0);
                    if (save > 0)
                    {
                        rmUpazila.SuccessMessage = "Save done";
                        LoadGrid();
                        txtUpazila.Text = "";
                        ddlDistrict.SelectedValue = "0";
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    save = objUpazilaBLL.UpazilaSp_InsertUpdateDeleteInfo(2, int.Parse(ddlDistrict.SelectedValue), txtUpazila.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateUpazilaId.Value));
                    if (save > 0)
                    {
                        rmUpazila.SuccessMessage = "Update done";
                        LoadGrid();
                        txtUpazila.Text = "";
                        ddlDistrict.SelectedValue = "0";
                        btnSave.Text = "Save";
                    }
                }
            }
            else
            {
                rmUpazila.FailureMessage = "Give Correct infomation";
            }
        }

        protected void gvDistrict_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnDistrictId = (HiddenField)gvDistrict.Rows[rowindex].FindControl("hdnDistrictId");
            HiddenField hdnUpazilaId = (HiddenField)gvDistrict.Rows[rowindex].FindControl("hdnUpazilaId");
            Label lblUpazila = (Label)gvDistrict.Rows[rowindex].FindControl("lblUpazila");

            if (e.CommandName == "editc")
            {
                hdnUpdateUpazilaId.Value = hdnUpazilaId.Value;
                ddlDistrict.SelectedValue = hdnDistrictId.Value;
                txtUpazila.Text = lblUpazila.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                int save1 = objUpazilaBLL.UpazilaSp_InsertUpdateDeleteInfo(3, int.Parse(hdnDistrictId.Value), lblUpazila.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpazilaId.Value));
                if (save1 > 0)
                {
                    rmUpazila.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtUpazila.Text = "";
                }
            }
        }
    }
}
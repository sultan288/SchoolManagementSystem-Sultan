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
    public partial class Designation : System.Web.UI.Page
    {
        DesignationBLL objDesignationBLL = new DesignationBLL();
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
            dt = objDesignationBLL.LoadDesignationList();
            if (dt.Rows.Count > 0)
            {
                gvDesignation.DataSource = dt;
                gvDesignation.DataBind();
            }
            else
            {
                gvDesignation.DataSource = null;
                gvDesignation.DataBind();
            }
        }


        protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnDesignationId = (HiddenField)gvDesignation.Rows[rowindex].FindControl("hdnDesignationId");
            Label lblDesignation = (Label)gvDesignation.Rows[rowindex].FindControl("lblDesignation");
            Label lblPosition = (Label)gvDesignation.Rows[rowindex].FindControl("lblPosition");

            if (e.CommandName == "editc")
            {
                hdnUpdateDesignationId.Value = hdnDesignationId.Value;
                TxtDesignation.Text = lblDesignation.Text;
                TxtPosition.Text = lblPosition.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {

                //int save1 = objDesignationBLL.DesignationSp_InsertUpdateDeleteInfo(3, txtDesignation.Text, int.Parse(txtPosition.Text), int.Parse(Session["UserId"].ToString()), int.Parse(hdnDesignationId.Value));
                int save = objDesignationBLL.DesignationSp_InsertUpdateDeleteInfo(3, "", 0, 0, int.Parse(hdnDesignationId.Value));
                if (save > 0)
                {
                    rmDesignation.SuccessMessage = "Delete done";
                    LoadGrid();
                    TxtDesignation.Text = "";
                    TxtPosition.Text = "";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objDesignationBLL.DesignationSp_InsertUpdateDeleteInfo(1, TxtDesignation.Text, int.Parse(TxtPosition.Text), int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmDesignation.SuccessMessage = "Save done";
                    LoadGrid();
                    TxtDesignation.Text = "";
                    TxtPosition.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objDesignationBLL.DesignationSp_InsertUpdateDeleteInfo(2, TxtDesignation.Text, int.Parse(TxtPosition.Text), int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateDesignationId.Value));
                if (save > 0)
                {
                    rmDesignation.SuccessMessage = "Update done";
                    LoadGrid();
                    TxtDesignation.Text = "";
                    TxtPosition.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }
    }
}
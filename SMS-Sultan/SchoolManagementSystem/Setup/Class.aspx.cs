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
    public partial class Class : System.Web.UI.Page
    {
        ClassBLL objClass = new ClassBLL();
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
            dt = objClass.LoadClassList();
            if (dt.Rows.Count > 0)
            {
                gvClass.DataSource = dt;
                gvClass.DataBind();
            }
            else
            {
                gvClass.DataSource = null;
                gvClass.DataBind();
            }
        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objClass.ClassSp_InsertUpdateDelete(1, txtClass.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmClass.SuccessMessage = "Save done";
                    LoadGrid();
                    txtClass.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objClass.ClassSp_InsertUpdateDelete(2, txtClass.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateClassId.Value));
                if (save > 0)
                {
                    rmClass.SuccessMessage = "Update done";
                    LoadGrid();
                    txtClass.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvClass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnClassId = (HiddenField)gvClass.Rows[rowindex].FindControl("hdnClassId");
            Label lblClass = (Label)gvClass.Rows[rowindex].FindControl("lblClass");

            if (e.CommandName == "editc")
            {
                hdnUpdateClassId.Value = hdnClassId.Value;
                txtClass.Text = lblClass.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {

                int save1 = objClass.ClassSp_InsertUpdateDelete(3, txtClass.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnClassId.Value));
                if (save1 > 0)
                {
                    rmClass.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtClass.Text = "";
                }
            }
        }
    }
}
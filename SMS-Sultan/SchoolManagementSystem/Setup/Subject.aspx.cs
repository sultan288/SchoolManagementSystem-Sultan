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
    public partial class Subject : System.Web.UI.Page
    {
        SubjectBLL objSubject = new SubjectBLL();
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
            dt = objSubject.LoadSubjectList();
            if (dt.Rows.Count > 0)
            {
                gvSubject.DataSource = dt;
                gvSubject.DataBind();
            }
            else
            {
                gvSubject.DataSource = null;
                gvSubject.DataBind();
            }
        }
       

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objSubject.SubjectSp_InsertUpdateDelete(1, txtSubject.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmSubj.SuccessMessage = "Save done";
                    LoadGrid();
                    txtSubject.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objSubject.SubjectSp_InsertUpdateDelete(2, txtSubject.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateSId.Value));
                if (save > 0)
                {
                    rmSubj.SuccessMessage = "Update done";
                    LoadGrid();
                    txtSubject.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvSubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnSubjectId = (HiddenField)gvSubject.Rows[rowindex].FindControl("hdnSubjectId");
            Label lblSubject = (Label)gvSubject.Rows[rowindex].FindControl("lblSubject");

            if (e.CommandName == "editc")
            {
                hdnUpdateSId.Value = hdnSubjectId.Value;
                txtSubject.Text = lblSubject.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                int save1 = objSubject.SubjectSp_InsertUpdateDelete(3, txtSubject.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnSubjectId.Value));
                if (save1 > 0)
                {
                    rmSubj.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtSubject.Text = "";
                }
            }
        }
    }
}
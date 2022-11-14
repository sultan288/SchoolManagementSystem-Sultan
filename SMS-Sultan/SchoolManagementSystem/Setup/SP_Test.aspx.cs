using DAL;
using BLL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SchoolManagementSystem.Setup
{
    public partial class ConSchool : System.Web.UI.Page
    {
        SchoolProfileBLL objSpBLL = new SchoolProfileBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId, DistrictName FROM Conf_District ORDER BY DistrictName", "DistrictName", "DistrictId");
                LoadGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                save();

                LoadGrid();
            }

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
               "swal('Good job!', 'You clicked the button!', 'success')", true);
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSpBLL.Get_SchoolProfile_bll();
            //if (dt.Rows.Count > 0)
            
                gvSchool.DataSource = dt;
                gvSchool.DataBind();
            
            //else
            
                gvSchool.DataSource = null;
                gvSchool.DataBind();
            
        }
        private void save()
        {
            int save = 0;
            ESchoolProfile objESp = new ESchoolProfile();


            objESp.SchoolId = 0;
            objESp.RegNo = txtRegno.Text;
            objESp.SchoolName = txtSchoolName.Text;
            objESp.Email = txtEmail.Text;
            objESp.Phone = txtPhone.Text;
          
            objESp.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objESp.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objESp.Address = txtAddress.Text;
           
            objESp.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text == "Save")
            {
                objESp.Action = 1;
                objESp.SchoolId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objESp.Action = 2;
                objESp.SchoolId = int.Parse(hdnUpdateSpId.Value);
            }

            save = objSpBLL.School_InsertUpdateDelete_bll(objESp);
            if (save > 0)
            {
                ResponseInstitute.SuccessMessage = btnSave.Text + " Complete Successfully.";

                btnSave.Text = "Save";
            }

        }
        private void DeleteInstitute(int SchoolId)
        {
            int save = 0;
            ESchoolProfile objESp = new ESchoolProfile();


            objESp.RegNo = "";
            objESp.SchoolName = "";
            objESp.Email = "";
            objESp.Phone = "";
            
            objESp.DistrictId = 0;
            objESp.UpazilaId = 0;
            objESp.Address = "";
           
            objESp.EntryBy = 0;

            objESp.Action = 3;
            objESp.SchoolId = SchoolId;

            save = objSpBLL.School_InsertUpdateDelete_bll(objESp);
            if (save > 0)
            {
                ResponseInstitute.SuccessMessage = "Delete Successfully.";
                LoadGrid();
            }

        }
        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtRegno.Text == "")
            {
                IsReq = true;
                ResponseInstitute.FailureMessage = "Username can't be empty";
            }
            else if (txtSchoolName.Text == "")
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "Password can't be empty";
            }
            else if (txtEmail.Text == "")
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "Password can't be empty";
            }
            else if (txtPhone.Text == "")
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "Password can't be empty";
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "District can't be empty";
            }
            else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedIndex == -1)
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "Upazila can't be empty";
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "Password can't be empty";
            }
           

            return IsReq;
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }

        protected void gvInstitute_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnSpId = (HiddenField)gvSchool.Rows[rowindex].FindControl("hdnSpId");

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnSpId.Value));
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                DeleteInstitute(int.Parse(hdnSpId.Value));
            }
        }

        private void FillControl(int SchoolId)
        {
            DataTable dt = new DataTable();
            dt = objSpBLL.Get_SchoolProfile_bll(SchoolId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateSpId.Value = SchoolId.ToString();
                txtRegno.Text = dt.Rows[0]["RegNo"].ToString();
                txtSchoolName.Text = dt.Rows[0]["SchoolName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();
                CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
              

            }
        }

        protected void AlertButton(object sender, EventArgs e)
        {
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
            //  "swal('Good job!', 'You clicked the button!', 'success')", true); 

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
               "swal('Good job!', 'You clicked the button!', 'success')", true);

            //swal("Good job!", "You clicked the button!", "success");
        }
    }
}
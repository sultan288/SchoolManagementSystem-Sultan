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
    public partial class ConInstitute : System.Web.UI.Page
    {
        InstituteBLL objInsBLL = new InstituteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId, DistrictName FROM Conf_District ORDER BY DistrictName", "DistrictName","DistrictId");
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
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objInsBLL.SetupSp_GetInstitute();
            if (dt.Rows.Count>0)
            {
                gvInstitute.DataSource = dt;
                gvInstitute.DataBind();
            }
            else
            {
                gvInstitute.DataSource = null;
                gvInstitute.DataBind();
            }
        }
        private void save()
        {
            int save = 0;
            EInstitute objEIns = new EInstitute();


            objEIns.InstituteId = 0;
            objEIns.EIIN_RegistrationNo = txtEIIN.Text;
            objEIns.InstituteName = txtInstituteName.Text;
            objEIns.Email = txtEmail.Text;
            objEIns.Phone = txtPhone.Text;
            objEIns.Fax = txtFax.Text;
            objEIns.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEIns.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEIns.Address = txtAddress.Text;
            objEIns.InstituteType = ddlInstituteType.Text;
            objEIns.InstituteLogo = txtInstituteLogo.Text;
            objEIns.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text == "Save")
            {
                objEIns.Action = 1;
                objEIns.InstituteId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEIns.Action = 2;
                objEIns.InstituteId = int.Parse(hdnUpdateInsId.Value);
            }

            save = objInsBLL.InsertUpdateDelete_InstituteInfo(objEIns);
            if (save > 0)
            {
                ResponseInstitute.SuccessMessage = btnSave.Text + " Complete Successfully.";
                btnSave.Text = "Save";
            }

        }
        private void DeleteInstitute(int InsttituteId)
        {
            int save = 0;
            EInstitute objEIns = new EInstitute();


            objEIns.EIIN_RegistrationNo = "";
            objEIns.InstituteName = "";
            objEIns.Email = "";
            objEIns.Phone = "";
            objEIns.Fax = "";
            objEIns.DistrictId = 0;
            objEIns.UpazilaId = 0;
            objEIns.Address = "";
            objEIns.InstituteType = "";
            objEIns.InstituteLogo = "";
            objEIns.EntryBy = 0;
  
            objEIns.Action = 3;
            objEIns.InstituteId = InsttituteId;

            save = objInsBLL.InsertUpdateDelete_InstituteInfo(objEIns);
            if (save > 0)
            {
                ResponseInstitute.SuccessMessage ="Delete Successfully.";
                LoadGrid();
            }

        }
        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtEIIN.Text == "")
            {
                IsReq = true;
                ResponseInstitute.FailureMessage = "Username can't be empty";
            }
            else if (txtInstituteName.Text == "")
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
            else if (txtInstituteName.Text == "")
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "Password can't be empty";
            }
            else if (ddlInstituteType.Text == "0")
            {
                IsReq = true;
                ResponseInstitute.SuccessMessage = "Password can't be empty";
            }

            return IsReq;
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = "+ddlDistrict.SelectedValue+") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }

        protected void gvInstitute_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnInstituteId = (HiddenField)gvInstitute.Rows[rowindex].FindControl("hdnInstituteId");        

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnInstituteId.Value));
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                DeleteInstitute(int.Parse(hdnInstituteId.Value));
            }
        }

        private void FillControl(int InstituteId)
        {
            DataTable dt = new DataTable();
            dt = objInsBLL.SetupSp_GetInstitute(InstituteId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateInsId.Value = InstituteId.ToString();
                txtEIIN.Text = dt.Rows[0]["EIIN_RegistrationNo"].ToString();
                txtInstituteName.Text = dt.Rows[0]["InstituteName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();
                CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                ddlInstituteType.Text = dt.Rows[0]["InstituteType"].ToString();
                txtInstituteLogo.Text = dt.Rows[0]["InstituteLogo"].ToString();

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using DAL.Entity;


namespace SchoolManagementSystem.Setup
{
    public partial class SchoolProfile : System.Web.UI.Page
    {
        SchoolProfileBLL objSchoolbll = new SchoolProfileBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId, DistrictName FROM Conf_District ORDER BY DistrictName", "DistrictName", "DistrictId");
                LoadGrid();
            }
        }

        private void Save()
        {
            int save = 0;

            ESchoolProfile objESchool = new ESchoolProfile();

            objESchool.SchoolId = 0;
            objESchool.RegNo = txtRegno.Text;
            objESchool.SchoolName = txtSchoolName.Text;
            objESchool.Email = txtEmail.Text;
            objESchool.Phone = txtPhone.Text;
            objESchool.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objESchool.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objESchool.Address = txtAddress.Text;
            objESchool.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text == "Save")
            {
                objESchool.Action = 1;
                objESchool.SchoolId = 0;
            }
            else if(btnSave.Text == "Update")
            {
                objESchool.Action = 2;
                objESchool.SchoolId = int.Parse(hdnUpdateSchoolId.Value);
            }

            save = objSchoolbll.School_InsertUpdateDelete_bll(objESchool);
            if (save > 0)
            {
                rmschool.SuccessMessage = btnSave.Text + " Completed Successfully";
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadGrid();
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSchoolbll.Get_SchoolProfile_bll();

            if (dt.Rows.Count>0)
            {
                gvSchool.DataSource = dt;
                gvSchool.DataBind();
            }
            else
            {
                gvSchool.DataSource = null;
                gvSchool.DataBind();
            }
        }

        protected void gvSchool_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnSchoolId = (HiddenField)gvSchool.Rows[rowindex].FindControl("hdnSchoolId");

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnSchoolId.Value));
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                DeleteSchool(int.Parse(hdnSchoolId.Value));
            }
        }

        private void FillControl(int schoolid)
        {
            DataTable dt = new DataTable();
            dt = objSchoolbll.Get_SchoolProfile_bll(schoolid);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateSchoolId.Value = schoolid.ToString();
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
        private void DeleteSchool(int schoolid)
        {
            int save = 0;
            ESchoolProfile objESchool = new ESchoolProfile();


            objESchool.RegNo = "";
            objESchool.SchoolName = "";
            objESchool.Email = "";
            objESchool.Phone = "";          
            objESchool.DistrictId = 0;
            objESchool.UpazilaId = 0;
            objESchool.Address = "";      
            objESchool.EntryBy = 0;

            objESchool.Action = 3;
            objESchool.SchoolId = schoolid;

            save = objSchoolbll.School_InsertUpdateDelete_bll(objESchool);
            if (save > 0)
            {
                rmschool.SuccessMessage = "Delete Successfully.";
                LoadGrid();
            }

        }
    }
}
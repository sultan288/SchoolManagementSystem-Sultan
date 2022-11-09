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
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        EmployeeBLL objEmpBLL = new EmployeeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId, DistrictName FROM Conf_District ORDER BY DistrictName", "DistrictName", "DistrictId");               
                CommonDAL.Fillddl(ddlDesigName, "SELECT DesignationId, DesignationName, Position FROM Con_Designation ORDER BY Position", "DesignationName", "DesignationId");
                CommonDAL.Fillddl(ddlReligion, "SELECT ReligionId, ReligionName FROM Conf_Religion", "ReligionName", "ReligionId");

                LoadGrid();
            }
        }

        protected void ddlDistrict_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }


        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objEmpBLL.SetupSp_GetEmployee();
            if (dt.Rows.Count > 0)
            {
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
            }
            else
            {
                gvEmployee.DataSource = null;
                gvEmployee.DataBind();
            }
        }
        private void save()
        {
            int save = 0;
            EEmployee objEEmp = new EEmployee();
           
            objEEmp.FirstName = txtFirstName.Text;
            objEEmp.LastName = txtLastName.Text;
            objEEmp.EmployeeType = ddlEmpType.SelectedValue;
            objEEmp.DesignationId = int.Parse(ddlDesigName.SelectedValue);
            objEEmp.StartingSalary = float.Parse(txtStartingSalary.Text);
            objEEmp.Nationality = ddlNationality.SelectedValue;
            objEEmp.NID = txtNID.Text;
            objEEmp.DOB = txtDOB.Text;
            objEEmp.JoiningDate = txtJoiningDate.Text;        
            objEEmp.ReligionId = int.Parse(ddlReligion.SelectedValue);
            objEEmp.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEEmp.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEEmp.Address = txtAddress.Text;
            objEEmp.Email = txtEmail.Text;
            objEEmp.ContactNo = txtContactNo.Text;
            objEEmp.Gender = ddlGender.SelectedValue;
            objEEmp.BloodGroup = ddlBloodGroup.SelectedValue;
            objEEmp.EntryBy = int.Parse(Session["UserId"].ToString());


            if (btnSave.Text == "Save")
            {
                objEEmp.Action = 1;
                objEEmp.EmployeeId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEEmp.Action = 2;
                objEEmp.EmployeeId = int.Parse(hdnUpdateEmpId.Value);
            }

            save = objEmpBLL.InsertUpdateDelete_EmployeeInfo(objEEmp);
            if (save > 0)
            {
                rmEmployee.SuccessMessage = btnSave.Text +" "+ "Complete Successfully.";
                btnSave.Text = "Save";
            }
            else
            {
                rmEmployee.FailureMessage = btnSave.Text+" "+"Failed";
            }

        }

        private void DeleteEmployee(int EmployeeId)
        {
            int save = 0;
            EEmployee objEEmp = new EEmployee();

            objEEmp.FirstName = "";
            objEEmp.LastName = "";
            objEEmp.EmployeeType = "";
            objEEmp.DesignationId = 0;
            objEEmp.StartingSalary = 0.0f;
            objEEmp.Nationality = "";
            objEEmp.NID = "";
            objEEmp.DOB = "";
            objEEmp.JoiningDate = "";
            objEEmp.ReligionId = 0;
            objEEmp.DistrictId = 0;
            objEEmp.UpazilaId = 0;
            objEEmp.Address = "";
            objEEmp.Email = "";
            objEEmp.ContactNo = "";
            objEEmp.Gender = "";
            objEEmp.BloodGroup = "0";
            objEEmp.EntryBy = 1;
            objEEmp.Action = 3;
            objEEmp.EmployeeId = EmployeeId;


            save = objEmpBLL.InsertUpdateDelete_EmployeeInfo(objEEmp);
            if (save > 0)
            {
                rmEmployee.SuccessMessage = "Delete Successfully.";
                LoadGrid();
            }

        }
        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtFirstName.Text == "")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "FirstName can't be empty";
            }
            else if (txtLastName.Text == "")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "LastName can't be empty";
            }
            else if (txtStartingSalary.Text == "")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "StartingSalary can't be empty";
            }
            else if (txtContactNo.Text == "")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "ContactNo can't be empty";
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "District can't be empty";
            }
            else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedIndex == -1)
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Upazila can't be empty";
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Address can't be empty";
            }
            else if (txtDOB.Text == "")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "DOB can't be empty";
            }
            else if (txtNID.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "NID can't be empty";
            }
            else if (txtJoiningDate.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "JoiningDate can't be empty";
            }

            else if (txtEmail.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Email can't be empty";
            }
            else if (ddlBloodGroup.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "BloodGroup can't be empty";
            }
            else if (ddlDesigName.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Designation Name can't be empty";
            }
            else if (ddlEmpType.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Employee Type can't be empty";
            }
            else if (ddlGender.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Gender can't be empty";
            }
            else if (ddlNationality.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Nationality can't be empty";
            }
            else if (ddlReligion.Text == "0")
            {
                IsReq = true;
                rmEmployee.FailureMessage = "Religion can't be empty";
            }
         
            return IsReq;
        }

        private void ClearFieldValue()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlEmpType.SelectedValue = "0";
            ddlDesigName.SelectedValue = "0";
            txtStartingSalary.Text = "";
            ddlNationality.SelectedValue = "0";
            txtNID.Text = "";
            txtDOB.Text = "";
            txtJoiningDate.Text = "";
            //ddlReligion.SelectedValue = "0";
            //ddlDistrict.SelectedValue = "0";
            //ddlUpazila.SelectedValue = "0";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            ddlGender.Text = "0";
            ddlBloodGroup.Text = "0";
            
            //fuUserImage.PostedFile.InputStream.Dispose();
        }



        private void FillControl(int EmployeeId)
        {
            DataTable dt = new DataTable();
            dt = objEmpBLL.SetupSp_GetEmployee(EmployeeId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateEmpId.Value = EmployeeId.ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                ddlEmpType.SelectedValue = dt.Rows[0]["EmployeeType"].ToString();
                ddlDesigName.SelectedValue = dt.Rows[0]["DesignationId"].ToString();
                txtStartingSalary.Text = dt.Rows[0]["StartingSalary"].ToString();
                ddlNationality.SelectedValue = dt.Rows[0]["Nationality"].ToString();
                txtNID.Text = dt.Rows[0]["NID"].ToString();
                txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                txtJoiningDate.Text = dt.Rows[0]["JoiningDate"].ToString();                     
                ddlReligion.SelectedValue = dt.Rows[0]["ReligionId"].ToString();
                ddlReligion.SelectedValue = dt.Rows[0]["DistrictId"].ToString();
                CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                ddlGender.Text = dt.Rows[0]["Gender"].ToString();
                ddlBloodGroup.Text = dt.Rows[0]["BloodGroup"].ToString();               

            }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                save();
                ClearFieldValue();
                LoadGrid();
            }
        }

        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnEmployeeId = (HiddenField)gvEmployee.Rows[rowindex].FindControl("hdnEmployeeId");

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnEmployeeId.Value));
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                DeleteEmployee(int.Parse(hdnEmployeeId.Value));
            }
        }
    }
}

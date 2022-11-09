using DAL;
using DAL.Entity;
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
    public partial class Student_profile : System.Web.UI.Page
    {
        StudentBLL objStuBLL = new StudentBLL();

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
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objStuBLL.SetupSp_GetStudentDT();
            if (dt.Rows.Count > 0)
            {
                gvStudent.DataSource = dt;
                gvStudent.DataBind();
            }
            else
            {
                gvStudent.DataSource = null;
                gvStudent.DataBind();
            }
        }
        private void save()
        {
            int save = 0;
            EStudent objEStu = new EStudent();

            objEStu.StudentId = 0;
            objEStu.RegistrationNo = txtRegistrationNo.Text;
            objEStu.FirstName = txtFirstName.Text;
            objEStu.LastName = txtLastName.Text;
            objEStu.ContactNo = txtContact.Text;
            objEStu.FatherName = txtFatherName.Text;
            objEStu.FatherContactNo = txtFatherContact.Text;
            objEStu.FatherOccupation = txtFatherOccupation.Text;
            objEStu.MotherName = txtMotherName.Text;
            objEStu.MotherContactNo = txtMotherContact.Text;
            objEStu.MotherOcupation = txtMotherOccupation.Text;
            objEStu.GurdianName = txtGuardianName.Text;
            objEStu.Relation = txtGRelation.Text;
            objEStu.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEStu.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEStu.Address = txtAddress.Text;                     
            objEStu.EntryBy = int.Parse(Session["UserId"].ToString());

            //objEIns.InstituteId = 0;
            //objEIns.EIIN_RegistrationNo = txtEIIN.Text;
            //objEIns.InstituteName = txtInstituteName.Text;
            //objEIns.Email = txtEmail.Text;
            //objEIns.Phone = txtPhone.Text;
            //objEIns.Fax = txtFax.Text;
            //objEIns.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            //objEIns.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            //objEIns.Address = txtAddress.Text;
            //objEIns.SchoolType = ddlInstituteType.Text;
            //objEIns.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text == "Save")
            {
                objEStu.Action = 1;
                objEStu.StudentId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEStu.Action = 2;
                objEStu.StudentId = int.Parse(hdnUpdateStudentId.Value);
            }

            save = objStuBLL.InsertUpdateDelete_StudentInfo(objEStu);
            if (save > 0)
            {
                rmStudent.SuccessMessage = "Action Complete Successfully.";
            }

        }
        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtRegistrationNo.Text == "")
            {
                IsReq = true;
                rmStudent.FailureMessage = "Registration can't be empty";
            }
            else if (txtFirstName.Text == "")
            {
                IsReq = true;
                rmStudent.SuccessMessage = "First Name can't be empty";
            }
            else if (txtLastName.Text == "")
            {
                IsReq = true;
                rmStudent.SuccessMessage = "Last Name can't be empty";
            }
            else if (txtContact.Text == "")
            {
                IsReq = true;
                rmStudent.SuccessMessage = "Password can't be empty";
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                rmStudent.SuccessMessage = "Password can't be empty";
            }
            else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedIndex == -1)
            {
                IsReq = true;
                rmStudent.SuccessMessage = "Password can't be empty";
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                rmStudent.SuccessMessage = "Password can't be empty";
            }
            else if (txtFatherName.Text == "")
            {
                IsReq = true;
                rmStudent.SuccessMessage = "Password can't be empty";
            }
            else if (ddlDistrict.Text == "0")
            {
                IsReq = true;
                rmStudent.SuccessMessage = "Password can't be empty";
            }

            return IsReq;
        }
    

        protected void ddlDistrict_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE(DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }
    }
}
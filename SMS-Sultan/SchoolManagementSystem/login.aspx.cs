using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace SchoolManagementSystem.dashboard
{
    public partial class login : System.Web.UI.Page
    {
        AuthBLL objAuthBLL = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RememberCookie();
            }
        }
        private void RememberCookie()
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtUsername.Text = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["Value"] = Request.Cookies["Password"].Value;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                DataTable dtUserInfo = objAuthBLL.CheckUserInfo(txtUsername.Text.Trim(), txtPassword.Text);
                if (dtUserInfo.Rows.Count > 0)
                {
                    Session["UserId"] = dtUserInfo.Rows[0]["UserId"].ToString();
                    Session["UserName"] = dtUserInfo.Rows[0]["FulName"].ToString();
                    Session["UserImage"] = dtUserInfo.Rows[0]["UserImage"].ToString();
                    SetCookie();
                    Response.Redirect("~/dashboard/admin-index.aspx");
                }
                else
                {
                    rmMsg.FailureMessage = "Incorrect Username or Password";

                }

            }
        }

        private void SetCookie()
        {
            HttpCookie mycookie = new HttpCookie("mycookie");
            //mycookie["UserName"] = txtUsername.Text.Trim();
            //mycookie["Password"] = txtPassword.Text.Trim();
            mycookie["UserName"] = "";
            mycookie["Password"] = "";

            Response.Cookies.Add(mycookie);

            if (chkRememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(3);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(3);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
            Response.Cookies["Password"].Value = txtPassword.Text.Trim();

        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtUsername.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Username can't be empty";
            }
            else if (txtPassword.Text == "")
            {
                IsReq = true;
                rmMsg.SuccessMessage = "Password can't be empty";
            }
            return IsReq;
        }

<<<<<<< HEAD
        protected void btnReg_Click(object sender, EventArgs e)
        {
            SaveReg();
        }
          
        private void SaveReg()
        {
            int reg = 0;

            if (btnReg.Text == "Register")
            {
                reg = objAuthBLL.Insert_Registerbll(txtFirstName.Text, txtLastName.Text, txtUName.Text, txtContactNo.Text, TextEmail.Text, TextAddress.Text, 0);
                if (reg > 0)
                {
                    if (CheckRegFieldValue() == true)
                    {
                        SaveReg();
                    }
                    else
                    {
                        rmMsg.FailureMessage = "Pleas provide information";
                    }
                }
            }

        }

        private bool CheckRegFieldValue()
        {
            bool value = true;

            if (txtFirstName.Text == "")
            {
                value = false;
            }
            if (txtLastName.Text == "")
            {
                value = false;
            }
            if (txtUName.Text == "")
            {
                value = false;
            }
            if (txtContactNo.Text == "")
            {
                value = false;
            }
            if (TextEmail.Text == "")
            {
                value = false;
            }
            if (TextAddress.Text == "")
            {
                value = false;
            }
            return value;
        }

        private void ClearFieldValue()
        {        
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUName.Text = "";
            txtContactNo.Text = "";
            TextEmail.Text = "";
            TextAddress.Text = "";
        }

        
=======
       

        protected void btnReg_Click(object sender, EventArgs e)
        {
            SaveReg();
        }

        private void SaveReg()
        {
            int reg = 0;

            if (btnReg.Text == "Register")
            {
                reg = objAuthBLL.Insert_Registerbll(txtFirstName.Text, txtLastName.Text, txtUName.Text, txtContactNo.Text, TextEmail.Text, TextAddress.Text, 0);
                if (reg > 0)
                {
                    rmMsg.SuccessMessage = "Save done";                   
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtUName.Text = "";
                    txtContactNo.Text = "";
                    TextEmail.Text = "";
                    TextAddress.Text = "";
                }
            }          

        }
>>>>>>> refs/remotes/origin/main
    }

}
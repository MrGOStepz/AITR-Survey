using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbIPAddress.Text = "Your IP is " + IPAddress.GetIPAddress();
            lbDate.Text = "&nbsp&nbsp&nbsp&nbspDate : " + DateTime.Now.ToShortDateString();

            String s = Request.QueryString["field1"];
            if (s != null)
            {
                lbLoginError.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = txtUserName.Text.ToLower();
            String password = txtPassword.Text;

            if (DatabaseHandle.CheckLogin(userName, password) > 0)
            {
                Response.Redirect("StaffSearch.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnStaffRegister_Click(object sender, EventArgs e)
        {
            if (txtUserNameStaff.Text == "")
            {
                lbAlerts.Text = "Please fill Username";  
            }
            else if (txtPasswordStaff.Text == "")
            {
                lbAlerts.Text = "Please fill Password";
            }
            else if (txtPasswordStaff.Text != txtConfirmPW.Text)
            {
                lbAlerts.Text = "Password doesn't match";
            }
            else if (DatabaseHandle.CheckUserStaff(txtUserNameStaff.Text) > 0)
            {
                lbAlerts.Text = "Username already used!";
            }
            else
            {
                if (DatabaseHandle.AddStaff(txtUserNameStaff.Text, txtPasswordStaff.Text) > 0)
                {
                    lbAlerts.CssClass = "alert alert-success";
                    lbAlerts.Text = "Register success!";
                }
                else
                {
                    lbAlerts.Text = "Database problem!";
                }
            }

            lbAlerts.Visible = true;
        }
    }
}
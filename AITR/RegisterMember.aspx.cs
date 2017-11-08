using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class RegisterMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbIPAddress.Text = "Your IP is " + IPAddress.GetIPAddress();
            lbDate.Text = "&nbsp&nbsp&nbsp&nbspDate : " + DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// Check Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRespondentRegister_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please enter your first name!";
            }
            else if (txtLastName.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please enter your last name!";
            }
            else if (txtEmail.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please enter your Email";
            }
            else if (txtDOB.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please enter your date of birth!";
            }
            else if (txtPhoneNumber.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please enter your phone number";
            }
            else
            {
                int memberID = 0;
                DatabaseHandle.AddNewMember(txtFirstName.Text, txtLastName.Text, txtDOB.Text, txtPhoneNumber.Text, txtEmail.Text);
                memberID = DatabaseHandle.GetMemberIDbyPhone(txtPhoneNumber.Text);
                DatabaseHandle.UpdateResponedent(memberID, AppSession.GetRespondentID());
                Response.Redirect("Final.aspx");
            }
        }

        /// <summary>
        /// Login for Staff Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Response.Redirect("Register.aspx?field1=value1");
            }
        }

        /// <summary>
        /// Add Staff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }


    }
}
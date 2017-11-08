using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class index : System.Web.UI.Page
    {
        /// <summary>
        /// Load IP Address and Date Time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lbIPAddress.Text = "Your IP is " + IPAddress.GetIPAddress();
            lbDate.Text = "&nbsp&nbsp&nbsp&nbspDate : " + DateTime.Now.ToShortDateString();
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

        /// <summary>
        /// Do servey with member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGoToRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question.aspx?reg=true");
        }

        /// <summary>
        /// Do servey without member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGoToQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question.aspx?reg=false");
        }
    }
}
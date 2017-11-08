using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbIPAddress.Text = "Your IP is " + IPAddress.GetIPAddress();
            lbDate.Text = "&nbsp&nbsp&nbsp&nbspDate : " + DateTime.Now.ToShortDateString();
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
    }
}

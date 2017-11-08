using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class StaffRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int countUserStaff = DatabaseHandle.CheckUserStaff(txtUserName.Text);
            if(countUserStaff > 0)
            {
                lbShowMessage.Text = "User has already.";
                return;
            }
            else if(txtPW.Text != txtConfirmPW.Text)
            {
                lbShowMessage.Text = "Password is not matched";
                return;
            }
            else
            {
                DatabaseHandle.AddStaff(txtUserName.Text, txtPW.Text);
                lbShowMessage.Text = "Staff has been added";
            }
        }

        protected void txtReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPW.Text = "";
            txtConfirmPW.Text = "";
        }
    }
}
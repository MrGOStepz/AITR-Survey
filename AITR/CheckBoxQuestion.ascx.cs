using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class CheckBoxQuestion : System.Web.UI.UserControl
    {
        public Label LabelQuestion
        {
            get { return lbQuestion; }
            set { lbQuestion = value; }
        }


        public CheckBoxList CheckBoxListAnswer
        {
            get { return cbList; }
            set { cbList = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
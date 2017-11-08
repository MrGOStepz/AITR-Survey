using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class CheckBoxListSearch : System.Web.UI.UserControl
    {
        public Label LabelTopic
        {
            get { return lbQuestion; }
            set { lbQuestion = value; }
        }

        public CheckBoxList CheckBoxListAnswer
        {
            get { return cbBoxList; }
            set { cbBoxList = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
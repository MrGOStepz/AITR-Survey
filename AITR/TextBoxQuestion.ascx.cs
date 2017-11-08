using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class TextBoxQuestion : System.Web.UI.UserControl
    {
        public Label QuestionLabel
        {
            get
            {
                return lbQuestion;
            }
            set
            {
                lbQuestion = value;
            }
        }

        public TextBox TextBoxAnswer
        {
            get
            {
                return txtQuestion;
            }
            set
            {
                txtQuestion = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
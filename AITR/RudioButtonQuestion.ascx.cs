﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class RudioButtonQuestion : System.Web.UI.UserControl
    {
        public Label LabelQuestion
        {
            get { return lbQuestion; }
            set { lbQuestion = value; }
        }

        public RadioButtonList RadioButtonListAnswer
        {
            get { return rbList; }
            set { rbList = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
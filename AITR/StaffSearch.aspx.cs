using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class StaffSearch : System.Web.UI.Page
    {
        private static int _countCheckBox = 0;
        private static List<CheckBoxListSearch> _lstCheckBoxListSearch = new List<CheckBoxListSearch>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _countCheckBox = 0;
                Dictionary<string, int> dicQuestion = new Dictionary<string, int>();
                dicQuestion = DatabaseHandle.GetListOfQuestionName();

                // Loop over pairs with foreach.
                foreach (KeyValuePair<string, int> pair in dicQuestion)
                {
                    ListItem lstiItem = new ListItem();
                    lstiItem.Text = pair.Key;
                    lstiItem.Value = pair.Value.ToString();

                    //My question 1-5 is a member question
                    if (int.Parse(lstiItem.Value) > 5)
                        ddList.Items.Add(lstiItem);
                }
                _lstCheckBoxListSearch = new List<CheckBoxListSearch>();
            }

            for (int i = 0; i < _lstCheckBoxListSearch.Count; i++)
            {
                phFilter.Controls.Add(_lstCheckBoxListSearch[i]);
            }
        }

        protected void btnAddFilter_Click(object sender, EventArgs e)
        {
            CheckBoxListSearch checkBoxListSearch = (CheckBoxListSearch)LoadControl("~/CheckBoxListSearch.ascx");
            checkBoxListSearch.ID = "checkBoxListSearch" + _countCheckBox;
            checkBoxListSearch.LabelTopic.Text = DatabaseHandle.GetNameofQuestionbyQuestionID(ddList.SelectedValue);

            List<string> lstQuestionChoice = new List<string>();
            lstQuestionChoice = DatabaseHandle.GetListOfChoiceQuestionByQuestionID(ddList.SelectedValue);

            //The question have choice
            if (lstQuestionChoice.Count > 0)
            {
                for (int i = 0; i < lstQuestionChoice.Count; i++)
                {
                    ListItem lstiItem = new ListItem();
                    lstiItem.Text = lstQuestionChoice[i].ToString();
                    lstiItem.Value = "";

                    checkBoxListSearch.CheckBoxListAnswer.Items.Add(lstiItem);
                }
            }
            //the question is a texbox
            else
            {
                lstQuestionChoice = new List<string>();
                lstQuestionChoice = DatabaseHandle.GetListOfAnswersByQuestionID(ddList.SelectedValue);
                if (lstQuestionChoice != null)
                    for (int i = 0; i < lstQuestionChoice.Count; i++)
                    {
                        ListItem lstiItem = new ListItem();
                        lstiItem.Text = lstQuestionChoice[i].ToString();
                        lstiItem.Value = "";

                        checkBoxListSearch.CheckBoxListAnswer.Items.Add(lstiItem);
                    }
            }

            _lstCheckBoxListSearch.Add(checkBoxListSearch);
            phFilter.Controls.Add(checkBoxListSearch);
            _countCheckBox++;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> lstAnswer = new List<string>();

            for (int i = 0; i < _lstCheckBoxListSearch.Count; i++)
            {
                CheckBoxListSearch checkBoxList = new CheckBoxListSearch();
                checkBoxList = (CheckBoxListSearch)phFilter.FindControl("checkBoxListSearch" + i);
                foreach (ListItem item in checkBoxList.CheckBoxListAnswer.Items)
                {
                    if (item.Selected)
                    {
                        lstAnswer.Add(item.Text);
                    }
                }
            }

            if (lstAnswer.Count == 0)
            {
                gvSearch.DataSource = DatabaseHandle.GetAllDataRespondents();
                gvSearch.DataBind();
            }
            else
            {
                List<int> lstAnswerID = new List<int>();
                lstAnswerID = DatabaseHandle.GetListofAnswerIDbyAnswer(lstAnswer);
                gvSearch.DataSource = DatabaseHandle.GetDataByListOfAnswerID(lstAnswerID);
                gvSearch.DataBind();
            }
        }

    }
}
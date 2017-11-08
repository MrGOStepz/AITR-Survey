using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class Question : System.Web.UI.Page
    {
        private static Stack<QuestionDetail> _stackQuestion = new Stack<QuestionDetail>();
        private static QuestionDetail _questionCurrent = new QuestionDetail();
        private static List<AnswerQuestion> _lstOfAnswer = new List<AnswerQuestion>();
        private static SessionDetail _sessionDetail = new SessionDetail();

        protected void Page_Init(object sender, EventArgs e)
        {
            //First Question of Survey is question_id = 6
            int questionNumber = 6;
            
            //Check List of Question from the session
            //If session is null, it will initial question and push into stack
            if (!IsPostBack)
            {
                QuestionDetail questionDetail = new QuestionDetail();
                QuestionDetail question;
                _stackQuestion = new Stack<QuestionDetail>();

                //Check Session is null?
                if (AppSession.GetInitialSession() != null)
                {
                    _sessionDetail = (SessionDetail)AppSession.GetInitialSession();
                    _stackQuestion = _sessionDetail.StackQuestionDetail;
                    _lstOfAnswer = _sessionDetail.ListAnswerQuestion;
                }
                else
                {
                    //Prepare List of question because session is null
                    List<int> lstQuestion = new List<int>();
                    lstQuestion = DatabaseHandle.GetListOfMainQuestion(questionNumber);

                    for (int i = lstQuestion.Count - 1; i >= 0; i--)
                    {
                        question = new QuestionDetail();
                        question = DatabaseHandle.GetQustionDetail(lstQuestion[i]);
                        _stackQuestion.Push(question);
                    }
                }

                //Pop the first question
                _questionCurrent = _stackQuestion.Pop();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Show Question Name and Question Choice
            switch (_questionCurrent.QuestionTypeID)
            {
                case 1:
                    TextBoxQuestion textBoxQuestion = (TextBoxQuestion)LoadControl("~/TextBoxQuestion.ascx");
                    textBoxQuestion.ID = "textBoxQuestion";
                    textBoxQuestion.QuestionLabel.Text = _questionCurrent.QuestionName;
                    phUserControl.Controls.Add(textBoxQuestion);
                    break;
                case 2:
                    CheckBoxQuestion checkBoxQuestion = (CheckBoxQuestion)LoadControl("~/CheckBoxQuestion.ascx");
                    checkBoxQuestion.ID = "checkBoxQuestion";
                    checkBoxQuestion.LabelQuestion.Text = _questionCurrent.QuestionName;
                    for (int i = 0; i < _questionCurrent.ListChoiceOfQuestion.Count; i++)
                        checkBoxQuestion.CheckBoxListAnswer.Items.Add(new ListItem(_questionCurrent.ListChoiceOfQuestion[i], "option " + i + 1));
                    phUserControl.Controls.Add(checkBoxQuestion);
                    break;
                case 3:
                    RadioButtonQuestion radioButtonQuestion = (RadioButtonQuestion)LoadControl("~/RadioButtonQuestion.ascx");
                    radioButtonQuestion.ID = "radioButtonQuestion";
                    radioButtonQuestion.LabelQuestion.Text = _questionCurrent.QuestionName;
                    for (int i = 0; i < _questionCurrent.ListChoiceOfQuestion.Count; i++)
                        radioButtonQuestion.RadioButtonAnswer.Items.Add(new ListItem(_questionCurrent.ListChoiceOfQuestion[i], "option " + i + 1));
                    phUserControl.Controls.Add(radioButtonQuestion);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Go to Next Question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Find Type of Control
            CheckBoxQuestion checkBoxQuestion = (CheckBoxQuestion)phUserControl.FindControl("checkBoxQuestion");
            RadioButtonQuestion radioButtonQuestion = (RadioButtonQuestion)phUserControl.FindControl("radioButtonQuestion");
            TextBoxQuestion textBoxQuestion = (TextBoxQuestion)phUserControl.FindControl("textBoxQuestion");

            AnswerQuestion answerQuestion = new AnswerQuestion();
            QuestionDetail qestionDetailNext = new QuestionDetail();

            int countIndex = 0;
            bool bSameQuestion = false;

            //Check Question is Checkbox ?
            if (checkBoxQuestion != null)
            {

                foreach (ListItem item in checkBoxQuestion.CheckBoxListAnswer.Items)
                {
                    if (item.Selected)
                    {
                        //Add Answer into _lstOfAnswer
                        answerQuestion = new AnswerQuestion();
                        answerQuestion.QuestionID = _questionCurrent.QuestionID;
                        answerQuestion.AnswerText = item.Text;
                        _lstOfAnswer.Add(answerQuestion);

                        //Push next question and distinct question into stack
                        if ((_questionCurrent.ListNextQuestion.Count > 1) && (_questionCurrent.ListNextQuestion[0] != _questionCurrent.ListNextQuestion[1]) && ((_questionCurrent.ListNextQuestion[0] > 1) || (_questionCurrent.ListNextQuestion[1] > 1)))
                        {
                            if (_questionCurrent.ListNextQuestion[countIndex] > 0)
                            {
                                qestionDetailNext = new QuestionDetail();
                                qestionDetailNext = DatabaseHandle.GetQustionDetail(_questionCurrent.ListNextQuestion[countIndex]);
                                _stackQuestion.Push(qestionDetailNext);
                            }
                        }
                        
                        else if(_questionCurrent.ListNextQuestion[countIndex] > 0 && _questionCurrent.HasSubQuestion == 1)
                        {
                            bSameQuestion = true;
                        }

                        item.Selected = false;
                    }
                    countIndex++;
                }

                //Check next question is the same? if it's same, it will be distinct.
                if (bSameQuestion)
                {
                    qestionDetailNext = new QuestionDetail();
                    qestionDetailNext = DatabaseHandle.GetQustionDetail(_questionCurrent.ListNextQuestion[0]);
                    _stackQuestion.Push(qestionDetailNext);
                }

                phUserControl.Controls.Remove(checkBoxQuestion);
            }
            //Check Question is Radio Button ?
            else if (radioButtonQuestion != null)
            {
                foreach (ListItem item in radioButtonQuestion.RadioButtonAnswer.Items)
                {
                    if (item.Selected)
                    {
                        answerQuestion = new AnswerQuestion();
                        answerQuestion.QuestionID = _questionCurrent.QuestionID;
                        answerQuestion.AnswerText = item.Text;
                        _lstOfAnswer.Add(answerQuestion);

                        if ((_questionCurrent.ListNextQuestion.Count > 1) && (_questionCurrent.ListNextQuestion[0] != _questionCurrent.ListNextQuestion[1]) && ((_questionCurrent.ListNextQuestion[0] > 1) || (_questionCurrent.ListNextQuestion[1] > 1)))
                        {
                            if (_questionCurrent.ListNextQuestion[countIndex] > 0)
                            {
                                qestionDetailNext = new QuestionDetail();
                                qestionDetailNext = DatabaseHandle.GetQustionDetail(_questionCurrent.ListNextQuestion[countIndex]);
                                _stackQuestion.Push(qestionDetailNext);
                            }
                        }

                        item.Selected = false;
                    }
                    countIndex++;
                }

                phUserControl.Controls.Remove(radioButtonQuestion);
            }
            //Check Question is Textbox ?
            else if (textBoxQuestion != null)
            {
                if (textBoxQuestion.TextBoxAnswer.Text != "")
                {
                    answerQuestion = new AnswerQuestion();
                    answerQuestion.QuestionID = _questionCurrent.QuestionID;
                    answerQuestion.AnswerText = textBoxQuestion.TextBoxAnswer.Text;
                    _lstOfAnswer.Add(answerQuestion);
                }

                textBoxQuestion.TextBoxAnswer.Text = "";
                phUserControl.Controls.Remove(textBoxQuestion);
            }

            //Set Session
            _sessionDetail.StackQuestionDetail = _stackQuestion;
            _sessionDetail.ListAnswerQuestion = _lstOfAnswer;
            AppSession.SetInitialSession(_sessionDetail);

            //Check Stack have question ?
            if (_stackQuestion.Count > 0)
            {
                _questionCurrent = _stackQuestion.Pop();
            }
            else
            {
                //Prepare to add value into the table
                int answerID = 0;
                int respondentID = 0;

                DatabaseHandle.AddRespondent(-1, IPAddress.GetIPAddress(), DateTime.Now);
                respondentID = DatabaseHandle.GetRespondentIDByIP(IPAddress.GetIPAddress());
                AppSession.SetRespondentID(respondentID);

                for (int i = 0; i < _lstOfAnswer.Count; i++)
                {
                    DatabaseHandle.AddAnswer(_lstOfAnswer[i].QuestionID, respondentID);
                    answerID = DatabaseHandle.GetAnswerID(_lstOfAnswer[i].QuestionID, respondentID);
                    DatabaseHandle.AddAnswerDetail(answerID, _lstOfAnswer[i].AnswerText);
                }

                //Check Respondent Register?  
                String s = Request.QueryString["reg"];
                if (s == "true")
                {
                    Response.Redirect("RegisterMember.aspx");
                }
                else if (s == "false")
                {
                    Response.Redirect("Final.aspx");
                }

                
                return;
            }

            //Go to next question
            switch (_questionCurrent.QuestionTypeID)
            {
                case 1:
                    textBoxQuestion = (TextBoxQuestion)LoadControl("~/TextBoxQuestion.ascx");
                    textBoxQuestion.ID = "textBoxQuestion";
                    textBoxQuestion.QuestionLabel.Text = _questionCurrent.QuestionName;
                    phUserControl.Controls.Add(textBoxQuestion);
                    break;
                case 2:
                    checkBoxQuestion = (CheckBoxQuestion)LoadControl("~/CheckBoxQuestion.ascx");
                    checkBoxQuestion.ID = "checkBoxQuestion";
                    checkBoxQuestion.LabelQuestion.Text = _questionCurrent.QuestionName;
                    for (int i = 0; i < _questionCurrent.ListChoiceOfQuestion.Count; i++)
                        checkBoxQuestion.CheckBoxListAnswer.Items.Add(new ListItem(_questionCurrent.ListChoiceOfQuestion[i], "option " + i + 1));
                    phUserControl.Controls.Add(checkBoxQuestion);
                    break;
                case 3:
                    radioButtonQuestion = (RadioButtonQuestion)LoadControl("~/RadioButtonQuestion.ascx");
                    radioButtonQuestion.ID = "radioButtonQuestion";
                    radioButtonQuestion.LabelQuestion.Text = _questionCurrent.QuestionName;
                    for (int i = 0; i < _questionCurrent.ListChoiceOfQuestion.Count; i++)
                        radioButtonQuestion.RadioButtonAnswer.Items.Add(new ListItem(_questionCurrent.ListChoiceOfQuestion[i], "option " + i + 1));
                    phUserControl.Controls.Add(radioButtonQuestion);
                    break;
                default:
                    break;
            }

        }
    }
}
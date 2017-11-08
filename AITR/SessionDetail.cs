using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR
{
    public class SessionDetail
    {
        private Stack<QuestionDetail> _stackQuestionDetail = new Stack<QuestionDetail>();
        private List<AnswerQuestion> _lstAnswerQuestion = new List<AnswerQuestion>();
        private int _respondentID = 0;

        public int RespondentID
        {
            get { return _respondentID; }
            set { _respondentID = value; }
        }


        public List<AnswerQuestion> ListAnswerQuestion
        {
            get { return _lstAnswerQuestion; }
            set { _lstAnswerQuestion = value; }
        }


        public Stack<QuestionDetail> StackQuestionDetail
        {
            get { return _stackQuestionDetail; }
            set { _stackQuestionDetail = value; }
        }

    }
}
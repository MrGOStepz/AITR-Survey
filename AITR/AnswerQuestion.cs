using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR
{
    public class AnswerQuestion
    {
        private string answerText;
        private int questionID;

        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }


        public string AnswerText
        {
            get { return answerText; }
            set { answerText = value; }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR
{
    public class QuestionDetail
    {
        private string questionName;
        private int questionID;
        private List<string> listChoiceOfQuestion;
        private List<int> listNextQuestion;
        private int questionNext;
        private string questionType;
        private int questionTypeID;
        private int hasSubQuestion;

        public List<int> ListNextQuestion
        {
            get { return listNextQuestion; }
            set { listNextQuestion = value; }
        }

        public int HasSubQuestion
        {
            get { return hasSubQuestion; }
            set { hasSubQuestion = value; }
        }


        public int QuestionTypeID
        {
            get { return questionTypeID; }
            set { questionTypeID = value; }
        }


        public string QuestionType
        {
            get { return questionType; }
            set { questionType = value; }
        }

        public int QuestionNext
        {
            get { return questionNext; }
            set { questionNext = value; }
        }


        public List<string> ListChoiceOfQuestion
        {
            get { return listChoiceOfQuestion; }
            set { listChoiceOfQuestion = value; }
        }


        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }


        public string QuestionName
        {
            get { return questionName; }
            set { questionName = value; }
        }


    }
}
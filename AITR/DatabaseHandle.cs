using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace AITR
{
    public static class DatabaseHandle
    {
        private static SqlConnection _connection;

        /// <summary>
        /// Database is Opened
        /// </summary>
        private static void DatabaseOpen()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            _connection.Open();
        }

        /// <summary>
        /// Database Closed
        /// </summary>
        private static void DatabaseClose()
        {
            _connection.Close();
        }

        /// <summary>
        /// Run SQL Command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static SqlCommand SQLCommandString(String command)
        {
            return new SqlCommand(command, _connection);
        }


        /// <summary>
        /// Add Staff Member
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int AddStaff(String userName, String password)
        {
            try
            {
                DatabaseOpen();
                String strSQLCommand = String.Format("INSERT INTO tb_staff (username, password) " +
                    "VALUES ('{0}', '{1}');", userName, password);

                SqlCommand command = SQLCommandString(strSQLCommand);
                command.ExecuteNonQuery();
                DatabaseClose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Add Respondent
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="ipAddress"></param>
        /// <param name="doDate"></param>
        /// <returns></returns>
        public static int AddRespondent(int memberID, String ipAddress, DateTime doDate)
        {
            try
            {
                DatabaseOpen();
                String strSQLCommand;
                if (memberID > 0)
                {
                    strSQLCommand = String.Format("INSERT INTO tb_respondent (member_id, ip_address, do_date) " +
                                        "VALUES ({0}, '{1}', '{2}');", memberID, ipAddress, doDate.ToShortDateString());
                }
                else
                {
                    strSQLCommand = String.Format("INSERT INTO tb_respondent (ip_address, do_date) " +
                                        "VALUES ('{0}', '{1}');", ipAddress, doDate.ToShortDateString());
                }

                SqlCommand command = SQLCommandString(strSQLCommand);
                command.ExecuteNonQuery();
                DatabaseClose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Add QuestionID and RespondentID to tb_answer table
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="respondentID"></param>
        /// <returns></returns>
        public static int AddAnswer(int questionID, int respondentID)
        {
            try
            {
                DatabaseOpen();
                String strSQLCommand = String.Format("INSERT INTO tb_answer (question_id, respondent_id) " +
                    "VALUES ({0}, {1});", questionID, respondentID);

                SqlCommand command = SQLCommandString(strSQLCommand);
                command.ExecuteNonQuery();
                DatabaseClose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Add Answer into tb_answer_record
        /// </summary>
        /// <param name="AnswerID"></param>
        /// <param name="AnswerDetail"></param>
        /// <returns></returns>
        public static int AddAnswerDetail(int AnswerID, String AnswerDetail)
        {
            try
            {
                DatabaseOpen();
                String strSQLCommand = String.Format("INSERT INTO tb_answer_record (answer_id, answer_detail) " +
                    "VALUES ({0}, '{1}');", AnswerID, AnswerDetail);

                SqlCommand command = SQLCommandString(strSQLCommand);
                command.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Check Username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static int CheckUserStaff(String userName)
        {
            try
            {
                int countUser;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT COUNT(staff_id) FROM tb_staff " +
                    "WHERE username = '{0}';", userName);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                countUser = reader.GetInt32(0);
                
                DatabaseClose();
                return countUser;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Get AnswerID by QuestionID and RespondentID
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="respondentID"></param>
        /// <returns></returns>
        public static int GetAnswerID(int questionID,int respondentID)
        {
            try
            {
                int answerID = 0;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT answer_id FROM tb_answer " +
                    "WHERE question_id = {0} AND respondent_id = {1};", questionID, respondentID);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    answerID = (int)reader["answer_id"];
                }
                DatabaseClose();
                return answerID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Check Username and Password for login
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static int CheckLogin(String UserName, String Password)
        {
            try
            {
                int countUser = 0;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT * FROM tb_staff WHERE username = '{0}' AND password = '{1}';", UserName, Password);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                countUser = reader.GetInt32(0);

                DatabaseClose();
                return countUser;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Get Question Detail
        /// </summary>
        /// <param name="questionNumber"></param>
        /// <returns></returns>
        public static QuestionDetail GetQustionDetail(int questionNumber)
        {
            try
            {
                QuestionDetail questionDetail = new QuestionDetail();
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT * FROM tb_question WHERE question_id = {0};", questionNumber);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    questionDetail.QuestionID = (int)reader["question_id"];
                    questionDetail.QuestionTypeID = (int)reader["question_type_id"];
                    questionDetail.QuestionName = (string)reader["description"];
                    questionDetail.HasSubQuestion = (int)reader["check_next"];
                }

                reader.Close();

                strSQLCommand = String.Format("SELECT * FROM tb_question_detail WHERE question_id = {0};", questionNumber);

                command.CommandText = strSQLCommand;
                reader = command.ExecuteReader();

                questionDetail.ListChoiceOfQuestion = new List<string>();
                questionDetail.ListNextQuestion = new List<int>();

                while (reader.Read())
                {
                    
                    if (questionDetail.QuestionTypeID != 1)
                    {
                        questionDetail.ListChoiceOfQuestion.Add((string)reader["name"]);
                        if (!reader.IsDBNull(reader.GetOrdinal("next_question")))
                            questionDetail.ListNextQuestion.Add((int)reader["next_question"]);
                        else
                            questionDetail.ListNextQuestion.Add(-1);
                    }
                    else if (questionDetail.QuestionTypeID == 1)
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("next_question")))
                            questionDetail.QuestionNext =  (int)reader["next_question"];
                        else
                            questionDetail.QuestionNext = -1;

                        DatabaseClose();
                        return questionDetail;

                    }
                }

                DatabaseClose();
                return questionDetail;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Total Question in tb_question table
        /// </summary>
        /// <returns></returns>
        public static int GetTotalQuestion()
        {
            try
            {
                int countQuestion = 0;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT COUNT(question_id) FROM tb_question;");

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                countQuestion = reader.GetInt32(0);

                DatabaseClose();
                return countQuestion;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        /// <summary>
        /// Get List of Main question from tb_question table
        /// </summary>
        /// <param name="questionStart"></param>
        /// <returns></returns>
        public static List<int> GetListOfMainQuestion(int questionStart)
        {
            try
            {
                List<int> lstMainQuestion = new List<int>();
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT question_id FROM tb_question WHERE main_question = 1 AND question_id >= {0};", questionStart);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstMainQuestion.Add(reader.GetInt32(0));
                }
                DatabaseClose();
                return lstMainQuestion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Next question by questionID
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static int GetNextQuestionNumber(int question)
        {
            try
            {
                int nextQuestion;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT DISTINCT next_question FROM tb_question_detail WHERE question_id = {0};", question);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                if (!reader.IsDBNull(reader.GetOrdinal("next_question")))
                    nextQuestion = (int)reader["next_question"];
                else
                    nextQuestion = -1;
                DatabaseClose();
                return nextQuestion;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        /// <summary>
        /// Get Respondent ID by IP Address
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public static int GetRespondentIDByIP(String IPAddress)
        {
            try
            {
                int respondentID = -1;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT respondent_id FROM tb_respondent WHERE ip_address LIKE '{0}';", IPAddress);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    respondentID = (int)(reader.GetInt32(0));
                }

                return respondentID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Get RespondentID by memberID
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public static int GetRespondentIDByMemberID(int memberID)
        {
            try
            {
                int respondentID = -1;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT respondent_id FROM tb_respondent WHERE member_id = '{0}';", memberID);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    respondentID = (int)(reader.GetInt32(0));
                }

                return respondentID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// To Register member
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="respondentID"></param>
        /// <returns></returns>
        public static int UpdateResponedent(int memberID, int respondentID)
        {
            try
            {
                DatabaseOpen();
                String strSQLCommand = String.Format("UPDATE tb_respondent SET member_id = {0} " +
                    "WHERE respondent_id = {1};", memberID, respondentID);

                SqlCommand command = SQLCommandString(strSQLCommand);
                command.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Add New member to tb_member table
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int AddNewMember(String firstName,String lastName, String dateOfBirth, String phone, String email)
        {
            try
            {
                DatabaseOpen();
                String strSQLCommand = String.Format("INSERT INTO tb_member (first_name, last_name, dob, phone, email) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", firstName,lastName,dateOfBirth,phone,email);

                SqlCommand command = SQLCommandString(strSQLCommand);
                command.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Get memberID by Phone number
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static int GetMemberIDbyPhone(String phone)
        {
            try
            {
                int memberID = -1;
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT member_id FROM tb_member WHERE phone LIKE '{0}';", phone);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    memberID = (int)(reader.GetInt32(0));
                }

                return memberID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Get List of question name for staff search
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String,int> GetListOfQuestionName()
        {
            try
            {
                Dictionary<String, int> dicQuestion = new Dictionary<string, int>();
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT description, question_id FROM tb_question;");

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                { 
                    dicQuestion.Add((String)reader["description"],(int)reader["question_id"]);
                }

                return dicQuestion;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static List<string> GetListOfChoiceQuestionByQuestionID(string questionID)
        {
            try
            {
                List<String> lstQuestionChoice = new List<string>();
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT name FROM tb_question_detail WHERE question_id = {0};", questionID);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstQuestionChoice.Add((String)reader["name"]);
                }

                return lstQuestionChoice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Nanme Question by Question ID
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public static string GetNameofQuestionbyQuestionID(string questionID)
        {
            try
            {
                string nameOfQuestion = "";
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT description FROM tb_question WHERE question_id = {0};", questionID);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nameOfQuestion = (String)reader["description"];
                }

                return nameOfQuestion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get List of Answers by QuestionID
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public static List<string> GetListOfAnswersByQuestionID(string questionID)
        {
            try
            {
                List<String> lstQuestionChoice = new List<string>();
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT ad.answer_detail FROM tb_answer_record AS ad " +
                    "INNER JOIN tb_answer AS a ON ad.answer_id = a.answer_id WHERE a.question_id = {0};", questionID);

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstQuestionChoice.Add((String)reader["answer_detail"]);
                }

                return lstQuestionChoice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get List of Respondent
        /// </summary>
        /// <returns></returns>
        public static List<string> GetListOfRespondent()
        {
            try
            {
                List<String> lstQuestionChoice = new List<string>();
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT * FROM tb_respondent);");

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstQuestionChoice.Add((String)reader["answer_detail"]);
                }

                return lstQuestionChoice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Data into Grid View by AnswerID
        /// </summary>
        /// <param name="lstAnswerID"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataByListOfAnswerID(List<int> lstAnswerID)
        {
            try
            {
                List<int> lstRespodnent = new List<int>();
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < lstAnswerID.Count; i++)
                {
                    if (i != lstAnswerID.Count - 1)
                        strB.AppendFormat("answer_id = {0} OR ", lstAnswerID[i]);
                    else
                        strB.AppendFormat("answer_id = {0}", lstAnswerID[i]);
                }

                DatabaseOpen();

                String strSQLCommand = String.Format("SELECT RE.respondent_id, RE.ip_address, RE.do_date, MEM.first_name, MEM.last_name, MEM.dob, MEM.phone, MEM.email FROM tb_respondent  AS RE " +
                    "LEFT JOIN tb_member AS MEM ON RE.member_id = MEM.member_id " +
                    "WHERE respondent_id IN (SELECT respondent_id FROM tb_answer " +
                    "WHERE {0});", strB.ToString());

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get List of AnswerID by Answer Detail
        /// </summary>
        /// <param name="lstAnswer"></param>
        /// <returns></returns>
        public static List<int> GetListofAnswerIDbyAnswer(List<string> lstAnswer)
        {
            try
            {
                List<int> lstAnswerID = new List<int>();
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < lstAnswer.Count; i++)
                {
                    if(i != lstAnswer.Count - 1)
                        strB.AppendFormat("answer_detail LIKE '{0}' OR ",lstAnswer[i]);
                    else
                        strB.AppendFormat("answer_detail LIKE '{0}'", lstAnswer[i]);
                }
                
                DatabaseOpen();
                String strSQLCommand = String.Format("SELECT answer_id FROM tb_answer_record " +
                    "WHERE {0};",strB.ToString());

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstAnswerID.Add((int)reader["answer_id"]);
                }

                return lstAnswerID;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get All respondents Data into Grid View 
        /// </summary>
        /// <param name="lstAnswerID"></param>
        /// <returns></returns>
        public static SqlDataReader GetAllDataRespondents()
        {
            try
            {
                DatabaseOpen();

                String strSQLCommand = String.Format("SELECT RE.respondent_id, RE.ip_address, RE.do_date, MEM.first_name, MEM.last_name, MEM.dob, MEM.phone, MEM.email FROM tb_respondent  AS RE " +
                    "LEFT JOIN tb_member AS MEM ON RE.member_id = MEM.member_id;");

                SqlCommand command = SQLCommandString(strSQLCommand);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
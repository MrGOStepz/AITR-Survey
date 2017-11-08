using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR
{
    public class AppSession
    {
        /// <summary>
        /// Set Respondent ID into Session
        /// </summary>
        /// <param name="respondentID"></param>
        public static void SetRespondentID(int respondentID)
        {
            HttpContext.Current.Session["ResoindentID"] = respondentID;
        }

        /// <summary>
        /// Get Respondent ID from Session
        /// </summary>
        /// <returns></returns>
        public static int GetRespondentID()
        {
            if (HttpContext.Current.Session["ResoindentID"] != null)
                return (int)HttpContext.Current.Session["ResoindentID"];
            else
                return -1;
        }

        /// <summary>
        /// Get Question Number From Session
        /// </summary>
        /// <returns></returns>
        public static object GetListOfQuestion()
        {
            return HttpContext.Current.Session["ListOfQuestion"];
        }

        /// <summary>
        /// Set List of Question and Answer into session
        /// </summary>
        /// <param name="sessionDetail"></param>
        public static void SetInitialSession(SessionDetail sessionDetail)
        {
            HttpContext.Current.Session["SessionDetail"] = sessionDetail;
        }

        /// <summary>
        /// Get List of Question and Answer from session
        /// </summary>
        /// <returns></returns>
        public static object GetInitialSession()
        {
            if (HttpContext.Current.Session["SessionDetail"] != null)
                return HttpContext.Current.Session["SessionDetail"];
            else
                return null;
        }
    }
}
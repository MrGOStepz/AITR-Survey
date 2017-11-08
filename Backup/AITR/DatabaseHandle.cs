using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AITR
{
    enum DatabaseStatus
    { 
        success,
        error,
        
    }
    public static class DatabaseHandle
    {
        public static int AddMember(String firstName,String lastName, String phoneNuber, DateTime dateOfBirth)
        {
            String connectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectString;
            connection.Open();
            return 1;

        }
    }
    
}
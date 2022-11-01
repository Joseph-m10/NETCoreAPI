using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.DAL
{
    public class DAL
    {

        //string con = 
        public static string GetToken(string uname, string password)
        {
            var sql = new SqlCommand();
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandText = "loginSP";
            sql.Parameters.AddWithValue("@uname",uname);
            sql.Parameters.AddWithValue("@password",password);
            //using (SqlConnection conn = new SqlConnection(con))
            //{

            //}
            return "1";   
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EDMService.Models;
using Newtonsoft.Json;

namespace EDMService.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/Login/{username}/{password}")]
        public string Get(string username, string password)
        {

            string sql ="SELECT CS.CompanyName,Users.*, getDate() as sysDate,L.Location As Location FROM Users INNER JOIN CompanySetup CS on CS.CompanyID = Users.CompanyID Inner Join GS_Locations L On L.LocationID = CS.LocationID  WHERE Login = '" +
                username + "' AND Password = '" + PerformCrypt(password.Trim()) + "'";
          
            SqlConnection connection;


            User user = new User();
            user.login = false;
            SqlCommand command;
            SqlDataReader dataReader;
            //connetionString = ConfigurationManager.ConnectionStrings["databaseString"].ConnectionString;
            string  connetionString = "Data Source=bizsoft.com.pk;Initial Catalog=b_PGM;User ID=sa_Pgm;Password=Pgm@2016";

            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user.login = true;
                    user.userId = dataReader.GetInt32(1);
                }

                dataReader.Close();
                command.Dispose();
                connection.Close();
                return JsonConvert.SerializeObject(user);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public string PerformCrypt(string strText)
        {
            //This function will perform the functionality of Encryption and Decryption as well
            int i = 0;
            string strResult = "";

            for (i = 0; i < strText.Length; i++)
            {
                int asc = ((int)strText[i]);
                if (asc < 128)
                {
                    strResult += ((char)(((int)strText[i]) + 128)).ToString();
                }
                else if (asc > 128)
                {
                    strResult += ((char)(((int)strText[i]) - 128)).ToString();
                }
            }
            return strResult;
        }
    }
}

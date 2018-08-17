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
    public class MobileUserLoginController : ApiController
    {

        [Route("api/MobileUserLogin/{cnic}/{mobileNo}")]
        public string Get(string cnic, string mobileNo)
        {
            string sql = "select * from MobileUsers where Cnic = '" + cnic + "'";
            //string sqlInsert = "insert into MobileUsers(CNIC) values ('"+cnic+"')";
            string sqlInsert = "insert into MobileUsers(CNIC,MobileNo) values ('"+cnic+"','"+mobileNo+"')";

            SqlConnection connection;
            MobileUserLogin user = new MobileUserLogin();
            user.found = false; 
            SqlCommand command;
            
            SqlDataReader dataReader;
           

            //connetionString = ConfigurationManager.ConnectionStrings["databaseString"].ConnectionString;
            string connetionString = "Data Source=bizsoft.com.pk;Initial Catalog=b_PGM;User ID=sa_Pgm;Password=Pgm@2016";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();



                while (dataReader.Read())
                {
                    user.found = true;


                    user.cnic = dataReader.GetString(1);
                    user.number = dataReader.GetString(2);
                    user.status = dataReader.GetInt32(3);
                    

                }

                dataReader.Close();
                if (!user.found)
                {
                    command = new SqlCommand(sqlInsert, connection);
                    user.cnic = cnic;
                    user.number = mobileNo;
                    user.status = command.ExecuteNonQuery();
                    user.status = 0;


                }



               
                command.Dispose();


               
                connection.Close();
                return JsonConvert.SerializeObject(user);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }





        }





    }
}

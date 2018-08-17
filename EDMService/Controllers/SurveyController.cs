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
    public class SurveyController : ApiController
    {


        [Route("api/Survey/{surveyedBy}/{cnic}/{party}")] 

        
public string Get(string surveyedBy, string cnic, string party)
        {
            string sql = "INSERT INTO SURVEY values ('" + surveyedBy + "','" + cnic + "','" + party + "',GetDate())";

            SqlConnection connection;
            SqlCommand command;
            Survey person = new Survey();
            person.status = 0;
       


            //connetionString = ConfigurationManager.ConnectionStrings["databaseString"].ConnectionString;
            string connetionString = "Data Source=bizsoft.com.pk;Initial Catalog=b_PGM;User ID=sa_Pgm;Password=Pgm@2016";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                person.surveyed_by = surveyedBy;
                person.cnic = cnic;
                person.supporting_party = party;
                person.status = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return JsonConvert.SerializeObject(person);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }





        }
    }
}

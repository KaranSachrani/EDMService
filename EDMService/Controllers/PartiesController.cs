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
    public class PartiesController : ApiController
    {
        [Route("api/Parties")]
        public string Get()
        {


            string sql = "select Description from GS_Voter_Party";
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            List<Parties> parties= new List<Parties>();



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
                    
                    parties.Add(new Parties {name = dataReader.GetString(0)});
                   

                }

                dataReader.Close();
                command.Dispose();
                connection.Close();



                return JsonConvert.SerializeObject(parties);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }





        }



    }
}

using EDMService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EDMService.Controllers
{
    public class GetAllMembersController : ApiController
    {
        [Route("api/GetAllMembers")]
        public string Get()
        {


            string sql = "SP_Voter_Slip_All";
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            List<Search> VoterSlipList = new List<Search>();



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
                    VoterSlipList.Add(new Search(SafeGetString(dataReader, 0), SafeGetString(dataReader, 1), SafeGetString(dataReader, 2), SafeGetString(dataReader, 3), SafeGetString(dataReader, 4), SafeGetString(dataReader, 5), SafeGetString(dataReader, 6), SafeGetString(dataReader, 7), SafeGetString(dataReader, 8), SafeGetString(dataReader, 9), SafeGetString(dataReader, 10), SafeGetString(dataReader, 11), SafeGetString(dataReader, 12), SafeGetString(dataReader, 13), SafeGetString(dataReader, 14), SafeGetString(dataReader, 15), SafeGetString(dataReader, 16), SafeGetString(dataReader, 17),
                                           SafeGetString(dataReader, 18), true));
                }

                dataReader.Close();
                command.Dispose();
                connection.Close();


                return JsonConvert.SerializeObject(VoterSlipList);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }



        }



        public static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetValue(colIndex).ToString();
            return string.Empty;
        }

    }
}

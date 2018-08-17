using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EDMService.Models;    
using Newtonsoft.Json;

namespace EDMService.Controllers
{
    public class FamilyController : ApiController
    {
        [Route("api/Family/{cnic}")]
        public string Get(string cnic)
        {


            string sql = "select Gharana,BlockCode from GS_Voters where Cnic = '" + cnic + "'";
            SqlConnection connection;
            Family user = new Family(); 
            user.found = false;
            SqlCommand command;
            SqlCommand command2;
            SqlDataReader dataReader;
            SqlDataReader dataReader2;
            List<FamiliyList> members = new List<FamiliyList>();
            
            

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
                    user.ghNum = dataReader.GetString(0);
                    user.blockCode =dataReader.GetString(1);

                }

                dataReader.Close();
                command.Dispose();



  string sqlnic = " select Cnic, Name from GS_Voters where Gharana = '" + user.ghNum + "' and BlockCode =  '" + user.blockCode + "' and CNIC not in (select CNIC from SURVEY )";
                command2 = new SqlCommand(sqlnic, connection);
                dataReader2 = command2.ExecuteReader();
                while (dataReader2.Read())
                {

                    members.Add(new FamiliyList { nic = dataReader2.GetString(0), name = dataReader2.GetString(1) });

                   


                }

                dataReader2.Close();
                command2.Dispose();
                connection.Close();
              

                
                return JsonConvert.SerializeObject(members);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }





        }


              

    }
}

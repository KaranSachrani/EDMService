using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EDMService.Models;
using Newtonsoft.Json;

namespace EDMService.Controllers
{
    public class UserVerificationController : ApiController
    {
        [Route("api/UserVerification/{mobileNo}/{code}")]
        public string Get(string mobileNo,string code )
            {

           
            
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            SqlDataAdapter da;
           



            //connetionString = ConfigurationManager.ConnectionStrings["databaseString"].ConnectionString;
            string connetionString = "Data Source=bizsoft.com.pk;Initial Catalog=b_PGM;User ID=sa_Pgm;Password=Pgm@2016";
            connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    String StrQry = "Select top 1 * from GS_SMS_Setting where isActive = 1";
                    da = new SqlDataAdapter(StrQry, connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    SMSSending obj = new SMSSending();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string msg = "Your Code is " + code;
                        obj.SendSMS(ds.Tables[0].Rows[0]["FromName"].ToString(), mobileNo,msg,ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["Password"].ToString(),
                            ds.Tables[0].Rows[0]["URL"].ToString(), ds.Tables[0].Rows[0]["UniCode"].ToString(), ds.Tables[0].Rows[0]["ShortCode"].ToString());
                    }
                
                
                connection.Close();



                return JsonConvert.SerializeObject("");

            }
            catch (Exception ex)
            {
                return ex.Message;
            }





        }


    }
}

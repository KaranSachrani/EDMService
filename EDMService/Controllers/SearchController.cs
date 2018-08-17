using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using EDMService.Models;
using Newtonsoft.Json;


namespace EDMService.Controllers
{
    public class SearchController : ApiController
    {
     
        public string Get(string id)
        {
            Search search = new Search();
            search.found = false;
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            //connetionString = ConfigurationManager.ConnectionStrings["databaseString"].ConnectionString;
            connetionString = "Data Source=bizsoft.com.pk;Initial Catalog=b_PGM;User ID=sa_Pgm;Password=Pgm@2016";

            sql = "sp_Voter_slip '" + id + "'";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    search = new Search(SafeGetString(dataReader,0), SafeGetString(dataReader, 1), SafeGetString(dataReader, 2), SafeGetString(dataReader, 3), SafeGetString(dataReader, 4), SafeGetString(dataReader, 5), SafeGetString(dataReader, 6), SafeGetString(dataReader, 7), SafeGetString(dataReader, 8), SafeGetString(dataReader, 9), SafeGetString(dataReader, 10), SafeGetString(dataReader, 11), SafeGetString(dataReader, 12), SafeGetString(dataReader, 13), SafeGetString(dataReader, 14), SafeGetString(dataReader, 15), SafeGetString(dataReader, 16), SafeGetString(dataReader, 17),
                        SafeGetString(dataReader, 18), true);
                        search.error = false;
                        break;
                }

                dataReader.Close();
                command.Dispose();
                connection.Close();
                return JsonConvert.SerializeObject(search);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

          
           
        }

        public string Get()
        {
            string data = "error";
            return JsonConvert.SerializeObject(data);
        }

        
        public static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetValue(colIndex).ToString();
            return string.Empty;
        }
        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                tw?.Close();
            }
            return sw.ToString();
        }
    }
}

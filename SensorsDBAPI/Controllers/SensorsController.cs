using SensorsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensorsDBAPI.Controllers
{
    public class SensorsController : ApiController
    {
        string connectionString = SensorsDBAPI.Properties.Settings.Default.ConnString;


        // GET: api/Sensors
        public IHttpActionResult Get()
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sensors", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sensor s = new Sensor
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        id_sensor = int.Parse(reader["id_sensor"].ToString()),
                        Temperature = float.Parse(reader["Temperature"].ToString()),
                        Humidity = float.Parse(reader["Humidity"].ToString()),
                        Date = (DateTime) reader["Date"],
                    };
                    sensors.Add(s);
                }
                Console.WriteLine(sensors.Count);
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    return Ok(e.Message);
                }
            }
            return Ok(sensors);
        }
    }
}

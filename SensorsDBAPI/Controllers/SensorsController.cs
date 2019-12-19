using SensorsDBAPI.Filters;
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
    [BasicAuthentication]
    public class SensorsController : ApiController
    {
        string connectionString = SensorsDBAPI.Properties.Settings.Default.ConnString;


        // GET: api/Sensors
        [Route("api/sensors")]
        public IEnumerable<Sensor> GetDataSensors()
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
                        Battery = int.Parse(reader["Battery"].ToString()),
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
                }
            }
            return sensors;
        }

        [Route("api/sensors/all")]
        public IHttpActionResult GetAllSensors()
        {
            List<int> sensors = new List<int>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT id_sensor FROM Sensors");
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sensors.Add(int.Parse(reader["id_sensor"].ToString()));
                }
                reader.Close();
                conn.Close();
                return Ok(sensors);
            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return NotFound();
        }

        [Route("api/sensors/{id:int}")]
        public IHttpActionResult GetDataSensorsByIdSensor(int id)
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sensors WHERE id_sensor=@id");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sensor s = new Sensor
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        id_sensor = int.Parse(reader["id_sensor"].ToString()),
                        Temperature = float.Parse(reader["Temperature"].ToString()),
                        Humidity = float.Parse(reader["Humidity"].ToString()),
                        Battery = int.Parse(reader["Battery"].ToString()),
                        Date = (DateTime)reader["Date"],
                    };
                    sensors.Add(s);
                }
                reader.Close();
                conn.Close();
                return Ok(sensors);
            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return NotFound();
        }

        [Route("api/sensors/{date1}/{date2}")]
        public IHttpActionResult GetSensorsByDate(DateTime date1, DateTime date2)
        {
            List<Sensor> lista = new List<Sensor>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sensors WHERE Date BETWEEN @date1 AND @date2");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@date1", date1);
                cmd.Parameters.AddWithValue("@date2", date2);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sensor p = new Sensor
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        id_sensor = int.Parse(reader["id_sensor"].ToString()),
                        Temperature = float.Parse(reader["Temperature"].ToString()),
                        Humidity = float.Parse(reader["Humidity"].ToString()),
                        Battery = int.Parse(reader["Battery"].ToString()),
                        Date = (DateTime)reader["Date"],
                    };
                    lista.Add(p);
                }
                reader.Close();
                conn.Close();
                return Ok(lista);
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return NotFound();
        }
    }
}

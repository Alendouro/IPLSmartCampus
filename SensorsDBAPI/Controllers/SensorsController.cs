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
        public IEnumerable<SensorData> GetDataSensors()
        {
            List<SensorData> sensors = new List<SensorData>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM sensorsData", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SensorData s = new SensorData
                    {
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
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT id_sensor FROM sensorsData");
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
            List<SensorData> sensors = new List<SensorData>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM sensorsData WHERE id_sensor=@id");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SensorData s = new SensorData
                    {
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

        

        //Post new sensor

        //Post new data of sensor
        [Route("api/sensor")]
        [HttpPost]
        public IHttpActionResult PostSensor([FromBody]SensorData data)
        {
            List<int> sensorlist = new List<int>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Sensor";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sensorlist.Add(int.Parse(reader["sensor"].ToString()));
                }

                if (!sensorlist.Contains(int.Parse(data.id_sensor.ToString()))){
                    return BadRequest("Sensor does not exist");
                }
                reader.Close();

                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sensorsData " +
                        "WHERE id_sensor = @id_sensor AND Date = @date AND Temperature = @temperature AND Humidity = @humidity " +
                        "AND Battery = @battery) " +
                    "BEGIN " +
                        "INSERT INTO sensorsData (id_sensor, Temperature, Humidity, Date, Battery) VALUES (@id_sensor, @temperature, @humidity, @date, @battery) " +
                    "END";
                cmd.Parameters.AddWithValue("@id_sensor", int.Parse(data.id_sensor.ToString()));
                cmd.Parameters.AddWithValue("@temperature", float.Parse(data.Temperature.ToString()));
                cmd.Parameters.AddWithValue("@humidity",float.Parse(data.Humidity.ToString()));
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(data.Date.ToString()));
                cmd.Parameters.AddWithValue("@battery", int.Parse(data.Battery.ToString()));

                cmd.ExecuteScalar();
                conn.Close();


            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                return BadRequest(e.Message);
            }

            return Ok();

        }

        [Route("api/sensors/date")]
        public IHttpActionResult GetSensorsByDate()
        {
            var queryStrings = new Dictionary<string, string>();
            string date1;
            string date2;
            foreach (var queryNameValuePair in Request.GetQueryNameValuePairs())
            {
                queryStrings[queryNameValuePair.Key] = queryNameValuePair.Value;
            }
            queryStrings.TryGetValue("date1", out date1);
            queryStrings.TryGetValue("date2", out date2);

            DateTime dateToCompareFirst = DateTime.Parse(date1);
            DateTime dateToCompareLast = DateTime.Parse(date2);

            List<SensorData> lista = new List<SensorData>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM sensorsData WHERE Date BETWEEN @date1 AND @date2");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@date1", dateToCompareFirst);
                cmd.Parameters.AddWithValue("@date2", dateToCompareLast);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SensorData p = new SensorData
                    {
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

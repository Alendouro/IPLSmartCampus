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
    //[BasicAuthentication]
    public class AlertsController : ApiController
    {
        string connectionString = SensorsDBAPI.Properties.Settings.Default.ConnString;

        [Route("api/alerts")]
        public IEnumerable<Alert> GetAlerts()
        {
            List<Alert> alerts = new List<Alert>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alerts", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Alert a = new Alert
                    {
                        id = int.Parse(reader["id"].ToString()),
                        type = reader["type"].ToString(),
                        condition = reader["condition"].ToString(),
                        value = float.Parse(reader["value"].ToString()),
                        valueMax = (reader["valueMax"] == DBNull.Value) ? 0 : float.Parse(reader["valueMax"].ToString()),
                        state = reader["state"].ToString(),
                    };
                    alerts.Add(a);
                }
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
            return alerts;
        }

        [Route("api/alerts/{state}")]
        public IHttpActionResult GetAlertsByState(string state)
        {
            List<Alert> lista = new List<Alert>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alerts WHERE state=@sta");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@sta", state);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Alert p = new Alert
                    {
                        id = int.Parse(reader["id"].ToString()),
                        type = reader["type"].ToString(),
                        condition = reader["condition"].ToString(),
                        value = float.Parse(reader["value"].ToString()),
                        valueMax = (reader["valueMax"] == DBNull.Value) ? 0 : float.Parse(reader["valueMax"].ToString()),
                        state = reader["state"].ToString(),
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

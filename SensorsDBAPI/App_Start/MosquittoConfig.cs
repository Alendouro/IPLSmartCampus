using System;
using System.Data.SqlClient;
using System.Text;
using System.Web.Http;
using System.Windows.Forms;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SensorsDBAPI
{
    public static class MosquittoConfig
    {
        private static MqttClient mClient = new MqttClient("127.0.0.1"); //OR use the broker hostname;
        private static string[] mStrTopicsInfo = { "sensors" };
        private static string connectionString = SensorsDBAPI.Properties.Settings.Default.ConnString;

        public static void Register(HttpConfiguration config)
        {
            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                return;
            }
            //Specify events we are interest on
            //New Msg Arrived
            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }; //QoS – depends on the topics number
            //Subscribe to topics
            mClient.Subscribe(mStrTopicsInfo, qosLevels);
        }


        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String msg = Encoding.UTF8.GetString(e.Message);
            XmlDocument xm = new XmlDocument();
            xm.LoadXml(string.Format(msg));
            XmlNodeList nodeList = xm.SelectNodes("/sensors/sensor");
            SqlConnection conn = new SqlConnection(SensorsDBAPI.Properties.Settings.Default.ConnString);
            //Save temperatures data in an array
            conn = new SqlConnection(connectionString);
            conn.Open();
            
            foreach (XmlNode sensor in nodeList)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM Sensors " +
                    "WHERE id_sensor = @id AND Date = @date AND Temperature = @temperature AND Humidity = @humidity " +
                    "AND Battery = @battery) " +
                    "BEGIN " +
                    "INSERT INTO Sensors (id_sensor, Temperature, Humidity, Date, Battery) VALUES (@id, @temperature, @humidity, @date, @battery) " +
                    "END";
                cmd.Parameters.AddWithValue("@id", float.Parse(sensor.SelectSingleNode("id").InnerText));
                cmd.Parameters.AddWithValue("@temperature", float.Parse(sensor.SelectSingleNode("temperature").InnerText));
                cmd.Parameters.AddWithValue("@humidity", float.Parse(sensor.SelectSingleNode("humidity").InnerText));
                cmd.Parameters.AddWithValue("@battery", int.Parse(sensor.SelectSingleNode("battery").InnerText));
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(sensor.SelectSingleNode("date").InnerText));
                cmd.ExecuteScalar();
            }
            conn.Close();

        }
    }
}
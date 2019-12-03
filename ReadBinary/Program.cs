using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Xml;

namespace ReadBinary
{
    class Program
    {

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) +
            " on topic " + e.Topic);
        }

        static void Main(string[] args)
        {
            MqttClient mClient = new MqttClient("127.0.0.1");
            string[] topic = { "sensors" };

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }

            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE}; 

            mClient.Subscribe(topic, qosLevels);

            //Console.ReadKey();

            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topic); //Put this in a button to see notif!
                mClient.Disconnect(); //Free process and process's resources
            }

            ReadingBinary("C:\\Users\\joao_\\data.bin");
        }

        private static void ReadingBinary(string path) {
            //FileStream fs = new FileStream(path, FileMode.Open);
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open))) {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    int id = (byte)br.ReadInt32();
                    float temperature = br.ReadSingle();
                    float humidity = br.ReadSingle();
                    int battery = (byte)br.ReadInt32();
                    int timestamp = br.ReadInt32();
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToLocalTime();
                    string formattedDate = dt.ToString("dd-MM-yyyy HH:mm");
                    int trash = br.ReadInt32();

                    /*Console.WriteLine("Sensor ID = " + id);
                    Console.WriteLine("Tenperature = " + temperature);
                    Console.WriteLine("Humidity = " + humidity);
                    Console.WriteLine("Batery = " + battery);
                    Console.WriteLine("Data = " + formattedDate + "\n");*/

                    XmlElement xml = createSensor(id, temperature, humidity, battery, formattedDate);
                    Console.WriteLine(xml);
                }  
            }
        }

        private static XmlElement createSensor(XmlDocument doc, int id, float t, float h, int b, string d)
        {
            XmlElement sensor = doc.CreateElement("sensor");
            sensor.SetAttribute("id", id);
            XmlElement temperature = doc.CreateElement("temperature");
            temperature.InnerText = t;
            XmlElement humidity = doc.CreateElement("humidity");
            humidity.InnerText = h;
            XmlElement battery = doc.CreateElement("battery");
            battery.InnerText = b;
            XmlElement date = doc.CreateElement("date");
            date.InnerText = d;
            sensor.AppendChild(temperature);
            sensor.AppendChild(humidity);
            sensor.AppendChild(battery);
            sensor.AppendChild(date);
            return sensor;
        }

        //Converter para XML
        //Enviar para BD 
        //Criar API na BD
        //Enviar dados para APP

    }
}

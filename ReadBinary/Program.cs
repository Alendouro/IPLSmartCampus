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
        static void Main(string[] args)
        {
            MqttClient mClient = new MqttClient("127.0.0.1");

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }

            //byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};
            XmlDocument doc = ReadingBinary();
            
            mClient.Publish("sensors", Encoding.UTF8.GetBytes(doc.OuterXml), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }

        private static XmlDocument ReadingBinary() {
            int id, battery;
            float temperature, humidity;
            string formattedDate;
            BinaryReader br = new BinaryReader(File.Open("C:\\Users\\hp\\Desktop\\data.bin", FileMode.Open));
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("sensors");
            doc.AppendChild(root);
            while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    id = (byte)br.ReadInt32();
                    temperature = br.ReadSingle();
                    humidity = br.ReadSingle();
                    battery = (byte)br.ReadInt32();
                    int timestamp = br.ReadInt32();
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToLocalTime();
                    formattedDate = dt.ToString("dd-MM-yyyy HH:mm:ss");
                    int trash = br.ReadInt32();

                root.AppendChild(createSensor(doc, id, temperature, humidity, battery, formattedDate));

            }
            return doc;
        }

        private static XmlElement createSensor(XmlDocument doc, int id, float t, float h, int b, string d)
        {
            XmlElement sensor = doc.CreateElement("sensor");
            XmlElement idx = doc.CreateElement("id");
            idx.InnerText = id +"";
            XmlElement temperature = doc.CreateElement("temperature");
            temperature.InnerText = t+"";
            XmlElement humidity = doc.CreateElement("humidity");
            humidity.InnerText = h+"";
            XmlElement battery = doc.CreateElement("battery");
            battery.InnerText = b +"";
            XmlElement date = doc.CreateElement("date");
            date.InnerText = d;
            sensor.AppendChild(idx);
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

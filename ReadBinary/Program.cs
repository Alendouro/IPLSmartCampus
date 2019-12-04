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

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }

            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            //byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};
            string doc = ReadingBinary();
            

            mClient.Publish("sensors", Encoding.UTF8.GetBytes(doc), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            //ReadingBinary();
        }

        private static string ReadingBinary() {
            //FileStream fs = new FileStream(path, FileMode.Open);
            int id = 0;
            float temperature = 0;
            float humidity = 0;
            int battery = 0;
            string formattedDate = "";
            XmlElement teste = null;
            BinaryReader br = new BinaryReader(File.Open("C:\\Users\\joao_\\data.bin", FileMode.Open));
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                     id = (byte)br.ReadInt32();
                     temperature = br.ReadSingle();
                     humidity = br.ReadSingle();
                     battery = (byte)br.ReadInt32();
                    int timestamp = br.ReadInt32();
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToLocalTime();
                     formattedDate = dt.ToString("dd-MM-yyyy HH:mm");
                    int trash = br.ReadInt32();

                /*Console.WriteLine("Sensor ID = " + id);
                Console.WriteLine("Tenperature = " + temperature);
                Console.WriteLine("Humidity = " + humidity);
                Console.WriteLine("Batery = " + battery);
                Console.WriteLine("Data = " + formattedDate + "\n");*/

                // return teste;
                teste = createDocSensor(id, temperature, humidity, battery, formattedDate);
                Console.WriteLine(teste.OuterXml);
            }
            
            //Console.WriteLine(teste.OuterXml);

            return teste.OuterXml;
        }

        private static XmlElement createDocSensor(int id, float temperature, float humidity, int battery, string date) {
            XmlDocument doc = new XmlDocument();
            // Create the XML Declaration, and append it to XML document
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            // Create the root element
            XmlElement root = doc.CreateElement("sensors");
            doc.AppendChild(root);
            // Create Books
            // Note that to set the text inside the element,
            // you use .InnerText
            // You use SetAttribute to set attribute
            root.AppendChild(createSensor(doc, id, temperature, humidity, battery, date));

            doc.Save(@"sample.xml");

            return doc.DocumentElement;
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

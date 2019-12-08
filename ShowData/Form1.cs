using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages; 

namespace ShowData
{
    public partial class Form1 : Form
    {
        MqttClient mClient = new MqttClient("127.0.0.1"); //OR use the broker hostname
        string[] mStrTopicsInfo = {"sensors"};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                MessageBox.Show("Error connecting to message broker...");
                return;
            }
            //Specify events we are interest on
            //New Msg Arrived
            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }; //QoS – depends on the topics number
            //Subscribe to topics
            mClient.Subscribe(mStrTopicsInfo, qosLevels);
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // We have to invoke because the mqttp works in a callback (so it doesn't have access to the elements)
            this.Invoke( (MethodInvoker) delegate
            {
                String msg = Encoding.UTF8.GetString(e.Message);
                XmlDocument xm = new XmlDocument();
                xm.LoadXml(string.Format(msg));
                XmlNodeList nodeList = xm.SelectNodes("/sensors/sensor");
                //Save temperatures data in an array
                List<float> temperatures = new List<float>();
                List<String> datas = new List<string>();
                foreach (XmlNode sensor in nodeList)
                {
                    listBoxSensorsData.Items.Add("Id: " + sensor.SelectSingleNode("id").InnerText);
                    listBoxSensorsData.Items.Add("Temperature: " + sensor.SelectSingleNode("temperature").InnerText);
                    listBoxSensorsData.Items.Add("Humidity: " + sensor.SelectSingleNode("humidity").InnerText);
                    listBoxSensorsData.Items.Add("Battery: " + sensor.SelectSingleNode("battery").InnerText);
                    listBoxSensorsData.Items.Add("Date: " + sensor.SelectSingleNode("date").InnerText);
                    listBoxSensorsData.Items.Add("--------------------------------------------------------------");
                    if (int.Parse(sensor.SelectSingleNode("id").InnerText) == 1)
                    {
                        datas.Add(sensor.SelectSingleNode("date").InnerText);
                        temperatures.Add(float.Parse(sensor.SelectSingleNode("temperature").InnerText));
                    }
                }


                // Data arrays.
                string[] seriesArray = datas.ToArray();
                float[] pointsArray = temperatures.ToArray();

                // Set palette.
                this.chartTemperature.Palette = ChartColorPalette.SeaGreen;

                this.chartTemperature.Series.Add("Temperature");

                this.chartTemperature.Titles.Add("Temperature");

                // Add series.
                for (int i = 0; i < seriesArray.Length; i++)
                {
                    this.chartTemperature.Series["Temperature"].Points.AddXY(seriesArray[i], pointsArray[i]);
                    // Add series.
                  //  Series series = this.chartTemperature.Series.Add(seriesArray[i]);

                    // Add point.
                    //series.Points.Add(pointsArray[i]);
                }
            });
        }
    }
}

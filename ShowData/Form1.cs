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
        //Sensor 1
        List<float> temperatures = new List<float>();
        List<String> datas = new List<string>();
        XmlNodeList nodeList;

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
                nodeList = xm.SelectNodes("/sensors/sensor");
                //Save temperatures data in an array
               
                foreach (XmlNode sensor in nodeList)
                {
                    listBoxSensorsData.Items.Add("Id: " + sensor.SelectSingleNode("id").InnerText);
                    listBoxSensorsData.Items.Add("Temperature: " + sensor.SelectSingleNode("temperature").InnerText);
                    listBoxSensorsData.Items.Add("Humidity: " + sensor.SelectSingleNode("humidity").InnerText);
                    listBoxSensorsData.Items.Add("Battery: " + sensor.SelectSingleNode("battery").InnerText);
                    listBoxSensorsData.Items.Add("Date: " + sensor.SelectSingleNode("date").InnerText);
                    listBoxSensorsData.Items.Add("--------------------------------------------------------------");

                    datas.Add(sensor.SelectSingleNode("date").InnerText);
                    temperatures.Add(float.Parse(sensor.SelectSingleNode("temperature").InnerText));
                }

                //Percorrer os nodes para ir buscar os sensores existentes (p/ id) 
                List<int> ids = new List<int>();
                foreach (XmlNode sensor in nodeList)
                {
                    int id = Int32.Parse(sensor.SelectSingleNode("id").InnerText);
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                        checkedListBoxSensors.Items.Add(id);
                    }

                }
            });
        }

        private void graphChanged(string[] date, float[] temperatures)
        {
            // Data arrays.
            string[] seriesArray = date;
            float[] pointsArray = temperatures;


            if (this.chartTemperature.Series.FindByName("Temperature") != null)
            {
                this.chartTemperature.Series.Remove(this.chartTemperature.Series.FindByName("Temperature"));
                this.chartTemperature.Titles.Remove(this.chartTemperature.Titles.FindByName("Temperature"));
            }

            this.chartTemperature.Series.Add("Temperature");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                this.chartTemperature.Series["Temperature"].Points.AddXY(seriesArray[i], pointsArray[i]);
                // Add series.
                //  Series series = this.chartTemperature.Series.Add(seriesArray[i]);

                // Add point.
                //series.Points.Add(pointsArray[i]);
            }
        }


        private void CheckedListBoxSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            datas = new List<string>();
            temperatures = new List<float>();

            foreach (var series in chartTemperature.Series)
            {
                series.Points.Clear();
            }

            for (int i = 0; i < checkedListBoxSensors.Items.Count; i++)
            {
                if (checkedListBoxSensors.GetItemChecked(i) == true)
                {
                    foreach (XmlNode sensor in nodeList)
                    {
                        if (Int32.Parse(sensor.SelectSingleNode("id").InnerText) == Int32.Parse(checkedListBoxSensors.GetItemText(i + 1)))
                        {
                            datas.Add(sensor.SelectSingleNode("date").InnerText);
                            temperatures.Add(float.Parse(sensor.SelectSingleNode("temperature").InnerText));
                        }
                    }
                }
                graphChanged(datas.ToArray(), temperatures.ToArray());
            }

        }
    }
}

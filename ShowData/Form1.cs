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
using DefineAlert;

namespace ShowData
{
    public partial class Form1 : Form
    {
        MqttClient mClient = new MqttClient("127.0.0.1"); //OR use the broker hostname
        string[] mStrTopicsInfo = {"sensors", "alerts" };
        //Sensor 1
        List<double> temperatures = new List<double>();
        List<double> humidity = new List<double>();
        List<String> datas = new List<string>();
        XmlNodeList nodeList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic result = MessageBox.Show("Do You Want To Exit?", "Application Name", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
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
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }; //QoS – depends on the topics number
            //Subscribe to topics
            mClient.Subscribe(mStrTopicsInfo, qosLevels);
        }

         private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // We have to invoke because the mqttp works in a callback (so it doesn't have access to the elements)
            this.Invoke( (MethodInvoker) delegate
            {
                if(e.Topic == "sensors")
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
                        temperatures.Add(Math.Round(double.Parse(sensor.SelectSingleNode("temperature").InnerText), 2, MidpointRounding.ToEven));
                        humidity.Add(Math.Round(double.Parse(sensor.SelectSingleNode("humidity").InnerText), 2, MidpointRounding.ToEven));
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
                            checkedListBoxHum.Items.Add(id);
                        }
                    }
                }
                if (e.Topic == "alerts")
                {
                    string msg = Encoding.UTF8.GetString(e.Message);
                    //Console.WriteLine(msg);
                    if (!listBoxCurrentAlerts.Items.Contains(msg))
                    {
                        listBoxCurrentAlerts.Items.Add(msg);
                    }
                }
            });
        }

        private void CheckedListBoxSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var series in chartTemperature.Series)
            {
                series.Points.Clear();
            }

            for (int i = 0; i < checkedListBoxSensors.Items.Count; i++)
            {
                if (checkedListBoxSensors.GetItemChecked(i) == true)
                {
                    datas.Clear();
                    temperatures.Clear();
                    foreach (XmlNode sensor in nodeList)
                    {
                        if (Int32.Parse(sensor.SelectSingleNode("id").InnerText) == Int32.Parse(checkedListBoxSensors.GetItemText(i + 1)))
                        {
                            datas.Add(sensor.SelectSingleNode("date").InnerText);
                            temperatures.Add(double.Parse(sensor.SelectSingleNode("temperature").InnerText));
                        }
                    }
                    graphTemperature(datas.ToArray(), temperatures.ToArray(), (i+1).ToString());
                }
            }

        }

        private void checkedListBoxHum_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var series in chartHumidity.Series)
            {
                series.Points.Clear();
            }

            for (int i = 0; i < checkedListBoxHum.Items.Count; i++)
            {
                if (checkedListBoxHum.GetItemChecked(i) == true)
                {
                    datas.Clear();
                    humidity.Clear();
                    foreach (XmlNode sensor in nodeList)
                    {
                        if (Int32.Parse(sensor.SelectSingleNode("id").InnerText) == Int32.Parse(checkedListBoxHum.GetItemText(i + 1)))
                        {
                            datas.Add(sensor.SelectSingleNode("date").InnerText);
                            humidity.Add(double.Parse(sensor.SelectSingleNode("humidity").InnerText));
                        }
                    }
                    graphHumidity(datas.ToArray(), humidity.ToArray(), (i+1).ToString());
                }
            }
        }

        private void graphTemperature(string[] date, double[] temperatures, string serie)
        {
            // Data arrays.
            string[] seriesArray = date;
            double[] pointsArray = temperatures;

            if (this.chartTemperature.Series.FindByName(serie) != null)
            {
                this.chartTemperature.Series.Remove(this.chartTemperature.Series.FindByName(serie));
                this.chartTemperature.Titles.Remove(this.chartTemperature.Titles.FindByName(serie));
            }


            this.chartTemperature.Series.Add(serie);
            this.chartTemperature.Series[serie].IsValueShownAsLabel = true;

            chartTemperature.Series[serie].ChartType = SeriesChartType.Bar;
            chartTemperature.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                this.chartTemperature.Series[serie].Points.AddXY(seriesArray[i], pointsArray[i]);
            }
        }


        private void graphHumidity(string[] date, double[] humidity, string serie)
        {
            // Data arrays.
            string[] seriesArray = date;
            double[] pointsArray = humidity;


            if (this.chartHumidity.Series.FindByName(serie) != null)
            {
                this.chartHumidity.Series.Remove(this.chartHumidity.Series.FindByName(serie));
                this.chartHumidity.Titles.Remove(this.chartHumidity.Titles.FindByName(serie));
            }

            this.chartHumidity.Series.Add(serie);

            chartHumidity.Series[serie].ChartType = SeriesChartType.Bar;
            this.chartHumidity.Series[serie].IsValueShownAsLabel = true;

            chartHumidity.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                this.chartHumidity.Series[serie].Points.AddXY(seriesArray[i], pointsArray[i]);
            }
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            DefineAlert.AlertForm al = new AlertForm();
            al.ShowDialog();
        }
    }
}

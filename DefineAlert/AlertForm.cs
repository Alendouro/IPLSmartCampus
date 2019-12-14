using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DefineAlert
{
    public partial class AlertForm : Form
    {
        MqttClient mClient = new MqttClient("127.0.0.1"); //OR use the broker hostname
        string[] mStrTopicsInfo = { "sensors" };

        String path = @"alerts.xml";
        XmlDocument doc = new XmlDocument();
        XmlNodeList nodeList;
        public AlertForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //put the initial value in comboboxs
            comboBoxTypeAlert.SelectedIndex = 0;
            comboBoxCondition.SelectedIndex = 0;
            comboBoxState.SelectedIndex = 0;

            //connect to mqtt
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

            //start showAlerts always execute
            showAlerts();

        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                String msg = Encoding.UTF8.GetString(e.Message);
                XmlDocument xm = new XmlDocument();
                xm.LoadXml(string.Format(msg));
                nodeList = xm.SelectNodes("/sensors/sensor");
            });
        }

        private void compareValues() {
          
        }

        //define a alert and save a xmlDoc
        private void btnDefine_Click(object sender, EventArgs e)
        {
            String path = @"alerts.xml";
            XmlDocument doc = new XmlDocument();
            String type;
            String condition;
            decimal value = numericUpDownValue.Value;
            decimal valueMax = numericUpDownValueMax.Value;

            if (comboBoxTypeAlert.SelectedItem == null || comboBoxCondition.SelectedItem == null)
            {
                MessageBox.Show("Both type and condition can't null!");
                return;
            }

            if (File.Exists(path)){
                doc.Load(path);
                XmlElement rootAddAlert = doc.DocumentElement;
                XmlNode lastChild = rootAddAlert.LastChild;
                int lastId = Int32.Parse(lastChild.SelectSingleNode("id").InnerText);
                int idAtual = lastId + 1;
                type = comboBoxTypeAlert.SelectedItem.ToString();
                condition = comboBoxCondition.SelectedItem.ToString();

                if (comboBoxCondition.SelectedItem.ToString().ToUpper() == "between".ToUpper()){
                    if (value > valueMax){
                        MessageBox.Show("Value " + value + " não poder superior ao value " + valueMax);
                        return;
                    }
                    else{
                        rootAddAlert.InsertAfter(createAlert(doc, idAtual, type, condition, value, valueMax, true), lastChild);
                    }
                }
                else{
                    rootAddAlert.InsertAfter(createAlert(doc, idAtual, type, condition, value, 0, true), lastChild);
                }
                doc.Save(@"alerts.xml");
                MessageBox.Show("Cretead alert with id " + idAtual + "! Can you see him in a tab Alerts");
                showAlerts();
            }
            else{
                XmlElement rootNovoAlert = doc.CreateElement("alerts");
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);
                doc.AppendChild(rootNovoAlert);
                int firstId = 1;
                type = comboBoxTypeAlert.SelectedItem.ToString();
                condition = comboBoxCondition.SelectedItem.ToString();

                if (comboBoxCondition.SelectedItem.ToString() == "between"){
                    if (value > valueMax){
                        MessageBox.Show("Value " + value + " não poder superior ao value " + valueMax);
                    }
                    else{
                        rootNovoAlert.AppendChild(createAlert(doc, firstId, type, condition, value, valueMax, true));
                    }
                }
                else{
                    rootNovoAlert.AppendChild(createAlert(doc, firstId, type, condition, value, 0, true));
                }
                MessageBox.Show("Cretead alert with id " + firstId + "! Can you see him in a tab Alerts");
                doc.Save(@"alerts.xml");
                showAlerts();
            }
            
            
        }
        private static XmlElement createAlert(XmlDocument doc, int id, string type, string condition, decimal value, decimal valueBetweenMax, bool state)
        {
            XmlElement alert = doc.CreateElement("alert");
            XmlElement idx = doc.CreateElement("id");
            idx.InnerText = id + "";
            alert.AppendChild(idx);
            XmlElement typex = doc.CreateElement("type");
            typex.InnerText = type;
            alert.AppendChild(typex);
            XmlElement conditionx = doc.CreateElement("condition");
            conditionx.InnerText = condition;
            alert.AppendChild(conditionx);
            if (condition == "between"){
                XmlElement min = doc.CreateElement("valueMin");
                min.InnerText = value + "";
                alert.AppendChild(min);
                XmlElement max = doc.CreateElement("valueMax");
                max.InnerText = valueBetweenMax + "";
                alert.AppendChild(max);
            }
            else{
                XmlElement valuex = doc.CreateElement("value");
                valuex.InnerText = value.ToString();
                alert.AppendChild(valuex);
            }
            XmlElement statex = doc.CreateElement("state");
            statex.InnerText = state + "";
            alert.AppendChild(statex);

            return alert;
        }       
        private void comboBoxCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCondition.SelectedItem.ToString() == "between")
            {
                numericUpDownValueMax.Enabled = true;
                numericUpDownValueMax.Visible = true;
                labelBetween.Visible = true;
            }
            else {
                numericUpDownValueMax.Enabled = false;
                numericUpDownValueMax.Visible = false;
                labelBetween.Visible = false;
            }
        }

        //clear values in comboboxs and numericUpDown
        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBoxTypeAlert.SelectedIndex = 0;
            comboBoxCondition.SelectedIndex = 0;
            numericUpDownValue.Value = 0;
            numericUpDownValueMax.Value = 0;
            
        }

        //show all alerts
        private void btnShowAllAlerts_Click(object sender, EventArgs e)
        {
            showAlerts();
        }
        private void showAlerts()
        {
            if (File.Exists(path))
            {
                listBoxAlerts.Items.Clear();
                doc.Load(path);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodeList = root.SelectNodes("alert");

                foreach (XmlNode alert in nodeList)
                {
                    addElementsToListBoxAlerts(alert);
                }
            }
            else
            {
                listBoxAlerts.Items.Clear();
                listBoxAlerts.Items.Add("Don't exist file with alerts!");
            }
        }

        //add elements to list box alerts ----- used in showAlerts and activeOrInactive
        private void addElementsToListBoxAlerts(XmlNode alert)
        {
            listBoxAlerts.Items.Add("ID: " + alert.SelectSingleNode("id").InnerText);
            listBoxAlerts.Items.Add("Type: " + alert.SelectSingleNode("type").InnerText);
            listBoxAlerts.Items.Add("Condition: " + alert.SelectSingleNode("condition").InnerText);
            if (alert.SelectSingleNode("condition").InnerText.ToUpper() == "between".ToUpper())
            {
                listBoxAlerts.Items.Add("Min: " + alert.SelectSingleNode("valueMin").InnerText);
                listBoxAlerts.Items.Add("Max: " + alert.SelectSingleNode("valueMax").InnerText);
            }
            else
            {
                listBoxAlerts.Items.Add("Value: " + alert.SelectSingleNode("value").InnerText);
            }
            listBoxAlerts.Items.Add("Estado: " + alert.SelectSingleNode("state").InnerText);
            listBoxAlerts.Items.Add("--------------------------------------------------------------");
        }

        //show active or inactive state
        private void btnAlertsAtive_Click(object sender, EventArgs e)
        {
            activeOrInactive("True");
        }
        private void btnAlertsInactive_Click(object sender, EventArgs e)
        {
            activeOrInactive("False");
        }
        private void activeOrInactive(string state) {
            if (File.Exists(path))
            {
                listBoxAlerts.Items.Clear();
                doc.Load(path);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodeList = root.SelectNodes("alert");

                foreach (XmlNode alert in nodeList)
                {
                    if (alert.SelectSingleNode("state").InnerText.ToUpper() == state.ToUpper())
                    {
                        addElementsToListBoxAlerts(alert);
                    }
                }
            }
            else
            {
                listBoxAlerts.Items.Clear();
                listBoxAlerts.Items.Add("Don't exist file with alerts!");
            }
        }

        //change state
        private void btnSaveState_Click(object sender, EventArgs e)
        {
            bool state = Convert.ToBoolean(comboBoxState.SelectedItem);
            int id = Convert.ToInt32(numericUpDownState.Value);
            updateStateById(id, state);
        } 
        public bool updateStateById(int id, bool state)
        {
            bool updated = false; 
            doc.Load(path);
            XmlNode stateAtual = doc.SelectSingleNode($"/alerts/alert[id='{id}']/state");
            XmlNodeList listAlerts = doc.SelectNodes($"/alerts/alert");
            List<int> ids = new List<int>();
            foreach (XmlNode nodeAlert in listAlerts)
            {
                int nodeId = Int32.Parse(nodeAlert.SelectSingleNode("id").InnerText);
                if (!ids.Contains(nodeId)){
                    ids.Add(nodeId);
                }
            }

            if (ids.Contains(id) && stateAtual.InnerText.ToUpper() != state.ToString().ToUpper() ){
                if (stateAtual != null){
                    stateAtual.InnerText = state.ToString();
                    updated = true;
                    doc.Save(path);
                    MessageBox.Show("State of alert with id= " + id + " changed with sucess!");
                    showAlerts();
                }
                doc.Save(path);
            }
            else{
                MessageBox.Show("Alert with id= " + id + " not exist! Or the select state it's the same");
            }

            return updated;
        }
    }

}

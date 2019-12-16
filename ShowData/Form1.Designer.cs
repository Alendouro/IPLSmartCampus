namespace ShowData
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.labelTitleDesktopApp = new System.Windows.Forms.Label();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPageRealTimeSensors = new System.Windows.Forms.TabPage();
            this.listBoxSensorsData = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkedListBoxSensors = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.chartHumidity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkedListBoxHum = new System.Windows.Forms.CheckedListBox();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.listBoxCurrentAlerts = new System.Windows.Forms.ListBox();
            this.tabPage.SuspendLayout();
            this.tabPageRealTimeSensors.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHumidity)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitleDesktopApp
            // 
            this.labelTitleDesktopApp.AutoSize = true;
            this.labelTitleDesktopApp.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleDesktopApp.Location = new System.Drawing.Point(250, 9);
            this.labelTitleDesktopApp.Name = "labelTitleDesktopApp";
            this.labelTitleDesktopApp.Size = new System.Drawing.Size(274, 23);
            this.labelTitleDesktopApp.TabIndex = 0;
            this.labelTitleDesktopApp.Text = "Data From Sensors [Real Time]";
            this.labelTitleDesktopApp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPageRealTimeSensors);
            this.tabPage.Controls.Add(this.tabPage3);
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Location = new System.Drawing.Point(32, 59);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(743, 354);
            this.tabPage.TabIndex = 1;
            // 
            // tabPageRealTimeSensors
            // 
            this.tabPageRealTimeSensors.Controls.Add(this.listBoxSensorsData);
            this.tabPageRealTimeSensors.Location = new System.Drawing.Point(4, 22);
            this.tabPageRealTimeSensors.Name = "tabPageRealTimeSensors";
            this.tabPageRealTimeSensors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRealTimeSensors.Size = new System.Drawing.Size(735, 328);
            this.tabPageRealTimeSensors.TabIndex = 0;
            this.tabPageRealTimeSensors.Text = "Real Sensor Data";
            this.tabPageRealTimeSensors.UseVisualStyleBackColor = true;
            // 
            // listBoxSensorsData
            // 
            this.listBoxSensorsData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxSensorsData.FormattingEnabled = true;
            this.listBoxSensorsData.Location = new System.Drawing.Point(9, 6);
            this.listBoxSensorsData.Name = "listBoxSensorsData";
            this.listBoxSensorsData.Size = new System.Drawing.Size(720, 316);
            this.listBoxSensorsData.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkedListBoxSensors);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.chartTemperature);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(735, 328);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Temperature";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxSensors
            // 
            this.checkedListBoxSensors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxSensors.CheckOnClick = true;
            this.checkedListBoxSensors.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBoxSensors.FormattingEnabled = true;
            this.checkedListBoxSensors.Location = new System.Drawing.Point(21, 26);
            this.checkedListBoxSensors.Name = "checkedListBoxSensors";
            this.checkedListBoxSensors.Size = new System.Drawing.Size(120, 90);
            this.checkedListBoxSensors.TabIndex = 3;
            this.checkedListBoxSensors.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxSensors_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sensores";
            // 
            // chartTemperature
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend1);
            this.chartTemperature.Location = new System.Drawing.Point(148, 7);
            this.chartTemperature.Name = "chartTemperature";
            this.chartTemperature.Size = new System.Drawing.Size(578, 312);
            this.chartTemperature.TabIndex = 0;
            this.chartTemperature.Text = "chart1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chartHumidity);
            this.tabPage1.Controls.Add(this.checkedListBoxHum);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(735, 328);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Humidity";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sensores";
            // 
            // chartHumidity
            // 
            chartArea2.Name = "ChartArea1";
            this.chartHumidity.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartHumidity.Legends.Add(legend2);
            this.chartHumidity.Location = new System.Drawing.Point(148, 7);
            this.chartHumidity.Name = "chartHumidity";
            this.chartHumidity.Size = new System.Drawing.Size(578, 316);
            this.chartHumidity.TabIndex = 5;
            this.chartHumidity.Text = "chart1";
            // 
            // checkedListBoxHum
            // 
            this.checkedListBoxHum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxHum.CheckOnClick = true;
            this.checkedListBoxHum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBoxHum.FormattingEnabled = true;
            this.checkedListBoxHum.Location = new System.Drawing.Point(21, 26);
            this.checkedListBoxHum.Name = "checkedListBoxHum";
            this.checkedListBoxHum.Size = new System.Drawing.Size(120, 90);
            this.checkedListBoxHum.TabIndex = 4;
            this.checkedListBoxHum.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxHum_SelectedIndexChanged);
            // 
            // btnAlerts
            // 
            this.btnAlerts.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAlerts.Location = new System.Drawing.Point(690, 12);
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Size = new System.Drawing.Size(75, 23);
            this.btnAlerts.TabIndex = 2;
            this.btnAlerts.Text = "Alerts";
            this.btnAlerts.UseVisualStyleBackColor = true;
            this.btnAlerts.Click += new System.EventHandler(this.btnAlerts_Click);
            // 
            // listBoxCurrentAlerts
            // 
            this.listBoxCurrentAlerts.FormattingEnabled = true;
            this.listBoxCurrentAlerts.HorizontalScrollbar = true;
            this.listBoxCurrentAlerts.Location = new System.Drawing.Point(794, 81);
            this.listBoxCurrentAlerts.Name = "listBoxCurrentAlerts";
            this.listBoxCurrentAlerts.Size = new System.Drawing.Size(174, 238);
            this.listBoxCurrentAlerts.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 416);
            this.Controls.Add(this.listBoxCurrentAlerts);
            this.Controls.Add(this.btnAlerts);
            this.Controls.Add(this.tabPage);
            this.Controls.Add(this.labelTitleDesktopApp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage.ResumeLayout(false);
            this.tabPageRealTimeSensors.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHumidity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleDesktopApp;
        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPageRealTimeSensors;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBoxSensorsData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.CheckedListBox checkedListBoxSensors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHumidity;
        private System.Windows.Forms.CheckedListBox checkedListBoxHum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.ListBox listBoxCurrentAlerts;
    }
}


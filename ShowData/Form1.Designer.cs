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
            this.labelTitleDesktopApp = new System.Windows.Forms.Label();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPageRealTimeSensors = new System.Windows.Forms.TabPage();
            this.listBoxSensorsData = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage.SuspendLayout();
            this.tabPageRealTimeSensors.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
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
            this.tabPage.Location = new System.Drawing.Point(32, 59);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(740, 358);
            this.tabPage.TabIndex = 1;
            // 
            // tabPageRealTimeSensors
            // 
            this.tabPageRealTimeSensors.Controls.Add(this.listBoxSensorsData);
            this.tabPageRealTimeSensors.Location = new System.Drawing.Point(4, 22);
            this.tabPageRealTimeSensors.Name = "tabPageRealTimeSensors";
            this.tabPageRealTimeSensors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRealTimeSensors.Size = new System.Drawing.Size(732, 332);
            this.tabPageRealTimeSensors.TabIndex = 0;
            this.tabPageRealTimeSensors.Text = "Real Sensor Data";
            this.tabPageRealTimeSensors.UseVisualStyleBackColor = true;
            // 
            // listBoxSensorsData
            // 
            this.listBoxSensorsData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxSensorsData.FormattingEnabled = true;
            this.listBoxSensorsData.Location = new System.Drawing.Point(9, 10);
            this.listBoxSensorsData.Name = "listBoxSensorsData";
            this.listBoxSensorsData.Size = new System.Drawing.Size(720, 316);
            this.listBoxSensorsData.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartTemperature);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(732, 332);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "tabPage2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartTemperature
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend1);
            this.chartTemperature.Location = new System.Drawing.Point(60, 15);
            this.chartTemperature.Name = "chartTemperature";
            this.chartTemperature.Size = new System.Drawing.Size(641, 300);
            this.chartTemperature.TabIndex = 0;
            this.chartTemperature.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabPage);
            this.Controls.Add(this.labelTitleDesktopApp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage.ResumeLayout(false);
            this.tabPageRealTimeSensors.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
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
    }
}


namespace DefineAlert
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
            this.btnAlertTemperature = new System.Windows.Forms.Button();
            this.btnAlertHumidity = new System.Windows.Forms.Button();
            this.btnAlertBattery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAlertTemperature
            // 
            this.btnAlertTemperature.Location = new System.Drawing.Point(63, 68);
            this.btnAlertTemperature.Name = "btnAlertTemperature";
            this.btnAlertTemperature.Size = new System.Drawing.Size(114, 23);
            this.btnAlertTemperature.TabIndex = 0;
            this.btnAlertTemperature.Text = "Alert Temperature";
            this.btnAlertTemperature.UseVisualStyleBackColor = true;
            this.btnAlertTemperature.Click += new System.EventHandler(this.btnAlertTemperature_Click);
            // 
            // btnAlertHumidity
            // 
            this.btnAlertHumidity.Location = new System.Drawing.Point(63, 131);
            this.btnAlertHumidity.Name = "btnAlertHumidity";
            this.btnAlertHumidity.Size = new System.Drawing.Size(114, 23);
            this.btnAlertHumidity.TabIndex = 1;
            this.btnAlertHumidity.Text = "Alert Humidity";
            this.btnAlertHumidity.UseVisualStyleBackColor = true;
            this.btnAlertHumidity.Click += new System.EventHandler(this.btnAlertHumidity_Click);
            // 
            // btnAlertBattery
            // 
            this.btnAlertBattery.Location = new System.Drawing.Point(63, 188);
            this.btnAlertBattery.Name = "btnAlertBattery";
            this.btnAlertBattery.Size = new System.Drawing.Size(114, 23);
            this.btnAlertBattery.TabIndex = 2;
            this.btnAlertBattery.Text = "Alert Battery";
            this.btnAlertBattery.UseVisualStyleBackColor = true;
            this.btnAlertBattery.Click += new System.EventHandler(this.btnAlertBattery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 301);
            this.Controls.Add(this.btnAlertBattery);
            this.Controls.Add(this.btnAlertHumidity);
            this.Controls.Add(this.btnAlertTemperature);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlertTemperature;
        private System.Windows.Forms.Button btnAlertHumidity;
        private System.Windows.Forms.Button btnAlertBattery;
    }
}


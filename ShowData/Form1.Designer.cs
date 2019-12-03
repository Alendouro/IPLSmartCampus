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
            this.labelTitleDesktopApp = new System.Windows.Forms.Label();
            this.listBoxSensorsData = new System.Windows.Forms.ListBox();
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
            // listBoxSensorsData
            // 
            this.listBoxSensorsData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSensorsData.FormattingEnabled = true;
            this.listBoxSensorsData.Location = new System.Drawing.Point(36, 73);
            this.listBoxSensorsData.Name = "listBoxSensorsData";
            this.listBoxSensorsData.Size = new System.Drawing.Size(711, 342);
            this.listBoxSensorsData.TabIndex = 1;
            this.listBoxSensorsData.SelectedIndexChanged += new System.EventHandler(this.ListBoxSensorsData_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxSensorsData);
            this.Controls.Add(this.labelTitleDesktopApp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleDesktopApp;
        private System.Windows.Forms.ListBox listBoxSensorsData;
    }
}


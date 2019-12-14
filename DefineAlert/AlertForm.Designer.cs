namespace DefineAlert
{
    partial class AlertForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDefineAlert = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.labelBetween = new System.Windows.Forms.Label();
            this.numericUpDownValueMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownValue = new System.Windows.Forms.NumericUpDown();
            this.btnDefine = new System.Windows.Forms.Button();
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeAlert = new System.Windows.Forms.ComboBox();
            this.tabAlert = new System.Windows.Forms.TabPage();
            this.listBoxAlerts = new System.Windows.Forms.ListBox();
            this.btnShowAllAlerts = new System.Windows.Forms.Button();
            this.btnAlertsAtive = new System.Windows.Forms.Button();
            this.btnAlertsInactive = new System.Windows.Forms.Button();
            this.numericUpDownState = new System.Windows.Forms.NumericUpDown();
            this.labelID = new System.Windows.Forms.Label();
            this.btnSaveState = new System.Windows.Forms.Button();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.labelState = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDefineAlert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).BeginInit();
            this.tabAlert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownState)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDefineAlert);
            this.tabControl1.Controls.Add(this.tabAlert);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDefineAlert
            // 
            this.tabDefineAlert.Controls.Add(this.btnClear);
            this.tabDefineAlert.Controls.Add(this.labelBetween);
            this.tabDefineAlert.Controls.Add(this.numericUpDownValueMax);
            this.tabDefineAlert.Controls.Add(this.numericUpDownValue);
            this.tabDefineAlert.Controls.Add(this.btnDefine);
            this.tabDefineAlert.Controls.Add(this.comboBoxCondition);
            this.tabDefineAlert.Controls.Add(this.comboBoxTypeAlert);
            this.tabDefineAlert.Location = new System.Drawing.Point(4, 22);
            this.tabDefineAlert.Name = "tabDefineAlert";
            this.tabDefineAlert.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefineAlert.Size = new System.Drawing.Size(542, 260);
            this.tabDefineAlert.TabIndex = 0;
            this.tabDefineAlert.Text = "Define Alert";
            this.tabDefineAlert.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(296, 197);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelBetween
            // 
            this.labelBetween.AutoSize = true;
            this.labelBetween.Location = new System.Drawing.Point(157, 144);
            this.labelBetween.Name = "labelBetween";
            this.labelBetween.Size = new System.Drawing.Size(26, 13);
            this.labelBetween.TabIndex = 7;
            this.labelBetween.Text = "And";
            this.labelBetween.Visible = false;
            // 
            // numericUpDownValueMax
            // 
            this.numericUpDownValueMax.Enabled = false;
            this.numericUpDownValueMax.Location = new System.Drawing.Point(198, 142);
            this.numericUpDownValueMax.Name = "numericUpDownValueMax";
            this.numericUpDownValueMax.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownValueMax.TabIndex = 6;
            this.numericUpDownValueMax.Visible = false;
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Location = new System.Drawing.Point(17, 142);
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownValue.TabIndex = 5;
            // 
            // btnDefine
            // 
            this.btnDefine.Location = new System.Drawing.Point(389, 197);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(75, 23);
            this.btnDefine.TabIndex = 3;
            this.btnDefine.Text = "Define";
            this.btnDefine.UseVisualStyleBackColor = true;
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // comboBoxCondition
            // 
            this.comboBoxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            "between"});
            this.comboBoxCondition.Location = new System.Drawing.Point(16, 92);
            this.comboBoxCondition.Name = "comboBoxCondition";
            this.comboBoxCondition.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCondition.TabIndex = 1;
            this.comboBoxCondition.SelectedIndexChanged += new System.EventHandler(this.comboBoxCondition_SelectedIndexChanged);
            // 
            // comboBoxTypeAlert
            // 
            this.comboBoxTypeAlert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeAlert.FormattingEnabled = true;
            this.comboBoxTypeAlert.Items.AddRange(new object[] {
            "Humidity",
            "Temperature"});
            this.comboBoxTypeAlert.Location = new System.Drawing.Point(16, 43);
            this.comboBoxTypeAlert.Name = "comboBoxTypeAlert";
            this.comboBoxTypeAlert.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypeAlert.TabIndex = 0;
            // 
            // tabAlert
            // 
            this.tabAlert.Controls.Add(this.labelState);
            this.tabAlert.Controls.Add(this.comboBoxState);
            this.tabAlert.Controls.Add(this.btnSaveState);
            this.tabAlert.Controls.Add(this.labelID);
            this.tabAlert.Controls.Add(this.numericUpDownState);
            this.tabAlert.Controls.Add(this.btnAlertsInactive);
            this.tabAlert.Controls.Add(this.btnAlertsAtive);
            this.tabAlert.Controls.Add(this.btnShowAllAlerts);
            this.tabAlert.Controls.Add(this.listBoxAlerts);
            this.tabAlert.Location = new System.Drawing.Point(4, 22);
            this.tabAlert.Name = "tabAlert";
            this.tabAlert.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlert.Size = new System.Drawing.Size(542, 260);
            this.tabAlert.TabIndex = 1;
            this.tabAlert.Text = "Alert";
            this.tabAlert.UseVisualStyleBackColor = true;
            // 
            // listBoxAlerts
            // 
            this.listBoxAlerts.FormattingEnabled = true;
            this.listBoxAlerts.Location = new System.Drawing.Point(18, 41);
            this.listBoxAlerts.Name = "listBoxAlerts";
            this.listBoxAlerts.ScrollAlwaysVisible = true;
            this.listBoxAlerts.Size = new System.Drawing.Size(221, 212);
            this.listBoxAlerts.TabIndex = 0;
            // 
            // btnShowAllAlerts
            // 
            this.btnShowAllAlerts.Location = new System.Drawing.Point(6, 6);
            this.btnShowAllAlerts.Name = "btnShowAllAlerts";
            this.btnShowAllAlerts.Size = new System.Drawing.Size(75, 23);
            this.btnShowAllAlerts.TabIndex = 1;
            this.btnShowAllAlerts.Text = "All Alerts";
            this.btnShowAllAlerts.UseVisualStyleBackColor = true;
            this.btnShowAllAlerts.Click += new System.EventHandler(this.btnShowAllAlerts_Click);
            // 
            // btnAlertsAtive
            // 
            this.btnAlertsAtive.Location = new System.Drawing.Point(87, 6);
            this.btnAlertsAtive.Name = "btnAlertsAtive";
            this.btnAlertsAtive.Size = new System.Drawing.Size(75, 23);
            this.btnAlertsAtive.TabIndex = 2;
            this.btnAlertsAtive.Text = "Alerts Active";
            this.btnAlertsAtive.UseVisualStyleBackColor = true;
            this.btnAlertsAtive.Click += new System.EventHandler(this.btnAlertsAtive_Click);
            // 
            // btnAlertsInactive
            // 
            this.btnAlertsInactive.Location = new System.Drawing.Point(168, 6);
            this.btnAlertsInactive.Name = "btnAlertsInactive";
            this.btnAlertsInactive.Size = new System.Drawing.Size(79, 23);
            this.btnAlertsInactive.TabIndex = 3;
            this.btnAlertsInactive.Text = "AlertsInactive";
            this.btnAlertsInactive.UseVisualStyleBackColor = true;
            this.btnAlertsInactive.Click += new System.EventHandler(this.btnAlertsInactive_Click);
            // 
            // numericUpDownState
            // 
            this.numericUpDownState.Location = new System.Drawing.Point(338, 99);
            this.numericUpDownState.Name = "numericUpDownState";
            this.numericUpDownState.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownState.TabIndex = 4;
            this.numericUpDownState.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(314, 101);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 13);
            this.labelID.TabIndex = 5;
            this.labelID.Text = "ID:";
            // 
            // btnSaveState
            // 
            this.btnSaveState.Location = new System.Drawing.Point(359, 166);
            this.btnSaveState.Name = "btnSaveState";
            this.btnSaveState.Size = new System.Drawing.Size(75, 23);
            this.btnSaveState.TabIndex = 6;
            this.btnSaveState.Text = "Save";
            this.btnSaveState.UseVisualStyleBackColor = true;
            this.btnSaveState.Click += new System.EventHandler(this.btnSaveState_Click);
            // 
            // comboBoxState
            // 
            this.comboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBoxState.Location = new System.Drawing.Point(338, 135);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(121, 21);
            this.comboBoxState.TabIndex = 7;
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(297, 138);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(35, 13);
            this.labelState.TabIndex = 8;
            this.labelState.Text = "State:";
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 299);
            this.Controls.Add(this.tabControl1);
            this.Name = "AlertForm";
            this.Text = "Alerts";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDefineAlert.ResumeLayout(false);
            this.tabDefineAlert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).EndInit();
            this.tabAlert.ResumeLayout(false);
            this.tabAlert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDefineAlert;
        private System.Windows.Forms.ComboBox comboBoxTypeAlert;
        private System.Windows.Forms.TabPage tabAlert;
        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.Button btnDefine;
        private System.Windows.Forms.NumericUpDown numericUpDownValueMax;
        private System.Windows.Forms.NumericUpDown numericUpDownValue;
        private System.Windows.Forms.Label labelBetween;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox listBoxAlerts;
        private System.Windows.Forms.Button btnAlertsInactive;
        private System.Windows.Forms.Button btnAlertsAtive;
        private System.Windows.Forms.Button btnShowAllAlerts;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Button btnSaveState;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.NumericUpDown numericUpDownState;
    }
}


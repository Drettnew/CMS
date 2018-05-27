namespace CMS
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.mainGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.certificationsDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.certificationsDatabaseDataSet = new CMS.CertificationsDatabaseDataSet();
            this.menuButton = new System.Windows.Forms.Button();
            this.jobMenu = new System.Windows.Forms.Panel();
            this.panelExtraPeop = new System.Windows.Forms.Panel();
            this.labelExtraPeople = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.totalCertCostLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PanelMissingCertMain = new System.Windows.Forms.Panel();
            this.labelCost = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listBoxMissingCert = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.varning1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxReqCert = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelEmployees = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddDateCheckBox = new System.Windows.Forms.CheckBox();
            this.dateCert = new System.Windows.Forms.DateTimePicker();
            this.buttonCertDelete = new System.Windows.Forms.Button();
            this.buttonCertAdd = new System.Windows.Forms.Button();
            this.comboAllCerts = new System.Windows.Forms.ComboBox();
            this.TextAdditInfo = new System.Windows.Forms.TextBox();
            this.listboxCurrentCerts = new System.Windows.Forms.ListBox();
            this.buttonControl = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.certificationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.certificationsTableAdapter = new CMS.CertificationsDatabaseDataSetTableAdapters.CertificationsTableAdapter();
            this.certMenu = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.textBoxCertCost = new System.Windows.Forms.TextBox();
            this.textBoxCertName = new System.Windows.Forms.TextBox();
            this.buttonCertRemove = new System.Windows.Forms.Button();
            this.buttonCertNew = new System.Windows.Forms.Button();
            this.comboBoxCerts = new System.Windows.Forms.ComboBox();
            this.buttonCerts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSet)).BeginInit();
            this.jobMenu.SuspendLayout();
            this.panelExtraPeop.SuspendLayout();
            this.PanelMissingCertMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.varning1.SuspendLayout();
            this.panelEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsBindingSource)).BeginInit();
            this.certMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGridView
            // 
            this.mainGridView.AllowUserToAddRows = false;
            this.mainGridView.AllowUserToDeleteRows = false;
            this.mainGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.name});
            this.mainGridView.Location = new System.Drawing.Point(10, 45);
            this.mainGridView.MultiSelect = false;
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainGridView.Size = new System.Drawing.Size(963, 500);
            this.mainGridView.TabIndex = 1;
            this.mainGridView.SelectionChanged += new System.EventHandler(this.mainGridView_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // certificationsDatabaseDataSetBindingSource
            // 
            this.certificationsDatabaseDataSetBindingSource.DataSource = this.certificationsDatabaseDataSet;
            this.certificationsDatabaseDataSetBindingSource.Position = 0;
            // 
            // certificationsDatabaseDataSet
            // 
            this.certificationsDatabaseDataSet.DataSetName = "CertificationsDatabaseDataSet";
            this.certificationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuButton
            // 
            this.menuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuButton.Location = new System.Drawing.Point(893, 13);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(81, 23);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "Calculate job";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // jobMenu
            // 
            this.jobMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.jobMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jobMenu.Controls.Add(this.panelExtraPeop);
            this.jobMenu.Controls.Add(this.totalCertCostLabel);
            this.jobMenu.Controls.Add(this.label12);
            this.jobMenu.Controls.Add(this.PanelMissingCertMain);
            this.jobMenu.Controls.Add(this.varning1);
            this.jobMenu.Controls.Add(this.listBoxReqCert);
            this.jobMenu.Controls.Add(this.label8);
            this.jobMenu.Controls.Add(this.label7);
            this.jobMenu.Controls.Add(this.label6);
            this.jobMenu.Controls.Add(this.label5);
            this.jobMenu.Controls.Add(this.button3);
            this.jobMenu.Controls.Add(this.textBox3);
            this.jobMenu.Controls.Add(this.textBox2);
            this.jobMenu.Controls.Add(this.button2);
            this.jobMenu.Controls.Add(this.button1);
            this.jobMenu.Controls.Add(this.textBox1);
            this.jobMenu.Controls.Add(this.comboBox1);
            this.jobMenu.Location = new System.Drawing.Point(625, 45);
            this.jobMenu.Name = "jobMenu";
            this.jobMenu.Size = new System.Drawing.Size(346, 500);
            this.jobMenu.TabIndex = 3;
            // 
            // panelExtraPeop
            // 
            this.panelExtraPeop.Controls.Add(this.labelExtraPeople);
            this.panelExtraPeop.Controls.Add(this.label13);
            this.panelExtraPeop.Location = new System.Drawing.Point(164, 219);
            this.panelExtraPeop.Name = "panelExtraPeop";
            this.panelExtraPeop.Size = new System.Drawing.Size(141, 49);
            this.panelExtraPeop.TabIndex = 19;
            // 
            // labelExtraPeople
            // 
            this.labelExtraPeople.AutoSize = true;
            this.labelExtraPeople.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelExtraPeople.Location = new System.Drawing.Point(6, 21);
            this.labelExtraPeople.MinimumSize = new System.Drawing.Size(50, 2);
            this.labelExtraPeople.Name = "labelExtraPeople";
            this.labelExtraPeople.Size = new System.Drawing.Size(50, 15);
            this.labelExtraPeople.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nr of extra people needed";
            // 
            // totalCertCostLabel
            // 
            this.totalCertCostLabel.AutoSize = true;
            this.totalCertCostLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalCertCostLabel.Location = new System.Drawing.Point(13, 240);
            this.totalCertCostLabel.MinimumSize = new System.Drawing.Size(145, 2);
            this.totalCertCostLabel.Name = "totalCertCostLabel";
            this.totalCertCostLabel.Size = new System.Drawing.Size(145, 15);
            this.totalCertCostLabel.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 223);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Cost for all Certifications used";
            // 
            // PanelMissingCertMain
            // 
            this.PanelMissingCertMain.Controls.Add(this.labelCost);
            this.PanelMissingCertMain.Controls.Add(this.label10);
            this.PanelMissingCertMain.Controls.Add(this.listBoxMissingCert);
            this.PanelMissingCertMain.Controls.Add(this.panel1);
            this.PanelMissingCertMain.Location = new System.Drawing.Point(10, 285);
            this.PanelMissingCertMain.Name = "PanelMissingCertMain";
            this.PanelMissingCertMain.Size = new System.Drawing.Size(331, 210);
            this.PanelMissingCertMain.TabIndex = 16;
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCost.Location = new System.Drawing.Point(225, 22);
            this.labelCost.MinimumSize = new System.Drawing.Size(90, 2);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(90, 15);
            this.labelCost.TabIndex = 16;
            this.labelCost.Text = "label13";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Total Cost to train";
            // 
            // listBoxMissingCert
            // 
            this.listBoxMissingCert.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listBoxMissingCert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxMissingCert.FormattingEnabled = true;
            this.listBoxMissingCert.Location = new System.Drawing.Point(3, 22);
            this.listBoxMissingCert.Name = "listBoxMissingCert";
            this.listBoxMissingCert.Size = new System.Drawing.Size(213, 184);
            this.listBoxMissingCert.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(35, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 19);
            this.panel1.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Missing Certifications";
            // 
            // varning1
            // 
            this.varning1.BackColor = System.Drawing.Color.Red;
            this.varning1.Controls.Add(this.label9);
            this.varning1.Location = new System.Drawing.Point(10, 194);
            this.varning1.Name = "varning1";
            this.varning1.Size = new System.Drawing.Size(277, 19);
            this.varning1.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(274, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "There are not enough employees to finish the job on time";
            // 
            // listBoxReqCert
            // 
            this.listBoxReqCert.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxReqCert.FormattingEnabled = true;
            this.listBoxReqCert.Location = new System.Drawing.Point(118, 32);
            this.listBoxReqCert.Name = "listBoxReqCert";
            this.listBoxReqCert.Size = new System.Drawing.Size(120, 121);
            this.listBoxReqCert.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Days to finish job";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Hours job will take";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number Required";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Job Requiered Certifications";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Calculate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(10, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(93, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(250, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(55, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 163);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // panelEmployees
            // 
            this.panelEmployees.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEmployees.Controls.Add(this.label4);
            this.panelEmployees.Controls.Add(this.label3);
            this.panelEmployees.Controls.Add(this.label2);
            this.panelEmployees.Controls.Add(this.AddDateCheckBox);
            this.panelEmployees.Controls.Add(this.dateCert);
            this.panelEmployees.Controls.Add(this.buttonCertDelete);
            this.panelEmployees.Controls.Add(this.buttonCertAdd);
            this.panelEmployees.Controls.Add(this.comboAllCerts);
            this.panelEmployees.Controls.Add(this.TextAdditInfo);
            this.panelEmployees.Controls.Add(this.listboxCurrentCerts);
            this.panelEmployees.Controls.Add(this.buttonControl);
            this.panelEmployees.Controls.Add(this.textBoxName);
            this.panelEmployees.Controls.Add(this.label1);
            this.panelEmployees.Location = new System.Drawing.Point(725, 45);
            this.panelEmployees.Name = "panelEmployees";
            this.panelEmployees.Size = new System.Drawing.Size(250, 500);
            this.panelEmployees.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Additional Certification Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Add Certification";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Certifications";
            // 
            // AddDateCheckBox
            // 
            this.AddDateCheckBox.AutoSize = true;
            this.AddDateCheckBox.Location = new System.Drawing.Point(6, 223);
            this.AddDateCheckBox.Name = "AddDateCheckBox";
            this.AddDateCheckBox.Size = new System.Drawing.Size(81, 17);
            this.AddDateCheckBox.TabIndex = 10;
            this.AddDateCheckBox.Text = "Add A Date";
            this.AddDateCheckBox.UseVisualStyleBackColor = true;
            this.AddDateCheckBox.CheckedChanged += new System.EventHandler(this.AddDateCheckBox_CheckedChanged);
            // 
            // dateCert
            // 
            this.dateCert.CustomFormat = "yyyy-mm-dd";
            this.dateCert.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCert.Location = new System.Drawing.Point(92, 223);
            this.dateCert.Name = "dateCert";
            this.dateCert.Size = new System.Drawing.Size(150, 20);
            this.dateCert.TabIndex = 9;
            this.dateCert.Visible = false;
            // 
            // buttonCertDelete
            // 
            this.buttonCertDelete.Location = new System.Drawing.Point(167, 129);
            this.buttonCertDelete.Name = "buttonCertDelete";
            this.buttonCertDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonCertDelete.TabIndex = 7;
            this.buttonCertDelete.Text = "Remove";
            this.buttonCertDelete.UseVisualStyleBackColor = true;
            this.buttonCertDelete.Click += new System.EventHandler(this.buttonCertDelete_Click);
            // 
            // buttonCertAdd
            // 
            this.buttonCertAdd.Location = new System.Drawing.Point(167, 99);
            this.buttonCertAdd.Name = "buttonCertAdd";
            this.buttonCertAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonCertAdd.TabIndex = 6;
            this.buttonCertAdd.Text = "Add";
            this.buttonCertAdd.UseVisualStyleBackColor = true;
            this.buttonCertAdd.Click += new System.EventHandler(this.buttonCertAdd_Click);
            // 
            // comboAllCerts
            // 
            this.comboAllCerts.FormattingEnabled = true;
            this.comboAllCerts.Location = new System.Drawing.Point(132, 72);
            this.comboAllCerts.Name = "comboAllCerts";
            this.comboAllCerts.Size = new System.Drawing.Size(110, 21);
            this.comboAllCerts.TabIndex = 5;
            this.comboAllCerts.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TextAdditInfo
            // 
            this.TextAdditInfo.Location = new System.Drawing.Point(6, 197);
            this.TextAdditInfo.Name = "TextAdditInfo";
            this.TextAdditInfo.Size = new System.Drawing.Size(239, 20);
            this.TextAdditInfo.TabIndex = 4;
            this.TextAdditInfo.TextChanged += new System.EventHandler(this.TextAdditInfo_TextChanged);
            // 
            // listboxCurrentCerts
            // 
            this.listboxCurrentCerts.FormattingEnabled = true;
            this.listboxCurrentCerts.Location = new System.Drawing.Point(6, 73);
            this.listboxCurrentCerts.Name = "listboxCurrentCerts";
            this.listboxCurrentCerts.Size = new System.Drawing.Size(120, 95);
            this.listboxCurrentCerts.TabIndex = 3;
            this.listboxCurrentCerts.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonControl
            // 
            this.buttonControl.Location = new System.Drawing.Point(167, 249);
            this.buttonControl.Name = "buttonControl";
            this.buttonControl.Size = new System.Drawing.Size(75, 23);
            this.buttonControl.TabIndex = 2;
            this.buttonControl.Text = "button1";
            this.buttonControl.UseVisualStyleBackColor = true;
            this.buttonControl.Click += new System.EventHandler(this.buttonControl_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(3, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(242, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // certificationsBindingSource
            // 
            this.certificationsBindingSource.DataMember = "Certifications";
            this.certificationsBindingSource.DataSource = this.certificationsDatabaseDataSetBindingSource;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(13, 12);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(95, 13);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(177, 13);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // certificationsTableAdapter
            // 
            this.certificationsTableAdapter.ClearBeforeFill = true;
            // 
            // certMenu
            // 
            this.certMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.certMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.certMenu.Controls.Add(this.label16);
            this.certMenu.Controls.Add(this.label15);
            this.certMenu.Controls.Add(this.label14);
            this.certMenu.Controls.Add(this.buttonApply);
            this.certMenu.Controls.Add(this.textBoxCertCost);
            this.certMenu.Controls.Add(this.textBoxCertName);
            this.certMenu.Controls.Add(this.buttonCertRemove);
            this.certMenu.Controls.Add(this.buttonCertNew);
            this.certMenu.Controls.Add(this.comboBoxCerts);
            this.certMenu.Location = new System.Drawing.Point(725, 45);
            this.certMenu.Name = "certMenu";
            this.certMenu.Size = new System.Drawing.Size(250, 500);
            this.certMenu.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Cost to train";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Current Existing Certifications";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(159, 126);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(86, 23);
            this.buttonApply.TabIndex = 11;
            this.buttonApply.Text = "Apply Change";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // textBoxCertCost
            // 
            this.textBoxCertCost.Location = new System.Drawing.Point(3, 129);
            this.textBoxCertCost.Name = "textBoxCertCost";
            this.textBoxCertCost.Size = new System.Drawing.Size(100, 20);
            this.textBoxCertCost.TabIndex = 10;
            this.textBoxCertCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCertCost_KeyPress);
            // 
            // textBoxCertName
            // 
            this.textBoxCertName.Location = new System.Drawing.Point(3, 73);
            this.textBoxCertName.Name = "textBoxCertName";
            this.textBoxCertName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCertName.TabIndex = 9;
            // 
            // buttonCertRemove
            // 
            this.buttonCertRemove.Location = new System.Drawing.Point(170, 55);
            this.buttonCertRemove.Name = "buttonCertRemove";
            this.buttonCertRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonCertRemove.TabIndex = 8;
            this.buttonCertRemove.Text = "Remove";
            this.buttonCertRemove.UseVisualStyleBackColor = true;
            this.buttonCertRemove.Click += new System.EventHandler(this.buttonCertRemove_Click);
            // 
            // buttonCertNew
            // 
            this.buttonCertNew.Location = new System.Drawing.Point(170, 21);
            this.buttonCertNew.Name = "buttonCertNew";
            this.buttonCertNew.Size = new System.Drawing.Size(75, 23);
            this.buttonCertNew.TabIndex = 7;
            this.buttonCertNew.Text = "New";
            this.buttonCertNew.UseVisualStyleBackColor = true;
            this.buttonCertNew.Click += new System.EventHandler(this.buttonCertNew_Click);
            // 
            // comboBoxCerts
            // 
            this.comboBoxCerts.FormattingEnabled = true;
            this.comboBoxCerts.Location = new System.Drawing.Point(3, 21);
            this.comboBoxCerts.Name = "comboBoxCerts";
            this.comboBoxCerts.Size = new System.Drawing.Size(110, 21);
            this.comboBoxCerts.TabIndex = 6;
            this.comboBoxCerts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCerts_SelectedIndexChanged);
            // 
            // buttonCerts
            // 
            this.buttonCerts.Location = new System.Drawing.Point(725, 13);
            this.buttonCerts.Name = "buttonCerts";
            this.buttonCerts.Size = new System.Drawing.Size(78, 23);
            this.buttonCerts.TabIndex = 7;
            this.buttonCerts.Text = "Handle Certs";
            this.buttonCerts.UseVisualStyleBackColor = true;
            this.buttonCerts.Click += new System.EventHandler(this.buttonCerts_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 566);
            this.Controls.Add(this.buttonCerts);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.panelEmployees);
            this.Controls.Add(this.mainGridView);
            this.Controls.Add(this.jobMenu);
            this.Controls.Add(this.certMenu);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSet)).EndInit();
            this.jobMenu.ResumeLayout(false);
            this.jobMenu.PerformLayout();
            this.panelExtraPeop.ResumeLayout(false);
            this.panelExtraPeop.PerformLayout();
            this.PanelMissingCertMain.ResumeLayout(false);
            this.PanelMissingCertMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.varning1.ResumeLayout(false);
            this.varning1.PerformLayout();
            this.panelEmployees.ResumeLayout(false);
            this.panelEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsBindingSource)).EndInit();
            this.certMenu.ResumeLayout(false);
            this.certMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView mainGridView;
        private System.Windows.Forms.BindingSource certificationsDatabaseDataSetBindingSource;
        private CertificationsDatabaseDataSet certificationsDatabaseDataSet;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Panel jobMenu;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelEmployees;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.ListBox listboxCurrentCerts;
        private System.Windows.Forms.TextBox TextAdditInfo;
        private System.Windows.Forms.ComboBox comboAllCerts;
        private System.Windows.Forms.BindingSource certificationsBindingSource;
        private CertificationsDatabaseDataSetTableAdapters.CertificationsTableAdapter certificationsTableAdapter;
        private System.Windows.Forms.Button buttonCertAdd;
        private System.Windows.Forms.Button buttonCertDelete;
        private System.Windows.Forms.CheckBox AddDateCheckBox;
        private System.Windows.Forms.DateTimePicker dateCert;
        private System.Windows.Forms.Panel certMenu;
        private System.Windows.Forms.Button buttonCerts;
        private System.Windows.Forms.Button buttonCertRemove;
        private System.Windows.Forms.Button buttonCertNew;
        private System.Windows.Forms.ComboBox comboBoxCerts;
        private System.Windows.Forms.TextBox textBoxCertCost;
        private System.Windows.Forms.TextBox textBoxCertName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBoxReqCert;
        private System.Windows.Forms.Panel varning1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel PanelMissingCertMain;
        private System.Windows.Forms.ListBox listBoxMissingCert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label totalCertCostLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelExtraPeop;
        private System.Windows.Forms.Label labelExtraPeople;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}


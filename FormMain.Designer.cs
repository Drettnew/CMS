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
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.certificationsDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.certificationsDatabaseDataSet = new CMS.CertificationsDatabaseDataSet();
            this.employeesTableAdapter = new CMS.CertificationsDatabaseDataSetTableAdapters.EmployeesTableAdapter();
            this.menuButton = new System.Windows.Forms.Button();
            this.jobMenu = new System.Windows.Forms.Panel();
            this.certificationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.certificationsTableAdapter = new CMS.CertificationsDatabaseDataSetTableAdapters.CertificationsTableAdapter();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSet)).BeginInit();
            this.jobMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsBindingSource)).BeginInit();
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
            this.name});
            this.mainGridView.Location = new System.Drawing.Point(10, 45);
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.Size = new System.Drawing.Size(963, 500);
            this.mainGridView.TabIndex = 1;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "Employees";
            this.employeesBindingSource.DataSource = this.certificationsDatabaseDataSetBindingSource;
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
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
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
            this.jobMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jobMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.jobMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jobMenu.Controls.Add(this.checkedListBox1);
            this.jobMenu.Location = new System.Drawing.Point(724, 45);
            this.jobMenu.Name = "jobMenu";
            this.jobMenu.Size = new System.Drawing.Size(250, 500);
            this.jobMenu.TabIndex = 3;
            // 
            // certificationsBindingSource
            // 
            this.certificationsBindingSource.DataMember = "Certifications";
            this.certificationsBindingSource.DataSource = this.certificationsDatabaseDataSetBindingSource;
            // 
            // certificationsTableAdapter
            // 
            this.certificationsTableAdapter.ClearBeforeFill = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(110, 94);
            this.checkedListBox1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 566);
            this.Controls.Add(this.jobMenu);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.mainGridView);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificationsDatabaseDataSet)).EndInit();
            this.jobMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.certificationsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView mainGridView;
        private System.Windows.Forms.BindingSource certificationsDatabaseDataSetBindingSource;
        private CertificationsDatabaseDataSet certificationsDatabaseDataSet;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private CertificationsDatabaseDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Panel jobMenu;
        private System.Windows.Forms.BindingSource certificationsBindingSource;
        private CertificationsDatabaseDataSetTableAdapters.CertificationsTableAdapter certificationsTableAdapter;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}


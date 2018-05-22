using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using System.Diagnostics;
using CMS.SelfCreatedLists;

namespace CMS
{
    public partial class FormMain : Form
    {
        static string conStr = ConfigurationManager.ConnectionStrings["CMS.Properties.Settings.CertificationsDatabaseConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        bool menu_job_show = false;
        int menu_job_size = 0;
        bool menu_Employee_show = false;
        int menu_Employee_size = 0;
        bool menu_Cert_show = false;
        int menu_Cert_size = 0;

        EmployeeChanges employee = new EmployeeChanges();
        List<JobCertReqList> reqCert;
        ModelBase mBase = new ModelBase();
        ListOfOutPutsFromModelBase result = new ListOfOutPutsFromModelBase();

        public FormMain()
        {
            InitializeComponent();
            test34();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void test34()
        {
            JobCertReqList t1 = new JobCertReqList();
            JobCertReqList t2 = new JobCertReqList();
            JobCertReqList t3 = new JobCertReqList();
            t1.Certificate = "EON";
            t1.Count = 2;
            t2.Certificate = "Atlas Copco";
            t2.Count = 2;
            t3.Certificate = "SSG utbild";
            t3.Count = 2;

            List<JobCertReqList> certForJob = new List<JobCertReqList>();
            certForJob.Add(t1);
            certForJob.Add(t2);
            certForJob.Add(t3);

            result = mBase.CheckJobReqWithEmployees(certForJob, 150, 25);
            mBase.clearEmployeeList();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'certificationsDatabaseDataSet.Certifications' table. You can move, or remove it, as needed.
            this.certificationsTableAdapter.Fill(this.certificationsDatabaseDataSet.Certifications);
            cmd.Connection = con;
            InitDataTable();
            fillTable();
            fillListBox();
            fillComboBoxes();

            menu_job_size = jobMenu.Width;
            jobMenu.Width = 0;

            menu_Employee_size = panelEmployees.Width;
            panelEmployees.Width = 0;

            menu_Cert_size = certMenu.Width;
            certMenu.Width = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!menu_job_show)
            {
                reqCert = new List<JobCertReqList>();
                textBox1.Text = "1";
                mainGridView.Width = mainGridView.Width - menu_job_size;
                jobMenu.Width = menu_job_size;
                menu_job_show = !menu_job_show;
            }
            else
            {
                mainGridView.Width = mainGridView.Width + menu_job_size;
                jobMenu.Width = 0;
                menu_job_show = !menu_job_show;
            }
        }

        private void InitDataTable()
        {
            mainGridView.Columns.Clear();

            mainGridView.Columns.Add("Id", "Id");
            mainGridView.Columns[0].Visible = false;

            mainGridView.Columns.Add("Name", "Name");

            con.Open();
            cmd.CommandText = "select Name from Certifications";
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                mainGridView.Columns.Add(dr["Name"].ToString(), dr["Name"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void fillTable()
        {
            mainGridView.Rows.Clear();
            mainGridView.Refresh();
            
            con.Open();
            cmd.CommandText = "select Id, Name from Employees";
            dr = cmd.ExecuteReader();

            Dictionary<string, int> employeeListIndex = new Dictionary<string, int>();
            while (dr.Read())
            {
                int index = mainGridView.Rows.Add();
                mainGridView.Rows[index].Cells["Id"].Value = dr[0].ToString();
                mainGridView.Rows[index].Cells["Name"].Value = dr[1].ToString();
                employeeListIndex.Add(dr[1].ToString(), index);
            }

            dr.Close();
            cmd.CommandText = "select Employees.name, Certifications.Name, EmployeeCertification.Expiration_Date," +
                                " EmployeeCertification.Expiration_Date, EmployeeCertification.Additional_Info" +
                                " from Certifications" +
                                " join EmployeeCertification on Certifications.Id = EmployeeCertification.CertificationId" +
                                " join Employees on Employees.Id = EmployeeCertification.EmployeeId";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int index;
                employeeListIndex.TryGetValue(dr[0].ToString(), out index);
                if (!DBNull.Value.Equals(dr[2]))
                {
                    mainGridView.Rows[index].Cells[dr[1].ToString()].Value = Convert.ToDateTime(dr[2]).ToShortDateString();
                }
                else
                {
                    mainGridView.Rows[index].Cells[dr[1].ToString()].Value = "Have";
                }
                    
            }
            dr.Close();
            con.Close();
        }

        private void fillListBox()
        {
            if (mainGridView.SelectedRows.Count > 0)
            {
                con.Open();

                cmd.CommandText = "select Certifications.Id, Certifications.Name, EmployeeCertification.Additional_Info, EmployeeCertification.Expiration_Date" +
                                    " from Certifications" +
                                    " join EmployeeCertification on Certifications.Id = EmployeeCertification.CertificationId" +
                                    " join Employees on Employees.Id = EmployeeCertification.EmployeeId where Employees.Id = " + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString();
                dr = cmd.ExecuteReader();

                listboxCurrentCerts.Items.Clear();
                employee = new EmployeeChanges();

                while (dr.Read())
                {
                    employee.CertId.Add(dr[0].ToString());
                    employee.CertAdditInfo.Add(dr[2].ToString());

                    if (!DBNull.Value.Equals(dr[3]))
                    {
                        employee.CertDate.Add(Convert.ToDateTime(dr[3]).ToShortDateString());
                    }
                    else
                    {
                        employee.CertDate.Add("NULL");
                    }
                    listboxCurrentCerts.Items.Add(new KeyValuePair<string, string>(dr[0].ToString(), dr[1].ToString()));
                }

                dr.Close();
                con.Close();


                listboxCurrentCerts.DisplayMember = "Value";
                listboxCurrentCerts.ValueMember = "Key";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (mainGridView.SelectedRows.Count > 0 && !menu_Employee_show)
            {
                mainGridView.Width = mainGridView.Width - menu_Employee_size;
                panelEmployees.Width = menu_Employee_size;
                menu_Employee_show = !menu_Employee_show;

                fillListBox();

                buttonControl.Text = "Confirm Edit";
                textBoxName.Text = mainGridView.SelectedRows[0].Cells["Name"].Value.ToString();
            }
            else if(mainGridView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You have to select a row for too edit!");
            }else if (menu_Employee_show)
            {
                mainGridView.Width = mainGridView.Width + menu_Employee_size;
                panelEmployees.Width = 0;
                menu_Employee_show = !menu_Employee_show;
                textBoxName.Text = "";
                TextAdditInfo.Text = "";
            }
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            if (buttonControl.Text == "Confirm Edit")
            {
                con.Open();

                for (int i = 0; i < employee.DeleteCertId.Count; i++)
                {
                    cmd.CommandText = "delete from EmployeeCertification where EmployeeId = " + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString()
                                        + " and CertificationId = " + employee.DeleteCertId[i];

                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < employee.AddCertId.Count; i++)
                {
                    cmd.CommandText = "insert into EmployeeCertification (EmployeeId, CertificationId, Additional_Info, Expiration_Date)"
                                + " values (\'" + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString()
                                + "\', \'" + employee.AddCertId[i] + "\'";
                    if (employee.AddCertAdditInfo[i] != "")
                    {
                        cmd.CommandText += ",\'" + employee.AddCertAdditInfo[i] + "\'";
                    }
                    else
                    {
                        cmd.CommandText += ",NULL";
                    }

                    if (employee.AddCertDate[i] != "NULL")
                    {
                        cmd.CommandText += ",\'" + employee.AddCertDate[i] + "\'";
                    }
                    else
                    {
                        cmd.CommandText += ",NULL";
                    }

                    cmd.CommandText += ");";

                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < employee.EditCertId.Count; i++)
                {
                    cmd.CommandText = "update EmployeeCertification set ";
                    if (employee.EditCertAdditInfo[i] != "")
                    {
                        cmd.CommandText += "Additional_info = \'" + employee.EditCertAdditInfo[i] + "\'";
                    }
                    else
                    {
                        cmd.CommandText += "Additional_info = " + "NULL";
                    }
                    if (employee.EditCertDate[i] != "NULL")
                    {
                        cmd.CommandText += ", Expiration_Date = \'" + DateTime.Parse(employee.EditCertDate[i]).Date + "\'";
                    }
                    else
                    {
                        cmd.CommandText += ", Expiration_Date = " + "NULL";
                    }

                    cmd.CommandText += " where EmployeeId = " + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString() +
                                    " and CertificationId = " + employee.EditCertId[i];

                    cmd.ExecuteNonQuery();
                }
                
                con.Close();

                fillTable();

                mainGridView.Width = mainGridView.Width + menu_Employee_size;
                panelEmployees.Width = 0;
                menu_Employee_show = !menu_Employee_show;
                textBoxName.Text = "";
                TextAdditInfo.Text = "";
            }
            else if (buttonControl.Text == "Add New!")
            {
                cmd.CommandText = "insert into Employees (Name) values (\'" + textBoxName.Text + "\');";

                con.Open();
                cmd.ExecuteNonQuery();
                

                cmd.CommandText = "select SCOPE_IDENTITY()";

                int id = Convert.ToInt32(cmd.ExecuteScalar());

                for (int i = 0; i < employee.AddCertId.Count; i++)
                {
                    cmd.CommandText = "insert into EmployeeCertification (EmployeeId, CertificationId, Additional_Info, Expiration_Date)"
                                + " values (\'" + id.ToString()
                                + "\', \'" + employee.AddCertId[i] + "\'";
                    if (employee.AddCertAdditInfo[i] != "")
                    {
                        cmd.CommandText += ",\'" + employee.AddCertAdditInfo[i] + "\'";
                    }
                    else
                    {
                        cmd.CommandText += ",NULL";
                    }
                    if (employee.AddCertDate[i] != "NULL")
                    {
                        cmd.CommandText += ",\'" + employee.AddCertDate[i] + "\'";
                    }
                    else
                    {
                        cmd.CommandText += ",NULL";
                    }
                    cmd.CommandText += ");";
                                    
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                fillTable();

                mainGridView.Width = mainGridView.Width + menu_Employee_size;
                panelEmployees.Width = 0;
                menu_Employee_show = !menu_Employee_show;
                textBoxName.Text = "";
                TextAdditInfo.Text = "";
            }

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (mainGridView.SelectedRows.Count > 0 && !menu_Employee_show)
            {
                mainGridView.Width = mainGridView.Width - menu_Employee_size;
                panelEmployees.Width = menu_Employee_size;
                menu_Employee_show = !menu_Employee_show;

                listboxCurrentCerts.Items.Clear();
                employee = new EmployeeChanges();

                buttonControl.Text = "Add New!";
            }
            else if (mainGridView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You have to select a row for too edit!");
            }
            else if (menu_Employee_show)
            {
                mainGridView.Width = mainGridView.Width + menu_Employee_size;
                panelEmployees.Width = 0;
                menu_Employee_show = !menu_Employee_show;
                textBoxName.Text = "";
                TextAdditInfo.Text = "";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            

            con.Open();

            cmd.CommandText = "delete from EmployeeCertification where EmployeeId = " + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from Employees where Id = " + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            cmd.ExecuteNonQuery();

            con.Close();

            fillTable();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(menu_Employee_show && listboxCurrentCerts.Items.Count > 0 && listboxCurrentCerts.SelectedIndex >= 0)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)listboxCurrentCerts.SelectedItem;
                if (employee.CertId.Contains(item.Key))
                {
                    TextAdditInfo.Text = employee.CertAdditInfo[employee.CertId.IndexOf(item.Key)];
                    textBoxDate.Text = employee.CertDate[employee.CertId.IndexOf(item.Key)];
                    if (employee.CertDate[employee.CertId.IndexOf(item.Key)] != "NULL")
                    {
                        AddDateCheckBox.Checked = true;
                        dateCert.Value = DateTime.Parse(employee.CertDate[employee.CertId.IndexOf(item.Key)]);
                    }
                    else
                    {
                        AddDateCheckBox.Checked = false;
                    }
                }
                else if (employee.AddCertId.Contains(item.Key))
                {
                    TextAdditInfo.Text = employee.AddCertAdditInfo[employee.AddCertId.IndexOf(item.Key)];
                    textBoxDate.Text = employee.AddCertDate[employee.AddCertId.IndexOf(item.Key)];
                    if (employee.AddCertDate[employee.AddCertId.IndexOf(item.Key)] != "NULL")
                    {
                        AddDateCheckBox.Checked = true;
                        dateCert.Value = DateTime.Parse(employee.AddCertDate[employee.AddCertId.IndexOf(item.Key)]);
                    }
                    else
                    {
                        AddDateCheckBox.Checked = false;
                    }
                }
                
            }
        }

        private void buttonCertAdd_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboAllCerts.SelectedItem;
            string a = item.Key.ToString();
            string b = item.Value.ToString();

            if (!employee.CertId.Contains(a) && !employee.AddCertId.Contains(a))
            {
                employee.AddCertId.Add(item.Key.ToString());
                employee.AddCertAdditInfo.Add(TextAdditInfo.Text);
                if (AddDateCheckBox.Checked)
                {
                    employee.AddCertDate.Add(dateCert.Value.ToShortDateString());
                }
                else
                {
                    employee.AddCertDate.Add("NULL");
                }

                listboxCurrentCerts.Items.Add(new KeyValuePair<string, string>(a, b));
                listboxCurrentCerts.DisplayMember = "Value";
                listboxCurrentCerts.ValueMember = "Key";
            }
            TextAdditInfo.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextAdditInfo.Text = "";
            AddDateCheckBox.Checked = false;
        }

        private void buttonCertDelete_Click(object sender, EventArgs e)
        {
            if (listboxCurrentCerts.SelectedIndex >= 0)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)listboxCurrentCerts.SelectedItem;
                if (employee.CertId.Contains(item.Key))
                {
                    employee.DeleteCertId.Add(employee.CertId[listboxCurrentCerts.SelectedIndex]);
                    employee.DeleteCertAdditInfo.Add(employee.CertAdditInfo[listboxCurrentCerts.SelectedIndex]);
                    employee.CertId.RemoveAt(listboxCurrentCerts.SelectedIndex);
                    employee.CertAdditInfo.RemoveAt(listboxCurrentCerts.SelectedIndex);
                }
                if (employee.AddCertId.Contains(item.Key))
                    employee.AddCertId.RemoveAt(listboxCurrentCerts.SelectedIndex);

                listboxCurrentCerts.Items.RemoveAt(listboxCurrentCerts.SelectedIndex);
            }
        }

        private void TextAdditInfo_TextChanged(object sender, EventArgs e)
        {
            if (menu_Employee_show && listboxCurrentCerts.Items.Count > 0 && listboxCurrentCerts.SelectedIndex >= 0)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)listboxCurrentCerts.SelectedItem;
                if (employee.AddCertId.Contains(item.Key))
                {
                    employee.AddCertAdditInfo[employee.AddCertId.IndexOf(item.Key)] = TextAdditInfo.Text;
                    

                }
                else if (employee.EditCertId.Contains(item.Key))
                {
                    employee.EditCertAdditInfo[employee.EditCertId.IndexOf(item.Key)] = TextAdditInfo.Text;
                    
                }
                else
                {
                    employee.EditCertId.Add(item.Key);
                    employee.EditCertAdditInfo.Add(TextAdditInfo.Text);
                    if (textBoxDate.Text != "NULL")
                    {
                        employee.EditCertDate.Add(textBoxDate.Text);
                    }
                    else
                    {
                        employee.EditCertDate.Add("NULL");
                    }
                }
            }
        }

        private void textBoxDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (menu_Employee_show)
            {
                dateCert.Value = DateTime.Now;
                dateCert.Visible = AddDateCheckBox.Checked;
                if (AddDateCheckBox.Checked && listboxCurrentCerts.SelectedIndex >= 0)
                {
                    KeyValuePair<string, string> item = (KeyValuePair<string, string>)listboxCurrentCerts.SelectedItem;
                    if (employee.CertId.Contains(item.Key))
                    {
                        if (employee.CertDate[employee.CertId.IndexOf(item.Key)] != "NULL")
                        {
                            dateCert.Value = DateTime.Parse(employee.CertDate[employee.CertId.IndexOf(item.Key)]);
                        }
                        else
                        {
                            if (employee.EditCertId.Contains(item.Key))
                            {
                                employee.EditCertDate[employee.EditCertId.IndexOf(item.Key)] = dateCert.Value.ToShortDateString();
                            }
                            else
                            {
                                employee.EditCertId.Add(item.Key);
                                employee.EditCertAdditInfo.Add(employee.CertAdditInfo[employee.CertId.IndexOf(item.Key)]);
                                employee.EditCertDate.Add(dateCert.Value.ToShortDateString());
                            }
                            employee.CertDate[employee.CertId.IndexOf(item.Key)] = dateCert.Value.ToShortDateString();
                        }
                    }
                    else
                    {
                        if (employee.AddCertId.Contains(item.Key))
                        {
                            employee.AddCertDate[employee.AddCertId.IndexOf(item.Key)] = dateCert.Value.ToShortDateString();
                        }
                        else if (employee.EditCertId.Contains(item.Key))
                        {
                            employee.EditCertDate[employee.EditCertId.IndexOf(item.Key)] = dateCert.Value.ToShortDateString();
                        }
                        else
                        {
                            employee.EditCertId.Add(item.Key);
                            employee.EditCertAdditInfo.Add(employee.CertAdditInfo[employee.CertId.IndexOf(item.Key)]);
                            employee.EditCertDate.Add(dateCert.Value.ToShortDateString());
                        }
                    }
                }
                else if(listboxCurrentCerts.SelectedIndex >= 0)
                {
                    KeyValuePair<string, string> item = (KeyValuePair<string, string>)listboxCurrentCerts.SelectedItem;
                    if (employee.CertId.Contains(item.Key))
                    {
                        employee.CertDate[employee.CertId.IndexOf(item.Key)] = "NULL";
                        if (employee.EditCertId.Contains(item.Key))
                        {
                            employee.EditCertDate[employee.EditCertId.IndexOf(item.Key)] = "NULL";
                        }
                        else
                        {
                            employee.EditCertId.Add(item.Key);
                            employee.EditCertAdditInfo.Add(employee.CertAdditInfo[employee.CertId.IndexOf(item.Key)]);
                            employee.EditCertDate.Add("NULL");
                        }
                    }
                    else if (employee.AddCertId.Contains(item.Key))
                    {
                        employee.AddCertDate[employee.AddCertId.IndexOf(item.Key)] = "NULL";


                    }
                    else if (employee.EditCertId.Contains(item.Key))
                    {
                        employee.EditCertDate[employee.EditCertId.IndexOf(item.Key)] = "NULL";

                    }
                    
                }
            }
        }

        private void mainGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (menu_Employee_show && buttonControl.Text == "Confirm Edit" && mainGridView.SelectedRows.Count > 0)
            {
                fillListBox();

                textBoxName.Text = mainGridView.SelectedRows[0].Cells["Name"].Value.ToString();
            }
        }

        private void buttonCerts_Click(object sender, EventArgs e)
        {
            if (!menu_Cert_show)
            {
                mainGridView.Width = mainGridView.Width - menu_Cert_size;
                certMenu.Width = menu_Cert_size;
                menu_Cert_show = !menu_Cert_show;

                fillListBox();
                fillComboBoxes();

                buttonControl.Text = "Confirm Edit";
                textBoxName.Text = mainGridView.SelectedRows[0].Cells["Name"].Value.ToString();
            }
            else if (menu_Cert_show)
            {
                mainGridView.Width = mainGridView.Width + menu_Cert_size;
                certMenu.Width = 0;
                menu_Cert_show = !menu_Cert_show;
            }
        }

        private void comboBoxCerts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCerts.SelectedIndex >= 0)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboBoxCerts.SelectedItem;

                con.Open();

                cmd.CommandText = "select Name, Cost" +
                                  " from Certifications" +
                                  " where Id = " + item.Key.ToString();
                dr = cmd.ExecuteReader();
                dr.Read();

                textBoxCertName.Text = dr[0].ToString();
                textBoxCertCost.Text = dr[1].ToString();

                dr.Close();
                con.Close();
            }
        }

        private void textBoxCertCost_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxCertCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {

            if (menu_Cert_show)
            {
                con.Open();
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboBoxCerts.SelectedItem;

                cmd.CommandText = "update Certifications set Name = \'" + textBoxCertName.Text
                                    + "\', Cost = \'" + textBoxCertCost.Text + "\' where Id = " + item.Key.ToString(); ;
                cmd.ExecuteNonQuery();

                con.Close();

                InitDataTable();

                fillTable();
            }
        }

        private void buttonCertNew_Click(object sender, EventArgs e)
        {
            if (menu_Cert_show)
            {
                con.Open();
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboBoxCerts.SelectedItem;

                cmd.CommandText = "insert into Certifications ( Name, Cost)"
                                + " values (\'" + textBoxCertName.Text
                                + "\', \'" + textBoxCertCost.Text + "\');";
                cmd.ExecuteNonQuery();

                con.Close();

                fillComboBoxes();

                InitDataTable();

                fillTable();
            }
        }

        private void buttonCertRemove_Click(object sender, EventArgs e)
        {
            if (menu_Cert_show && comboBoxCerts.SelectedIndex >= 0)
            {
                con.Open();
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboBoxCerts.SelectedItem;

                cmd.CommandText = "delete from EmployeeCertification where CertificationId = " + item.Key.ToString();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from Certifications where Id = " + item.Key.ToString();
                cmd.ExecuteNonQuery();

                con.Close();

                fillComboBoxes();

                InitDataTable();

                fillTable();
            }
        }

        private void fillComboBoxes()
        {
            comboBoxCerts.Items.Clear();
            comboBoxCerts.DisplayMember = "Value";
            comboBoxCerts.ValueMember = "Key";

            comboAllCerts.Items.Clear();
            comboAllCerts.DisplayMember = "Value";
            comboAllCerts.ValueMember = "Key";

            comboBox1.Items.Clear();
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            con.Open();

            cmd.CommandText = "select Id, Name" +
                              " from Certifications";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxCerts.Items.Add(new KeyValuePair<string, string>(dr[0].ToString(), dr[1].ToString()));
                comboAllCerts.Items.Add(new KeyValuePair<string, string>(dr[0].ToString(), dr[1].ToString()));
                comboBox1.Items.Add(new KeyValuePair<string, string>(dr[0].ToString(), dr[1].ToString()));
            }

            dr.Close();
            con.Close();

            comboBoxCerts.SelectedIndex = 0;
            comboAllCerts.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && menu_job_show)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboBox1.SelectedItem;

                bool contains = false;
                foreach (JobCertReqList CertItem in reqCert)
                {
                    if (CertItem.Certificate == item.Value)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    JobCertReqList cert = new JobCertReqList();
                    cert.Certificate = item.Value;
                    cert.Count = int.Parse(textBox1.Text);

                    reqCert.Add(cert);

                    listBox1.Items.Add(new KeyValuePair<string, string>(cert.Certificate, cert.Certificate + " : " + cert.Count));
                    listBox1.ValueMember = "Key";
                    listBox1.DisplayMember = "Value";

                    textBox1.Text = "1";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && menu_job_show)
            {
                reqCert.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hoursForWork = int.Parse(textBox2.Text);
            int daysRequested = int.Parse(textBox3.Text);
            //reqCert for Certs required
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}

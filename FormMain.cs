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
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cmd.Connection = con;
            InitDataTable();
            fillTable();

            menu_job_size = jobMenu.Width;
            jobMenu.Width = 0;

            menu_Employee_size = panelEmployees.Width;
            panelEmployees.Width = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!menu_job_show)
            {
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (mainGridView.SelectedRows.Count > 0 && !menu_Employee_show)
            {
                mainGridView.Width = mainGridView.Width - menu_Employee_size;
                panelEmployees.Width = menu_Employee_size;
                menu_Employee_show = !menu_Employee_show;

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
            }
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            if (buttonControl.Text == "Confirm Edit")
            {
                cmd.CommandText = "update Employees set Name = \'" + textBoxName.Text + "\' where Id = " + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString();

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                fillTable();

                mainGridView.Width = mainGridView.Width + menu_Employee_size;
                panelEmployees.Width = 0;
                menu_Employee_show = !menu_Employee_show;
            }
            else if (buttonControl.Text == "Add New!")
            {
                cmd.CommandText = "insert into Employees (Name) values (\'" + textBoxName.Text + "\');";

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                fillTable();

                mainGridView.Width = mainGridView.Width + menu_Employee_size;
                panelEmployees.Width = 0;
                menu_Employee_show = !menu_Employee_show;
            }

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (mainGridView.SelectedRows.Count > 0 && !menu_Employee_show)
            {
                mainGridView.Width = mainGridView.Width - menu_Employee_size;
                panelEmployees.Width = menu_Employee_size;
                menu_Employee_show = !menu_Employee_show;

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
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "delete from Employees where Id = " + mainGridView.SelectedRows[0].Cells["Id"].Value.ToString();

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            fillTable();
        }
    }
}

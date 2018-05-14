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
        bool menu_show = false;
        int menu_size = 0;
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
            fillTable();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!menu_show)
            {
                mainGridView.Width = mainGridView.Width - menu_size;
                jobMenu.Width = menu_size;
                menu_show =! menu_show;
            }
            else
            {
                mainGridView.Width = mainGridView.Width + menu_size;
                jobMenu.Width = 0;
                menu_show = !menu_show;
            }
            
        }

        private void fillTable()
        {
            this.certificationsTableAdapter.Fill(this.certificationsDatabaseDataSet.Certifications);
            menu_size = jobMenu.Width;
            jobMenu.Width = 0;

            string conStr = ConfigurationManager.ConnectionStrings["CMS.Properties.Settings.CertificationsDatabaseConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string sqlQuery = "select Name from Certifications";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                mainGridView.Columns.Add(dr["Name"].ToString(), dr["Name"].ToString());
            }
            dr.Close();

            cmd.CommandText = "select Name from Employees";
            dr = cmd.ExecuteReader();

            Dictionary<string, int> employeeListIndex = new Dictionary<string, int>();
            while (dr.Read())
            {
                int index = mainGridView.Rows.Add();
                mainGridView.Rows[index].Cells["Name"].Value = dr[0].ToString();
                employeeListIndex.Add(dr[0].ToString(), index);
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
    }
}

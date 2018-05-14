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
            cmd.CommandText =   "select Employees.name, Certifications.Name" +
                                " from Certifications" +
                                " join EmployeeCertification on Certifications.Id = EmployeeCertification.CertificationId" +
                                " join Employees on Employees.Id = EmployeeCertification.EmployeeId";
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                int index;
                employeeListIndex.TryGetValue(dr[0].ToString(), out index);
                mainGridView.Rows[index].Cells[dr[1].ToString()].Value = "Have";
            }
            dr.Close();
            con.Close();

        }
    }
}

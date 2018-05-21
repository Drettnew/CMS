using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using CMS.SelfCreatedLists;

namespace CMS
{
    class ModelBase
    {
        static string conStr = ConfigurationManager.ConnectionStrings["CMS.Properties.Settings.CertificationsDatabaseConnectionString"].ConnectionString;
        private SqlConnection con = new SqlConnection(conStr);
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader dr;

        private int nrOfDiffCert;
        ListOfEmployees employees = new ListOfEmployees();
        ListOfOutPutsFromModelBase result = new ListOfOutPutsFromModelBase();


        public ModelBase()
        {
            nrOfDiffCert = 0;
        }
        public String CheckJobReqWithEmployees(List<JobCertReqList> certForJob, int hoursToCompleteJob, int reqDaysToFinishJob)
        {
            List<int> certIndex = new List<int>();

            GetListOfEmployessFromDataBase();

            for(int i = 0; i < certForJob.Count; i++)
            {
                for(int j = 0; j < nrOfDiffCert; j++)
                {
                    if (certForJob[i].Certificate == employees.cert[0][j])
                    {
                        certIndex.Add(j);
                        result.howManyOfEachCertExists.Add(0);
                        j = nrOfDiffCert;
                    }
                }
            }
            

            for (int i = 0; i < employees.names.Count; i++)
            {
                for(int j = 0; j < certIndex.Count; j++)
                {
                    if(employees.cert[i][j] == "1")
                    {
                        result.namesWithCert.Add(employees.names[i]);
                        result.howManyOfEachCertExists[certIndex[j]] += 1;
                        j = certIndex.Count;
                    }
                }
            }

            return "";
        }

        private void calcCertNeeded()
        {
            int count = 0;
            int total = 0;

            for (int i = 0; i < result.reqForTheJob.Count; i++)
            {
                count = result.reqForTheJob[i].Count - result.howManyOfEachCertExists[i];
                result.howManyMoreOfEachCertNeeded.Add(count);
                total += count;
            }

            needToTrainMorePeople(total);
        }

        private void calcTotalWorksHoursAvailable(int hoursToCompleteJob, int reqDaysToFinishJob)
        {
            for (int i = 0; i < result.howManyOfEachCertExists.Count; i++)
                result.timeNeeded += result.howManyOfEachCertExists[i] * 8 * reqDaysToFinishJob;

            int days = result.timeNeeded / 8;

            //Checks if the job can be completed in the req days
            if (days <= reqDaysToFinishJob)
                result.canCompleteInReqDays = true;
            else
                result.canCompleteInReqDays = false;

        }

        private void needToTrainMorePeople(int nrOfPeopleNeeded)
        {
            if(nrOfPeopleNeeded > 0)
            {

            }
        }

        private void GetListOfEmployessFromDataBase()
        {
            int nrOfNames = 0;

            employees.cert.Add(new List<String>());

            con.Open();

            string sqlQuery = "select Name from Certifications";
            cmd = new SqlCommand(sqlQuery, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nrOfDiffCert++;
                employees.cert[0].Add(dr["Name"].ToString());
            }
            dr.Close();

            cmd.CommandText = "select Name from Employees";
            dr = cmd.ExecuteReader();

            Dictionary<string, int> employeeListIndex = new Dictionary<string, int>();
            while (dr.Read())
            {
                employees.names.Add(dr[0].ToString());
                employees.cert.Add(new List<String>());
                nrOfNames++;

                int index = nrOfNames - 1;
                employeeListIndex.Add(dr[0].ToString(), index);
            }

            dr.Close();

            for (int i = 1; i < nrOfNames + 1; i++)
            {
                for (int j = 0; j < nrOfDiffCert; j++)
                {
                    employees.cert[i].Add("0");
                }
            }


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

                String tmp = dr[1].ToString();
                for (int i = 0; i < nrOfDiffCert; i++)
                {
                    if (employees.cert[0][i].Contains(tmp))
                    {
                        employees.cert[index + 1][i] = "1";
                        i = nrOfDiffCert;
                    }
                }
            }

            dr.Close();
            con.Close();
        }

        public void clearEmployeeList()
        {
            employees.ClearList();
            nrOfDiffCert = 0;
        }
    }
}

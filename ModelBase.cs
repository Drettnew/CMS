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

        private int nrOfDiffCert;  //Holds the number of different cert the job requests.
        private ListOfEmployee employees = new ListOfEmployee();
        private ListOfOutPutsFromModelBase result = new ListOfOutPutsFromModelBase();


        public ModelBase()
        {
            nrOfDiffCert = 0;
        }


        /// <summary>
        /// Checks and saves how many of each employees with right cert we have.
        /// Listing their names and amount per cert.
        /// </summary>
        /// <param name="certForJob"></param>  Job request details
        /// <param name="hoursToCompleteJob"></param> Hours it should take to complete job
        /// <param name="reqDaysToFinishJob"></param> Number of days we have available.
        /// <returns></returns>
        public ListOfOutPutsFromModelBase CheckJobReqWithEmployees(List<JobCertReqList> certForJob, int hoursPredictedToCompleteJob, int reqDaysToFinishJob)
        {
            List<int> certIndex = new List<int>();
            List<int> copyOfCertIndex = new List<int>();
            result.reqForTheJob = certForJob;

            GetListOfEmployessFromDataBase();

            for(int i = 0; i < certForJob.Count; i++)
            {
                for(int j = 0; j < nrOfDiffCert; j++)
                {
                    if (certForJob[i].Certificate == employees.cert[0][j])
                    {
                        certIndex.Add(j);
                        copyOfCertIndex.Add(j);
                        result.howManyOfEachCertExists.Add(0);
                        j = nrOfDiffCert;
                    }
                }
            }

            bool newEmployeeFound = true; 
            bool employeeCounted = false;
            String name = "";
            int id = -1;
            List<String> lCert = new List<String>();
            for (int i = 1; i < employees.names.Count + 1; i++)
            {
                newEmployeeFound = true;
                employeeCounted = false;

                for (int j = 0; j < certIndex.Count; j++)
                {
                    if (employees.cert[i][certIndex[j]] == "1")
                    {
                        if(newEmployeeFound)
                        {
                            name = employees.names[i - 1];
                            id = employees.ids[i - 1];
                            newEmployeeFound = false;
                        }

                        result.howManyOfEachCertExists[j] += 1;
                        lCert.Add(employees.cert[0][certIndex[j]]);

                        if (result.howManyOfEachCertExists[j] <= result.reqForTheJob[j].Count && !employeeCounted)
                        {
                            result.nrOfActualPeopleFound++;
                            employeeCounted = true;
                        }
                    }
                }

                List<String> newList = new List<String>(lCert);

                if (!newEmployeeFound)
                {
                    result.listOfAvailableEmpoyees.Add(new ChoosenEmployee(name, id, newList)); 
                }
                name = "";
                id = -1;
                lCert.Clear();
            }  

            calcTotalWorksHoursAvailable(hoursPredictedToCompleteJob, reqDaysToFinishJob, copyOfCertIndex);

            return result;
        }


        /// <summary>
        /// Gets all the employees names and certs from database and put them
        /// into the "ListOfEmployees"
        /// </summary>
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


            cmd.CommandText = "select Id, Name from Employees";
            dr = cmd.ExecuteReader();

            Dictionary<string, int> employeeListIndex = new Dictionary<string, int>();
            while (dr.Read())
            {
                employees.ids.Add(Int32.Parse(dr[0].ToString()));
                employees.names.Add(dr[1].ToString());
                employees.cert.Add(new List<String>());
                nrOfNames++;

                int index = nrOfNames - 1;
                employeeListIndex.Add(dr[1].ToString(), index);
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


        /// <summary>
        /// Calculates how much time our available employees with right cert can work
        /// and checks it against the request time limit.
        /// </summary>
        /// <param name="hoursToCompleteJob"></param>
        /// <param name="reqDaysToFinishJob"></param>
        private void calcTotalWorksHoursAvailable(int hoursPredictedToCompleteJob, int reqDaysToFinishJob, List<int> certIndex)
        {
            for (int i = 0; i < result.howManyOfEachCertExists.Count; i++)
            {
                if (result.nrOfActualPeopleFound > 0)
                    result.timeNeeded = result.nrOfActualPeopleFound * 8 * reqDaysToFinishJob;
                else
                    result.timeNeeded = 0;
            } 

            //Checks if the job can be completed in the req days
            if (result.timeNeeded >= hoursPredictedToCompleteJob)
                result.canCompleteInReqDays = true;
            else
                result.canCompleteInReqDays = false;

            calcCertNeeded(certIndex);

        }


        /// <summary>
        /// Just calculates the number of employees with right cert we have in 
        /// total and per certificate.
        /// </summary>
        private void calcCertNeeded(List<int> certIndex)
        {
            int count = 0;
            int total = 0;

            for (int i = 0; i < result.reqForTheJob.Count; i++)
            {
                count = result.reqForTheJob[i].Count - result.howManyOfEachCertExists[i];
                if (count < 0)
                    count = 0;
                if (count > 0)
                    result.moreCertNeeded = true;
                result.howManyMoreOfEachCertNeeded.Add(count);
                total += count;
            }

           needToTrainMorePeople(total, certIndex);
        } 


        private void needToTrainMorePeople(int nrOfPeopleNeeded, List<int> certIndex)
        {
            List<int> listOfCost = new List<int>();
            String tmp = "";

            if(nrOfPeopleNeeded > 0)
            {
                con.Open();
                int x = 0;

                string sqlQuery = "select Cost from Certifications";
                cmd = new SqlCommand(sqlQuery, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tmp = dr["Cost"].ToString();
                    x = Int32.Parse(tmp);
                    listOfCost.Add(x);
                }
                dr.Close();
                con.Close();
                for(int i = 0; i < result.howManyMoreOfEachCertNeeded.Count; i++)
                {
                    if (result.howManyMoreOfEachCertNeeded[i] > 0)
                    {
                        result.costToTrainMorePeople.Add(listOfCost[certIndex[i]] * result.howManyMoreOfEachCertNeeded[i]);
                    }
                    else
                        result.costToTrainMorePeople.Add(0);
                }

            }

            costToAddOnPrice(listOfCost, certIndex);
        }


        private void costToAddOnPrice(List<int> listOfCost, List<int> certIndex)
        {
            for(int i = 0; i < result.reqForTheJob.Count; i++)
            {
                result.costToAddForEachCert.Add((listOfCost[certIndex[i]] / 1920.0) * result.reqForTheJob[i].Count);
            }
        }

        /// <summary>
        /// Clears all the lists and variables.
        /// </summary>
        public void clearEmployeeList()
        {
            employees.ClearList();
            result.ClearList();
            nrOfDiffCert = 0;
        }
    }
}
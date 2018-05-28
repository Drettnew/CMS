using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    class EmployeeChanges
    {
        public string EmployeeId;
        public List<string> CertId;
        public List<string> CertAdditInfo;
        public List<string> CertDate;

        public List<string> AddCertId;
        public List<string> AddCertAdditInfo;
        public List<string> AddCertDate;

        public List<string> EditCertId;
        public List<string> EditCertAdditInfo;
        public List<string> EditCertDate;

        public List<string> DeleteCertId;
        public List<string> DeleteCertAdditInfo;
        public List<string> DeleteCertDate;

        public EmployeeChanges()
        {
            CertId = new List<string>();
            CertAdditInfo = new List<string>();
            CertDate = new List<string>();

            AddCertId = new List<string>();
            AddCertAdditInfo = new List<string>();
            AddCertDate = new List<string>();

            EditCertId = new List<string>();
            EditCertAdditInfo = new List<string>();
            EditCertDate = new List<string>();

            DeleteCertId = new List<string>();
            DeleteCertAdditInfo = new List<string>();
            DeleteCertDate = new List<string>();
        }

        public string GetAdditInfo(string id)
        {
            if(EditCertId.Contains(id))
            {
                if(EditCertAdditInfo.Count >= EditCertId.IndexOf(id))
                {
                    return EditCertAdditInfo[EditCertId.IndexOf(id)];
                }
            }
            if (AddCertId.Contains(id))
            {
                if (AddCertAdditInfo.Count >= AddCertId.IndexOf(id))
                {
                    return AddCertAdditInfo[AddCertId.IndexOf(id)];
                }
            }
            if (CertId.Contains(id))
            {
                if (CertAdditInfo.Count >= CertId.IndexOf(id))
                {
                    return CertAdditInfo[CertId.IndexOf(id)];
                }
            }

            return "Error: No data found!";
        }

        public string GetDate(string id)
        {
            if (EditCertId.Contains(id))
            {
                if (EditCertDate.Count >= EditCertId.IndexOf(id))
                {
                    return EditCertDate[EditCertId.IndexOf(id)];
                }
            }
            if (AddCertId.Contains(id))
            {
                if (AddCertDate.Count >= AddCertId.IndexOf(id))
                {
                    return AddCertDate[AddCertId.IndexOf(id)];
                }
            }
            if (CertId.Contains(id))
            {
                if (CertDate.Count >= CertId.IndexOf(id))
                {
                    return CertDate[CertId.IndexOf(id)];
                }
            }

            return "Error: No data found!";
        }
    }
}

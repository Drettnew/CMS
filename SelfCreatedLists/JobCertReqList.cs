using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SelfCreatedLists
{
    /// <summary>
    /// All the certification requests from the GUI,
    /// This holds a single cert and how many people with that cert are needed.
    /// </summary>
    public class JobCertReqList
    {
        public String Certificate { get; set; }
        public int Count { get; set; }

        public JobCertReqList()
        {
            Count = 0;
        }
    }
}

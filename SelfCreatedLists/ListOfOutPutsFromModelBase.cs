using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SelfCreatedLists
{
    class ListOfOutPutsFromModelBase
    {
        public List<JobCertReqList> reqForTheJob;
        public List<String> namesWithCert = new List<String>();
        public List<int> howManyOfEachCertExists = new List<int>();
        public List<int> howManyMoreOfEachCertNeeded = new List<int>();
        public bool canCompleteInReqDays;
        public int timeNeeded;
        public int costToTrainMorePeople;

        public ListOfOutPutsFromModelBase()
        {
            timeNeeded = 0;
            costToTrainMorePeople = 0;
            canCompleteInReqDays = false;
        }
    }
}

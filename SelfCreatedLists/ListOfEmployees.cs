using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SelfCreatedLists
{
    class ListOfEmployees
    {
        public List<String> names;
        public List<List<String>> cert;

        public ListOfEmployees()
        {
            names = new List<String>();
            cert = new List<List<String>>();
        }
    }
}

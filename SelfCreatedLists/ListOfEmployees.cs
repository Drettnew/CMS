using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SelfCreatedLists
{
    class ListOfEmployees
    {
        public List<String> names = new List<String>();
        public List<List<String>> cert = new List<List<String>>();

        public ListOfEmployees()
        {
        }

        public void ClearList()
        {
            names.Clear();
            cert.Clear();
        }
    }
}

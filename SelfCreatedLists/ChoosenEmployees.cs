using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SelfCreatedLists
{
    public class ChoosenEmployee
    {
        public String name;
        public int id;
        public List<String> cert = new List<String>();

        public ChoosenEmployee()
        {

        }

        public ChoosenEmployee(String name, int id, List<String> cert)
        {
            this.name = name;
            this.id = id;
            this.cert = cert;
        }

        public void Clear()
        {
            name = "";
            id = -1;
            cert.Clear();
        }
    }
}

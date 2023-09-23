using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class City
    {
        string name;
        string subject;

        public City(string name, string subject)
        {
            this.name = name;
            this.subject = subject;
        }

        public string GetName()
        {
            return name;
        }
    }
}

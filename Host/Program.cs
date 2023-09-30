using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(PeaceLab5.Classes.Register)))
            {
                host.Open();
                Console.WriteLine("Хост стартовал");
            }
        }
    }
}

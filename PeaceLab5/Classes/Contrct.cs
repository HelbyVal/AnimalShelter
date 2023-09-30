using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PeaceLab5.Classes
{
    [DataContractAttribute]
    public class Contrct
    {
        string number;
        DateTime date;
        double cost;
        DateTime accDate;
        Shelter shelter;

        public double GetCost()
        {
            return cost;
        }

        public Contrct(DateTime date, string contractNum, double cost)
        {
            number = contractNum;
            this.date = date;
            this.cost = cost;
            accDate = DateTime.Now;
        }

        public void SetShelter(Shelter shelt)
        {
            shelter = shelt;
        }
    }
}

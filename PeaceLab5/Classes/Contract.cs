using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class Contract
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

        public Contract(DateTime date, string contractNum, double cost)
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

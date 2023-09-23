using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class Register
    {
        RegContract regContract;

        public Register()
        { }

        public void SetRegContract(RegContract reg)
        {
            regContract = reg;
        }

        public Contract AddContract(string nameCity, DateTime data, string contractNum, double cost)
        {
            var contr = regContract.AddContract(nameCity, data, contractNum, cost);
            return contr;
        }

        public void AddAnimal(string anType, string anCol, string anSex, double anSize, string chipNum, DateTime accDate, string cityName)
        {
            regContract.AddAnimal(anType, anCol, anSex, anSize, chipNum, accDate, cityName);
        }

        public void AddAnimal(string chipNum, DateTime accDate, string cityName)
        {
            regContract.AddAnimal(chipNum, accDate, cityName);
        }

        public void ReleaseAnimal(string chipNum, DateTime accDate, string cityName)
        {
            regContract.ReleaseAnimal(chipNum, accDate, cityName);
        }

        public double CreateReport(string cityName, DateTime firstDate, DateTime lastDate)
        {
            double overallCost = regContract.CreateReport(cityName, firstDate, lastDate);
            return overallCost;
        }
    }
}

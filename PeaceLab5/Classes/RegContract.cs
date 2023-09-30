using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class RegContract
    {
        RegShelter regShelter;

        public RegContract()
        { }

        public void SetRegShelter(RegShelter reg)
        {
            regShelter = reg;
        }

        public Contrct AddContract(string nameCity, DateTime data, string contractNum, double cost)
        {
            Contrct contr = new Contrct(data, contractNum, cost);
            var shelt = regShelter.AddContToShelt(nameCity, contr);
            contr.SetShelter(shelt);
            return contr;
        }

        public void AddAnimal(string anType, string anCol, string anSex, double anSize, string chipNum, DateTime accDate, string cityName)
        {
            regShelter.AddAnimal(anType, anCol, anSex, anSize, chipNum, accDate, cityName);
        }

        public void AddAnimal(string chipNum, DateTime accDate, string cityName)
        {
            regShelter.AddAnimal(chipNum, accDate, cityName);
        }

        public void ReleaseAnimal(string chipNum, DateTime accDate, string cityName)
        {
            regShelter.ReleaseAnimal(chipNum, accDate, cityName);
        }

        public double CreateReport(string cityName, DateTime firstDate, DateTime lastDate)
        {
            double overallCost = regShelter.CreateReport(cityName, firstDate, lastDate);
            return overallCost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class RegShelter
    {
        List<Shelter> shelterList;

        public RegShelter()
        {
            shelterList = new List<Shelter>();
        }
        
        public void AddShelter(Shelter shelter)
        {
            shelterList.Add(shelter);
        }

        public Shelter FindShelter(string nameCity)
        {
            var shelt = shelterList.Find(shel => shel.GetCityName() == nameCity);
            return shelt;
        }
        public void AddAnimal(string anType, string anCol, string anSex, double anSize, string chipNum, DateTime accDate, string cityName)
        {
            var shelt = FindShelter(cityName);
            shelt.AddAnimal(anType, anCol, anSex, anSize, chipNum, accDate);
        }

        public void AddAnimal(string chipNum, DateTime accDate, string cityName)
        {
            var shelt = FindShelter(cityName);
            shelt.AddAnimal(chipNum, accDate);
        }

        public void ReleaseAnimal(string chipNum, DateTime accDate, string cityName)
        {
            var shelt = FindShelter(cityName);
            shelt.ReleaseAnimal(chipNum, accDate);
        }

        public Shelter AddContToShelt(string nameCity, Contract contr)
        {
            var shelt = FindShelter(nameCity);
            shelt.SetContract(contr);
            return shelt;
        }

        public double CreateReport(string cityName, DateTime firstDate, DateTime lastDate)
        {
            var shelt = FindShelter(cityName);
            double overallCost = shelt.CalculateOverallCost(firstDate, lastDate);
            return overallCost;
        }
    }
}

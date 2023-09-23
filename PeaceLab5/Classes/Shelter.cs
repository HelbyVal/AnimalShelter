using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class Shelter
    {
        string INN;
        string KPP;
        string orgType;
        City city;
        Contract contr;
        RegAnimal animals;

        public Shelter(string inn, string kpp, string orgType, City city)
        {
            INN = inn;
            KPP = kpp;
            this.orgType = orgType;
            this.city = city;
            animals = new RegAnimal();
        }

        public void SetContract(Contract contr)
        {
            this.contr = contr;
        } 

        public void AddAnimal(string anType, string anCol, string anSex, double anSize, string chipNum, DateTime accDate)
        {
            animals.AcceptAnimal(anType, anCol, anSex, anSize, chipNum, accDate);
        }

        public void AddAnimal(string chipNum, DateTime accDate)
        {
            animals.AcceptAnimal(chipNum, accDate);
        }

        public void ReleaseAnimal(string chipNum, DateTime date)
        {
            animals.ReleaseAnimal(chipNum, date);
        }

        public double CalculateOverallCost(DateTime firstDate, DateTime lastDate)
        {
            double cost = contr.GetCost();
            var days = animals.CalculateOverallDays(firstDate, lastDate);
            double overallCost = days * cost;
            return Math.Round(overallCost, 2);
        }

        public string GetCityName()
        {
            string nameCity = city.GetName();
            return nameCity;
        }
    }
}

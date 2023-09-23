using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class RegAnimal
    {
        List<Animal> animalList;
        public RegAnimal()
        {
            animalList = new List<Animal>();
        }

        public void AcceptAnimal(string anType, string anCol, string anSex, double anSize, string chipNum, DateTime accDate)
        {
            var anim = new Animal(anType, anCol, anSex, anSize, chipNum, accDate);
            animalList.Add(anim);
        }

        public void AcceptAnimal(string chipNum, DateTime accDate)
        {
            var anim = animalList.Find(an => an.GetChipNum() == chipNum);
            anim.AddCard(accDate);
        }

        public void ReleaseAnimal(string chipNum, DateTime date)
        {
            var anim = animalList.Find(an => an.GetChipNum() == chipNum);
            anim.Release(date);
        }

        public int CalculateOverallDays(DateTime firstDate, DateTime lastDate)
        {
            int overallDays = 0;
            foreach (var anim in animalList)
            {
                overallDays += anim.CalculateAnimDays(firstDate, lastDate);
            }
            return overallDays;
        }
    }
}

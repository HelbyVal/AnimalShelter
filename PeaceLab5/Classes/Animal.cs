using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class Animal
    {
        List<AnimalCard> cardList;
        double size;
        string color;
        string sex;
        string type;
        string chipNum;

        public Animal(string anType, string anCol, string anSex, double anSize, string chipNum, DateTime accDate)
        {
            size = anSize;
            color = anCol;
            sex = anSex;
            type = anType;
            this.chipNum = chipNum;
            cardList = new List<AnimalCard>();
            var card = new AnimalCard(accDate);
            cardList.Add(card);
        }

        public int CalculateAnimDays(DateTime firstDate, DateTime lastDate)
        {
            int animDays = 0;
            foreach (var card in cardList)
            {
                animDays += card.CalculateDays(firstDate, lastDate);
            }
            return animDays;
        }

        public void Release(DateTime date)
        {
            var card = cardList.Last();
            card.AddReleaseDate(date);
        }

        public void AddCard(DateTime accDate)
        {
            var card = new AnimalCard(accDate);
            cardList.Add(card);
        } 

        public string GetChipNum()
        {
            return chipNum;
        }
    }
}

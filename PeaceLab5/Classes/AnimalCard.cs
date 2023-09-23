using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceLab5.Classes
{
    public class AnimalCard
    {
        DateTime accDate;
        DateTime relDate;

        public AnimalCard(DateTime accDate) 
        {
            this.accDate = accDate;
        }
        public void AddReleaseDate(DateTime date)
        {
            relDate = date;
        }
        public int CalculateDays(DateTime firstDate, DateTime lastDate)
        {
            if (lastDate <= accDate)
                return 0;
            if (relDate.Year != 1 && firstDate >= relDate)
                return 0;
            if (firstDate <= accDate)
                firstDate = accDate;
            if (relDate.Year != 1 && lastDate >= relDate)
                lastDate = relDate;
            var cardDay = lastDate - firstDate;
            return (int)cardDay.TotalDays + 1;
        }
    }
}

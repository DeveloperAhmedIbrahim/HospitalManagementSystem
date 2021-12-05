using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Managment_System.Expences
{
    class Dinner : Std
    {
        private int dinnerCost;
        private int totalDinnerCost;

        public Dinner(int numofstudent , int dinnercost) : base(numofstudent)
        {
            this.dinnerCost = dinnercost;
        }

        public int TotalDinnerCost()
        {

            this.totalDinnerCost = this.numberOfStudent * this.dinnerCost;
            return this.totalDinnerCost;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Managment_System.Expences
{
    public class Breakfast: Std
    {
        private int breakfastCost;
        private int totalBreakfastCost;
        public Breakfast(int numofStudent , int breakfastcost) : base(numofStudent)
        {
            this.breakfastCost = breakfastcost;
        }
        

        public int TotalBreakfastCost() {

            
            this.totalBreakfastCost = this.breakfastCost * this.numberOfStudent;
            return this.totalBreakfastCost;
           

        }
    }
}

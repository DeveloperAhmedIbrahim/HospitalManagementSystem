using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Managment_System.Expences
{
    class Lunch : Std
    {
        private int lunchCost;
        private int totalLunchCost;
        public Lunch(int numofstudent, int lunchcost): base(numofstudent)
        {
            this.lunchCost = lunchcost;
        }

        public int TotalLunchCost()
        {
           this.totalLunchCost = this.lunchCost * this.numberOfStudent;
           return this.totalLunchCost;            
        }
    }    
}

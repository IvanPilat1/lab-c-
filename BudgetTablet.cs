using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_03
{
    public class BudgetTablet : Tablet
    {
        public bool IsKidsFriendly { get; set; }
        

        public BudgetTablet() { }
    
        public BudgetTablet(string brand, string model, double screenSize, string resolution,
            int rAM, int storage, int prise, string operatingSystem, bool hasCamera, bool isKidsFriendly)
            : base(brand, model, screenSize, resolution, rAM, storage, prise, operatingSystem, hasCamera)
        {
            IsKidsFriendly = isKidsFriendly;
        }

        public override string Kategoria()
        {
            return "budget";
        }

    }
}

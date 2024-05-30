using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_03
{
    public class HighEndTablet : Tablet
    {
        public bool SupportsStylus { get; set; }
        


        public HighEndTablet() { }


        public HighEndTablet(string brand, string model, double screenSize, string resolution,
            int rAM, int storage, int prise, string operatingSystem, bool hasCamera, bool supportsStylus)
            : base(brand, model, screenSize, resolution, rAM, storage, prise, operatingSystem, hasCamera)
        {
            SupportsStylus = supportsStylus;
        }

        public override string Kategoria()
        {
            return "high-end";
        }
    }
}

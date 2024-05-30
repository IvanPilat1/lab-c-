using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_04_03
{
    public abstract class Tablet
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double ScreenSize { get; set; }
        public string Resolution { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
        public int Price
        {
            get; set;
        }
        public string OperatingSystem { get; set; }
        
        public bool HasCamera { get; set; }

        public virtual string  Kategoria()
        {
            if (Price > 20000)
                return "cheap";
            else if (Price > 20000 && Price < 100000)
                return "average price";
            else
                return "expensive";
        }
        public Tablet() { }
        public Tablet(string brand, string model, double screenSize, string resolution,
            int rAM, int storage, int prise, string operatingSystem, bool hasCamera)

        {
            Brand = brand; Model = model; ScreenSize = screenSize; Resolution = resolution;
            RAM = rAM; Storage = storage; Price = prise; OperatingSystem = operatingSystem;
            HasCamera = hasCamera;
        }
    }
}

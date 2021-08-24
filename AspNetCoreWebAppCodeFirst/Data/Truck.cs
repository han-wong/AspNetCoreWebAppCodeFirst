using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class Truck
    {
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int LoadVolumeKvm { get; set; }
    }
}

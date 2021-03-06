using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class Truck : IVehicle
    {
        public int Id { get; set; }
        public int LoadVolumeKvm { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string RegNo { get; set; }
        public int Year { get; set; }
    }
}

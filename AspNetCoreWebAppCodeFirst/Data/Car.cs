using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class Car : IVehicle
    {
        public int Id { get; set; }
        public bool HasRadio { get; set; }
        //public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string RegNo { get; set; }
        public int Year { get; set; }
    }
}

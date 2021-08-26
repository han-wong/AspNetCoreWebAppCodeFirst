using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppCodeFirst.Pages.Cars
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string Model { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}

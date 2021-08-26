using AspNetCoreWebAppCodeFirst.Data;
using AspNetCoreWebAppCodeFirst.Pages.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppCodeFirst.Pages.Manufacturers
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarViewModel> Cars { get; set; }
    }
}

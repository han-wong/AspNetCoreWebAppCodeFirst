using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class CV
    {
        public int Id { get; set; }
        public bool HasCar { get; set; }
        public bool HasLicense { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public PossibleWorkLocation PossibleWorkLocation { get; set; }
        public List<Education> Educations { get; set; }
    }

    public enum PossibleWorkLocation
    {
        Regional, Sweden, EU
    }
}

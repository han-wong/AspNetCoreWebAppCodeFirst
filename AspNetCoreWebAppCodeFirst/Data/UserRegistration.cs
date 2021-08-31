using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public enum UserType
    {
        Normal,
        Premium,
        VIP
    }

    public class UserRegistration
    {
        public int Id { get; set; }
        public Country Country { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string First { get; set; }

        [MaxLength(100)]
        public string Last { get; set; }

        public bool OkUpdates { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public UserType UserType { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

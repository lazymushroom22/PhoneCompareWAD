using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneCompare.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string YearBorn { get; set; }
    }
}

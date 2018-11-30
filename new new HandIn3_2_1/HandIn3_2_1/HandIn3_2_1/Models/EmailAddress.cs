using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HandIn3_2_1.Models
{
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        public string EmailAddr { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandIn3_2_1.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<EmailAddress> EmailAddresses { get; set; }

    }
}

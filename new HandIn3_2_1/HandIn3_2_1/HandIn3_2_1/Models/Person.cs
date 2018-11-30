using System;
using System.Collections.Generic;

namespace HandIn3_2_1.Models
{
    public partial class Person
    {
        public Person()
        {
   
            EmailAddress = new HashSet<EmailAddress>();
        }

        public long PersonId { get; set; }
        public long AddressId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }

        public Address Address { get; set; }
        public ICollection<EmailAddress> EmailAddress { get; set; }
    }
}

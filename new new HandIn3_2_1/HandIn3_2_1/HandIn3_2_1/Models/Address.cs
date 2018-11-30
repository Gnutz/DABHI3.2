using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandIn3_2_1.Models
{
    public class Address
    {

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Person> PersonsOnAddress { get; set; }


    }
}

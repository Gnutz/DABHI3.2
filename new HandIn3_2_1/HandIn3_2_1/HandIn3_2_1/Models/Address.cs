using System;
using System.Collections.Generic;

namespace HandIn3_2_1.Models
{
    public partial class Address
    {
        public Address()
        {
            PersonsOnAddress = new HashSet<Person>();
        }

        public long AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public long? CityId { get; set; }

        public City City { get; set; }
        public ICollection<Person> PersonsOnAddress { get; set; }
    }
}

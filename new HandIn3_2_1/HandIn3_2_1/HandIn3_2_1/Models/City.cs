using System;
using System.Collections.Generic;

namespace HandIn3_2_1.Models
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public long CityId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}

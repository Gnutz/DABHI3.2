using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalogueDocumentModel
{

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public Emaiaddress[] EmaiAddress { get; set; }
    }

    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public City City { get; set; }
    }

    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
    }

    public class Emaiaddress
    {
        public int EmailAddressID { get; set; }
        public string EmailAddress { get; set; }
    }

}

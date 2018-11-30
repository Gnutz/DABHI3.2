using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PersonCatalogueDocumentModel
{

    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "MiddkeName")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string Surname { get; set; }

        [JsonProperty("Address")]
        public Address Address { get; set; }

        [JsonProperty("EmailAddress")]
        public EmailAddress EmailAddress { get; set; }
                                                
    }

    public class Address
    {

        [JsonProperty(PropertyName = "AddressId")]
        public string AddressID { get; set; }

        [JsonProperty(PropertyName = "Street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "HouseNumber")]
        public string HouseNumber { get; set; }

        [JsonProperty("City")]
        public City City { get; set; }
    }

    public class City
    {
        [JsonProperty(PropertyName = "CityId")]
        public string CityID { get; set; }

        [JsonProperty(PropertyName = "CityName")]
        public string CityName { get; set; }

        [JsonProperty(PropertyName = "ZipCode")]
        public string ZipCode { get; set; }
    }

    public class EmailAddress
    {

        [JsonProperty(PropertyName = "EmailAddressID")]
        public string EmailAddressID { get; set; }

        [JsonProperty(PropertyName = "EmailAddress")]
        public string Emailaddress { get; set; }
    }

}

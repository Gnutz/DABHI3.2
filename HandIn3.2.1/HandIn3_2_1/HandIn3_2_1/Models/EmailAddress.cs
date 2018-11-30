using System;
using System.Collections.Generic;

namespace HandIn3_2_1.Models
{
    public partial class EmailAddress
    {
        public long EmailId { get; set; }
        public string Email { get; set; }
        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}

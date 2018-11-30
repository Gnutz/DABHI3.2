using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HandIn3_2_1.Models
{
    public class PersonCatalogueCORECOntext : DbContext
    {
        public PersonCatalogueCORECOntext(DbContextOptions<PersonCatalogueCORECOntext> options)
            :base(options)
        {
        
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HandIn3_2_1.Models
{
    public partial class E18I4DABau569735Context : DbContext
    {
        public E18I4DABau569735Context()
        {
        }

        public E18I4DABau569735Context(DbContextOptions<E18I4DABau569735Context> options)
            : base(options)
        {
        }

        public virtual  DbSet<Address> Address { get; set; } 
        public virtual  DbSet<City> City { get; set; }
        public virtual  DbSet<EmailAddress> EmailAddress { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=st-I4dab.uni.au.dk;Initial Catalog=E18I4DABau569735;User ID=E18I4DABau569735;Password=E18I4DABau569735;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
               // "Data Source = st - i4dab.uni.au.dk; Initial Catalog = E18I4DABau569735; User ID = E18I4DABau569735; Password = E18I4DABau569735; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
            }
        } 

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonCatalogueDocumentModel;

namespace HandIn3_2_2.Models
{
    public class HandIn3_2_2Context : DbContext
    {
        public HandIn3_2_2Context (DbContextOptions<HandIn3_2_2Context> options)
            : base(options)
        {
        }

        public DbSet<PersonCatalogueDocumentModel.Person> Person { get; set; }
    }
}

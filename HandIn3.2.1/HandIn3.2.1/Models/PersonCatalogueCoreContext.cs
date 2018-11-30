using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HandIn3_2_1.Models
{
    public partial class PersonCatalogueContext : DbContext
    {
        public PersonCatalogueContext()
        {
        }

        public PersonCatalogueContext(DbContextOptions<PersonCatalogueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<City> City { get; set; }

        public virtual DbSet<EmailAddress> EmailAddress { get; set; }
        public virtual DbSet<Person> Person { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonCatalogueDB.NETCORE;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
                //optionsBuilder.UseSqlServer("Data Source=st-i4dab.uni.au.dk; Initial Catalog=E18I4DABau569735;User ID=E18I4DABau569735;Password=E18I4DABau569735;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("UQ__Address__091C2A1A882359CE")
                    .IsUnique();

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithOne(p => p.Address)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasMany(d => d.PersonsOnAddress)
                    .WithOne()
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

           

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.CityId)
                    .HasName("UQ__City__F2D21A976387AC09")
                    .IsUnique();

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<EmailAddress>(entity =>
            {
                entity.HasKey(e => e.EmailId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__EmailAdd__A9D105347677E6A0")
                    .IsUnique();

                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__EmailAdd__7ED91AEECC440EBD")
                    .IsUnique();

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.PersonId)
                    .HasName("UQ__Person__AA2FFB84BF36F5C7")
                    .IsUnique();

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Middlename)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Person");
            });
        }
    }
}

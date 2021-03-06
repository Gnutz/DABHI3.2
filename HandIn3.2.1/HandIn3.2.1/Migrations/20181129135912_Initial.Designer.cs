﻿// <auto-generated />
using System;
using HandIn3_2_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HandIn3._2._1.Migrations
{
    [DbContext(typeof(PersonCatalogueContext))]
    [Migration("20181129135912_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HandIn3_2_1.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CityId")
                        .HasColumnName("CityID");

                    b.Property<long?>("CityId1");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("AddressId");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasName("UQ__Address__091C2A1A882359CE");

                    b.HasIndex("CityId1")
                        .IsUnique()
                        .HasFilter("[CityId1] IS NOT NULL");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("HandIn3_2_1.Models.City", b =>
                {
                    b.Property<long>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("CityId");

                    b.HasIndex("CityId")
                        .IsUnique()
                        .HasName("UQ__City__F2D21A976387AC09");

                    b.ToTable("City");
                });

            modelBuilder.Entity("HandIn3_2_1.Models.EmailAddress", b =>
                {
                    b.Property<long>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmailID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<long>("PersonId")
                        .HasColumnName("PersonID");

                    b.Property<long?>("PersonId1");

                    b.HasKey("EmailId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__EmailAdd__A9D105347677E6A0");

                    b.HasIndex("EmailId")
                        .IsUnique()
                        .HasName("UQ__EmailAdd__7ED91AEECC440EBD");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonId1");

                    b.ToTable("EmailAddress");
                });

            modelBuilder.Entity("HandIn3_2_1.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PersonID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddressId")
                        .HasColumnName("AddressID");

                    b.Property<long?>("AddressId1");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Middlename")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.HasIndex("AddressId1");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasName("UQ__Person__AA2FFB84BF36F5C7");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("HandIn3_2_1.Models.Address", b =>
                {
                    b.HasOne("HandIn3_2_1.Models.City", "City")
                        .WithOne("Address")
                        .HasForeignKey("HandIn3_2_1.Models.Address", "CityId1");
                });

            modelBuilder.Entity("HandIn3_2_1.Models.EmailAddress", b =>
                {
                    b.HasOne("HandIn3_2_1.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("HandIn3_2_1.Models.Person")
                        .WithMany("EmailAddress")
                        .HasForeignKey("PersonId1");
                });

            modelBuilder.Entity("HandIn3_2_1.Models.Person", b =>
                {
                    b.HasOne("HandIn3_2_1.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .HasConstraintName("fk_Person");

                    b.HasOne("HandIn3_2_1.Models.Address")
                        .WithMany("PersonsOnAddress")
                        .HasForeignKey("AddressId1");
                });
#pragma warning restore 612, 618
        }
    }
}

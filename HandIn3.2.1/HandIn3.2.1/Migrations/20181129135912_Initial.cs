﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HandIn3._2._1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    HouseNumber = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CityID = table.Column<long>(nullable: false),
                    CityId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId1",
                        column: x => x.CityId1,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressID = table.Column<long>(nullable: false),
                    Firstname = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Middlename = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Surname = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    AddressId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "fk_Person",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId1",
                        column: x => x.AddressId1,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    EmailID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    PersonID = table.Column<long>(nullable: false),
                    PersonId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.EmailID);
                    table.ForeignKey(
                        name: "FK_EmailAddress_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailAddress_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Address__091C2A1A882359CE",
                table: "Address",
                column: "AddressID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId1",
                table: "Address",
                column: "CityId1",
                unique: true,
                filter: "[CityId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__City__F2D21A976387AC09",
                table: "City",
                column: "CityID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__EmailAdd__A9D105347677E6A0",
                table: "EmailAddress",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__EmailAdd__7ED91AEECC440EBD",
                table: "EmailAddress",
                column: "EmailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_PersonID",
                table: "EmailAddress",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_PersonId1",
                table: "EmailAddress",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressID",
                table: "Person",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId1",
                table: "Person",
                column: "AddressId1");

            migrationBuilder.CreateIndex(
                name: "UQ__Person__AA2FFB84BF36F5C7",
                table: "Person",
                column: "PersonID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}

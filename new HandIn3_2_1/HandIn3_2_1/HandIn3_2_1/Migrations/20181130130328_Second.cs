using Microsoft.EntityFrameworkCore.Migrations;

namespace HandIn3_2_1.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Address",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "fk_EmailAddress",
                table: "EmailAddress");

            migrationBuilder.AlterColumn<long>(
                name: "PersonID",
                table: "EmailAddress",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "PersonId1",
                table: "EmailAddress",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CityID",
                table: "Address",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "CityId1",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_PersonId1",
                table: "EmailAddress",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId1",
                table: "Address",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "fk_Address",
                table: "Address",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId1",
                table: "Address",
                column: "CityId1",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_EmailAddress",
                table: "EmailAddress",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddress_Person_PersonId1",
                table: "EmailAddress",
                column: "PersonId1",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Address",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId1",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "fk_EmailAddress",
                table: "EmailAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddress_Person_PersonId1",
                table: "EmailAddress");

            migrationBuilder.DropIndex(
                name: "IX_EmailAddress_PersonId1",
                table: "EmailAddress");

            migrationBuilder.DropIndex(
                name: "IX_Address_CityId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "EmailAddress");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Address");

            migrationBuilder.AlterColumn<long>(
                name: "PersonID",
                table: "EmailAddress",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CityID",
                table: "Address",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_Address",
                table: "Address",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_EmailAddress",
                table: "EmailAddress",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

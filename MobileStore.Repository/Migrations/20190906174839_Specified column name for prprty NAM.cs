using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Repository.Migrations
{
    public partial class SpecifiedcolumnnameforprprtyNAM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MobilePhones",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MobilePhones");
        }
    }
}

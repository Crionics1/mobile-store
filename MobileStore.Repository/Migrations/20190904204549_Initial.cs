using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MobilePhones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Size = table.Column<string>(maxLength: 50, nullable: true),
                    Weight = table.Column<string>(maxLength: 50, nullable: false),
                    DisplayResolution = table.Column<string>(maxLength: 50, nullable: false),
                    Processor = table.Column<string>(maxLength: 50, nullable: false),
                    Memory = table.Column<string>(maxLength: 50, nullable: false),
                    Ram = table.Column<string>(maxLength: 50, nullable: false),
                    OS = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MobilePhones_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visuals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 50, nullable: false),
                    MobilePhoneID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visuals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Visuals_MobilePhones_MobilePhoneID",
                        column: x => x.MobilePhoneID,
                        principalTable: "MobilePhones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhones_ManufacturerID",
                table: "MobilePhones",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Visuals_MobilePhoneID",
                table: "Visuals",
                column: "MobilePhoneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visuals");

            migrationBuilder.DropTable(
                name: "MobilePhones");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}

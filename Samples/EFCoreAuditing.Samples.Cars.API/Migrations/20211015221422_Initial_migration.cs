using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreAuditing.Samples.Cars.API.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audits",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    modified_by = table.Column<string>(nullable: true),
                    table_name = table.Column<string>(nullable: true),
                    date_time = table.Column<DateTime>(nullable: false),
                    key_values = table.Column<string>(type: "text", nullable: true),
                    old_values = table.Column<string>(type: "text", nullable: true),
                    new_values = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    brand = table.Column<string>(nullable: true),
                    registration_number = table.Column<string>(nullable: true),
                    owner = table.Column<string>(nullable: true),
                    market_value = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTimeOffset>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audits");

            migrationBuilder.DropTable(
                name: "cars");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace newPrideMore.Migrations
{
    public partial class newDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profission",
                table: "ProfessionalType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profission",
                table: "ProfessionalType",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}

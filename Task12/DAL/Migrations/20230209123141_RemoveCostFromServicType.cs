using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveCostFromServicType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalCost",
                table: "ServiceType");

            migrationBuilder.DropColumn(
                name: "MainCost",
                table: "ServiceType");

            migrationBuilder.DropColumn(
                name: "More5Cost",
                table: "ServiceType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AdditionalCost",
                table: "ServiceType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MainCost",
                table: "ServiceType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "More5Cost",
                table: "ServiceType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

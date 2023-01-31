using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddServiceCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHardwares_ServiceInfo_ServiceInfoId",
                table: "ServiceHardwares");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSoftwares_ServiceInfo_ServiceInfoId",
                table: "ServiceSoftwares");

            migrationBuilder.DropTable(
                name: "ServiceInfo");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "ServiceSoftwares",
                newName: "ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceSoftwares_ServiceInfoId",
                table: "ServiceSoftwares",
                newName: "IX_ServiceSoftwares_ServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "ServiceHardwares",
                newName: "ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceHardwares_ServiceInfoId",
                table: "ServiceHardwares",
                newName: "IX_ServiceHardwares_ServiceTypeId");

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainCost = table.Column<double>(type: "float", nullable: false),
                    AdditionalCost = table.Column<double>(type: "float", nullable: false),
                    More5Cost = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    MainCost = table.Column<double>(type: "float", nullable: false),
                    AdditionalCost = table.Column<double>(type: "float", nullable: false),
                    More5Cost = table.Column<double>(type: "float", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCost_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServiceType",
                columns: new[] { "Id", "AdditionalCost", "Description", "MainCost", "More5Cost", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, "Консультации, удалённая поддержка. При необходимости выезд к клиенту", 0.0, 0.0, "Обслуживание КлиентТК" },
                    { 2, 0.0, "Консультации, удалённая поддержка. При необходимости выезд к клиенту.", 0.0, 0.0, "Обслуживание ГРС" },
                    { 3, 0.0, "Обслуживание техники. Ежемесечная проверка с диагностикой на месте эксплуатации.", 0.0, 0.0, "Сопровождение вычислительно техники" },
                    { 4, 0.0, "Удалённое бслуживание техники без выезда на место", 0.0, 0.0, "Удалённое сопровождение вычислительно техники" },
                    { 5, 0.0, "Удалённая установка. При необходимости выезд к клиенту и установка на месте.", 0.0, 0.0, "Установка ГРС" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCost",
                columns: new[] { "Id", "AdditionalCost", "MainCost", "Month", "More5Cost", "ServiceTypeId", "Year" },
                values: new object[,]
                {
                    { 1, 19.800000000000001, 39.600000000000001, 0, 14.76, 1, 2021 },
                    { 2, 19.800000000000001, 39.600000000000001, 0, 14.76, 2, 2021 },
                    { 3, 52.799999999999997, 24.0, 0, 0.0, 3, 2021 },
                    { 4, 14.4, 19.199999999999999, 0, 0.0, 4, 2021 },
                    { 5, 21.48, 50.399999999999999, 0, 0.0, 5, 2021 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCost_ServiceTypeId",
                table: "ServiceCost",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHardwares_ServiceType_ServiceTypeId",
                table: "ServiceHardwares",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSoftwares_ServiceType_ServiceTypeId",
                table: "ServiceSoftwares",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHardwares_ServiceType_ServiceTypeId",
                table: "ServiceHardwares");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSoftwares_ServiceType_ServiceTypeId",
                table: "ServiceSoftwares");

            migrationBuilder.DropTable(
                name: "ServiceCost");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceSoftwares",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceSoftwares_ServiceTypeId",
                table: "ServiceSoftwares",
                newName: "IX_ServiceSoftwares_ServiceInfoId");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceHardwares",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceHardwares_ServiceTypeId",
                table: "ServiceHardwares",
                newName: "IX_ServiceHardwares_ServiceInfoId");

            migrationBuilder.CreateTable(
                name: "ServiceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalCost = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCost = table.Column<double>(type: "float", nullable: false),
                    More5Cost = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ServiceInfo",
                columns: new[] { "Id", "AdditionalCost", "Description", "MainCost", "More5Cost", "Name" },
                values: new object[,]
                {
                    { 1, 19.800000000000001, "Консультации, удалённая поддержка. При необходимости выезд к клиенту", 39.600000000000001, 14.76, "Обслуживание КлиентТК" },
                    { 2, 19.800000000000001, "Консультации, удалённая поддержка. При необходимости выезд к клиенту.", 39.600000000000001, 14.76, "Обслуживание ГРС" },
                    { 3, 52.799999999999997, "Обслуживание техники. Ежемесечная проверка с диагностикой на месте эксплуатации.", 24.0, 0.0, "Сопровождение вычислительно техники" },
                    { 4, 14.4, "Удалённое бслуживание техники без выезда на место", 19.199999999999999, 0.0, "Удалённое сопровождение вычислительно техники" },
                    { 5, 21.48, "Удалённая установка. При необходимости выезд к клиенту и установка на месте.", 50.399999999999999, 0.0, "Установка ГРС" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHardwares_ServiceInfo_ServiceInfoId",
                table: "ServiceHardwares",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSoftwares_ServiceInfo_ServiceInfoId",
                table: "ServiceSoftwares",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

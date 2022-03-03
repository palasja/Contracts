using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreateDBandaddServiceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SimpleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInfo",
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
                    table.PrimaryKey("PK_ServiceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNP = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smdo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHardwares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerCount = table.Column<int>(type: "int", nullable: false),
                    WorkplaceCount = table.Column<int>(type: "int", nullable: false),
                    ServiceInfoId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHardwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHardwares_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHardwares_ServiceInfo_ServiceInfoId",
                        column: x => x.ServiceInfoId,
                        principalTable: "ServiceInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSoftwares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainPlaceCount = table.Column<int>(type: "int", nullable: false),
                    AdditionalPlaceCount = table.Column<int>(type: "int", nullable: false),
                    ServiceInfoId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSoftwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSoftwares_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSoftwares_ServiceInfo_ServiceInfoId",
                        column: x => x.ServiceInfoId,
                        principalTable: "ServiceInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_OrganizationId",
                table: "Contracts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AreaId",
                table: "Organizations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UNP",
                table: "Organizations",
                column: "UNP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_OrganizationId",
                table: "People",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHardwares_ContractId",
                table: "ServiceHardwares",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHardwares_ServiceInfoId",
                table: "ServiceHardwares",
                column: "ServiceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSoftwares_ContractId",
                table: "ServiceSoftwares",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSoftwares_ServiceInfoId",
                table: "ServiceSoftwares",
                column: "ServiceInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "ServiceHardwares");

            migrationBuilder.DropTable(
                name: "ServiceSoftwares");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ServiceInfo");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}

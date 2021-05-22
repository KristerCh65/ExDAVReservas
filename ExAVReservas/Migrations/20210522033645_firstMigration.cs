using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExAVReservas.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientModels",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientModels", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "eventModels",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventModels", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "reservationModels",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationModels", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_reservationModels_clientModels_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "clientModels",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservationModels_eventModels_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "eventModels",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservationDetails",
                columns: table => new
                {
                    IdDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReseration = table.Column<int>(type: "int", nullable: false),
                    IdReservation = table.Column<int>(type: "int", nullable: true),
                    IdFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationDetails", x => x.IdDetail);
                    table.ForeignKey(
                        name: "FK_reservationDetails_reservationModels_IdReservation",
                        column: x => x.IdReservation,
                        principalTable: "reservationModels",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "furnitureModels",
                columns: table => new
                {
                    IdFurniture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ReservationDetailIdDetail = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furnitureModels", x => x.IdFurniture);
                    table.ForeignKey(
                        name: "FK_furnitureModels_reservationDetails_ReservationDetailIdDetail",
                        column: x => x.ReservationDetailIdDetail,
                        principalTable: "reservationDetails",
                        principalColumn: "IdDetail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_furnitureModels_ReservationDetailIdDetail",
                table: "furnitureModels",
                column: "ReservationDetailIdDetail");

            migrationBuilder.CreateIndex(
                name: "IX_reservationDetails_IdFurniture",
                table: "reservationDetails",
                column: "IdFurniture");

            migrationBuilder.CreateIndex(
                name: "IX_reservationDetails_IdReservation",
                table: "reservationDetails",
                column: "IdReservation");

            migrationBuilder.CreateIndex(
                name: "IX_reservationModels_IdCliente",
                table: "reservationModels",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_reservationModels_IdEvent",
                table: "reservationModels",
                column: "IdEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDetails_furnitureModels_IdFurniture",
                table: "reservationDetails",
                column: "IdFurniture",
                principalTable: "furnitureModels",
                principalColumn: "IdFurniture",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_furnitureModels_reservationDetails_ReservationDetailIdDetail",
                table: "furnitureModels");

            migrationBuilder.DropTable(
                name: "reservationDetails");

            migrationBuilder.DropTable(
                name: "furnitureModels");

            migrationBuilder.DropTable(
                name: "reservationModels");

            migrationBuilder.DropTable(
                name: "clientModels");

            migrationBuilder.DropTable(
                name: "eventModels");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using Lab.Models;

namespace Lab.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Rut = table.Column<string>(nullable: false),
                    Materno = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Paterno = table.Column<string>(nullable: true),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Rut);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Monto = table.Column<string>(nullable: true),
                    NombreCliente = table.Column<string>(nullable: true),
                    RUT = table.Column<string>(nullable: true),
                    fechaCreacion = table.Column<DateTime>(nullable: false),
                    fechaRevision = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Personas_RUT",
                        column: x => x.RUT,
                        principalTable: "Personas",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_RUT",
                table: "Cotizaciones",
                column: "RUT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}

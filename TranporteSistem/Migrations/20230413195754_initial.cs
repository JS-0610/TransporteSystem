using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranporteSistem.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Colaborador_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Colaborador_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    Sucursal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.Sucursal_Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportista",
                columns: table => new
                {
                    Transportista_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarifa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportista", x => x.Transportista_Id);
                });

            migrationBuilder.CreateTable(
                name: "SucursalColaborador",
                columns: table => new
                {
                    SucursalColaborador_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colaborador_Id = table.Column<int>(type: "int", nullable: false),
                    Sucursal_Id = table.Column<int>(type: "int", nullable: false),
                    Distancia = table.Column<double>(type: "float", nullable: false),
                    Colaborador_Id1 = table.Column<int>(type: "int", nullable: true),
                    Sucursal_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalColaborador", x => x.SucursalColaborador_Id);
                    table.ForeignKey(
                        name: "FK_SucursalColaborador_Colaborador_Colaborador_Id1",
                        column: x => x.Colaborador_Id1,
                        principalTable: "Colaborador",
                        principalColumn: "Colaborador_Id");
                    table.ForeignKey(
                        name: "FK_SucursalColaborador_Sucursal_Sucursal_Id1",
                        column: x => x.Sucursal_Id1,
                        principalTable: "Sucursal",
                        principalColumn: "Sucursal_Id");
                });

            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    Viaje_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transportista_Id = table.Column<int>(type: "int", nullable: false),
                    Sucursal_Id = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Sucursal_Id1 = table.Column<int>(type: "int", nullable: true),
                    Transportista_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.Viaje_Id);
                    table.ForeignKey(
                        name: "FK_Viaje_Sucursal_Sucursal_Id1",
                        column: x => x.Sucursal_Id1,
                        principalTable: "Sucursal",
                        principalColumn: "Sucursal_Id");
                    table.ForeignKey(
                        name: "FK_Viaje_Transportista_Transportista_Id1",
                        column: x => x.Transportista_Id1,
                        principalTable: "Transportista",
                        principalColumn: "Transportista_Id");
                });

            migrationBuilder.CreateTable(
                name: "ViajeDetalle",
                columns: table => new
                {
                    ViajeDetalle_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Viaje_Id = table.Column<int>(type: "int", nullable: false),
                    SucursalColaborador_Id = table.Column<int>(type: "int", nullable: false),
                    Viaje_Id1 = table.Column<int>(type: "int", nullable: true),
                    SucursalColaborador_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajeDetalle", x => x.ViajeDetalle_Id);
                    table.ForeignKey(
                        name: "FK_ViajeDetalle_SucursalColaborador_SucursalColaborador_Id1",
                        column: x => x.SucursalColaborador_Id1,
                        principalTable: "SucursalColaborador",
                        principalColumn: "SucursalColaborador_Id");
                    table.ForeignKey(
                        name: "FK_ViajeDetalle_Viaje_Viaje_Id1",
                        column: x => x.Viaje_Id1,
                        principalTable: "Viaje",
                        principalColumn: "Viaje_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SucursalColaborador_Colaborador_Id1",
                table: "SucursalColaborador",
                column: "Colaborador_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalColaborador_Sucursal_Id1",
                table: "SucursalColaborador",
                column: "Sucursal_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Sucursal_Id1",
                table: "Viaje",
                column: "Sucursal_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Transportista_Id1",
                table: "Viaje",
                column: "Transportista_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDetalle_SucursalColaborador_Id1",
                table: "ViajeDetalle",
                column: "SucursalColaborador_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDetalle_Viaje_Id1",
                table: "ViajeDetalle",
                column: "Viaje_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViajeDetalle");

            migrationBuilder.DropTable(
                name: "SucursalColaborador");

            migrationBuilder.DropTable(
                name: "Viaje");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Transportista");
        }
    }
}

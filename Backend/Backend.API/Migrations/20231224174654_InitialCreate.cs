using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaActual = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NombreUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.NombreUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cosas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaActual = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cosas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaRetorno = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    IdCosa = table.Column<int>(type: "int", nullable: false),
                    PersonaDni = table.Column<int>(type: "int", nullable: false),
                    CosaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Cosas_CosaId",
                        column: x => x.CosaId,
                        principalTable: "Cosas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Personas_PersonaDni",
                        column: x => x.PersonaDni,
                        principalTable: "Personas",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "NombreUsuario", "Clave" },
                values: new object[] { "Admin", "1234" });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Descripcion",
                table: "Categorias",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cosas_CategoriaId",
                table: "Cosas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cosas_Descripcion",
                table: "Cosas",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CosaId",
                table: "Prestamos",
                column: "CosaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_PersonaDni",
                table: "Prestamos",
                column: "PersonaDni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cosas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}

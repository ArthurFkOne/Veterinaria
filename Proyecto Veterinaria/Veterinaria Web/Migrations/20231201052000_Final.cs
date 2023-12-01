using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria_Web.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturaProducto_Producto_PkProducto",
                table: "FacturaProducto");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto");

            migrationBuilder.DropIndex(
                name: "IX_FacturaProducto_PkProducto",
                table: "FacturaProducto");

            migrationBuilder.RenameColumn(
                name: "PkProducto",
                table: "FacturaProducto",
                newName: "PkArticulo");

            migrationBuilder.AddColumn<string>(
                name: "Total",
                table: "Facturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto",
                columns: new[] { "PkArticulo", "PkFactura" });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    PKArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    UrlImagenPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.PKArticulo);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    PKPromocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlImagenPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkArticulo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.PKPromocion);
                    table.ForeignKey(
                        name: "FK_Promocion_Articulo_FkArticulo",
                        column: x => x.FkArticulo,
                        principalTable: "Articulo",
                        principalColumn: "PKArticulo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaProducto_PkFactura",
                table: "FacturaProducto",
                column: "PkFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Promocion_FkArticulo",
                table: "Promocion",
                column: "FkArticulo");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaProducto_Articulo_PkArticulo",
                table: "FacturaProducto",
                column: "PkArticulo",
                principalTable: "Articulo",
                principalColumn: "PKArticulo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturaProducto_Articulo_PkArticulo",
                table: "FacturaProducto");

            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto");

            migrationBuilder.DropIndex(
                name: "IX_FacturaProducto_PkFactura",
                table: "FacturaProducto");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Facturas");

            migrationBuilder.RenameColumn(
                name: "PkArticulo",
                table: "FacturaProducto",
                newName: "PkProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto",
                columns: new[] { "PkFactura", "PkProducto" });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    PkProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.PkProducto);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaProducto_PkProducto",
                table: "FacturaProducto",
                column: "PkProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaProducto_Producto_PkProducto",
                table: "FacturaProducto",
                column: "PkProducto",
                principalTable: "Producto",
                principalColumn: "PkProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

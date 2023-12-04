using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria_Web.Migrations
{
    /// <inheritdoc />
    public partial class ffinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hora",
                table: "Cita",
                newName: "Nombreanimal");

            migrationBuilder.AlterColumn<long>(
                name: "Numero",
                table: "Cita",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Animal",
                table: "Cita",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Animal",
                table: "Cita");

            migrationBuilder.RenameColumn(
                name: "Nombreanimal",
                table: "Cita",
                newName: "Hora");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Cita",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}

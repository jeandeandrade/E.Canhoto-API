using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E.CanhotoAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovidoocamposobrenomenatabelaUserseocampoNomenatabelaLefthanded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "LeftHanded");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "LeftHanded",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}

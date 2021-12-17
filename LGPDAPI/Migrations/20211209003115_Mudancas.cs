using Microsoft.EntityFrameworkCore.Migrations;

namespace LGPD.Migrations
{
    public partial class Mudancas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Processos",
                newName: "Macroprocesso");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Processos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Processos");

            migrationBuilder.RenameColumn(
                name: "Macroprocesso",
                table: "Processos",
                newName: "Nome");
        }
    }
}

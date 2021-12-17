using Microsoft.EntityFrameworkCore.Migrations;

namespace LGPD.Migrations
{
    public partial class LGPD_subprocesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Subprocesso_Subprocessoid_subprocesso",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subprocesso",
                table: "Subprocesso");

            migrationBuilder.RenameTable(
                name: "Subprocesso",
                newName: "Subprocessos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subprocessos",
                table: "Subprocessos",
                column: "id_subprocesso");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Subprocessos_Subprocessoid_subprocesso",
                table: "Processos",
                column: "Subprocessoid_subprocesso",
                principalTable: "Subprocessos",
                principalColumn: "id_subprocesso",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Subprocessos_Subprocessoid_subprocesso",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subprocessos",
                table: "Subprocessos");

            migrationBuilder.RenameTable(
                name: "Subprocessos",
                newName: "Subprocesso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subprocesso",
                table: "Subprocesso",
                column: "id_subprocesso");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Subprocesso_Subprocessoid_subprocesso",
                table: "Processos",
                column: "Subprocessoid_subprocesso",
                principalTable: "Subprocesso",
                principalColumn: "id_subprocesso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

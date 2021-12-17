using Microsoft.EntityFrameworkCore.Migrations;

namespace LGPD.Migrations
{
    public partial class remove_Leis_Subprocesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Leis_LeisId_lei",
                table: "Processos");

            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Subprocessos_Subprocessoid_subprocesso",
                table: "Processos");

            migrationBuilder.DropTable(
                name: "Subprocessos");

            migrationBuilder.DropIndex(
                name: "IX_Processos_LeisId_lei",
                table: "Processos");

            migrationBuilder.DropIndex(
                name: "IX_Processos_Subprocessoid_subprocesso",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "LeisId_lei",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "Subprocessoid_subprocesso",
                table: "Processos");

            migrationBuilder.AddColumn<string>(
                name: "BaseLegal",
                table: "Processos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subprocesso",
                table: "Processos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descricaoBase",
                table: "Processos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseLegal",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "Subprocesso",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "descricaoBase",
                table: "Processos");

            migrationBuilder.AddColumn<int>(
                name: "LeisId_lei",
                table: "Processos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Subprocessoid_subprocesso",
                table: "Processos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subprocessos",
                columns: table => new
                {
                    id_subprocesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subprocessos", x => x.id_subprocesso);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processos_LeisId_lei",
                table: "Processos",
                column: "LeisId_lei");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_Subprocessoid_subprocesso",
                table: "Processos",
                column: "Subprocessoid_subprocesso");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Leis_LeisId_lei",
                table: "Processos",
                column: "LeisId_lei",
                principalTable: "Leis",
                principalColumn: "Id_lei",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Subprocessos_Subprocessoid_subprocesso",
                table: "Processos",
                column: "Subprocessoid_subprocesso",
                principalTable: "Subprocessos",
                principalColumn: "id_subprocesso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace LGPD.Migrations
{
    public partial class remove_Leis_Subprocesso2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leis",
                columns: table => new
                {
                    Id_lei = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricaoBase = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leis", x => x.Id_lei);
                });
        }
    }
}

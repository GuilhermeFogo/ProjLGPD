using Microsoft.EntityFrameworkCore.Migrations;

namespace LGPD.Migrations
{
    public partial class LGPD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dados",
                columns: table => new
                {
                    id_dado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dados_regulares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dados_Senssiveis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dados", x => x.id_dado);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Subprocesso",
                columns: table => new
                {
                    id_subprocesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subprocesso", x => x.id_subprocesso);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consentimento = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subprocessoid_subprocesso = table.Column<int>(type: "int", nullable: true),
                    Descricao_processo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dadoid_dado = table.Column<int>(type: "int", nullable: true),
                    LeisId_lei = table.Column<int>(type: "int", nullable: true),
                    Compartilhamento_interno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compartilhamento_Externo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destino_final = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controlador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Armazenamento_Fisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Armazenamento_Digital = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_Dados_Dadoid_dado",
                        column: x => x.Dadoid_dado,
                        principalTable: "Dados",
                        principalColumn: "id_dado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Processos_Leis_LeisId_lei",
                        column: x => x.LeisId_lei,
                        principalTable: "Leis",
                        principalColumn: "Id_lei",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Processos_Subprocesso_Subprocessoid_subprocesso",
                        column: x => x.Subprocessoid_subprocesso,
                        principalTable: "Subprocesso",
                        principalColumn: "id_subprocesso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_Dadoid_dado",
                table: "Processos",
                column: "Dadoid_dado");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_LeisId_lei",
                table: "Processos",
                column: "LeisId_lei");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_Subprocessoid_subprocesso",
                table: "Processos",
                column: "Subprocessoid_subprocesso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Dados");

            migrationBuilder.DropTable(
                name: "Leis");

            migrationBuilder.DropTable(
                name: "Subprocesso");
        }
    }
}

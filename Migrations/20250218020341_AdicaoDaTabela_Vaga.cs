using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDoSaber.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDaTabela_Vaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_carreiras",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModoTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncerramentoVaga = table.Column<DateOnly>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsabilidades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitosQualificacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adicionais = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_carreiras", x => x.Codigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_carreiras");
        }
    }
}

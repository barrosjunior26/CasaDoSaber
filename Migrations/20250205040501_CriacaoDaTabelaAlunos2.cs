using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDoSaber.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDaTabelaAlunos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel");

            migrationBuilder.RenameTable(
                name: "UsuarioModel",
                newName: "tb_usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tb_alunos",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtMatricula = table.Column<DateOnly>(type: "date", nullable: false),
                    Portugues = table.Column<double>(type: "float", nullable: true),
                    Matematica = table.Column<double>(type: "float", nullable: true),
                    Ciencias = table.Column<double>(type: "float", nullable: true),
                    Estrangeira = table.Column<double>(type: "float", nullable: true),
                    Geografia = table.Column<double>(type: "float", nullable: true),
                    MediaGeral = table.Column<double>(type: "float", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alunos", x => x.Matricula);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios");

            migrationBuilder.RenameTable(
                name: "tb_usuarios",
                newName: "UsuarioModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel",
                column: "Id");
        }
    }
}

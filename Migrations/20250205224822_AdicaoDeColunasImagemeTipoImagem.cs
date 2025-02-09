using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDoSaber.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDeColunasImagemeTipoImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoImagem",
                table: "tb_alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "imagemAluno",
                table: "tb_alunos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoImagem",
                table: "tb_alunos");

            migrationBuilder.DropColumn(
                name: "imagemAluno",
                table: "tb_alunos");
        }
    }
}

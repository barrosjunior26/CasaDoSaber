using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDoSaber.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDaTabelaAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios");

            migrationBuilder.RenameTable(
                name: "tb_usuarios",
                newName: "UsuarioModel");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagemFuncionario",
                table: "UsuarioModel",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel");

            migrationBuilder.RenameTable(
                name: "UsuarioModel",
                newName: "tb_usuarios");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagemFuncionario",
                table: "tb_usuarios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios",
                column: "Id");
        }
    }
}

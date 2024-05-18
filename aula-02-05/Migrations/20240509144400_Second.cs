using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula_02_05.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto_De_Perfil",
                table: "Tabela_usuario",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Usuario_Ativo",
                table: "Tabela_usuario",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto_De_Perfil",
                table: "Tabela_usuario");

            migrationBuilder.DropColumn(
                name: "Usuario_Ativo",
                table: "Tabela_usuario");
        }
    }
}

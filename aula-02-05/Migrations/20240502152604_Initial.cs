using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula_02_05.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabela_Jogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo_Do_Jogo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Desenvolvedor_Do_Jogo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_De_Publicacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Genero_Do_Jogo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Plataforma_Do_Jogo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Jogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_De_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nick = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Hash_da_senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Do_Registro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    JogoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Classificacao_Do_Jogo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Conteudo_Da_Avaliacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_De_Postagem = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabela_Avaliacao_Tabela_Jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Tabela_Jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tabela_Avaliacao_Tabela_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Tabela_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_De_Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    useId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UseId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AvaliationId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    JogoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Jogo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Texto_Do_Comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_De_Postagem = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DtComentario = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_De_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabela_De_Comentario_Tabela_Avaliacao_AvaliationId",
                        column: x => x.AvaliationId,
                        principalTable: "Tabela_Avaliacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tabela_De_Comentario_Tabela_Jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Tabela_Jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tabela_De_Comentario_Tabela_usuario_UseId",
                        column: x => x.UseId,
                        principalTable: "Tabela_usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_Avaliacao_JogoId",
                table: "Tabela_Avaliacao",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_Avaliacao_UserId",
                table: "Tabela_Avaliacao",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_De_Comentario_AvaliationId",
                table: "Tabela_De_Comentario",
                column: "AvaliationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_De_Comentario_JogoId",
                table: "Tabela_De_Comentario",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_De_Comentario_UseId",
                table: "Tabela_De_Comentario",
                column: "UseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabela_De_Comentario");

            migrationBuilder.DropTable(
                name: "Tabela_Avaliacao");

            migrationBuilder.DropTable(
                name: "Tabela_Jogo");

            migrationBuilder.DropTable(
                name: "Tabela_usuario");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlus_.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationEventosPlus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    InstituicaoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.InstituicaoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    TipoEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.TipoEventoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    TipoUsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.TipoUsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEvento = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    TipoEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituicaoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventosID);
                    table.ForeignKey(
                        name: "FK_Eventos_Instituicao_InstituicaoID",
                        column: x => x.InstituicaoID,
                        principalTable: "Instituicao",
                        principalColumn: "InstituicaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_TipoEvento_TipoEventoID",
                        column: x => x.TipoEventoID,
                        principalTable: "TipoEvento",
                        principalColumn: "TipoEventoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TipoUsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioID",
                        column: x => x.TipoUsuarioID,
                        principalTable: "TipoUsuario",
                        principalColumn: "TipoUsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioEvento",
                columns: table => new
                {
                    ComentarioEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEvento", x => x.ComentarioEventoID);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Eventos_EventosID",
                        column: x => x.EventosID,
                        principalTable: "Eventos",
                        principalColumn: "EventosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    PresencaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: true),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.PresencaID);
                    table.ForeignKey(
                        name: "FK_Presenca_Eventos_EventosID",
                        column: x => x.EventosID,
                        principalTable: "Eventos",
                        principalColumn: "EventosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_EventosID",
                table: "ComentarioEvento",
                column: "EventosID");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_UsuarioID",
                table: "ComentarioEvento",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_InstituicaoID",
                table: "Eventos",
                column: "InstituicaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoID",
                table: "Eventos",
                column: "TipoEventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_Cnpj",
                table: "Instituicao",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_EventosID",
                table: "Presenca",
                column: "EventosID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_UsuarioID",
                table: "Presenca",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioID",
                table: "Usuario",
                column: "TipoUsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEvento");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}

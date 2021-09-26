using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MATC84.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seminario",
                columns: table => new
                {
                    SeminarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tema = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: true),
                    QtdPessoas = table.Column<int>(type: "INTEGER", nullable: true),
                    Nota = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminario", x => x.SeminarioId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: true),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    Semestre = table.Column<int>(type: "INTEGER", nullable: true),
                    SeminarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                    table.UniqueConstraint("AK_Pessoa_Matricula", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Pessoa_Seminario_SeminarioId",
                        column: x => x.SeminarioId,
                        principalTable: "Seminario",
                        principalColumn: "SeminarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_SeminarioId",
                table: "Pessoa",
                column: "SeminarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Seminario");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infra.Data.Migrations
{
    public partial class script1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Matricula = table.Column<string>(maxLength: 20, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TurmaAluno",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    AlunoId = table.Column<string>(maxLength: 36, nullable: true),
                    TurmaId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplinas",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    DisciplinaId = table.Column<string>(maxLength: 36, nullable: true),
                    TurmaId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Id",
                table: "Alunos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_Id",
                table: "Disciplinas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAluno_AlunoId",
                table: "TurmaAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAluno_Id",
                table: "TurmaAluno",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAluno_TurmaId",
                table: "TurmaAluno",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinas_DisciplinaId",
                table: "TurmaDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinas_Id",
                table: "TurmaDisciplinas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinas_TurmaId",
                table: "TurmaDisciplinas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_Id",
                table: "Turmas",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurmaAluno");

            migrationBuilder.DropTable(
                name: "TurmaDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}

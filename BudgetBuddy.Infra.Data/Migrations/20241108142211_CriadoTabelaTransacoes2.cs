using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriadoTabelaTransacoes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdContaBancaria = table.Column<int>(type: "int", nullable: false),
                    IdSubcategoriaTransacao = table.Column<int>(type: "int", nullable: false),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: true),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transacoes_contas_bancarias_IdContaBancaria",
                        column: x => x.IdContaBancaria,
                        principalTable: "contas_bancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transacoes_subcategoria_transacoes_IdSubcategoriaTransacao",
                        column: x => x.IdSubcategoriaTransacao,
                        principalTable: "subcategoria_transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_IdContaBancaria",
                table: "transacoes",
                column: "IdContaBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_IdSubcategoriaTransacao",
                table: "transacoes",
                column: "IdSubcategoriaTransacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transacoes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriadoBancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria_contas_bancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_contas_bancarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoria_transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_transacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contas_bancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contas_bancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contas_bancarias_categoria_contas_bancarias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "categoria_contas_bancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subcategoria_transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CategoriaTransacaoId = table.Column<int>(type: "int", nullable: false),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategoria_transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subcategoria_transacoes_categoria_transacoes_CategoriaTransacaoId",
                        column: x => x.CategoriaTransacaoId,
                        principalTable: "categoria_transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cartoes_credito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DigBandeira = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiaFechamento = table.Column<int>(type: "int", nullable: false),
                    DiaVencimento = table.Column<int>(type: "int", nullable: false),
                    IdContaVinculada = table.Column<int>(type: "int", nullable: true),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartoes_credito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartoes_credito_contas_bancarias_IdContaVinculada",
                        column: x => x.IdContaVinculada,
                        principalTable: "contas_bancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartoes_credito_IdContaVinculada",
                table: "cartoes_credito",
                column: "IdContaVinculada");

            migrationBuilder.CreateIndex(
                name: "IX_contas_bancarias_IdCategoria",
                table: "contas_bancarias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_subcategoria_transacoes_CategoriaTransacaoId",
                table: "subcategoria_transacoes",
                column: "CategoriaTransacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartoes_credito");

            migrationBuilder.DropTable(
                name: "subcategoria_transacoes");

            migrationBuilder.DropTable(
                name: "contas_bancarias");

            migrationBuilder.DropTable(
                name: "categoria_transacoes");

            migrationBuilder.DropTable(
                name: "categoria_contas_bancarias");
        }
    }
}

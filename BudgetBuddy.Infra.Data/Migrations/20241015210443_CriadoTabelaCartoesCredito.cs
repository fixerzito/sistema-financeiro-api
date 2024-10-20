using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriadoTabelaCartoesCredito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IdContaVinculada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartoes_credito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartoes_credito_contas_bancarias_IdContaVinculada",
                        column: x => x.IdContaVinculada,
                        principalTable: "contas_bancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartoes_credito_IdContaVinculada",
                table: "cartoes_credito",
                column: "IdContaVinculada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartoes_credito");
        }
    }
}

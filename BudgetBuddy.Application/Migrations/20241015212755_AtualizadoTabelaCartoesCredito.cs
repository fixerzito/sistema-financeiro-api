using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Application.Migrations
{
    /// <inheritdoc />
    public partial class AtualizadoTabelaCartoesCredito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartoes_credito_contas_bancarias_IdContaVinculada",
                table: "cartoes_credito");

            migrationBuilder.AlterColumn<int>(
                name: "IdContaVinculada",
                table: "cartoes_credito",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_cartoes_credito_contas_bancarias_IdContaVinculada",
                table: "cartoes_credito",
                column: "IdContaVinculada",
                principalTable: "contas_bancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartoes_credito_contas_bancarias_IdContaVinculada",
                table: "cartoes_credito");

            migrationBuilder.AlterColumn<int>(
                name: "IdContaVinculada",
                table: "cartoes_credito",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cartoes_credito_contas_bancarias_IdContaVinculada",
                table: "cartoes_credito",
                column: "IdContaVinculada",
                principalTable: "contas_bancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

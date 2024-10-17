using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSistemaFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarBancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subcategoria_transacoes_categoria_transacoes_IdCategoria",
                table: "subcategoria_transacoes");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "subcategoria_transacoes",
                newName: "Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_subcategoria_transacoes_IdCategoria",
                table: "subcategoria_transacoes",
                newName: "IX_subcategoria_transacoes_Categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_subcategoria_transacoes_categoria_transacoes_Categoria",
                table: "subcategoria_transacoes",
                column: "Categoria",
                principalTable: "categoria_transacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subcategoria_transacoes_categoria_transacoes_Categoria",
                table: "subcategoria_transacoes");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "subcategoria_transacoes",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_subcategoria_transacoes_Categoria",
                table: "subcategoria_transacoes",
                newName: "IX_subcategoria_transacoes_IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_subcategoria_transacoes_categoria_transacoes_IdCategoria",
                table: "subcategoria_transacoes",
                column: "IdCategoria",
                principalTable: "categoria_transacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

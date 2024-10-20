using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriadoTabelaSubcategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subcategoria_transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategoria_transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subcategoria_transacoes_categoria_transacoes_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "categoria_transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subcategoria_transacoes_IdCategoria",
                table: "subcategoria_transacoes",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subcategoria_transacoes");
        }
    }
}

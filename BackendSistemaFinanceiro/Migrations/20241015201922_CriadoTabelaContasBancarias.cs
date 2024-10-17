using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSistemaFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class CriadoTabelaContasBancarias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contas_bancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_contas_bancarias_IdCategoria",
                table: "contas_bancarias",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contas_bancarias");
        }
    }
}

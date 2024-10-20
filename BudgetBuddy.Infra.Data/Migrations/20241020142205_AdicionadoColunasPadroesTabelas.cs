using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoColunasPadroesTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "subcategoria_transacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_hora_criacao",
                table: "subcategoria_transacoes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "registro_ativo",
                table: "subcategoria_transacoes",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "contas_bancarias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_hora_criacao",
                table: "contas_bancarias",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "registro_ativo",
                table: "contas_bancarias",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "categoria_transacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_hora_criacao",
                table: "categoria_transacoes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "registro_ativo",
                table: "categoria_transacoes",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "categoria_contas_bancarias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_hora_criacao",
                table: "categoria_contas_bancarias",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "registro_ativo",
                table: "categoria_contas_bancarias",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "cartoes_credito",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_hora_criacao",
                table: "cartoes_credito",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "registro_ativo",
                table: "cartoes_credito",
                type: "BIT",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "subcategoria_transacoes");

            migrationBuilder.DropColumn(
                name: "data_hora_criacao",
                table: "subcategoria_transacoes");

            migrationBuilder.DropColumn(
                name: "registro_ativo",
                table: "subcategoria_transacoes");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "contas_bancarias");

            migrationBuilder.DropColumn(
                name: "data_hora_criacao",
                table: "contas_bancarias");

            migrationBuilder.DropColumn(
                name: "registro_ativo",
                table: "contas_bancarias");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "categoria_transacoes");

            migrationBuilder.DropColumn(
                name: "data_hora_criacao",
                table: "categoria_transacoes");

            migrationBuilder.DropColumn(
                name: "registro_ativo",
                table: "categoria_transacoes");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "categoria_contas_bancarias");

            migrationBuilder.DropColumn(
                name: "data_hora_criacao",
                table: "categoria_contas_bancarias");

            migrationBuilder.DropColumn(
                name: "registro_ativo",
                table: "categoria_contas_bancarias");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "cartoes_credito");

            migrationBuilder.DropColumn(
                name: "data_hora_criacao",
                table: "cartoes_credito");

            migrationBuilder.DropColumn(
                name: "registro_ativo",
                table: "cartoes_credito");
        }
    }
}

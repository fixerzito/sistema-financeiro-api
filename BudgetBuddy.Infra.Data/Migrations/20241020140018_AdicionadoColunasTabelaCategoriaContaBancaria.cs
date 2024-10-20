using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoColunasTabelaCategoriaContaBancaria : Migration
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
                name: "DataHoraCriacao",
                table: "subcategoria_transacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RegistroAtivo",
                table: "subcategoria_transacoes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "contas_bancarias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "contas_bancarias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RegistroAtivo",
                table: "contas_bancarias",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "categoria_transacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "categoria_transacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RegistroAtivo",
                table: "categoria_transacoes",
                type: "bit",
                nullable: true);

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
                defaultValue: new DateTime(2024, 10, 20, 11, 0, 18, 467, DateTimeKind.Local).AddTicks(5159));

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
                name: "DataHoraCriacao",
                table: "cartoes_credito",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RegistroAtivo",
                table: "cartoes_credito",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "subcategoria_transacoes");

            migrationBuilder.DropColumn(
                name: "DataHoraCriacao",
                table: "subcategoria_transacoes");

            migrationBuilder.DropColumn(
                name: "RegistroAtivo",
                table: "subcategoria_transacoes");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "contas_bancarias");

            migrationBuilder.DropColumn(
                name: "DataHoraCriacao",
                table: "contas_bancarias");

            migrationBuilder.DropColumn(
                name: "RegistroAtivo",
                table: "contas_bancarias");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "categoria_transacoes");

            migrationBuilder.DropColumn(
                name: "DataHoraCriacao",
                table: "categoria_transacoes");

            migrationBuilder.DropColumn(
                name: "RegistroAtivo",
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
                name: "DataHoraCriacao",
                table: "cartoes_credito");

            migrationBuilder.DropColumn(
                name: "RegistroAtivo",
                table: "cartoes_credito");
        }
    }
}

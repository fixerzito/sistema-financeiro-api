using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoBD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categoria_contas_bancarias",
                columns: new[] { "Id", "CriadoPor", "data_hora_criacao", "Nome", "registro_ativo" },
                values: new object[,]
                {
                    { 100, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5582), "Conta Corrente", true },
                    { 101, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5598), "Conta Poupança", true },
                    { 102, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5600), "Conta Salário", true },
                    { 103, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5603), "Conta de Investimentos", true },
                    { 104, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5606), "Conta de Reserva", true },
                    { 105, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5611), "Conta Conjunta", true },
                    { 106, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5612), "Conta Jurídica", true },
                    { 107, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5614), "Conta Digital", true },
                    { 108, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5617), "Conta de Depósito", true },
                    { 109, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5619), "Conta de Pagamento", true },
                    { 110, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5621), "Conta de Investimento Imobiliário", true },
                    { 111, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5623), "Conta de Previdência", true },
                    { 112, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5626), "Conta de Fomento", true },
                    { 113, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5628), "Conta de Pagamento Eletrônico", true },
                    { 114, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5631), "Conta Universitária", true },
                    { 115, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5632), "Conta Infantil", true },
                    { 116, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5636), "Conta de Crédito", true },
                    { 117, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5637), "Conta de Empréstimo", true },
                    { 118, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5639), "Conta de Transferência", true },
                    { 119, null, new DateTime(2024, 11, 20, 20, 37, 24, 679, DateTimeKind.Local).AddTicks(5641), "Conta com Investimento Automático", true }
                });

            migrationBuilder.InsertData(
                table: "categoria_transacoes",
                columns: new[] { "Id", "CriadoPor", "data_hora_criacao", "Nome", "registro_ativo" },
                values: new object[,]
                {
                    { 100, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6097), "Transporte", true },
                    { 101, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6112), "Saúde", true },
                    { 102, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6114), "Laser", true },
                    { 103, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6116), "Impostos", true },
                    { 104, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6118), "Rendimentos", true },
                    { 105, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6119), "Serviços", true },
                    { 106, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6127), "Viagens", true },
                    { 107, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6131), "Emergências", true },
                    { 108, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6133), "Alimentação", true },
                    { 109, null, new DateTime(2024, 11, 20, 20, 37, 24, 674, DateTimeKind.Local).AddTicks(6136), "Jogos", true }
                });

            migrationBuilder.InsertData(
                table: "contas_bancarias",
                columns: new[] { "Id", "CriadoPor", "data_hora_criacao", "Icon", "IdCategoria", "Nome", "registro_ativo", "Saldo" },
                values: new object[,]
                {
                    { 150, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6160), "pi pi-wallet", 100, "Conta Corrente Banco A", true, 5000.00m },
                    { 151, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6174), "pi pi-money-bill", 101, "Conta Poupança Banco B", true, 2000.00m },
                    { 152, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6176), "pi pi-chart-line", 102, "Conta Salário Banco C", true, 3000.00m },
                    { 153, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6179), "pi pi-briefcase", 103, "Conta de Investimentos Banco D", true, 15000.00m },
                    { 154, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6182), "pi pi-check", 104, "Conta de Reserva Banco E", true, 8000.00m },
                    { 155, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6186), "pi pi-times", 105, "Conta Conjunta Banco F", true, 12000.00m },
                    { 156, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6188), "pi pi-user", 106, "Conta Jurídica Banco G", true, 25000.00m },
                    { 157, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6191), "pi pi-home", 107, "Conta Digital Banco H", true, 4000.00m },
                    { 158, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6195), "pi pi-credit-card", 108, "Conta de Depósito Banco I", true, 7000.00m },
                    { 159, null, new DateTime(2024, 11, 20, 20, 37, 24, 680, DateTimeKind.Local).AddTicks(6198), "pi pi-wallet", 109, "Conta de Pagamento Banco J", true, 6000.00m }
                });

            migrationBuilder.InsertData(
                table: "subcategoria_transacoes",
                columns: new[] { "Id", "CategoriaTransacaoId", "CriadoPor", "data_hora_criacao", "Nome", "registro_ativo" },
                values: new object[,]
                {
                    { 100, 100, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9876), "Transporte Público", true },
                    { 101, 100, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9891), "Combustível", true },
                    { 102, 100, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9893), "Manutenção do Carro", true },
                    { 103, 101, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9898), "Plano de Saúde", true },
                    { 104, 101, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9899), "Medicamentos", true },
                    { 105, 101, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9902), "Consultas Médicas", true },
                    { 106, 101, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9905), "Tratamentos Estéticos", true },
                    { 107, 101, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9907), "Cortes de Cabelo", true },
                    { 108, 102, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9910), "Tratamentos Laser", true },
                    { 109, 102, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9912), "Equipamentos de Laser", true },
                    { 110, 103, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9914), "Impostos Municipais", true },
                    { 111, 103, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9916), "Impostos Estaduais", true },
                    { 112, 103, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9918), "Impostos Federais", true },
                    { 113, 103, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9920), "Impostos sobre Rendimento", true },
                    { 114, 103, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9922), "Impostos de Propriedade", true },
                    { 115, 104, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9924), "Investimentos em Ações", true },
                    { 116, 104, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9926), "Investimentos Imobiliários", true },
                    { 117, 104, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9928), "Fundos de Rendimento", true },
                    { 118, 104, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9930), "Rendimentos de Poupança", true },
                    { 119, 105, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9933), "Serviços Domésticos", true },
                    { 120, 105, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9935), "Consultoria", true },
                    { 121, 105, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9937), "Assinaturas de Serviços", true },
                    { 122, 106, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9939), "Viagens a Negócios", true },
                    { 123, 106, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9943), "Viagens de Lazer", true },
                    { 124, 106, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9945), "Passagens Aéreas", true },
                    { 125, 106, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9947), "Hospedagem", true },
                    { 126, 107, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9949), "Saúde Emergencial", true },
                    { 127, 107, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9951), "Ambulância", true },
                    { 128, 107, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9956), "Consultas de Urgência", true },
                    { 129, 107, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9958), "Alimentos de Emergência", true },
                    { 130, 108, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9961), "Alimentação no Trabalho", true },
                    { 131, 108, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9965), "Refeições Rápidas", true },
                    { 132, 108, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9968), "Mercado", true },
                    { 133, 108, null, new DateTime(2024, 11, 20, 20, 37, 24, 677, DateTimeKind.Local).AddTicks(9970), "Restaurantes", true },
                    { 134, 108, null, new DateTime(2024, 11, 20, 20, 37, 24, 678, DateTimeKind.Local).AddTicks(27), "Lanches", true },
                    { 135, 109, null, new DateTime(2024, 11, 20, 20, 37, 24, 678, DateTimeKind.Local).AddTicks(30), "Jogos Online", true },
                    { 136, 109, null, new DateTime(2024, 11, 20, 20, 37, 24, 678, DateTimeKind.Local).AddTicks(32), "Jogos de Tabuleiro", true },
                    { 137, 109, null, new DateTime(2024, 11, 20, 20, 37, 24, 678, DateTimeKind.Local).AddTicks(34), "Cartões de Jogo", true },
                    { 138, 109, null, new DateTime(2024, 11, 20, 20, 37, 24, 678, DateTimeKind.Local).AddTicks(38), "Acessórios para Jogos", true },
                    { 139, 109, null, new DateTime(2024, 11, 20, 20, 37, 24, 678, DateTimeKind.Local).AddTicks(41), "Desenvolvimento de Jogos", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "contas_bancarias",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "subcategoria_transacoes",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "categoria_contas_bancarias",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "categoria_transacoes",
                keyColumn: "Id",
                keyValue: 109);
        }
    }
}

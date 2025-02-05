using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetBuddy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistroAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoria_contas_bancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_contas_bancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoria_contas_bancarias_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "categoria_transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoria_transacoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contas_bancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contas_bancarias_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategoria_transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subcategoria_transacoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    data_hora_criacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartoes_credito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartoes_credito_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cartoes_credito_contas_bancarias_IdContaVinculada",
                        column: x => x.IdContaVinculada,
                        principalTable: "contas_bancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoTransacao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "BIT", nullable: false),
                    DataPrevista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEfetivacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdContaBancaria = table.Column<int>(type: "int", nullable: false),
                    IdSubcategoriaTransacao = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    registro_ativo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transacoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "categoria_contas_bancarias",
                columns: new[] { "Id", "data_hora_criacao", "Nome", "registro_ativo", "UsuarioId" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Corrente", true, null },
                    { 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Poupança", true, null },
                    { 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Salário", true, null },
                    { 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Investimentos", true, null },
                    { 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Reserva", true, null },
                    { 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Conjunta", true, null },
                    { 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Jurídica", true, null },
                    { 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Digital", true, null },
                    { 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Depósito", true, null },
                    { 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Pagamento", true, null },
                    { 110, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Investimento Imobiliário", true, null },
                    { 111, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Previdência", true, null },
                    { 112, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Fomento", true, null },
                    { 113, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Pagamento Eletrônico", true, null },
                    { 114, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Universitária", true, null },
                    { 115, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta Infantil", true, null },
                    { 116, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Crédito", true, null },
                    { 117, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Empréstimo", true, null },
                    { 118, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta de Transferência", true, null },
                    { 119, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conta com Investimento Automático", true, null }
                });

            migrationBuilder.InsertData(
                table: "categoria_transacoes",
                columns: new[] { "Id", "data_hora_criacao", "Nome", "registro_ativo", "UsuarioId" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transporte", true, null },
                    { 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saúde", true, null },
                    { 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laser", true, null },
                    { 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impostos", true, null },
                    { 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rendimentos", true, null },
                    { 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serviços", true, null },
                    { 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viagens", true, null },
                    { 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emergências", true, null },
                    { 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alimentação", true, null },
                    { 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogos", true, null }
                });

            migrationBuilder.InsertData(
                table: "contas_bancarias",
                columns: new[] { "Id", "data_hora_criacao", "Icon", "IdCategoria", "Nome", "registro_ativo", "Saldo", "UsuarioId" },
                values: new object[,]
                {
                    { 150, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-wallet", 100, "Conta Corrente Banco A", true, 5000.00m, null },
                    { 151, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-money-bill", 101, "Conta Poupança Banco B", true, 2000.00m, null },
                    { 152, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-chart-line", 102, "Conta Salário Banco C", true, 3000.00m, null },
                    { 153, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-briefcase", 103, "Conta de Investimentos Banco D", true, 15000.00m, null },
                    { 154, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-check", 104, "Conta de Reserva Banco E", true, 8000.00m, null },
                    { 155, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-times", 105, "Conta Conjunta Banco F", true, 12000.00m, null },
                    { 156, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-user", 106, "Conta Jurídica Banco G", true, 25000.00m, null },
                    { 157, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-home", 107, "Conta Digital Banco H", true, 4000.00m, null },
                    { 158, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-credit-card", 108, "Conta de Depósito Banco I", true, 7000.00m, null },
                    { 159, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pi pi-wallet", 109, "Conta de Pagamento Banco J", true, 6000.00m, null }
                });

            migrationBuilder.InsertData(
                table: "subcategoria_transacoes",
                columns: new[] { "Id", "CategoriaTransacaoId", "data_hora_criacao", "Nome", "registro_ativo", "UsuarioId" },
                values: new object[,]
                {
                    { 100, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transporte Público", true, null },
                    { 101, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Combustível", true, null },
                    { 102, 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manutenção do Carro", true, null },
                    { 103, 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plano de Saúde", true, null },
                    { 104, 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamentos", true, null },
                    { 105, 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultas Médicas", true, null },
                    { 106, 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tratamentos Estéticos", true, null },
                    { 107, 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cortes de Cabelo", true, null },
                    { 108, 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tratamentos Laser", true, null },
                    { 109, 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Equipamentos de Laser", true, null },
                    { 110, 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impostos Municipais", true, null },
                    { 111, 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impostos Estaduais", true, null },
                    { 112, 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impostos Federais", true, null },
                    { 113, 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impostos sobre Rendimento", true, null },
                    { 114, 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impostos de Propriedade", true, null },
                    { 115, 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investimentos em Ações", true, null },
                    { 116, 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investimentos Imobiliários", true, null },
                    { 117, 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fundos de Rendimento", true, null },
                    { 118, 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rendimentos de Poupança", true, null },
                    { 119, 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serviços Domésticos", true, null },
                    { 120, 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultoria", true, null },
                    { 121, 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assinaturas de Serviços", true, null },
                    { 122, 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viagens a Negócios", true, null },
                    { 123, 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viagens de Lazer", true, null },
                    { 124, 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Passagens Aéreas", true, null },
                    { 125, 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hospedagem", true, null },
                    { 126, 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saúde Emergencial", true, null },
                    { 127, 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ambulância", true, null },
                    { 128, 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultas de Urgência", true, null },
                    { 129, 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alimentos de Emergência", true, null },
                    { 130, 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alimentação no Trabalho", true, null },
                    { 131, 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refeições Rápidas", true, null },
                    { 132, 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercado", true, null },
                    { 133, 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restaurantes", true, null },
                    { 134, 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lanches", true, null },
                    { 135, 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogos Online", true, null },
                    { 136, 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogos de Tabuleiro", true, null },
                    { 137, 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cartões de Jogo", true, null },
                    { 138, 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acessórios para Jogos", true, null },
                    { 139, 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolvimento de Jogos", true, null }
                });

            migrationBuilder.InsertData(
                table: "transacoes",
                columns: new[] { "Id", "DataEfetivacao", "DataHoraCriacao", "DataPrevista", "IdContaBancaria", "IdSubcategoriaTransacao", "Nome", "registro_ativo", "Status", "TipoTransacao", "UsuarioId", "Valor" },
                values: new object[] { 150, null, null, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 158, 132, "Cooper", true, false, 2, null, 250m });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cartoes_credito_IdContaVinculada",
                table: "cartoes_credito",
                column: "IdContaVinculada");

            migrationBuilder.CreateIndex(
                name: "IX_cartoes_credito_UsuarioId",
                table: "cartoes_credito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_contas_bancarias_UsuarioId",
                table: "categoria_contas_bancarias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_transacoes_UsuarioId",
                table: "categoria_transacoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_contas_bancarias_IdCategoria",
                table: "contas_bancarias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_contas_bancarias_UsuarioId",
                table: "contas_bancarias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_subcategoria_transacoes_CategoriaTransacaoId",
                table: "subcategoria_transacoes",
                column: "CategoriaTransacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_subcategoria_transacoes_UsuarioId",
                table: "subcategoria_transacoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_IdContaBancaria",
                table: "transacoes",
                column: "IdContaBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_IdSubcategoriaTransacao",
                table: "transacoes",
                column: "IdSubcategoriaTransacao");

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_UsuarioId",
                table: "transacoes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "cartoes_credito");

            migrationBuilder.DropTable(
                name: "transacoes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "contas_bancarias");

            migrationBuilder.DropTable(
                name: "subcategoria_transacoes");

            migrationBuilder.DropTable(
                name: "categoria_contas_bancarias");

            migrationBuilder.DropTable(
                name: "categoria_transacoes");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

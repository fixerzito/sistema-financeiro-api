﻿// <auto-generated />
using System;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetBuddy.Infra.Data.Migrations
{
    [DbContext(typeof(BudgetBuddyContext))]
    [Migration("20241111191017_AlteradoTabelaTransacoes")]
    partial class AlteradoTabelaTransacoes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.BankAccounts.CategoriaContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataHoraCriacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("data_hora_criacao")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<bool>("RegistroAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("registro_ativo");

                    b.HasKey("Id");

                    b.ToTable("categoria_contas_bancarias", (string)null);
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.BankAccounts.ContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataHoraCriacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("data_hora_criacao")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("RegistroAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("registro_ativo");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("contas_bancarias", (string)null);
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.CreditCards.CartaoCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataHoraCriacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("data_hora_criacao")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("DiaFechamento")
                        .HasColumnType("int");

                    b.Property<int>("DiaVencimento")
                        .HasColumnType("int");

                    b.Property<string>("DigBandeira")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("IdContaVinculada")
                        .HasColumnType("int");

                    b.Property<decimal>("Limite")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("RegistroAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("registro_ativo");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdContaVinculada");

                    b.ToTable("cartoes_credito", (string)null);
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.Transactions.CategoriaTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataHoraCriacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("data_hora_criacao")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<bool>("RegistroAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("registro_ativo");

                    b.HasKey("Id");

                    b.ToTable("categoria_transacoes", (string)null);
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.Transactions.SubcategoriaTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaTransacaoId")
                        .HasColumnType("int");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataHoraCriacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("data_hora_criacao")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<bool>("RegistroAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("registro_ativo");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaTransacaoId");

                    b.ToTable("subcategoria_transacoes", (string)null);
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.Transactions.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataHoraCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdContaBancaria")
                        .HasColumnType("int");

                    b.Property<int>("IdSubcategoriaTransacao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("RegistroAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("registro_ativo");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdContaBancaria");

                    b.HasIndex("IdSubcategoriaTransacao");

                    b.ToTable("transacoes", (string)null);
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.BankAccounts.ContaBancaria", b =>
                {
                    b.HasOne("BudgetBuddy.Domain.Entities.BankAccounts.CategoriaContaBancaria", null)
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.CreditCards.CartaoCredito", b =>
                {
                    b.HasOne("BudgetBuddy.Domain.Entities.BankAccounts.ContaBancaria", "ContaBancaria")
                        .WithMany()
                        .HasForeignKey("IdContaVinculada")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ContaBancaria");
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.Transactions.SubcategoriaTransacao", b =>
                {
                    b.HasOne("BudgetBuddy.Domain.Entities.Transactions.CategoriaTransacao", "CategoriaTransacao")
                        .WithMany()
                        .HasForeignKey("CategoriaTransacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoriaTransacao");
                });

            modelBuilder.Entity("BudgetBuddy.Domain.Entities.Transactions.Transacao", b =>
                {
                    b.HasOne("BudgetBuddy.Domain.Entities.BankAccounts.ContaBancaria", "ContaBancaria")
                        .WithMany()
                        .HasForeignKey("IdContaBancaria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BudgetBuddy.Domain.Entities.Transactions.SubcategoriaTransacao", "SubcategoriaTransacao")
                        .WithMany()
                        .HasForeignKey("IdSubcategoriaTransacao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ContaBancaria");

                    b.Navigation("SubcategoriaTransacao");
                });
#pragma warning restore 612, 618
        }
    }
}

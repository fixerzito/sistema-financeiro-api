﻿// <auto-generated />
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetBuddy.Application.Migrations
{
    [DbContext(typeof(BudgetBuddyContext))]
    [Migration("20241015210443_CriadoTabelaCartoesCredito")]
    partial class CriadoTabelaCartoesCredito
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.CartoesCredito.CartaoCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiaFechamento")
                        .HasColumnType("int");

                    b.Property<int>("DiaVencimento")
                        .HasColumnType("int");

                    b.Property<string>("DigBandeira")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdContaVinculada")
                        .HasColumnType("int");

                    b.Property<decimal>("Limite")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdContaVinculada");

                    b.ToTable("cartoes_credito", (string)null);
                });

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.ContasBancarias.CategoriaContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("categoria_contas_bancarias", (string)null);
                });

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.ContasBancarias.ContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("contas_bancarias", (string)null);
                });

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.Transacoes.CategoriaTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("categoria_transacoes", (string)null);
                });

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.Transacoes.SubcategoriaTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("Categoria");

                    b.ToTable("subcategoria_transacoes", (string)null);
                });

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.CartoesCredito.CartaoCredito", b =>
                {
                    b.HasOne("BackendSistemaFinanceiro.Entidades.ContasBancarias.ContaBancaria", null)
                        .WithMany()
                        .HasForeignKey("IdContaVinculada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.ContasBancarias.ContaBancaria", b =>
                {
                    b.HasOne("BackendSistemaFinanceiro.Entidades.ContasBancarias.CategoriaContaBancaria", null)
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackendSistemaFinanceiro.Entidades.Transacoes.SubcategoriaTransacao", b =>
                {
                    b.HasOne("BackendSistemaFinanceiro.Entidades.Transacoes.CategoriaTransacao", null)
                        .WithMany()
                        .HasForeignKey("Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using BackendSistemaFinanceiro.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendSistemaFinanceiro.Migrations
{
    [DbContext(typeof(SistemaFinanceiroContext))]
    [Migration("20241015201922_CriadoTabelaContasBancarias")]
    partial class CriadoTabelaContasBancarias
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

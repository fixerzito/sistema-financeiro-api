using BudgetBuddy.Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infra.Data.Mapping.Usuarios;

public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.CPF)
            .IsRequired()
            .HasMaxLength(14);
        
        builder.Property(x => x.DataNascimento)
            .IsRequired();
        
        builder.Property(x => x.RefreshToken)
            .HasMaxLength(200);
        
        builder.Property(x => x.Permission)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue("Usuario");
        
        builder.HasMany(x => x.Transacoes)
            .WithOne(t => t.Usuario)
            .HasForeignKey(t => t.UserId);
        
        builder.HasMany(x => x.CategoriaContaBancaria)
            .WithOne()
            .HasForeignKey("UserId");
        
        builder.HasMany(x => x.ContasBancarias)
            .WithOne()
            .HasForeignKey("UserId");
        
        builder.HasMany(x => x.CartaoCredito)
            .WithOne()
            .HasForeignKey("UserId");
        
        builder.HasMany(x => x.CategoriaTransacao)
            .WithOne()
            .HasForeignKey("UserId");
        
        builder.HasMany(x => x.SubcategoriaTransacao)
            .WithOne()
            .HasForeignKey("UserId");
    }
}
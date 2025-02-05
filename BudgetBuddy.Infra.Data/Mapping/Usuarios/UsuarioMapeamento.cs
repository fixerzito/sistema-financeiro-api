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
        
        builder.Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(x => x.RefreshToken)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Permission)
            .IsRequired()
            .HasColumnType("string")
            .HasDefaultValue("Usuario");
        
        builder.Property(x => x.RegistroAtivo)
            .IsRequired()
            .HasColumnName("registro_ativo")
            .HasColumnType("BIT")
            .HasDefaultValue(true);
        
        builder.Property(x => x.DataHoraCriacao)
            .IsRequired()
            .HasColumnName("data_hora_criacao")
            .HasDefaultValueSql("GETDATE()");
       
    }
}
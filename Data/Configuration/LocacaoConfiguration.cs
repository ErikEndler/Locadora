using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(k => k.Filme)
               .WithMany()
               .HasForeignKey(k => k.FilmeID)
               .IsRequired();
            builder.HasOne(k => k.Cliente)
              .WithMany()
              .HasForeignKey(k => k.ClienteID)
              .IsRequired();
        }
    }
}

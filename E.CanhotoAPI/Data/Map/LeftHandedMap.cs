using E.CanhotoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.CanhotoAPI.Data.Map
{
    public class LeftHandedMap : IEntityTypeConfiguration<LeftHanded>
    {
        public void Configure(EntityTypeBuilder<LeftHanded> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Categoria).IsRequired();
            builder.Property(x => x.ValorGasto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NotaFiscal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Data);
            builder.Property(x => x.Status);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User);
        }
    }
}

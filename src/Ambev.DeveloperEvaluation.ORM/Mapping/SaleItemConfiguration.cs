using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(i => i.SaleId)
              .IsRequired()
              .HasColumnType("uuid");

        builder.Property(i => i.ProductId)
            .IsRequired()
            .HasColumnType("uuid");

        builder.Property(i => i.ProductName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(i => i.Quantity)
            .IsRequired();

        builder.Property(i => i.UnitPrice)
            .IsRequired()
            .HasColumnType("numeric(18,2)");

        builder.Property(i => i.IsCanceled)
            .IsRequired();
    }
}

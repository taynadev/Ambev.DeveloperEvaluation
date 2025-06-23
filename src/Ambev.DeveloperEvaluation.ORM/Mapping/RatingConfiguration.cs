using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("Ratings");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Rate).IsRequired();
        builder.Property(p => p.Count);

        builder.HasOne(p => p.Product)
            .WithOne(p => p.Rating)
            .HasForeignKey<Rating>(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
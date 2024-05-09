using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR(255)");
            builder.Property(x => x.Category).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Price).HasColumnType("DECIMAL(6, 2)");
            builder.Property(x => x.Quantity).HasColumnType("INT");
        }
    }
}

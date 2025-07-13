using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NS.Domain.Entities;

namespace NS.Infrastructure.EfCore
{
    public class ProductMapper:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.ProductDate, x.ManufactureEmail }).IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ManufactureEmail).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ManufacturePhone).IsRequired().HasMaxLength(20);

        }
    }
}

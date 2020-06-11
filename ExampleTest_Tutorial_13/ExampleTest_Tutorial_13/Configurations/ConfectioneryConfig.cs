using ExampleTest_Tutorial_13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleTest_Tutorial_13.Configurations
{
    public class ConfectioneryConfig : IEntityTypeConfiguration<Confectionery>
    {
        public void Configure(EntityTypeBuilder<Confectionery> builder)
        {
            builder.HasKey(x => x.IdConfectionery)
                .HasName("Confectionery_pk");

            builder.ToTable("Confectionery", "apbd_order");
                
            builder.Property(e => e.IdConfectionery)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PricePerItem)
                .IsRequired();

            builder.HasMany(x => x.Confectionery_Order)
                .WithOne(x => x.Confectionery);

        }
    }
}
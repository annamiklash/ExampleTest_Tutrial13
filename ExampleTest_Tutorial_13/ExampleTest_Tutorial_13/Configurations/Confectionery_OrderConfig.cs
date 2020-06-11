using ExampleTest_Tutorial_13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleTest_Tutorial_13.Configurations
{
    public class Confectionery_OrderConfig : IEntityTypeConfiguration<Confectionery_Order>
    {
        public void Configure(EntityTypeBuilder<Confectionery_Order> builder)
        {
            builder.HasKey(e => new {e.IdConfectionery, e.IdOrder});

            builder.Property(e => e.IdConfectionery);

            builder.Property(e => e.IdOrder);

            builder.ToTable("Confectionery_Order", "apbd_order");

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Confectionery)
                .WithMany(x => x.Confectionery_Order)
                .HasForeignKey(x => x.IdConfectionery)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Confectionery_Confectionery_Order");

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Confectionery_Order)
                .HasForeignKey(x => x.IdOrder)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Order_Confectionery_Order");
        }
    }
}
using ExampleTest_Tutorial_13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleTest_Tutorial_13.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.IdOrder)
                .HasName("Order_pk");

            builder.ToTable("Order", "apbd_order");
                
            builder.Property(e => e.IdOrder)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.DateAccepted)
             
                .HasColumnType("date");

            builder.Property(x => x.DateFinished)
      
                .HasColumnType("date");
            
            builder.Property(x => x.Notes)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.IdCustomer)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Customer_Order");
            
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.IdEmployee)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Employee_Order");
            
                
            builder.HasMany(x => x.Confectionery_Order)
                .WithOne(x => x.Order);

        }
    }
}
using ExampleTest_Tutorial_13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleTest_Tutorial_13.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
              
            builder.HasKey(x => x.IdCustomer)
                .HasName("Customer_pk");

            builder.ToTable("Customer", "apbd_order");
                
            builder.Property(e => e.IdCustomer).
                ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

                
            builder.HasMany(d => d.Order)
                .WithOne(x => x.Customer);
        }
    }
}
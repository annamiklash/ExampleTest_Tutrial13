using ExampleTest_Tutorial_13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleTest_Tutorial_13.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>

    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            
            builder.HasKey(x => x.IdEmployee)
                .HasName("Employee_pk");

            builder.ToTable("Employee", "apbd_order");
                
            builder.Property(e => e.IdEmployee).
                ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

                
            builder.HasMany(d => d.Order)
                .WithOne(x => x.Employee);

        }
    }
}
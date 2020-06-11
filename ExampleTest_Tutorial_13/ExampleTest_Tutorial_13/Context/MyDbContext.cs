using ExampleTest_Tutorial_13.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest_Tutorial_13.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Confectionery> Confectionery { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Confectionery_Order> Confectionery_Order { get; set; }
       
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public MyDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());

            modelBuilder.ApplyConfiguration(new EmployeeConfig());

            modelBuilder.ApplyConfiguration(new ConfectioneryConfig());

            modelBuilder.ApplyConfiguration(new OrderConfig());

            modelBuilder.ApplyConfiguration(new Confectionery_OrderConfig());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
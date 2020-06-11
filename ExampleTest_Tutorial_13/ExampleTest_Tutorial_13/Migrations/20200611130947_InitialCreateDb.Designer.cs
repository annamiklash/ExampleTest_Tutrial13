﻿// <auto-generated />
using System;
using ExampleTest_Tutorial_13.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExampleTest_Tutorial_13.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200611130947_InitialCreateDb")]
    partial class InitialCreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExampleTest_Tutorial_13.Models.Confectionery", b =>
                {
                    b.Property<int>("IdConfectionery")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<float>("PricePerItem")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdConfectionery")
                        .HasName("Confectionery_pk");

                    b.ToTable("Confectionery","apbd_order");
                });

            modelBuilder.Entity("ExampleTest_Tutorial_13.Models.Confectionery_Order", b =>
                {
                    b.Property<int>("IdConfectionery")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdConfectionery", "IdOrder");

                    b.HasIndex("IdOrder");

                    b.ToTable("Confectionery_Order","apbd_order");
                });

            modelBuilder.Entity("ExampleTest_Tutorial_13.Models.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdCustomer")
                        .HasName("Customer_pk");

                    b.ToTable("Customer","apbd_order");
                });

            modelBuilder.Entity("ExampleTest_Tutorial_13.Models.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdEmployee")
                        .HasName("Employee_pk");

                    b.ToTable("Employee","apbd_order");
                });

            modelBuilder.Entity("ExampleTest_Tutorial_13.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("date");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdOrder")
                        .HasName("Order_pk");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdEmployee");

                    b.ToTable("Order","apbd_order");
                });

            modelBuilder.Entity("ExampleTest_Tutorial_13.Models.Confectionery_Order", b =>
                {
                    b.HasOne("ExampleTest_Tutorial_13.Models.Confectionery", "Confectionery")
                        .WithMany("Confectionery_Order")
                        .HasForeignKey("IdConfectionery")
                        .HasConstraintName("Confectionery_Confectionery_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExampleTest_Tutorial_13.Models.Order", "Order")
                        .WithMany("Confectionery_Order")
                        .HasForeignKey("IdOrder")
                        .HasConstraintName("Order_Confectionery_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExampleTest_Tutorial_13.Models.Order", b =>
                {
                    b.HasOne("ExampleTest_Tutorial_13.Models.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("IdCustomer")
                        .HasConstraintName("Customer_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExampleTest_Tutorial_13.Models.Employee", "Employee")
                        .WithMany("Order")
                        .HasForeignKey("IdEmployee")
                        .HasConstraintName("Employee_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
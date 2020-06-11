using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest_Tutorial_13.Models.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var customers =GenerateCustomers();
            var employees = GenerateEmployees();
            var confectionery = GenerateConfectionery();
            var orders = GenerateOrders();
            var confectioneryOrders = GenerateConfectioneryOrder();
            
            SeedCustomers(customers, modelBuilder);
            SeedEmployees(employees, modelBuilder);
            SeedConfectionery(confectionery, modelBuilder);
            SeedOrders(orders, modelBuilder);
            SeedConfectioneryOrders(confectioneryOrders, modelBuilder);
        }
        private static void SeedCustomers(List<Customer> customers, ModelBuilder modelBuilder)
        {
            foreach (var customer in customers)
            {
                modelBuilder
                    .Entity<Customer>()
                    .HasData(customer);
            }
        }
        private static void SeedEmployees(List<Employee> employees, ModelBuilder modelBuilder)
        {
            foreach (var employee in employees)
            {
                modelBuilder
                    .Entity<Employee>()
                    .HasData(employee);
            }
        }
        private static void SeedConfectionery(List<Confectionery> confectioneries, ModelBuilder modelBuilder)
        {
            foreach (var confectionery in confectioneries)
            {
                modelBuilder
                    .Entity<Confectionery>()
                    .HasData(confectionery);
            }
        }
        private static void SeedOrders(List<Order> orders, ModelBuilder modelBuilder)
        {
            foreach (var order in orders)
            {
                modelBuilder
                    .Entity<Order>()
                    .HasData(order);
            }
        }
        private static void SeedConfectioneryOrders(List<Confectionery_Order> confectioneryOrders, ModelBuilder modelBuilder)
        {
            foreach (var order in confectioneryOrders)
            {
                modelBuilder
                    .Entity<Confectionery_Order>()
                    .HasData(order);
            }
        }

        private static List<Employee> GenerateEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                   IdEmployee = 1,
                   Name = "Jon",
                   Surname = "Doe"
                },
                new Employee
                {
                    IdEmployee = 2,
                    Name = "Anna",
                    Surname = "Smith"
                },
                new Employee
                {
                    IdEmployee = 3,
                    Name = "Jack",
                    Surname = "Daniels"
                },
            };
        }
        private static List<Customer> GenerateCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    IdCustomer = 1,
                    Name = "Kelly",
                    Surname = "Kapour"
                },
                new Customer
                {
                    IdCustomer = 2,
                    Name = "Michael",
                    Surname = "Scott"
                },
                new Customer
                {
                    IdCustomer = 3,
                    Name = "Dwight",
                    Surname = "Schrute"
                }
            };
        }
        private static List<Confectionery> GenerateConfectionery()
        {
            return new List<Confectionery>
            {
                new Confectionery
                {
                    IdConfectionery = 1,
                    Name = "Birthday Cake",
                    PricePerItem = (float) 30.99,
                    Type = "Cake"
                    
                },
                new Confectionery
                {
                    IdConfectionery = 2,
                    Name = "Wedding Cake",
                    PricePerItem = (float) 49.99,
                    Type = "Cake"
                    
                },
                new Confectionery
                {
                    IdConfectionery = 3,
                    Name = "Chocolate Muffin",
                    PricePerItem = (float) 8.99,
                    Type = "Muffin"
                    
                },
                new Confectionery
                {
                    IdConfectionery = 4,
                    Name = "Caramel Brittle",
                    PricePerItem = (float) 15.89,
                    Type = "Brittle"
                    
                }
            };
        }
        private static List<Order> GenerateOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    IdOrder = 1,
                    IdCustomer = 1,
                    IdEmployee = 1,
                    DateAccepted = Convert.ToDateTime("02.06.2020"),
                    DateFinished = Convert.ToDateTime("09.06.2020"),
                    Notes = "notes ccccc"
                },
                new Order
                {
                    IdOrder = 2,
                    IdCustomer = 2,
                    IdEmployee = 1,
                    DateAccepted = Convert.ToDateTime("03.06.2020"),
                    DateFinished = Convert.ToDateTime("10.06.2020"),
                    Notes = "notes aaaaa"
                },
                new Order
                {
                    IdOrder = 3,
                    IdCustomer = 3,
                    IdEmployee = 2,
                    DateAccepted = Convert.ToDateTime("03.06.2020"),
                    DateFinished = Convert.ToDateTime("11.06.2020"),
                    Notes = "notes bbbbb"
                },
                new Order
                {
                    IdOrder = 4,
                    IdCustomer = 1,
                    IdEmployee = 3,
                    DateAccepted = Convert.ToDateTime("10.06.2020"),
                    Notes = "notes qqqqq"
                },
                new Order
                {
                    IdOrder = 5,
                    IdCustomer = 3,
                    IdEmployee = 2,
                    DateAccepted = Convert.ToDateTime("02.06.2020"),
                    DateFinished = Convert.ToDateTime("09.06.2020"),
                    Notes = "notes slhgkdshk"
                },
            };
        }
        private static List<Confectionery_Order> GenerateConfectioneryOrder()
        {
            return new List<Confectionery_Order>
            {
                new Confectionery_Order
                {
                    IdConfectionery = 1,
                    IdOrder = 1,
                    Notes = "happy bday",
                    Quantity = 1
                },
                new Confectionery_Order
                {
                    IdConfectionery = 1,
                    IdOrder = 2,
                    Notes = "happy anniversary",
                    Quantity = 2
                },
                new Confectionery_Order
                {
                    IdConfectionery = 2,
                    IdOrder = 2,
                    Notes = "happy retirement",
                    Quantity = 2
                },
                new Confectionery_Order
                {
                    IdConfectionery = 3,
                    IdOrder = 4,
                    Notes = "happy graduation",
                    Quantity = 1
                },
                new Confectionery_Order
                {
                    IdConfectionery = 4,
                    IdOrder = 3,
                    Notes = "--",
                    Quantity = 1
                },
                new Confectionery_Order
                {
                    IdConfectionery = 2,
                    IdOrder = 5,
                    Notes = "happy 12 bday",
                    Quantity = 1
                }
            };
        }
    }
}
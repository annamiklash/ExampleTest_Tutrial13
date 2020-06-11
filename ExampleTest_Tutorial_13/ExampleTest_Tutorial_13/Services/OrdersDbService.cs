using System;
using System.Collections.Generic;
using System.Linq;
using ExampleTest_Tutorial_13.Models;
using ExampleTest_Tutorial_13.Models.Context;
using ExampleTest_Tutorial_13.Models.Requests;

namespace ExampleTest_Tutorial_13.Services
{
    public class OrdersDbService : IOrdersDbService
    {
        private readonly MyDbContext _context;
        private static Random random = new Random();

        public OrdersDbService(MyDbContext context)
        {
            _context = context;
        }

        public List<OrderResponse> GetCustomerOrders(int id)
        {
            return _context.Order.Where(o => o.IdCustomer == id)
                .Join(
                    _context.Confectionery_Order,
                    ord1 => ord1.IdOrder,
                    co1 => co1.IdOrder,
                    (ord1, co1) => new {Order = ord1, Confectionery_Order = co1})
                .Join(
                    _context.Confectionery,
                    co2 => co2.Confectionery_Order.IdConfectionery,
                    c1 => c1.IdConfectionery,
                    (co2, c1) => new {Confectionery_Order = co2, Confectionery = c1})
                .Select(c => new OrderResponse
                {
                    ConfName = c.Confectionery.Name,
                    ConfType = c.Confectionery.Type,
                    PricePerItem = c.Confectionery.PricePerItem,
                    Quantity = c.Confectionery_Order.Confectionery_Order.Quantity,
                    Notes = c.Confectionery_Order.Confectionery_Order.Notes,
                    DateAccepted = c.Confectionery_Order.Order.DateAccepted
                }).ToList();
        }

        public List<OrderResponse> GetAllCustomersOrders()
        {
            return _context.Order
                .Join(
                    _context.Confectionery_Order,
                    ord1 => ord1.IdOrder,
                    co1 => co1.IdOrder,
                    (ord, co1) => new {Order = ord, Confectionery_Order = co1})
                .Join(
                    _context.Confectionery,
                    co2 => co2.Confectionery_Order.IdConfectionery,
                    c1 => c1.IdConfectionery,
                    (co2, c1) => new {Confectionery_Order = co2, Confectionery = c1})
                .Select(c => new OrderResponse
                {
                    ConfName = c.Confectionery.Name,
                    ConfType = c.Confectionery.Type,
                    PricePerItem = c.Confectionery.PricePerItem,
                    Quantity = c.Confectionery_Order.Confectionery_Order.Quantity,
                    Notes = c.Confectionery_Order.Confectionery_Order.Notes,
                    DateAccepted = c.Confectionery_Order.Order.DateAccepted
                }).ToList();
        }

        public Customer GetCustomerBySurname(string customerSurname)
        {
            return _context.Customer
                .FirstOrDefault(customer => customer.Surname.Equals(customerSurname));
        }

        public bool CustomerWithIdExists(string id)
        {
            return _context.Customer.Any(customer => customer.IdCustomer == Convert.ToInt32(id));
        }

        public bool ConfectioneryExists(ConfectioneryRequest confectioneryRequest)
        {
            return _context.Confectionery.Any(confectionery =>
                confectionery.Name.Equals(confectioneryRequest.Name));
        }

        public NewOrderResponse AddNewOrder(NewOrderRequest newOrderRequest, string customerId)
        {
            var response = new NewOrderResponse();
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (!CustomerWithIdExists(customerId))
                {
                    throw new Exception("Customer with Id " + customerId + " DOESNT EXIST");
                }

                var confectioneries = newOrderRequest.Confectionery;
                foreach (var confectioneryRequest in confectioneries)
                {
                    if (!ConfectioneryExists(confectioneryRequest))
                    {
                        throw new Exception("Confectionery with name " + confectioneryRequest.Name + " DOESNT EXIST");
                    }
                }

                var idOrder = CreateNewOrder(newOrderRequest, customerId);

                response.CustomerSurname = GetCustomerSurnameById(customerId);
                response.IdOrder = idOrder;
                response.IdEmployee = GetEmployeeIdByOrderId(idOrder);
                List<int> confectioneryIdList = new List<int>();

                foreach (var confectioneryRequest in confectioneries)
                {
                    var confId = CreateNewConfectioneryOrder(idOrder, confectioneryRequest);
                    confectioneryIdList.Add(confId);
                }

                response.ConfectioneryIdList = confectioneryIdList;
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return response;
        }

        private int GetEmployeeIdByOrderId(int idOrder)
        {
            return _context.Order.Find(idOrder).IdEmployee;
        }

        private string GetCustomerSurnameById(string customerId)
        {
            return _context.Customer.Find(Convert.ToInt32(customerId)).Surname;
        }

        private int CreateNewConfectioneryOrder(int idOrder, ConfectioneryRequest confectioneryRequest)
        {
            Confectionery confectionery =
                _context.Confectionery.FirstOrDefault(c => c.Name == confectioneryRequest.Name);
            _context.Confectionery_Order.Add(new Confectionery_Order
            {
                IdConfectionery = confectionery.IdConfectionery,
                IdOrder = idOrder,
                Quantity = Convert.ToInt32(confectioneryRequest.Quantity),
                Notes = confectioneryRequest.Notes
            });
            _context.SaveChanges();
            return confectionery.IdConfectionery;
        }

        private int CreateNewOrder(NewOrderRequest newOrderRequest, string customerId)
        {
            var newOrderId = GetNewOrderId();
            _context.Order.Add(new Order
            {
                IdCustomer = Convert.ToInt32(customerId),
                DateAccepted = Convert.ToDateTime(newOrderRequest.DateAccepted),
                Notes = newOrderRequest.Notes,
                IdEmployee = GetRandomEmployeeId(),
                IdOrder = newOrderId
            });
            _context.SaveChanges();
            return newOrderId;
        }

        private int GetNewOrderId()
        {
            return _context.Order.Max(order => order.IdOrder) + 1;
        }

        private int GetRandomEmployeeId()
        {
            var max = _context.Employee.Max(employee => employee.IdEmployee);
            var min = _context.Employee.Min(employee => employee.IdEmployee);
            return random.Next(min, max + 1);
        }
    }
}
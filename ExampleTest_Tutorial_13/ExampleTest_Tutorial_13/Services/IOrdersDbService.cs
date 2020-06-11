using System.Collections.Generic;
using ExampleTest_Tutorial_13.Models;
using ExampleTest_Tutorial_13.Models.Requests;

namespace ExampleTest_Tutorial_13.Services
{
    public interface IOrdersDbService
    {
        List<OrderResponse> GetCustomerOrders(int id);
        
        List<OrderResponse>  GetAllCustomersOrders();
        Customer GetCustomerBySurname(string customerSurname);

        bool CustomerWithIdExists(string id);
        bool ConfectioneryExists(ConfectioneryRequest confectioneryRequest);
        NewOrderResponse AddNewOrder(NewOrderRequest request, string customerId);
    }
}
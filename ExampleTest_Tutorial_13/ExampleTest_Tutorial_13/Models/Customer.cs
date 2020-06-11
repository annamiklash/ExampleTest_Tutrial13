using System.Collections;
using System.Collections.Generic;

namespace ExampleTest_Tutorial_13.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual IEnumerable<Order> Order { get; set; }
    }
}
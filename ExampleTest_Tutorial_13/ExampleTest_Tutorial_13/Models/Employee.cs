using System.Collections.Generic;

namespace ExampleTest_Tutorial_13.Models
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public virtual IEnumerable<Order> Order { get; set; }
    }
}
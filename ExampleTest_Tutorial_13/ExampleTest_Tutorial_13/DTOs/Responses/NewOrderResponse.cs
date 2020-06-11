using System.Collections.Generic;

namespace ExampleTest_Tutorial_13.Models
{
    public class NewOrderResponse
    {
        public string CustomerSurname { get; set; }
        public int IdEmployee { get; set; }
        public int IdOrder { get; set; }

        public List<int> ConfectioneryIdList { get; set; }
    }
}
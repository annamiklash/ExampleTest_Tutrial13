using System;
using System.Collections.Generic;

namespace ExampleTest_Tutorial_13.Models.Requests
{
    public class NewOrderRequest
    {
        public string DateAccepted { get; set; }
        public string Notes { get; set; }
        public List<ConfectioneryRequest> Confectionery { get; set; }
    }
}
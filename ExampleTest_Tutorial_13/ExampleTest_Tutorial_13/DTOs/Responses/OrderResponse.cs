using System;

namespace ExampleTest_Tutorial_13.Models
{
    public class OrderResponse
    {
        public string ConfName { get; set; }
        public string ConfType { get; set; }
        public int Quantity { get; set; }
        public float PricePerItem { get; set; }
        public DateTime DateAccepted { get; set; }
        public string Notes { get; set; }
        
    }
}
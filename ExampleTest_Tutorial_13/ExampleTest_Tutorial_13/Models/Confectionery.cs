using System.Collections;
using System.Collections.Generic;

namespace ExampleTest_Tutorial_13.Models
{
    public class Confectionery
    {
        public int IdConfectionery { get; set; }
        public string Name { get; set; }
        public float PricePerItem { get; set; }
        public string Type { get; set; }
        
        public virtual IEnumerable<Confectionery_Order> Confectionery_Order { get; set; }
    }
}
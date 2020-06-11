namespace ExampleTest_Tutorial_13.Models
{
    public class Confectionery_Order
    {
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public int IdConfectionery { get; set; }
        public virtual Confectionery Confectionery { get; set; }

        public int IdOrder { get; set; }
        public virtual Order Order { get; set; }
    }
}
namespace ExampleTest_Tutorial_13.Models
{
    public class Error
    {
        public string Field { get; set; }
        public string InvalidValue { get; set; }
        public string Message { get; set; }


        public Error(string field, string invalidValue, string message)
        {
            Field = field;
            Message = message;
            InvalidValue = invalidValue;
        }
    }
}
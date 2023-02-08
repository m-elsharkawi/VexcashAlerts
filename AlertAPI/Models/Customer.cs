namespace AlertAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string CreditNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}

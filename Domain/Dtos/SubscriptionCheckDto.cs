namespace Domain.Dtos
{
    public class SubscriptionCheckDto
    {
        public string BankTransactionId { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Date { get; set; }
        
        public double TotalCost { get; set; }

        public Guid SubscriptionId { get; set; }
    }
}
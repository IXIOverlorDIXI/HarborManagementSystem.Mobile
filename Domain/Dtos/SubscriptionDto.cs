namespace Domain.Dtos
{
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public int MaxHarborAmount { get; set; }
        
        public double TaxOnBooking { get; set; }
        
        public double TaxOnServices { get; set; }
        
        public double Price { get; set; }
        
        public int SubscriberAmount { get; set; }
    }
}
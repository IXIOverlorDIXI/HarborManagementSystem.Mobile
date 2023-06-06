namespace Domain.Dtos
{
    public class SubscriptionChangeDto
    {
        public double ChangeCost { get; set; }
        
        public SubscriptionDto NewSubscription { get; set; }
    }
}
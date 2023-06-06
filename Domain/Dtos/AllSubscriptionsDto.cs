namespace Domain.Dtos
{
    public class AllSubscriptionsDto
    {
        public List<SubscriptionDto> Subscriptions { get; set; }
        
        public int CurrentSubscriptionIndex { get; set; }
    }
}
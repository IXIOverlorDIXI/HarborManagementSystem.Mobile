namespace Domain.Dtos
{
    public class BookingsFilter
    {
        public Guid ShipId { get; set; }
        
        public Guid HarborId { get; set; }
        
        public Guid BerthId { get; set; }
    }
}
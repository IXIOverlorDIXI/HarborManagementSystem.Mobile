namespace Domain.Dtos
{
    public class BookingEditDataDto
    {
        public Guid Id { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public Guid? ShipId { get; set; }
        
        public Guid? BerthId { get; set; }
        
        public Guid? HarborId { get; set; }
    
        public List<ServicePreviewDto> AdditionalServices { get; set; }
    }
}
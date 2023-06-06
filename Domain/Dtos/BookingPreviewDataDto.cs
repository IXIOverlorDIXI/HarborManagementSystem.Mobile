namespace Domain.Dtos
{
    public class BookingPreviewDataDto
    {
        public Guid Id { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string ShipName { get; set; }
        
        public string BerthName { get; set; }
        
        public string HarborName { get; set; }
        
        public bool IsPayed { get; set; }
    
        public List<ServiceDto> AdditionalServices { get; set; }
    }
}
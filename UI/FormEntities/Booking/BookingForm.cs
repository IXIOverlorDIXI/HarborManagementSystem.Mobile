using Domain.Dtos;

namespace UI.FormEntities.Booking
{
    public class BookingForm
    {
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        public Guid HarborId { get; set; }
        
        public Guid ShipId { get; set; }
        
        public Guid BerthId { get; set; }
    
        public IEnumerable<ServicePreviewDto> AdditionalServices { get; set; }
    }
}
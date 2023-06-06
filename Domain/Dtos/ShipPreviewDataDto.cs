namespace Domain.Dtos
{
    public class ShipPreviewDataDto
    {
        public string DisplayName { get; set; }

        public Guid Id { get; set; }
        
        public string PhotoUrl { get; set; }
        
        public string ShipTypeName { get; set; }
        
        public string ShipTypeDescription { get; set; }
    }
}
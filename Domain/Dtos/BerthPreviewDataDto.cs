namespace Domain.Dtos
{
    public class BerthPreviewDataDto
    {
        public Guid Id { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }
        
        public List<string> Photos { get; set; }
        
        public double AverageRate { get; set; }
        
        public int ReviewsAmount { get; set; }
        
        public double GeolocationLongitude { get; set; }
    
        public double GeolocationLatitude  { get; set; }
        
        public bool IsActive { get; set; }
        
        public List<ShipTypeDto> SuitableShipTypes { get; set; }

        public bool IsOwner { get; set; }
    }
}
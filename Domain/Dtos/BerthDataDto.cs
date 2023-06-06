namespace Domain.Dtos
{
    public class BerthDataDto
    {
        public Guid Id { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }
        
        public Guid HarborId { get; set; }
        
        public List<ShipTypeDto> SuitableShipTypes { get; set; }
    }
}
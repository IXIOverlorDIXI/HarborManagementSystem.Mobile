namespace Domain.Dtos
{
    public class ShipDataDto
    {
        public Guid Id { get; set; }
        
        public string DisplayName { get; set; }

        public Guid ShipTypeId { get; set; }
    }
}
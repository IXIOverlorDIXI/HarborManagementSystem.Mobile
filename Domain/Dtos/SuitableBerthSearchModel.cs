namespace Domain.Dtos
{
    public class SuitableBerthSearchModel
    {
        public ShipTypeDto ShipType { get; set; }
        
        public Guid HarborId { get; set; }
    }
}
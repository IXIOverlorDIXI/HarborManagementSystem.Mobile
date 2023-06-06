using Domain.Dtos;

namespace UI.FormEntities.Harbor
{
    public class BerthForm
    {
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }

        public IEnumerable<ShipTypeDto> SuitableShipTypes { get; set; }
    }
}
using Domain.Enums;

namespace Domain.Dtos
{
    public class EnvironmentalConditionDto
    {
        public double Temperature { get; set; }
        
        public double AtmospherePressure { get; set; }
        
        public double WindSpeed { get; set; }
        
        public ShipRelativeWindDirection ShipRelativeWindDirection { get; set; }
        
        public double WaveSpeed { get; set; }
        
        public double WaveForce { get; set; }
        
        public Guid BerthId { get; set; }
        
        public DateTime MeteringDate { get; set; }
    }
}
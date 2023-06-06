namespace Domain.Dtos
{
    public class StorageEnvironmentalConditionDto
    {
        public Guid BerthId { get; set; }
        
        public double AirPollution { get; set; }
        
        public double WaterPollution { get; set; }
        
        public double RadiationLevel { get; set; }
        
        public double ShipTemperature { get; set; }
        
        public DateTime MeteringDate { get; set; }
    }
}
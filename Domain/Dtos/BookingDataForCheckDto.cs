namespace Domain.Dtos
{
    public class BookingDataForCheckDto
    {
        public double TotalCost { get; set; }
        
        public List<AdditionalServiceDto> Services { get; set; }
        
        public string BerthName { get; set; }
        
        public string HarborName { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string IBAN { get; set; }
        
        public string BIC { get; set; }
    }
}
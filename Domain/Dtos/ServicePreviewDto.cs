namespace Domain.Dtos
{
    public class ServicePreviewDto
    {
        public Guid Id { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }
    }
}
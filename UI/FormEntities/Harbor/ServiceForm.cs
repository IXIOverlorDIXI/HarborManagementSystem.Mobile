namespace UI.FormEntities.Harbor
{
    public class ServiceForm
    {
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }
        
        public Guid Id { get; set; }
        
        public Guid HarborId { get; set; }
    }
}
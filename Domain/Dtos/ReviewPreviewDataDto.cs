namespace Domain.Dtos
{
    public class ReviewPreviewDataDto
    {
        public Guid Id { get; set; }
        
        public int ReviewMark { get; set; }
        
        public string ReviewBody { get; set; }
        
        public string ReviewPluses { get; set; }
        
        public string ReviewMinuses { get; set; }
        
        public DateTime Date { get; set; }
        
        public Guid BerthId { get; set; }
        
        public string AuthorDisplayName { get; set; }
        
        public string AuthorPhotoUrl { get; set; }
        
        public bool DoesAuthorPay { get; set; }
        
        public bool IsAuthor { get; set; }
    }
}
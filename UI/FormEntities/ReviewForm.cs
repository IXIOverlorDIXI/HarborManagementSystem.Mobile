namespace UI.FormEntities
{
    public class ReviewForm
    {
        public int ReviewMark { get; set; }
        
        public string ReviewBody { get; set; }
        
        public string ReviewPluses { get; set; }
        
        public string ReviewMinuses { get; set; }

        public Guid BerthId { get; set; }
    }
}
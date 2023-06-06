namespace Domain.Dtos
{
    public class ShipPhotoDataDto
    {
        public string FileNameWithExtension { get; set; }
        
        public byte[] FileStream { get; set; }
        
        public Guid ShipId { get; set; }
    }
}
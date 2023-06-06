namespace Domain.Dtos
{
    public class ProfilePhotoDataDto
    {
        public string FileNameWithExtension { get; set; }
        
        public byte[] FileStream { get; set; }
    }
}
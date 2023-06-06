namespace Domain.Dtos;

public class HarborPhotoDataDto
{
    public string FileNameWithExtension { get; set; }
        
    public byte[] FileStream { get; set; }
        
    public Guid HarborId { get; set; }
}
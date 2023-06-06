namespace Domain.Dtos;

public class HarborDocumentDataDto
{
    public string FileNameWithExtension { get; set; }
        
    public byte[] FileStream { get; set; }
        
    public Guid HarborId { get; set; }
}
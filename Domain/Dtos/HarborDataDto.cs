namespace Domain.Dtos;

public class HarborDataDto
{
    public Guid Id { get; set; }
    
    public string DisplayName { get; set; }
        
    public string Description { get; set; }
        
    public string SupportEmail { get; set; }
        
    public string SupportPhoneNumber { get; set; }
        
    public string BIC { get; set; }
        
    public string IBAN { get; set; }

    public double GeolocationLongitude { get; set; }
    
    public double GeolocationLatitude  { get; set; }
    
    public string OwnerName { get; set; }
}
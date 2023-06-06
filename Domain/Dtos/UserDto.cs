namespace Domain.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Token { get; set; }
        
        public string Photo { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
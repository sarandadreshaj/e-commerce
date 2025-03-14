namespace Application.DTOs{
    public class CreateUserDto
    {
        public string Username{get; set;}
        public string PasswordHash{get; set;}
        public string Email{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Role{get; set;}
    }
}
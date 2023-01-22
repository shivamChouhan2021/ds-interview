namespace DotNetCoreWebApp.Data.Dto
{
    public class AccountDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginRequestDto
    {        
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }        
    }
}

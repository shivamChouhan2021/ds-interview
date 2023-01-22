using System.Collections.Generic;

namespace DotNetCoreWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}

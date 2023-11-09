using Microsoft.Extensions.Configuration;

namespace TestSolution.Models
{
    public  class User
    {
        [ConfigurationKeyName("Email")]
        public string Email { get; set; }
        [ConfigurationKeyName("Password")]
        public string Password { get; set; }
        [ConfigurationKeyName("FullName")]
        public string FullName { get; set; }

        public User()
        {
            Email = string.Empty;
            Password = string.Empty;
            FullName = string.Empty;
        }
    }
}

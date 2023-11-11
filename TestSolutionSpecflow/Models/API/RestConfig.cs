using Microsoft.Extensions.Configuration;

namespace TestSolution.Models
{
    public class RestConfig
    {
        [ConfigurationKeyName("Email")]
        public string Email { get; set; }
        [ConfigurationKeyName("Password")]
        public string Password { get; set; }
        [ConfigurationKeyName("FullName")]
        public string FullName { get; set; }
        [ConfigurationKeyName("Url")]
        public string Url { get; set; }

        public RestConfig()
        {
            Email = string.Empty;
            Password = string.Empty;
            FullName = string.Empty;
            Url = string.Empty;
        }
    }
}
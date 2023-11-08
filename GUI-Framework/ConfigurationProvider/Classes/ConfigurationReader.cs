using Microsoft.Extensions.Configuration;

namespace ConfigurationProvider.Classes
{
    public class ConfigurationReader
    {
        private readonly IConfigurationRoot _root;
        public ConfigurationReader(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"{nameof(filePath)} does not exist.", nameof(filePath));

            _root = new ConfigurationBuilder().AddJsonFile(filePath, false, true).Build();
        }

        public T GetConfiguration<T>()
        {
            var configuration = _root.Get<T>();

            if (configuration is null)
                throw new InvalidCastException($"The {nameof(configuration)} cannot be null");

            return configuration;
        }

        public T GetConfigurationSection<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

            var section = _root.GetSection(key);
            var configuration = section.Get<T>();

            if (configuration is null)
                throw new InvalidCastException($"The {nameof(configuration)} cannot be null");

            return configuration;
        }
    }
}
using ConfigurationProvider.Enums;

namespace ConfigurationProvider.Elements
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ElementAttribute : Attribute
    {
        public string Name { get; }
        public ElementType Type { get; }

        public ElementAttribute(string name, ElementType type)
        {
            Name = name;
            Type = type;
        }
    }
}

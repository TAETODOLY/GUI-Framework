namespace ConfigurationProvider.Classes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewAttribute : Attribute
    {
        public string Name { get; }
        public ViewAttribute(string name)
        {
            Name = name;
        }
    }
}

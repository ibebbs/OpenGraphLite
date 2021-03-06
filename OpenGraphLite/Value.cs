namespace OpenGraphLite
{
    public class Value
    {
        public Value(string property, string content)
        {
            Property = property;
            Content = content;
        }

        public string Property { get; }
        public string Content { get; }
    }
}

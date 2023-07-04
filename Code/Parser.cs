using Nail.Code.Element;
using Nail.Code.Table;

namespace Nail.Code
{
    public static class Parser
    {
        private static readonly List<IElement> _elements = new();

        public static void Add(IElement element) =>
            _elements.Add(element);
        public static Node Parse(string code) =>
            Parse(new Node(Token.None.ToString(), code), code);
        public static Node Parse(Node parent, string code)
        {
            using var stream = new CodeStream(code);
            char current;
            var node = new Node(Token.None.ToString(), "");
            while (stream.EndOfStream == false)
            {
                current = (char)stream.Read(); // read every char

                foreach (var e in _elements) // run every parser
                {
                    if (e.Type == Token.None.ToString())
                        throw new System.Exception("IElement.Type cannot be of type None");
                    if (e.IsElement(current) == false) continue;

                    if (parent.Type != e.Type)
                    {
                        node = new Node(e.Type);
                        parent.Add(node.Parse());
                    }
                }
                node.Add(current);
            }
            return parent;
        }
    }
}

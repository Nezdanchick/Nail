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
            Parse(new Node(code), code);
        public static Node Parse(Node parent, string code)
        {
            using var stream = new CodeStream(code);
            var node = new Node("");
            char current;
            try
            {
                while (stream.EndOfStream == false)
                {
                    current = (char)stream.Read(); // read every char

                    foreach (var e in _elements) // run every parser
                    {
                        if (e.Type == Token.None.ToString())
                            throw new Exception($"IElement.Type cannot be of type {e.Type}");
                        if (e.IsElement(current) == false) continue;

                        string lastCode = code[stream.Position..];
                        int parsed = e.Parse(lastCode);

                        node = new Node(e.Type, current + stream.Read(parsed));
                        parent.Add(node.Parse());
                    }
                }
            }
            catch (Exception e) { stream.Crash(e.Message); }
            return parent;
        }
    }
}

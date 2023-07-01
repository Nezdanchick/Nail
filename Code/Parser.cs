using Nail.Code.Element;

namespace Nail.Code
{
    public static class Parser
    {
        private static List<IElement> _elements = new List<IElement>();

        public static void Add(IElement element) =>
            _elements.Add(element);
        public static void Parse(string code)
        {
            foreach (var e in _elements)
            {
                if (e.IsElement(code[0])) e.Parse(code);
            }
        }
    }
}

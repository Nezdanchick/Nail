using Nail.Code.Table;

namespace Nail.Code.Element
{
    public interface IElement
    {
        public string Type { get; }
        public bool IsElement(char character);
        public string Parse(string code);
    }
}

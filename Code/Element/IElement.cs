namespace Nail.Code.Element
{
    public interface IElement
    {
        public bool IsElement(char character);
        public string Parse(string code);
    }
}

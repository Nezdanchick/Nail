namespace Nail.Code.Element
{
    public interface IElement
    {
        /// <summary>
        /// String, represents type of code element
        /// </summary>
        public string Type { get; }
        public bool IsElement(char character);
        public int Parse(string code);
    }
}

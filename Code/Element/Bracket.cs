using Nail.Code.Table;

namespace Nail.Code.Element
{
    public class Bracket : IElement
    {
        public string Type => Token.Bracket.ToString();

        public bool IsElement(char c) =>
            c == '(' || c == '{' || c == '[';
        public int Parse(string code)
        {
            char s = code[0];
            var e = s switch
            {
                '(' => ')',
                '{' => '}',
                '[' => ']',
                _ => throw new Exception("Parser error: not a bracket"),
            };
            int result = code.IndexOf(e);
            if (result == -1)
                throw new Exception("Сlosing bracket required");

            return result;
        }
    }
}

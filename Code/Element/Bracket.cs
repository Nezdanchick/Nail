using System.Reflection.Metadata.Ecma335;

namespace Nail.Code.Element
{
    internal class Bracket : IElement
    {
        public bool IsElement(char c) =>
            c == '(' || c == '[' || c == '{' || c == '<';
        public string Parse(string code)
        {
            // find close bracket '(' is ')', '[' is ']', etc.
            char s = code[0];
            char e = s == '(' ? ')' : s == '[' ? ']' : s == '{' ? '}' : s == '<' ? '>' : ' ';
            if (e == ' ') return "";
            return code[0..code.IndexOf(e)];
        }
    }
}

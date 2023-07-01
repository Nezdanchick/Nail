using System;
using System.Xml.Linq;

namespace Nail.Code
{
    public static class Interpreter
    {
        public static void Run(string code)
        {
            var args = code.Split(' ');
            foreach (var arg in args)
            {
                Console.Write(arg + " ");
            }
        }

        private static bool IsBracket(this char c) =>
            c == '(' || c == '[' || c == '{' || c == '<';
        private static string ParseBracket(this string code)
        {
            // find close bracket '(' is ')', '[' is ']', etc.
            //char b = e == '(' ? ')' : e == '[' ? ']' : e == '{' ? '}' : ' ';
            //return code[++i..code.IndexOf(b, i)]);
            return code;
        }
        //TODO: simplify Parse_??? methods creation process
    }
}

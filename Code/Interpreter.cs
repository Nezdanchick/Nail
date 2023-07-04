using Nail.Code.Element;
using System;
using System.Net.WebSockets;
using System.Xml.Linq;

namespace Nail.Code
{
    public class Interpreter
    {
        public string Code { get => _code ?? ""; }
        private readonly string? _code;

        public Interpreter(string code) : this() =>
            _code = code;
        private Interpreter()
        {
            Parser.Add(new Bracket());
        }

        public void Run()
        {
            var ast = Parser.Parse(Code).ToString();
            Console.WriteLine(ast);
        }
    }
}

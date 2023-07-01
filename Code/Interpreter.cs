using System;
using System.Net.WebSockets;
using System.Xml.Linq;

namespace Nail.Code
{
    public class Interpreter
    {
        private readonly string _code;

        public Interpreter(string code) => _code = code;

        public void Run()
        {
            using var stream = new CodeStream(_code);
            Console.WriteLine(stream.ReadToEnd());
            stream.Crash("test");
        }
    }
}

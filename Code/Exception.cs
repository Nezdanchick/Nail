using System;

namespace Nail.Code
{
    public class Exception : System.Exception
    {
        public Exception(string message) : base(message) =>
            Console.Error.WriteLine(message);
    }
}

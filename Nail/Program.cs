using Nail.Code;
using Nail.Code.Element;

namespace Nail
{
    class Program
    {
        private const string _welcome = "Welcome to nail!\n" +
            "Nail is Nezdanchick's Awesome Interpreted Language";
        private const string _prompt = ">";

        private static void Main(string[] args)
        {
            Console.Title = $"Nail";

            { // add default code elements
                Parser.Add(new Bracket());
            }

            if (args.Length > 0)
            {
                foreach (string arg in args)
                    Run(arg);
                return;
            } // run args and exit

            Console.WriteLine(_welcome);

            string? line = "";
            while (line != "exit")
            {
                Console.Write(_prompt);
                line = Console.ReadLine();

                if (line == null || line == "")
                    continue;
                Run(line);
                Console.WriteLine();
            } // run every user command and exit on "exit" command
        }
        private static void Run(string arg)
        {
            if (File.Exists(arg)) // if arg is path
                arg = File.ReadAllText(arg); // convert path to code
            new Interpreter(arg).Run(); // run code
        }
    }
}
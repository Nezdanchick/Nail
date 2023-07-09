namespace Nail.Code
{
    internal class CodeStream : StreamReader
    {
        public int Position { get => _position; }
        public int Length { get => (int)_stream.Length; }

        private readonly Stream _stream;
        private int _position = -1;
        private int _collumn = 0;   // x
        private int _line = 0;      // y

        private CodeStream(string code, Stream stream) : base(stream)
        {
            _stream = stream;
            var writer = new StreamWriter(stream);
            writer.Write(code);
            writer.Flush();
            stream.Position = 0;
        }
        public CodeStream(string code) : this(code, new MemoryStream()) { }

        public override int Read()
        {
            var c = base.Read();
            _position++;
            if (c == '\n')
            {
                _line++;
                _collumn = 0;
            }
            else _collumn++;
            return c;
        }
        public string Read(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
                result += (char)Read();
            return result;
        }
        public override string? ReadLine()
        {
            int line = _line;
            string result = "";
            for (int i = Position; _line == line; i++)
                result += (char)Read();
            return result;
        }
        public override string ReadToEnd()
        {
            string result = "";
            for (int i = Position; !EndOfStream; i++)
                result += (char)Read();
            return result;
        }
        public void Crash(string message)
        {
            Console.Error.WriteLine($"{message} exception on row:{_line} collumn:{_collumn}");
            Console.Write("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

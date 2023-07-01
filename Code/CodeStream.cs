namespace Nail.Code
{
    internal class CodeStream : StreamReader
    {
        private readonly Stream _stream;
        public long Position { get => _stream.Position; }  // position in stream
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
            if (c == '\n')
            {
                _line++;
                _collumn = 0;
            }
            else _collumn++;
            return c;
        }
        public override string ReadToEnd()
        {
            string result = "";
            for (long i = Position; !EndOfStream; i++)
                result += (char)Read();
            return result;
        }
        public void Crash(string message) =>
            throw new Exception($"{message} exception on row:{_line} collumn:{_collumn}");
    }
}

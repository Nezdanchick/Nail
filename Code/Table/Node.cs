namespace Nail.Code.Table
{
    public class Node
    {
        public string Type { get; private set; }
        public string Code { get; private set; } = "";
        public List<Node> Nodes { get; private set; } = new();

        public Node(string type, string code)
        {
            Type = type;
            Code = code;
        }
        public Node(string code) : this(Token.None.ToString(), code) { } // for parent

        public Node Parse() => Parser.Parse(this, Code[1..]);
        /// <summary>
        /// Add child
        /// </summary>
        /// <param name="node">child Node</param>
        public void Add(Node node) =>
            Nodes.Add(node);
        public void Add(char c) =>
            Code += c;
        public void Add(string s) =>
            Code += s;
        /// <summary>
        /// for debugging purpose only
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            result += $"Type: {Type}\nCode:\n";
            foreach (var line in Code.Split('\n'))
            {
                result += $"\t{ line }\n";
            }
            foreach (Node node in Nodes)
            {
                result += node.ToString();
            }
            return result;
        }
    }
}

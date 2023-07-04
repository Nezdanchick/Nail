namespace Nail.Code.Table
{
    public class Node
    {
        public string Type { get; private set; }
        public string Code { get; private set; } = "";
        public List<Node> Nodes { get; private set; } = new();

        public Node(string type) =>
            Type = type;
        public Node(string type, string code) : this(type) =>
            Code = code;

        public Node Parse() => Parser.Parse(this, Code);
        /// <summary>
        /// Add child
        /// </summary>
        /// <param name="node">child Node</param>
        public void Add(Node node) =>
            Nodes.Add(node);
        /// <summary>
        /// Add char
        /// </summary>
        /// <param name="c">character</param>
        public void Add(char c) =>
            Code += c;
        /// <summary>
        /// for debugging purpose only
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            result += $"Type: {Type}\nCode:\n{Code}\n### EOF ###\n";
            foreach (Node node in Nodes)
            {
                result += node.ToString();
            }
            return result;
        }
    }
}

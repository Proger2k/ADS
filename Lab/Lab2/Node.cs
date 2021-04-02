namespace Lab2
{
    public class Node
    {
        public double Data { get; set; }
        public Node Parent { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(double data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return $"{Data}"; 
        }
    }
}
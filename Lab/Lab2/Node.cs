namespace Lab2
{
    public class Node<T>
    {
        private T Data { get; set; }
        private Node<T> Parent { get; set; }
        private Node<T> LeftChild { get; set; }
        private Node<T> RightChild { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return $"{Data}"; 
        }
    }
}
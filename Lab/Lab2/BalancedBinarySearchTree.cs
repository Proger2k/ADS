namespace Lab2
{
    public class BalancedBinarySearchTree
    {
        public Node MainNode { get; set; }
        public int Count { get; set; }

        public BalancedBinarySearchTree(double mainNode)
        {
            Count = 0;
            MainNode = new Node(mainNode);;
        }

        public void Insert(Node node, double x)
        {
            if (node == null)
                node = MainNode;
            
            if(node.Data.Equals(x))
                return;
            
            if (node.Data > x)
                if (node.LeftChild == null)
                    node.LeftChild = new Node(x);
                else
                    Insert(node.LeftChild, x);
            else 
                if (node.RightChild == null)
                    node.RightChild = new Node(x);
                else
                    Insert(node.RightChild, x);
        }

        public void DeleteNode(Node node, double x)
        {
            if(node == null)
                return;
            
            if (node.Data.Equals(x))
            {
                
            }

            if (x < node.Data)
                DeleteNode(node.LeftChild, x);
            else
                DeleteNode(node.RightChild, x);
        }

        private void ChangeChild(Node node, Node childNode)
        {
            if (node.Parent.LeftChild == node)
                node.Parent.LeftChild = childNode;
            else
                node.Parent.RightChild = childNode;
        }
    }
}
using System;

namespace Lab2
{
    public class Node<T> : IComparable
    where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        
        public Node(T data)
        {
            Data = data;
        }
        
        public Node(T data, Node<T> leftChild, Node<T> rightChild)
        {
            Data = data;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public void Insert(T data)
        {
            var node = new Node<T>(data);
            
            if (Data.CompareTo(data) == 1)
            {
                if (LeftChild == null)
                {
                    LeftChild = node;
                    LeftChild.Parent = this;
                }
                else
                {
                    LeftChild.Insert(data);
                }
            }
            else
            {
                if (RightChild == null)
                {
                    RightChild = node;
                    RightChild.Parent = this;
                }
                else
                {
                    RightChild.Insert(data);
                }
            }
        }

        public override string ToString()
        {
            return $"{Data}"; 
        }

        public int CompareTo(object obj)
        {
            if (obj is Node<T> objData)
                return Data.CompareTo(objData);
            
            throw new ArgumentException("Не совпадение типов");
        }
    }
}
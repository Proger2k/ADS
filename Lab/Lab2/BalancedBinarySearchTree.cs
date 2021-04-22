using System;
using System.Collections.Generic;

namespace Lab2
{
    public class BalancedBinarySearchTree<T>
    where T: IComparable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public BalancedBinarySearchTree()
        {
        }

        public void Insert(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }
            
            Root.Insert(data);
            Count++;
        }

        public List<T> Preorder()
        {
            if (Root == null)
                return new List<T>();

            return Preorder(Root);
        }

        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();
            
            if (node != null)
            {
                list.Add(node.Data);
                if (node.LeftChild != null)
                {
                    list.AddRange(Preorder(node.LeftChild));
                }

                if (node.RightChild != null)
                {
                    list.AddRange(Preorder(node.RightChild));
                }
            }

            return list;
        }
        
        public List<T> Postorder()
        {
            if (Root == null)
                return new List<T>();

            return Postorder(Root);
        }
        
        private List<T> Postorder(Node<T> node)
        {
            var list = new List<T>();
            
            if (node != null)
            {
                if (node.LeftChild != null)
                {
                    list.AddRange(Postorder(node.LeftChild));
                }

                if (node.RightChild != null)
                {
                    list.AddRange(Postorder(node.RightChild));
                }
                
                list.Add(node.Data);
            }

            return list;
        }
        
        public List<T> Inorder()
        {
            if (Root == null)
                return new List<T>();

            return Inorder(Root);
        }
        
        private List<T> Inorder(Node<T> node)
        {
            var list = new List<T>();
            
            if (node != null)
            {
                if (node.LeftChild != null)
                {
                    list.AddRange(Inorder(node.LeftChild));
                }
                
                list.Add(node.Data);
                
                if (node.RightChild != null)
                {
                    list.AddRange(Inorder(node.RightChild));
                }
            }

            return list;
        }
    }
}
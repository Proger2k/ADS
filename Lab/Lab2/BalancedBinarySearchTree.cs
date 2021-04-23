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
        
        #region 1) PrintSorted
        
        /// <summary>
        /// It prints keys of a BBST in 2 lines:
        ///     -Sorted in ascending order (first line)
        ///     -Sorted in descending order (second line )
        ///
        /// Inorder
        /// </summary>
        public void PrintSorted()
        {
            foreach (var item in Ascending())
            {
                Console.Write(item + " ");
            }
            
            Console.WriteLine();
            
            foreach (var item in Descending())
            {
                Console.Write(item + " ");
            }
        }
        
        private List<T> Ascending ()
        {
            if (Root == null)
                return new List<T>();

            return Ascending(Root);
        }
        
        private List<T> Ascending(Node<T> node)
        {
            var list = new List<T>();
            
            if (node != null)
            {
                if (node.LeftChild != null)
                {
                    list.AddRange(Ascending(node.LeftChild));
                }
                
                list.Add(node.Data);
                
                if (node.RightChild != null)
                {
                    list.AddRange(Ascending(node.RightChild));
                }
            }

            return list;
        }
        
        private List<T> Descending ()
        {
            if (Root == null)
                return new List<T>();

            return Descending(Root);
        }
        
        private List<T> Descending(Node<T> node)
        {
            var list = new List<T>();
            
            if (node != null)
            {
                if (node.RightChild != null)
                {
                    list.AddRange(Descending(node.RightChild));
                }
                
                list.Add(node.Data);
                
                if (node.LeftChild != null)
                {
                    list.AddRange(Descending (node.LeftChild));
                }
            }

            return list;
        }

        #endregion

        #region 2) CountNode
        
        private int _countNode;
        
        /// <summary>
        /// It count the number of left son nodes in a BBST.
        ///
        /// Inorder
        /// </summary>
        public int CountNode()
        {
            _countNode = 0;
            
            if (Root == null)
                return _countNode;

            CountNode(Root);

            return _countNode;
        }
        
        private void CountNode(Node<T> node)
        {
            if (node != null)
            {
                if (node.LeftChild != null)
                {
                    _countNode++;
                    CountNode(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    CountNode(node.RightChild);
                }
            }
        }

        #endregion
        
        #region 3) SumKeys

        private double _sumKeys;
        
        /// <summary>
        /// It finds the sum of keys in right son nodes in a BBST.
        ///
        /// Inorder
        /// </summary>
        public double SumKeys()
        {
            _sumKeys = 0;
            
            if (Root == null)
                return _countNode;

            SumKeys(Root);

            return _sumKeys;
        }
        
        private void SumKeys(Node<T> node)
        {
            if (node != null)
            {
                if (node.LeftChild != null)
                {
                    SumKeys(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    _sumKeys += Convert.ToDouble((node.RightChild.Data)); 
                    SumKeys(node.RightChild);
                }
            }
        }

        #endregion

        #region DeleteEven
        /// <summary>
        /// It deletes all even keys from a BBST. (Result is also a BBST) 
        /// </summary>
        
        

        #endregion
        
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


    }
}
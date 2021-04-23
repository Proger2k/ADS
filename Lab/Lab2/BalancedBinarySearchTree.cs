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

        #region 4) DeleteEven
        
        /// <summary>
        /// It deletes all even keys from a BBST. (Result is also a BBST)
        ///
        /// Preorder
        /// </summary>
        public void DeleteEven()
        {
            if (Root == null)
                return;

            FindNode(Root);
        }

        private void FindNode(Node<T> node)
        {
            if (node != null)
            {
                if (Convert.ToInt32(node.Data) % 2 == 0)
                    DeleteEven(node);
                    
                if (node.LeftChild != null)
                {
                    FindNode(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    FindNode(node.RightChild);
                }
            }
        }

        private T _min;
        private void DeleteEven(Node<T> node)
        {
            if (node.LeftChild == null && node.RightChild == null)
                RemoveNodeWithOneChildOrNoChild(node, null);
            else if (node.LeftChild != null && node.RightChild == null)
                RemoveNodeWithOneChildOrNoChild(node, node.LeftChild);
            else if (node.LeftChild == null && node.RightChild != null) 
                RemoveNodeWithOneChildOrNoChild(node, node.RightChild);
            else
            {
                if(node.RightChild != null)
                    _min = node.RightChild.Data;
                
                RemoveNodeWithTwoChild(node);
                node.Data = _min;
            }
        }
        
        private void RemoveNodeWithOneChildOrNoChild(Node<T> parent, Node<T> child)
        {
            if (parent.Parent.LeftChild == parent)
            {
                parent.Parent.LeftChild = child;
            }
            else if (parent.Parent.RightChild == parent)
            {
                parent.Parent.RightChild = child;
            }
            
            if(child != null)
                child.Parent = parent.Parent;
        }
        private void RemoveNodeWithTwoChild(Node<T> node)
        {
            if(node == null)
                return;
            
            if(node.LeftChild == null && (_min.CompareTo(node.Data) == 1 || _min.CompareTo(node.Data) == 0))
                RemoveNodeWithOneChildOrNoChild(node, node.RightChild);
            
            if(_min.CompareTo(node.Data) == 1)
                _min = node.Data;
            
            RemoveNodeWithTwoChild(node.LeftChild);
        }

        #endregion

        #region 5) FindMiddle()

        

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
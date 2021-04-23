using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Lab2
{
    public class BalancedBinarySearchTree<T>
    where T: IComparable
    {
        private Node<T> Root { get; set; }

        public BalancedBinarySearchTree()
        {
        }

        public void Insert(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                return;
            }
            
            Root.Insert(data);
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

            while (Convert.ToInt32(Root.Data) % 2 == 0)
            {
                DeleteRoot();
            }

            DeleteEven(Root);
            
            //TODO 
        }
        
        private void DeleteEven(Node<T> node)
        {
            if (node != null)
            {
                if (Convert.ToInt32(node.Data) % 2 == 0)
                    Delete(node);
                    
                if (node.LeftChild != null)
                {
                    DeleteEven(node.LeftChild);
                }
                
                if (Convert.ToInt32(node.Data) % 2 == 0)
                    Delete(node);
                
                if (node.RightChild != null)
                {
                    DeleteEven(node.RightChild);
                }
                
                if (Convert.ToInt32(node.Data) % 2 == 0)
                    Delete(node);
            }
        }

        private T _min;
        private void Delete(Node<T> node)
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
                
                RemoveNodeWithTwoChild(node.RightChild);
                node.Data = _min;
            }
        }
        
        private void DeleteRoot()
        {
            if (Root.LeftChild == null && Root.RightChild == null)
                Root = null;
            else if (Root.LeftChild != null && Root.RightChild == null)
                Root = Root.LeftChild;
            else if (Root.LeftChild == null && Root.RightChild != null)
                Root = Root.RightChild;
            else
            {
                if(Root.RightChild != null)
                    _min = Root.RightChild.Data;
                
                RemoveNodeWithTwoChild(Root.RightChild);
                Root.Data = _min;
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

        #region 5) FindMiddle

        private T _max;
        private double _average;

        /// <summary>
        /// It returns the tree key which is the nearest to the Valuemid = (keymin + keymax) / 2.
        /// </summary>
        public double FindMiddle()
        {
            if (Root == null)
                return Double.MinValue;
            
            FindMax(Root);
            FindMin(Root);
            
            _average = (Convert.ToDouble(_max) + Convert.ToDouble(_min)) / 2;
            
            _smallestDifference = Double.MaxValue;
            
            FindMiddle(Root);

            return _nodeData;
        }
        
        private void FindMax(Node<T> node)
        {
            if (node == null)
                return;

            _max = node.Data;
            
            FindMax(node.RightChild);
        }

        private void FindMin(Node<T> node)
        {
            if (node == null)
                return;
            
            _min = node.Data;
            
            FindMin(node.LeftChild);
        }
        
        private double _smallestDifference;
        private double _nodeData;
        
        private void FindMiddle(Node<T> node)
        {
            if (node != null)
            {
                double difference = _average - Convert.ToDouble(node.Data);
                if (Math.Abs(difference) < Math.Abs(_smallestDifference))
                {
                    _smallestDifference = difference;
                    _nodeData = Convert.ToDouble(node.Data);
                }
                
                if (node.LeftChild != null)
                {
                    FindMiddle(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    FindMiddle(node.RightChild);
                }
            }
        }

        #endregion

        #region 6) DeleteDuplicate
        
        /// <summary>
        /// It deletes all duplicate values from a BBST. (Result is also a BBST with a single value of each key.)
        /// </summary>
        public void DeleteDuplicate()
        {
            if (Root == null)
                return;

            while (Root.Data.Equals(Root.RightChild.Data))
            {
                DeleteRoot();
            }
            
            DeleteDuplicate(Root);
            
            //TODO 
        }
        
        private void DeleteDuplicate(Node<T> node)
        {
            if (node != null)
            {
                if (node.RightChild != null && node.Data.Equals(node.RightChild.Data))
                    Delete(node);
                    
                if (node.LeftChild != null)
                {
                    DeleteDuplicate(node.LeftChild);
                }
                
                if (node.RightChild != null && node.Data.Equals(node.RightChild.Data))
                    Delete(node);
                
                if (node.RightChild != null)
                {
                    DeleteDuplicate(node.RightChild);
                }
                
                if (node.RightChild != null && node.Data.Equals(node.RightChild.Data))
                    Delete(node);
            }
        }

        #endregion

        #region 7) FindSecondLargest

        private double _secondLargest;
        
        /// <summary>
        /// It returns the second largest key of a BBST without deleting it
        /// </summary>
        /// <returns></returns>
        public double FindSecondLargest()
        {
            FindMax(Root);

            _secondLargest = Convert.ToDouble(_max) - 100000;
            FindSecondLargest(Root);
            
            return _secondLargest;
        }

        private void FindSecondLargest(Node<T> node)
        {
            if (node == null)
                return;

            if (Convert.ToDouble(node.Data) < Convert.ToDouble(_max))
                _secondLargest = Convert.ToDouble(node.Data);
            
            FindSecondLargest(node.RightChild);
        }
        
        #endregion

        #region 8) CopyBBST

        private BalancedBinarySearchTree<T> _tree;
        
        /// <summary>
        /// It creates and returns a copy of a given BBST.
        /// </summary>
        public BalancedBinarySearchTree<T> CopyBBST()
        {
            _tree = new BalancedBinarySearchTree<T>();

            CopyBBST(Root);
            
            return _tree;
        }

        private void CopyBBST(Node<T> node)
        {
            if(node == null)
                return;
            
            _tree.Insert(node.Data);

            CopyBBST(node.LeftChild);
            CopyBBST(node.RightChild);
        }
        
        #endregion

        #region 9) InsertBBST

        public void InsertBBST(BalancedBinarySearchTree<T> tree)
        {
            InsertBBST(tree.Root);
            
            //TODO
        }

        private void InsertBBST(Node<T> node)
        {
            if(node == null)
                return;
            
            Insert(node.Data);

            InsertBBST(node.LeftChild);
            InsertBBST(node.RightChild);
            
        }

        #endregion

        #region MyRegion

        

        #endregion

        #region Postorder
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
        

        #endregion
        
    }
}
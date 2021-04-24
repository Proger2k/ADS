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

        /// <summary>
        /// It inserts al keys of BBST2 into a BBST1. Result is BBST1 which is balanced.
        /// </summary>
        /// <param name="tree"></param>
        public void InsertBBST(BalancedBinarySearchTree<T> tree)
        {
            InsertBBST(tree.Root);
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

        #region 10) ContainsBBST 

        /// <summary>
        /// It determines if all keys of BBST2 are contained in BBST1. If so it returns true, otherwise false.
        /// </summary>
        public bool ContainsBBST(BalancedBinarySearchTree<T> tree)
        {
            _containNode = false;
            _containsBBST = true;
            
            Traversal(tree.Root);

            return _containsBBST;
        }

        private bool _containNode;
        private bool _containsBBST;

        private void Traversal(Node<T> node)
        {
            if(node == null)
                return;

            ContainsBBST(Root, node);
            if (!_containNode)
                _containsBBST = false;

            _containNode = false;
            
            Traversal(node.LeftChild);
            Traversal(node.RightChild);
        }

        private void ContainsBBST(Node<T> node, Node<T> val)
        {
            if(node == null)
                return;

            if (node.Data.Equals(val.Data))
                _containNode = true;
            
            ContainsBBST(node.LeftChild, val);
            ContainsBBST(node.RightChild, val);
        }

        #endregion

        #region 11) IsBalanced

        private bool _isBalanced;
        
        /// <summary>
        /// It returns true if the calling object is a balanced binary search tree, otherwise false.
        /// </summary>
        public bool IsBalanced()
        {
            CalculateSubtreeHeights();
            _isBalanced = true;
            
            IsBalanced(Root);
            
            return _isBalanced;
        }
        private void CalculateSubtreeHeights()
        {
            if (Root == null)
                return;

            CalculateSubtreeHeights(Root);
        }
        
        private void CalculateSubtreeHeights(Node<T> node)
        {
            if (node == null)
                return;
            
            if (node.LeftChild != null)
            {
                CalculateSubtreeHeights(node.LeftChild);
            }

            if (node.LeftChild == null)
                node.LeftSubtreeHeight = 0;
            else
            {
                if(node.LeftChild.LeftSubtreeHeight > node.RightSubtreeHeight)
                    node.LeftSubtreeHeight = node.LeftChild.LeftSubtreeHeight + 1;
                else
                    node.LeftSubtreeHeight = node.LeftChild.RightSubtreeHeight + 1;
            }


            if (node.RightChild != null)
            {
                CalculateSubtreeHeights(node.RightChild);
            }
            
            if (node.RightChild == null)
                node.RightSubtreeHeight = 0;
            else
            {
                if(node.RightChild.RightSubtreeHeight > node.RightChild.LeftSubtreeHeight)
                    node.RightSubtreeHeight = node.RightChild.RightSubtreeHeight + 1;
                else
                    node.RightSubtreeHeight = node.RightChild.LeftSubtreeHeight + 1;
            }
        }

        private void IsBalanced(Node<T> node)
        {
            if (node == null)
                return;

            if (node.LeftSubtreeHeight > node.RightSubtreeHeight + 1 ||
                node.LeftSubtreeHeight + 1 < node.RightSubtreeHeight)
                _isBalanced = false;
            
            IsBalanced(node.LeftChild);
            IsBalanced(node.RightChild);
        }

        #endregion IsBalanced

        #region 12) EqualsBBST

        private bool _isEqualsBBST;
        private bool _isEqualNode;
        
        /// <summary>
        /// It returns true if two BBSTs are equal ( if tree shapes and corresponding keys are the same). Otherwise it returns false.
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public bool EqualsBBST(BalancedBinarySearchTree<T> tree)
        {
            _isEqualsBBST = true;
            _isEqualNode = false;
            
            EqaulsBBST(tree.Root, Root);
            if (!_isEqualsBBST)
                return false;
            
            _isEqualNode = false;
            EqaulsBBST(Root, tree.Root);
            
            return _isEqualsBBST;
        }

        private void EqaulsBBST(Node<T> node, Node<T> root)
        {
            if (node == null)
                return;

            FindEqual(root, node);
            if (!_isEqualNode)
                _isEqualsBBST = false;
            
            _isEqualNode = false;
            
            EqaulsBBST(node.LeftChild, root);
            EqaulsBBST(node.RightChild, root);
        }

        private void FindEqual(Node<T> node, Node<T> val)
        {
            if (node == null)
                return;

            if (node.Data.Equals(val.Data) && node.LeftSubtreeHeight == val.LeftSubtreeHeight &&
                node.RightSubtreeHeight == val.RightSubtreeHeight)
                _isEqualNode = true;
            
            FindEqual(node.LeftChild, val);
            FindEqual(node.RightChild, val);
        }
        
        #endregion

        #region 13) SymmetricalBBST
        #endregion

        #region 14) FatherNode
        
        /// <summary>
        /// It returns the key of the father node for the node with the argument key, if the argument key belongs to the calling tree object, otherwise it returns -10000.
        /// </summary>
        public double FatherNode(double data)
        {
            FindNode(Root, data);
            if (_requiredNode == null || _requiredNode.Data.Equals(Root.Data))
                return -10000;

            return Convert.ToDouble(_requiredNode.Parent.Data);
        }

        private Node<T> _requiredNode;
        private void FindNode(Node<T> node, double value)
        {
            if(node == null)
                return;

            if ((Convert.ToDouble(node.Data) == value) && _requiredNode == null)
                _requiredNode = node;
            
            FindNode(node.LeftChild, value);
            FindNode(node.RightChild, value);
        }

        #endregion

        #region CommonAncestor

        /// <summary>
        /// ). It returns the lowest common ancestor of the two nodes containing the argument keys.
        /// </summary>

        private int _commonAncestor;
        public int CommonAncestor(int a, int b)
        {
            _commonAncestor = Convert.ToInt32(Root.Data);
            CommonAncestor(Root, a, b);
            
            return _commonAncestor;
        }

        private void CommonAncestor(Node<T> node, int a, int b)
        {
            if(node == null)
                return;

            int data = Convert.ToInt32(node.Data);

            if (data > a && data > b)
                CommonAncestor(node.LeftChild, a, b);
            else if (data <= a && data <= b)
                CommonAncestor(node.RightChild, a, b);
            else
                _commonAncestor = data;
        }
        
        #endregion
    }
}
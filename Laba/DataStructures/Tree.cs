using Laba.DataStructures.Interfaces;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Laba.DataStructures
{
    public class Tree : ITree
    {
        private TreeNode? _root;
        private List<double> _travestingArray;
        public Tree()
        {
            _root = null;
        }
        public void Add(double value)
        {
            if (_root is null)
            {
                _root = new TreeNode(value);
                return;
            }

            if (IfAlreadyExists(value, _root))
                throw new ArgumentException("Element with such value already exists", nameof(value));
            
            TreeNode current = _root;
            do
            {
                if (value < current.Value)
                {
                    if (current.Left is null)
                    {
                        TreeNode node = new TreeNode(value);
                        current.Left = node;
                        node.Parent = current;
                        return;
                    }
                    else
                        current = current.Left;
                }
                else
                {
                    if (current.Right is null)
                    {
                        TreeNode node = new TreeNode(value);
                        current.Right = node;
                        node.Parent = current;
                        return;
                    }
                    else
                        current = current.Right;
                }
            } while (true);
        }

        public string GetPackedArray()
        {
            if (_root is null)
                throw new NullReferenceException(nameof(_root));

            int height = GetTreeHeight();
            
            string?[] packedArray = new string?[(int)Math.Pow(2, height) - 1];
            FillPackedArray(ref packedArray, _root, 0);
            packedArray = packedArray.Select(e => e is null ? "null" : e).ToArray();
            
            return $"[{string.Join(',', packedArray)}]";
        }

        public (double parent, double[]? children) GetParentAndChildren()
        {
            throw new NotImplementedException();
        }

        public string GetTraversing()
        {
            if (_root is null)
                throw new NullReferenceException(nameof(_root));
            
            _travestingArray = new List<double>();
            TraversingRecursion(_root, ref _travestingArray);

            return $"[{string.Join(" -> ", _travestingArray)}]";
        }

        public bool IfExists(double value)
        {
            if (_root is null)
                throw new NullReferenceException(nameof(_root));

            return IfAlreadyExists(value, _root);
        }

        private int GetTreeHeight()
        {
            if (_root is null)
                throw new NullReferenceException(nameof(_root));

            int height = 1;
            TreeNode current = _root;

            return TreeTraverseForHeight(current, height);
        }

        private int TreeTraverseForHeight(TreeNode node, int currentHeight)
        {
            if (node.Left is not null && node.Right is not null)
            {
                return TreeTraverseForHeight(node.Left, currentHeight + 1) >= TreeTraverseForHeight(node.Right, currentHeight + 1) ?
                    TreeTraverseForHeight(node.Left, currentHeight + 1) :
                    TreeTraverseForHeight(node.Right, currentHeight + 1);
            }

            if (node.Left is not null)
                return TreeTraverseForHeight(node.Left, currentHeight + 1);

            if (node.Right is not null)
                return TreeTraverseForHeight(node.Right, currentHeight + 1);

            return currentHeight;
        }

        private void FillPackedArray(ref string?[] packedArray, TreeNode node, int currentIndex)
        {
            packedArray[currentIndex] = node.Value.ToString();

            if (node.Left is not null && node.Right is not null)
            {
                FillPackedArray(ref packedArray, node.Left, currentIndex * 2 + 1);
                FillPackedArray(ref packedArray, node.Right, currentIndex * 2 + 2);
                return;
            }

            if (node.Left is not null)
            {
                FillPackedArray(ref packedArray, node.Left, currentIndex * 2 + 1);
                return;
            }


            if (node.Right is not null)
            {
                FillPackedArray(ref packedArray, node.Right, currentIndex * 2 + 2);
                return;
            }

            return;
        }

        private bool IfAlreadyExists(double value, TreeNode node)
        {
            if (node.Left is not null && node.Right is not null)
            {
                return (node.Value == value) || IfAlreadyExists(value, node.Left) || IfAlreadyExists(value, node.Right);
            }

            if (node.Left is not null)
            {
                return (node.Value == value) || IfAlreadyExists(value, node.Left);
            }


            if (node.Right is not null)
            {
                return (node.Value == value) || IfAlreadyExists(value, node.Right);
            }

            return node.Value == value;
        }

        private void TraversingRecursion(TreeNode node, ref List<double> traversingArray)
        {
            if (node.Left is not null && node.Right is not null)
            {
                TraversingRecursion(node.Left, ref traversingArray);
                TraversingRecursion(node.Right, ref traversingArray);
                traversingArray.Add(node.Value);
                return;
            }
            if (node.Left is not null)
            {
                TraversingRecursion(node.Left, ref traversingArray);
                traversingArray.Add(node.Value);
                return;
            }


            if (node.Right is not null)
            {
                TraversingRecursion(node.Right, ref traversingArray);
                traversingArray.Add(node.Value);
                return;
            }

            traversingArray.Add(node.Value);
            return;
        }
    }
}

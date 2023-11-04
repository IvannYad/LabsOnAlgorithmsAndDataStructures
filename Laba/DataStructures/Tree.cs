using Laba.DataStructures.Interfaces;

namespace Laba.DataStructures
{
    public class Tree : ITree
    {
        private TreeNode? _root;
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
            throw new NotImplementedException();
        }

        public (double parent, double[]? children) GetParentAndChildren()
        {
            throw new NotImplementedException();
        }

        public double[] GetTraversing()
        {
            throw new NotImplementedException();
        }

        public bool IfAlreadyExists()
        {
            throw new NotImplementedException();
        }

        public bool IfExists(double value)
        {
            throw new NotImplementedException();
        }
    }
}

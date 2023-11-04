namespace Laba.DataStructures
{
    public class TreeNode
    {
        public TreeNode(double value)
        {
            Value = value;
        }
        public double Value { get; init; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
        public TreeNode? Parent { get; set; }
    }
}

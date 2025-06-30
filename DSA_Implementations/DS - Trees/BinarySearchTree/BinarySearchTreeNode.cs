namespace DSA_Implementations.DS___Trees.BinarySearchTree;

public class BinarySearchTreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public BinarySearchTreeNode<T> Left { get; set; }
    public BinarySearchTreeNode<T> Right { get; set; }

    public BinarySearchTreeNode(T value)
    {
        this.Value = value;
    }
}
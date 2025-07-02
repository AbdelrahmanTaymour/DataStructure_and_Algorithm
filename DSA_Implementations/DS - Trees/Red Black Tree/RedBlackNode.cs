namespace DSA_Implementations.DS___Trees.Red_Black_Tree;

public class RedBlackNode<T> where T : IComparable<T>
{
    public T Value;
    public RedBlackNode<T> Left, Right, Parent;
    public bool IsRed = true;  // New nodes are red by default

    public RedBlackNode(T value)
    {
        this.Value = value;
    }
}
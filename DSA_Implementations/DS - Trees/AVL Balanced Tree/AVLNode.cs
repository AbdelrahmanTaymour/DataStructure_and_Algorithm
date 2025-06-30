namespace DSA_Implementations.DS___Trees.AVL_Balanced_Tree;

public class AVLNode<T> where T : IComparable<T>
{
    public T Value {get; set; }
    public AVLNode<T> Left { get; set; }
    public AVLNode<T> Right { get; set; }
    public int Height { get; set; }

    public AVLNode(T value)
    {
        this.Value = value;
        this.Height = 1;
    }
}
namespace DSA_Implementations.DS___Trees.BinaryTree;

public class CompleteBinaryTree<T>
{
    public BinaryTreeNode<T> Root { get; private set; }

    public CompleteBinaryTree()
    {
        Root = null;
    }

    public void Insert(T value)
    {
        var newNode = new BinaryTreeNode<T>(value);
        if (Root == null)
        {
            Root = newNode;
            return;
        }
        
        Queue<BinaryTreeNode<T>> q = new Queue<BinaryTreeNode<T>>();
        q.Enqueue(Root);

        while (q.Count > 0)
        {
            var current = q.Dequeue();
            if (current.Left == null)
            {
                current.Left = newNode;
                break;
            }
            q.Enqueue(current.Left);

            if (current.Right == null)
            {
                current.Right = newNode;
                break;
            }
            q.Enqueue(current.Right);
        }
    }

    public void PrintTree()
    {
        PrintTree(Root, 0);
    }
    
    private void PrintTree(BinaryTreeNode<T> root, int space)
    {
        if (root == null)
            return;
        
        int COUNT = 10;
        space += COUNT;
        
        PrintTree(root.Right, space);

        Console.WriteLine();
        for(int i = COUNT; i< space;i++)
            Console.Write(" ");
        Console.WriteLine(root.Value);

        PrintTree(root.Left, space);
    }

    public void LevelOrderTraversal()
    {
        if(Root == null) return;
        
        Queue<BinaryTreeNode<T>> q = new Queue<BinaryTreeNode<T>>();
        q.Enqueue(Root);
        
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            Console.Write(current.Value + " ");
            
            if(current.Left != null)
                q.Enqueue(current.Left);

            if (current.Right != null)
                q.Enqueue(current.Right);
        }
    }
    public void PreOrderTraversal()
    {
        PreOrderTraversal(Root);
        Console.WriteLine();
    }
    public void PostOrderTraversal()
    {
        PostOrderTraversal(Root);
        Console.WriteLine();
    }
    public void InorderTraversal()
    {
        InorderTraversal(Root);
        Console.WriteLine();
    }

    private void PreOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
    }
    private void PostOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Value + " ");
        }
    }
    private void InorderTraversal(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            InorderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InorderTraversal(node.Right);
        }
    }
    
}
namespace DSA_Implementations.DS___Trees.BinarySearchTree;

public class BinarySearchTree<T> where T : IComparable<T>
{
    public BinarySearchTreeNode<T> Root { get; private set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(T value)
    {
        Root = Insert(Root, value);
    }

    private BinarySearchTreeNode<T> Insert(BinarySearchTreeNode<T> node, T value)
    {
        if (node == null)
        {
            return new BinarySearchTreeNode<T>(value);
        }
        else if (value.CompareTo(node.Value) < 0)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    public bool Search(T value)
    {
        return Search(Root, value) != null;
    }
    private BinarySearchTreeNode<T> Search(BinarySearchTreeNode<T> node, T value)
    {
        if (node == null || node.Value.Equals(value))
        {
            return node;
        }
        
        if (value.CompareTo(node.Value) < 0)
        {
            return Search(node.Left, value);
        }
        else
        {
            return Search(node.Right, value);
        }
    }
    
    
    public void Delete(T value)
    {
        Root = DeleteNode(Root, value);
    }

    private BinarySearchTreeNode<T> DeleteNode(BinarySearchTreeNode<T> node, T value)
    {
        if (node == null)
        {
            return node;
        }

        // Step 1: Perform standard BST delete
        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = DeleteNode(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = DeleteNode(node.Right, value);
        }
        else
        {
            //If the node to be deleted has one child or no child,
            //simply remove the node and return the non - null child(if any).

            // Node with only one child or no child
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            //if the node to be deleted has two children,
            //find the smallest node in the right subtree (inorder successor), then
            //copy its value to the node to be deleted, and then recursively delete the inorder successor.

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            BinarySearchTreeNode<T> temp = MinValueNode(node.Right);

            // Copy the inorder successor's data to this node
            node.Value = temp.Value;

            // Delete the inorder successor
            node.Right = DeleteNode(node.Right, temp.Value);
        }

        return node;
    }

    private BinarySearchTreeNode<T> MinValueNode(BinarySearchTreeNode<T> node)
    {
        // the minimum value is always located in the leftmost node.
        // This is because for any given node in a BST,
        // all values in the left subtree are less than the value of the node,
        // and all values in the right subtree are greater.
        BinarySearchTreeNode<T> current = node;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current;
    }
    
    private bool Exists(BinarySearchTreeNode<T> node, T value)
    {
        if (node == null)
        {
            return false; // Value not found
        }

        if (value.CompareTo(node.Value) < 0)
        {
            return Exists(node.Left, value); // Search in the left subtree
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            return Exists(node.Right, value); // Search in the right subtree
        }
        else
        {
            return true; // Value found
        }
    }


    public BinarySearchTreeNode<T> Search(int value)
    {
        return Search(Root, value);
    }

    private BinarySearchTreeNode<T> Search(BinarySearchTreeNode<T> node, int value)
    {
        if (node == null)
        {
            return null; // Value not found
        }

        if (value.CompareTo(node.Value) < 0)
        {
            return Search(node.Left, value); // Search in the left subtree
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            return Search(node.Right, value); // Search in the right subtree
        }
        else
        {
            return node; // Value found, return the node
        }
    }
    
    public void InOrderTraversal()
    {
        InOrderTraversal(Root);
        Console.WriteLine();
    }
    private void InOrderTraversal(BinarySearchTreeNode<T> node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversal(node.Right);
        }
    }
   
    public void PreOrderTraversal()
    {
        PreOrderTraversal(Root);
        Console.WriteLine();
    }
    private void PreOrderTraversal(BinarySearchTreeNode<T> node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversal(Root);
        Console.WriteLine();
    }
    private void PostOrderTraversal(BinarySearchTreeNode<T> node)
    {
        if (node != null)
        {
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    public void PrintTree()
    {
        PrintTree(Root, 0);
    }
    private void PrintTree(BinarySearchTreeNode<T> root, int space)
    {
        int COUNT = 10;
        if (root == null) return;
        
        space += COUNT;
        PrintTree(root.Right, space);
        
        for (int i = COUNT; i < space; i++)
            Console.Write(" ");

        Console.WriteLine(root.Value);
        PrintTree(root.Left, space);
    }
}

class Program
{
    /*static void Main(string[] args)
    {
        Console.WriteLine("\nInserting : 45, 15, 79, 90, 10, 55, 12, 20, 50\r\n");

        var bst = new BinarySearchTree<int>();
        bst.Insert(45);
        bst.Insert(15);
        bst.Insert(79);
        bst.Insert(90);
        bst.Insert(10);
        bst.Insert(55);
        bst.Insert(12);
        bst.Insert(20);
        bst.Insert(50);
        bst.PrintTree();

        Console.WriteLine("\n\nAfter Delete 45:\n\n");
        bst.Delete(45);
        bst.PrintTree();

        Console.WriteLine("\nDoes The BST contains 79? " + bst.Search(79));
        Console.WriteLine("Does The BST contains 100? " + bst.Search(100));

        Console.WriteLine("\nInOrder Traversal:");
        bst.InOrderTraversal();

        Console.WriteLine("\nPreOrder Traversal:");
        bst.PreOrderTraversal();

        Console.WriteLine("\nPostOrder Traversal:");
        bst.PostOrderTraversal();

        Console.ReadKey();

    }*/
}
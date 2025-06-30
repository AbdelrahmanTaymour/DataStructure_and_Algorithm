namespace DSA_Implementations.DS___Trees.AVL_Balanced_Tree;


public class AVLTree<T> where T : IComparable<T>
{
    public AVLNode<T> Root { get; private set; }

    public void Insert(T value)
    {
        Root = Insert(Root, value);
    }
    private AVLNode<T> Insert(AVLNode<T> node, T value)
    {
        if (node == null)
            return new AVLNode<T>(value);


        if (value.CompareTo(node.Value) < 0)
            node.Left = Insert(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = Insert(node.Right, value);
        else
            return node; // Duplicate values are not allowed

        UpdateHeight(node);
        // return node;
        return Balance(node);
    }

    private void UpdateHeight(AVLNode<T> node)
    {
        //this will add 1 to the max height and update the node height.
        node.Height = 1 + System.Math.Max(Height(node.Left), Height(node.Right));
    }
    private int Height(AVLNode<T> node)
    {
        //this will get the height of the node, in case the node is null it will return 0.
        return node != null ? node.Height : 0;
    }
    private int GetBalanceFactor(AVLNode<T> node)
    {
        return (node != null) ? Height(node.Left) - Height(node.Right) : 0;
    }
    private AVLNode<T> Balance(AVLNode<T> node)
    {
        
        //this function will balance the node.

        int balanceFactor = GetBalanceFactor(node);

        //decide which rotation to use and work accordingly.

        // RR - Right Rotation Case : Parent BF=-2 , Child BF for right child = -1 or 0
        if (balanceFactor < -1 && GetBalanceFactor(node.Right) <= 0)
            return LeftRotate(node);

        // LL Case: Parent BF=+2 , Child BF for left child = +1 or 0
        if (balanceFactor > 1 && GetBalanceFactor(node.Left) >= 0)
            return RightRotate(node);


        // LR - Left Rotation Case : Parent BF=+2 , Child BF for right child = -1 
        if (balanceFactor > 1 && GetBalanceFactor(node.Left) < 0)
        {
            //Step1: Perform left rotation
            node.Left = LeftRotate(node.Left);
            //Step2: Perform Right Rotation
            return RightRotate(node);
        }

        // RL - Right-Left Rotation Case : Parent BF=-2 , Child BF for right child = +1
        if (balanceFactor < -1 && GetBalanceFactor(node.Right) > 0)
        {
            //Step1: Perform right rotation
            node.Right = RightRotate(node.Right);
            //Step2: Perform Left Rotation
            return LeftRotate(node);
        }

        return node;
    }

    private AVLNode<T> RightRotate(AVLNode<T> originalRoot)
    {

        //Remember the algorithm
        // The left child of the node becomes the new root of the subtree.
        // The original root node becomes the right child of the new root.
        // If the new root already had a right child, it becomes the left child of the new right child(the original root).


        // The left child of the node becomes the new root of the subtree.
        AVLNode<T> newRoot = originalRoot.Left;

        //Save the Original Right Child Temperately
        AVLNode<T> originalRightChild = newRoot.Right;


        //The original root node becomes the right child of the new root.
        newRoot.Right = originalRoot;

        // The original root node becomes the right child of the new root.
        originalRoot.Left = originalRightChild;

        //After the rotation, the heights of the nodes may no longer be correct.
        //These two lines call a method UpdateHeight for
        //both OriginalRoot and NewRoot to recalculate their heights based on the heights of their children.
        //This is crucial for maintaining the balance of the AVL tree.
        UpdateHeight(originalRoot);
        UpdateHeight(newRoot);

        //Finally, the node NewRoot, which is now the root of this subtree after the rotation, is returned.
        return newRoot;
    }
    private AVLNode<T> LeftRotate(AVLNode<T> OriginalRoot)
    {

        //Remember the algorithm: go back to presentation.
        // The right child of the node becomes the new root of the subtree.
        // The original root node becomes the left child of the new root.
        // If the new root already had a left child, it becomes the right child of the new right child(the original root).

        //Right child of the node becomes the new root of the subtree
        AVLNode<T> newRoot = OriginalRoot.Right;
        //Save the Original Left Child Temperately
        AVLNode<T> originalLeftChild = newRoot.Left;

        //Original root node becomes the left child of the new root.
        newRoot.Left = OriginalRoot;
        
        //The new root  left child,it becomes the right child of the new right child(the original root)
        OriginalRoot.Right = originalLeftChild;

        //After the rotation, the heights of the nodes may no longer be correct.
        //These two lines call a method UpdateHeight for
        //both OriginalRoot and NewRoot to recalculate their heights based on the heights of their children.
        //This is crucial for maintaining the balance of the AVL tree.
        UpdateHeight(OriginalRoot);
        UpdateHeight(newRoot);

        //Finally, the node NewRoot, which is now the root of this subtree after the rotation, is returned.
        return newRoot;
    }

    public void Delete(T value)
    {
        Root = Delete(Root, value);
    }
    private AVLNode<T> Delete(AVLNode<T> node, T value)
    {
        if(value.CompareTo(node.Value) < 0)
            node.Left = Delete(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = Delete(node.Right, value);
        else
        {
            //If the node to be deleted has one child or no child,
            //simply remove the node and return the non - null child(if any).

            // Node with only one child or no child
            if(node.Left == null)
                return node.Right;
            else if(node.Right == null)
                return node.Left;
            
            //if the node to be deleted has two children,
            //find the smallest node in the right subtree (inorder successor), then
            //copy its value to the node to be deleted, and then recursively delete the inorder successor.
            AVLNode<T> temp = MinValueNode(node.Right);
            node.Value = temp.Value;
            node.Right = Delete(node.Right, temp.Value);
        }
        UpdateHeight(node);
        return Balance(node);
    }
    private AVLNode<T> MinValueNode(AVLNode<T> node)
    {
        AVLNode<T> current = node;
        while (node.Left != null)
        {
            current = node.Left;
        }
        return current;
    }

    public bool Exists(int value)
    {
        return Exists(Root, value);
    }

    private bool Exists(AVLNode<T> node, int value)
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


    public AVLNode<T> Search(int value)
    {
        return Search(Root, value);
    }

    private AVLNode<T> Search(AVLNode<T> node, int value)
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
    
    public void PrintTree()
    {
        PrintTree(Root, "", true);
    }
    private void PrintTree(AVLNode<T> node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "     ";
            }
            else
            {
                Console.Write("L----");
                indent += "|    ";
            }
            Console.WriteLine(node.Value);
            PrintTree(node.Left, indent, false);
            PrintTree(node.Right, indent, true);
        }
    }
    
    /*static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();

        //RR
        // int[] values = { 10, 20, 30 };

        //LL
        //  int[] values = { 30, 20, 10 };

        //LR
        // int[] values = { 30, 10, 20 };

        //RL
        //int[] values = { 10, 30, 20 };

        // Inserting values
        int[] values = { 10, 20, 30, 40, 50, 25 };
        foreach (var value in values)
        {
            Console.WriteLine($"Inserting {value} into the AVL tree.");
            tree.Insert(value);
            tree.PrintTree();
            Console.WriteLine("\n-------------------------------------------------\n");
        }
        Console.ReadKey();  

    }*/
    
}
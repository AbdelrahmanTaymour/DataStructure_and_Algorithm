namespace DSA_Implementations.DS___Trees.Red_Black_Tree;

public class RedBlackTree<T> where T : IComparable<T>
{
    private RedBlackNode<T> root;

    // Public method to insert a value into the tree
    public void Insert(T newValue)
    {
        RedBlackNode<T> newNode = new RedBlackNode<T>(newValue);
        // Handle the special case when the tree is empty
        if (root == null)
        {
            root = newNode;
            root.IsRed = false; // The root must be black
            return;
        }


        // Standard Binary Search Tree insertion
        RedBlackNode<T> current = root;
        RedBlackNode<T> parent = null;
        while (current != null)
        {
            parent = current;
            if (newValue.CompareTo(current.Value) < 0)
                current = current.Left;
            else
                current = current.Right;
        }


        // Set the parent of the new node
        newNode.Parent = parent;
        if (newValue.CompareTo(parent.Value) < 0)
            parent.Left = newNode;
        else
            parent.Right = newNode;


        // Restore Red-Black properties that might have been violated during insertion
        FixInsert(newNode);
    }


    // Method to restore Red-Black properties after insertion
    private void FixInsert(RedBlackNode<T> node)
    {
        RedBlackNode<T> parent = null;
        RedBlackNode<T> grandparent = null;


        // Fix the tree as long as the node is not the root and both the node and its parent are red
        while ((node != root) && (node.IsRed) && (node.Parent.IsRed))
        {
            parent = node.Parent;
            grandparent = parent.Parent;


            // Parent node is a left child
            if (parent == grandparent.Left)
            {
                RedBlackNode<T> uncle = grandparent.Right; // Uncle node is the right child


                // Case 1: The uncle is red (recoloring)
                if (uncle != null && uncle.IsRed)
                {
                    grandparent.IsRed = true; // Recolor grandparent to red
                    parent.IsRed = false; // Recolor parent to black
                    uncle.IsRed = false; // Recolor uncle to black
                    node = grandparent; // Move up the tree to continue fixing
                }
                else
                {
                    // Case 2: Node is the right child of its parent (Triangle Case)
                    if (node == parent.Right)
                    {
                        // Perform left rotation on parent to transform the triangle case into the line case
                        RotateLeft(parent);
                        node = parent;
                        parent = node.Parent;
                    }


                    // Case 3: Node is now the left child of its parent (Line Case)
                    // Perform right rotation on grandparent to balance the tree
                    RotateRight(grandparent);
                    // Swap colors of parent and grandparent to maintain Red-Black properties
                    (parent.IsRed, grandparent.IsRed) = (grandparent.IsRed, parent.IsRed);
                    node = parent;
                }
            }
            else // Parent node is a right child
            {
                RedBlackNode<T> uncle = grandparent.Left; // Uncle node is the left child


                // Case 1: The uncle is red (recoloring)
                if (uncle != null && uncle.IsRed)
                {
                    grandparent.IsRed = true; // Recolor grandparent to red
                    parent.IsRed = false; // Recolor parent to black
                    uncle.IsRed = false; // Recolor uncle to black
                    node = grandparent; // Move up the tree to continue fixing
                }
                else
                {
                    // Case 2: Node is the left child of its parent (Triangle Case)
                    if (node == parent.Left)
                    {
                        // Perform right rotation on parent to transform the triangle case into the line case
                        RotateRight(parent);
                        node = parent;
                        parent = node.Parent;
                    }
                    
                    // Case 3: Node is now the right child of its parent (Line Case)
                    // Perform left rotation on grandparent to balance the tree
                    RotateLeft(grandparent);
                    // Swap colors of parent and grandparent to maintain Red-Black properties
                    (parent.IsRed, grandparent.IsRed) = (grandparent.IsRed, parent.IsRed);
                    node = parent;
                }
            }
        }

        root.IsRed = false; // Ensure the root remains black
    }


    // Rotate left pivots around the given node making the right child the parent of the pivoted node
    private void RotateLeft(RedBlackNode<T> node)
    {
        RedBlackNode<T> right = node.Right; // Right child becomes the new root of the subtree
        node.Right = right.Left; // Move the left subtree of right to the right subtree of node
        if (node.Right != null)
            node.Right.Parent = node; // Set parent of the new right child


        right.Parent = node.Parent; // Connect new root with the grandparent


        if (node.Parent == null)
            root = right; // The right child becomes new root of the tree
        else if (node == node.Parent.Left)
            node.Parent.Left = right; // Set right child to left child of parent
        else
            node.Parent.Right = right; // Set right child to right child of parent


        right.Left = node; // Original node becomes the left child of its right child
        node.Parent = right; // Update parent of the original node
    }


    // Rotate right pivots around the given node making the left child the parent of the pivoted node
    private void RotateRight(RedBlackNode<T> node)
    {
        RedBlackNode<T> left = node.Left; // Left child becomes the new root of the subtree
        node.Left = left.Right; // Move the right subtree of left to the left subtree of node
        if (node.Left != null)
            node.Left.Parent = node; // Set parent of the new left child
        
        
        left.Parent = node.Parent; // Connect new root with the grandparent
        
        
        if (node.Parent == null)
            root = left; // The left child becomes new root of the tree
        else if (node == node.Parent.Right)
            node.Parent.Right = left; // Set left child to right child of parent
        else
            node.Parent.Left = left; // Set left child to left child of parent


        left.Right = node; // Original node becomes the right child of its left child
        node.Parent = left; // Update parent of the original node
    }

    // Public method to print the tree
    public void PrintTree()
    {
        PrintHelper(root, "", true);
    }

    // Helper method to print the tree
    private void PrintHelper(RedBlackNode<T> node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "   ";
            }
            else
            {
                Console.Write("L----");
                indent += "|  ";
            }
            var color = node.IsRed ? "RED" : "BLK";
            Console.WriteLine(node.Value + "(" + color + ")");
            PrintHelper(node.Left, indent, false);
            PrintHelper(node.Right, indent, true);
        }
    }

    // Find a node for a specific value
    private RedBlackNode<T> FindNode(RedBlackNode<T> searchInNode, T value)
    {
        if(searchInNode == null || searchInNode.Value.Equals(value))
            return searchInNode; // Return the node if found, or null if not found
        
        if(value.CompareTo(searchInNode.Value) < 0)
            return FindNode(searchInNode.Left, value); // Search left subtree
        else
            return FindNode(searchInNode.Right, value); // Search right subtree
    }

    // Public method to search for a value in the tree and return the node
    public RedBlackNode<T> Find(T value)
    {
        return FindNode(root, value);
    }
    
     // Public method to delete a value from the tree
    public bool Delete(T value)
    {
        RedBlackNode<T> nodeToDelete = FindNode(root, value);
        if (nodeToDelete == null)
            return false; // Node to delete not found

        DeleteNode(nodeToDelete);
        return true;
    }

    // Helper method to delete a node and maintain Red-Black properties
    private void DeleteNode(RedBlackNode<T> nodeToDelete)
    {
        RedBlackNode<T> nodeToFix = null;  // Node that may require fixing the Red-Black properties
        RedBlackNode<T> child = null;      // Child of the node to delete or its successor
        RedBlackNode<T> parent = null;     // Parent of the node to delete

        bool originalColor = nodeToDelete.IsRed;  // Store the original color of the node to delete

        // Case 1: The node to delete has no left child
        if (nodeToDelete.Left == null)
        {
            child = nodeToDelete.Right;  // The child is the right child of the node
            Transplant(nodeToDelete, child);  // Replace nodeToDelete with its right child
        }
       
        // Case 2: The node to delete has no right child
        else if (nodeToDelete.Right == null)
        {
            child = nodeToDelete.Left;  // The child is the left child of the node
            Transplant(nodeToDelete, child);  // Replace nodeToDelete with its left child
        }
        // Case 3: The node to delete has both left and right children
        else
        {
            // Find the in-order successor (smallest node in the right subtree)
            RedBlackNode<T> successor = Minimum(nodeToDelete.Right);
            originalColor = successor.IsRed;  // Store the original color of the successor
            child = successor.Right;  // The child is the right child of the successor

            // If the successor is the immediate child of the node to delete
            if (successor.Parent == nodeToDelete)
            {
                if (child != null)
                    child.Parent = successor;  // Update the parent of the child
            }
            else
            {
                // Replace the successor with its right child in its original position
                Transplant(successor, successor.Right);
                successor.Right = nodeToDelete.Right;  // Connect the right child of the node to delete to the successor
                successor.Right.Parent = successor;  // Update the parent of the right child
            }

            // Replace the node to delete with the successor
            Transplant(nodeToDelete, successor);
            successor.Left = nodeToDelete.Left;  // Connect the left child of the node to delete to the successor
            successor.Left.Parent = successor;  // Update the parent of the left child
            successor.IsRed = nodeToDelete.IsRed;  // Maintain the original color of the node being deleted
        }

        // If the original color of the node was black, fix the Red-Black properties
        if (!originalColor && child != null)
        {
            FixDelete(child);  // Call the fix-up method to maintain Red-Black properties
        }
    }

    // Transplant replaces one subtree as a child of its parent with another subtree
    private void Transplant(RedBlackNode<T> target, RedBlackNode<T> with)
    {
        // If the target node is the root of the tree (i.e., it has no parent),
        // then the new subtree (with) becomes the new root of the tree.
        if (target.Parent == null)
            root = with;
        
        // If the target node is the left child of its parent,
        // then update the parent's left child to be the new subtree (with).
        else if (target == target.Parent.Left)
            target.Parent.Left = with;
        // If the target node is the right child of its parent,
        // then update the parent's right child to be the new subtree (with).
        else
            target.Parent.Right = with;

        // If the new subtree (with) is not null, 
        // update its parent to be the parent of the target node.
        if (with != null)
            with.Parent = target.Parent;
    }

    // Method to fix Red-Black properties after deletion
    private void FixDelete(RedBlackNode<T> node)
    {
        // Loop until the node is the root or until the node is red
        while (node != root && !node.IsRed)
        {
            // If the node is the left child of its parent
            if (node == node.Parent.Left)
            {
                // Get the sibling of the node
                RedBlackNode<T> sibling = node.Parent.Right;

                // Case 1: If the sibling is red, perform a rotation and recolor
                if (sibling.IsRed)
                {
                    sibling.IsRed = false; // Recolor sibling to black
                    node.Parent.IsRed = true; // Recolor parent to red
                    RotateLeft(node.Parent); // Rotate the parent to the left
                    sibling = node.Parent.Right; // Update sibling after rotation
                }

                // Case 2.1: If both of sibling's children are black
                if (!sibling.Left.IsRed && !sibling.Right.IsRed)
                {
                    sibling.IsRed = true; // Recolor sibling to red
                    node = node.Parent; // Move up the tree to continue fixing
                }
                else
                {
                    // Case 2.2.2: If sibling's right child  is black and left child is red (Near child Red)
                    if (!sibling.Right.IsRed)
                    {
                        sibling.Left.IsRed = false; // Recolor sibling's left child to black
                        sibling.IsRed = true; // Recolor sibling to red
                        RotateRight(sibling); // Rotate sibling to the right
                        sibling = node.Parent.Right; // Update sibling after rotation
                    }

                    // Case 2.2.1: Sibling's right child is red (Far child Red)
                    sibling.IsRed = node.Parent.IsRed; // Recolor sibling with parent's color
                    node.Parent.IsRed = false; // Recolor parent to black
                    sibling.Right.IsRed = false; // Recolor sibling's right child to black
                    RotateLeft(node.Parent); // Rotate parent to the left
                    node = root; // Set node to root to break out of the loop
                }
            }
            else // If the node is the right child of its parent
            {
                // Get the sibling of the node
                RedBlackNode<T> sibling = node.Parent.Left;

                // Case 1: If the sibling is red, perform a rotation and recolor
                if (sibling.IsRed)
                {
                    sibling.IsRed = false; // Recolor sibling to black
                    node.Parent.IsRed = true; // Recolor parent to red
                    RotateRight(node.Parent); // Rotate the parent to the right
                    sibling = node.Parent.Left; // Update sibling after rotation
                }

                // Case 2.1: If both of sibling's children are black
                if (!sibling.Left.IsRed && !sibling.Right.IsRed)
                {
                    sibling.IsRed = true; // Recolor sibling to red
                    node = node.Parent; // Move up the tree to continue fixing
                }
                else
                {
                    // Case 2.2.2: If sibling's left child is black and right child is red (Near Child is Red)
                    if (!sibling.Left.IsRed)
                    {
                        sibling.Right.IsRed = false; // Recolor sibling's right child to black
                        sibling.IsRed = true; // Recolor sibling to red
                        RotateLeft(sibling); // Rotate sibling to the left
                        sibling = node.Parent.Left; // Update sibling after rotation
                    }

                    // Case 2.2.1: Sibling's left child is red (Far Child is Red)
                    sibling.IsRed = node.Parent.IsRed; // Recolor sibling with parent's color
                    node.Parent.IsRed = false; // Recolor parent to black
                    sibling.Left.IsRed = false; // Recolor sibling's left child to black
                    RotateRight(node.Parent); // Rotate parent to the right
                    node = root; // Set node to root to break out of the loop
                }
            }
        }
        node.IsRed = false; // Ensure the node is black before exiting
    }


    // Helper method to find the minimum value node in the tree
    private RedBlackNode<T> Minimum(RedBlackNode<T> node)
    {
        // Traverse down the left subtree until the leftmost node is reached
        while (node.Left != null)
            node = node.Left; // Move to the left child

        // Return the leftmost (minimum value) node
        return node;
    }
}
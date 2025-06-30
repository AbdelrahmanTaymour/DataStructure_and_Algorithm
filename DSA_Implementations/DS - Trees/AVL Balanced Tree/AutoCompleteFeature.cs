namespace DSA_Implementations.DS___Trees.AVL_Balanced_Tree;

public class AutoCompleteFeature
{
    static AVLTree<string> tree = new AVLTree<string>();

    public static IEnumerable<string> AutoComplete(string prefix)
    {
        List<string> results = new List<string>();
        AutoComplete(tree.Root, prefix, results);
        return results;
    }
    private static void AutoComplete(AVLNode<string> node, string prefix, List<string> results)
    {
        if (node != null)
        {
            if (node.Value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(node.Value);
                AutoComplete(node.Left, prefix, results);
                AutoComplete(node.Right, prefix, results);
            }
            else
            {
                if(string.Compare(prefix, node.Value, StringComparison.OrdinalIgnoreCase) < 0)
                    AutoComplete(node.Left, prefix, results);
                else
                    AutoComplete(node.Right, prefix, results);
            }
        }
    }

    public static void Main(string[] args)
    {
        string[] words = { "Ahmad", "Mohammed", "Motasem", "Mohab", "Abla", "Abeer", "Abdullah", "Abbas", "Montaser", "Khalil","Khalid" };

        foreach (var word in words)
        {
            tree.Insert(word);
        }
        tree.PrintTree();

        Console.WriteLine("\nEnter a prefix to search:\n");
        string prefix = Console.ReadLine();
        var completions = AutoComplete(prefix);

        Console.WriteLine($"\nSuggestions for '{prefix}':\n");
        foreach (var completion in completions)
        {
            Console.WriteLine(completion);
        }

        Console.ReadKey(); // Wait for the user to press a key before closing
    }
}
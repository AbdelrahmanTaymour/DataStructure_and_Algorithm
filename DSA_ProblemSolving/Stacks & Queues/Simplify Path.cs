namespace DSA_ProblemSolving.Stacks___Queues;

/// <summary>
/// Leetcode Problem: Simplify Path
/// - https://leetcode.com/problems/simplify-path/
///
/// Problem:
/// Given a string path, representing an absolute path for a Unix-style file system,
/// return the simplified canonical path.
///
/// Rules:
/// - "." means current directory → ignore it.
/// - ".." means go up one directory → remove last directory from the path if possible.
/// - Multiple consecutive slashes should be treated as a single slash.
/// - The canonical path always starts with a "/" and has no trailing slash.
///
/// Example:
/// Input: "/home//foo/"
/// Output: "/home/foo"
///
/// Input: "/a/./b/../../c/"
/// Output: "/c"
///
/// Approach:
/// 1. Split the path by "/" and remove empty entries (to handle multiple slashes).
/// 2. Use a list to simulate a stack of directories:
///     - Ignore "." (stay in current directory).
///     - On "..", pop from the stack if possible.
///     - Otherwise, push the directory name.
/// 3. Join the list with "/" to get the final canonical path.
/// </summary>
public class Simplify_Path
{
    public string SimplifyPath(string path)
    {
        // Split by "/" and ignore empty parts (caused by multiple slashes)
        var tokens = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        List<string> stack = new();

        foreach (var token in tokens)
        {
            if (token == ".")
            {
                // "." means current directory → do nothing
                continue;
            }
            if (token == "..")
            {
                // ".." means go back one directory → pop if stack is not empty
                if (stack.Count > 0)
                    stack.RemoveAt(stack.Count - 1);
            }
            else
            {
                // Valid directory name → push to stack
                stack.Add(token);
            }
        }

        // If stack is empty, we are at the root "/"
        if (stack.Count == 0)
            return "/";

        // Join stack elements into a valid Unix path
        return "/" + string.Join("/", stack);
    }
}
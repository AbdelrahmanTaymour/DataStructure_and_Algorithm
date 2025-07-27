namespace DSA_ProblemSolving.LinkedList;

/// <summary>
/// Leetcode Problem: LRU Cache  
/// - https://leetcode.com/problems/lru-cache/
///
/// Problem Statement:
/// Design a data structure that follows the Least Recently Used (LRU) cache eviction policy.
/// It should support the following operations in O(1) time:
/// - Get(key): Return the value of the key if it exists, otherwise return -1.
/// - Put(key, value): Update or insert the value. If the cache reaches capacity,
///   evict the least recently used item before inserting the new one.
///
/// Implementation Details:
/// - Use a Dictionary to store key-to-node mappings for O(1) access.
/// - Use a LinkedList to track the usage order (most recently used at the front).
///
/// Time Complexity: O(1) for both Get and Put.
/// Space Complexity: O(capacity)
/// </summary>

public class LRUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<CacheItem>> cacheMap;
    private readonly LinkedList<CacheItem> cacheList;

    
    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cacheMap = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
        cacheList = new LinkedList<CacheItem>();
    }

    /// <summary>
    /// Retrieves the value associated with the given key if present.
    /// Moves the accessed item to the front as it is now most recently used.
    /// </summary>
    /// <param name="key">The key to retrieve</param>
    /// <returns>The value of the key if present, otherwise -1</returns>
    public int Get(int key)
    {
        if (cacheMap.TryGetValue(key, out var node))
        {
            // Move the node to the front (most recently used)
            cacheList.Remove(node);
            cacheList.AddFirst(node);
            return node.Value.Value;
        }
        return -1;
    }

    /// <summary>
    /// Inserts a new key-value pair or updates an existing one.
    /// If capacity is exceeded, removes the least recently used item.
    /// </summary>
    /// <param name="key">The key to insert or update</param>
    /// <param name="value">The value to associate with the key</param>
    public void Put(int key, int value)
    {
        if (cacheMap.TryGetValue(key, out var node))
        {
            // Update value and move to front
            node.Value.Value = value;
            cacheList.Remove(node);
            cacheList.AddFirst(node);
        }
        else
        {
            // If cache is full, remove the least recently used item (last node)
            if (cacheMap.Count >= capacity)
            {
                var lastNode = cacheList.Last;
                cacheMap.Remove(lastNode.Value.Key);
                cacheList.RemoveLast();
            }

            // Insert new node at the front
            var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
            cacheList.AddFirst(newNode);
            cacheMap.Add(key, newNode);
        }
    }
}

/// <summary>
/// Represents a key-value pair stored in the LRU Cache.
/// </summary>
public class CacheItem
{
    public int Key { get; set; }
    public int Value { get; set; }

    public CacheItem(int key, int value)
    {
        Key = key;
        Value = value;
    }
}
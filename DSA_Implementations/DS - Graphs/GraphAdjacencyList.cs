namespace DSA_Implementations.DS___Graphs;

/// <summary>
/// Represents a generic graph data structure that uses an adjacency list for storage.
/// Supports both directed and undirected graphs with operations to add/remove edges, 
/// check connections, and display the graph.
/// </summary>
/// <typeparam name="T">The type of the vertices in the graph. Must implement <see cref="IComparable{T}"/>.</typeparam>
public class GraphAdjacencyList<T> where T : IComparable<T>
{
    public enum EnGraphDirectionType { Directed, UnDirected }
    
    // Dictionary to store the adjacency list (vertex -> list of edges)
    private readonly Dictionary<T, List<Tuple<T, int>>> _adjacencyList;
    
    // Dictionary to map string vertices to their neighbors
    private readonly Dictionary<T, int> _vertexDictionary;
    
    private readonly int _numberOfVertices;
    private readonly EnGraphDirectionType _graphDirectionType;

    public GraphAdjacencyList(List<T> vertices,
        EnGraphDirectionType graphDirectionType = EnGraphDirectionType.UnDirected)
    {
        _graphDirectionType = graphDirectionType;
        _numberOfVertices = vertices.Count;
        _adjacencyList = new Dictionary<T, List<Tuple<T, int>>>(); // Initialize the adjacency list.
        _vertexDictionary = new Dictionary<T, int>();
        for (int i = 0; i < _numberOfVertices; i++)
        {
            _vertexDictionary[vertices[i]] = i; // Initialize an empty edge list for each vertex.
            _adjacencyList[vertices[i]] = new List<Tuple<T, int>>(); // Assign each vertex an index.
        }
    }
    
    /// <summary>
    /// Adds a new edge between the source and destination vertices with an optional weight.
    /// </summary>
    /// <param name="source">The source vertex.</param>
    /// <param name="destination">The destination vertex.</param>
    /// <param name="weight">The weight of the edge (default is 1).</param>
    /// <exception cref="Exception">Thrown for invalid vertices.</exception>
    public void AddEdge(T source, T destination, int weight = 1)
    {
        if (_vertexDictionary.ContainsKey(source) &&
            _vertexDictionary.ContainsKey(destination))
        {
            // Add the edge from source to destination with the given weight
            _adjacencyList[source].Add(new Tuple<T, int>(destination, weight));
            
            // If the graph is undirected, add the reverse edge (from destination to source)
            if (_graphDirectionType == EnGraphDirectionType.Directed)
            {
                _adjacencyList[destination].Add(new Tuple<T, int>(source, weight));
            }
        }
        else
        {
            throw new Exception($"Ignored. Invalid vertices.{source} ===> {destination}");
        }
    }
    
    /// <summary>
    /// Removes an edge between the source and destination vertices.
    /// </summary>
    /// <param name="source">The source vertex.</param>
    /// <param name="destination">The destination vertex.</param>
    /// <exception cref="Exception">Thrown for invalid vertices.</exception>
    public void RemoveEdge(T source, T destination)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
        {
            // Remove the edge from the source's adjacency list.
            _adjacencyList[source].RemoveAll(edge => edge.Item1.CompareTo(destination) == 0);
            
            // For undirected graphs, remove the edge in both directions.
            if (_graphDirectionType == EnGraphDirectionType.Directed)
            {
                _adjacencyList[destination].RemoveAll(edge => edge.Item1.CompareTo(source) == 0);
            }
        }
        else
        {
            throw new Exception("Invalid vertices.");
        }
    }
    
    /// <summary>
    /// Checks whether there is an edge between the source and destination vertices.
    /// </summary>
    /// <param name="source">The source vertex.</param>
    /// <param name="destination">The destination vertex.</param>
    /// <returns>True if an edge exists, otherwise false.</returns>
    public bool IsEdge(T source, T destination)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
        {
            foreach (var edge in _adjacencyList[source])
            {
                if (edge.Item1.CompareTo(destination) == 0)
                    return true;
            }
        }

        return false;
    }
    
    /// <summary>
    /// Calculates the in-degree (number of edges coming into) of a specified vertex.
    /// </summary>
    /// <param name="vertex">The vertex for which the in-degree is computed.</param>
    /// <returns>The in-degree of the vertex.</returns>
    public int GetInDegree(T vertex)
    {
        int degree = 0;
        if (_vertexDictionary.ContainsKey(vertex))
        {
            // Iterate through all adjacency lists to count edges pointing to the vertex.
            foreach (var source in _adjacencyList)
            {
                foreach (var edge in source.Value)
                {
                    if (edge.Item1.CompareTo(vertex) == 0)
                        degree++;
                }
            }
        }
        return degree;
    }
    
    /// <summary>
    /// Calculates the out-degree (number of edges going out of) a specified vertex.
    /// </summary>
    /// <param name="vertex">The vertex for which the out-degree is computed.</param>
    /// <returns>The out-degree of the vertex.</returns>
    public int GetOutDegree(T vertex)
    {
        int degree = 0;
        if (_vertexDictionary.ContainsKey(vertex))
        {
            degree = _adjacencyList[vertex].Count;
        }
        return degree;
    }
    
    
    /// <summary>
    /// Displays the graph in adjacency list format, showing all vertices and their connected edges with weights.
    /// </summary>
    /// <param name="message">An optional message to display before the graph.</param>
    public void DisplayGraph(string message = "")
    {
        Console.WriteLine($"\n {message} \n");

        // Iterate through each vertex and display its adjacency list.
        foreach (var vertex in _adjacencyList)
        {
            Console.Write(vertex.Key + " -> "); // Print the source vertex.
            foreach (var edge in vertex.Value)
            {
                // Display destination vertex and edge weight.
                Console.Write(edge.Item1 + " (" + edge.Item2 + ") ");
            }
            Console.WriteLine();
        }
    }
}
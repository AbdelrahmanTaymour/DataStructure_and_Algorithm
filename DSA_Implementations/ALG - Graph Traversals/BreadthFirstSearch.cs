namespace DSA_Implementations.ALG___Graph_Traversals;

public class BreadthFirstSearch<T>
{
    public enum EnGraphDirectionType { Directed, UnDirected }

    private readonly int[,] _adjacencyMatrix;
    private readonly Dictionary<T, int> _vertexDictionary;
    private readonly int _numberOfVertices;
    private readonly EnGraphDirectionType _graphDirectionType;
    
    /// <summary>
    /// Initializes a new graph with a given set of vertices and optionally specifies 
    /// whether the graph is directed or undirected.
    /// </summary>
    /// <param name="vertices">List of vertices in the graph.</param>
    /// <param name="graphDirectionType">Specifies whether the graph is directed or undirected. 
    /// Default is <see cref="EnGraphDirectionType.UnDirected"/>.</param>
    public BreadthFirstSearch(List<T> vertices, EnGraphDirectionType graphDirectionType = EnGraphDirectionType.UnDirected)
    {
        _graphDirectionType = graphDirectionType;
        _numberOfVertices = vertices.Count;
        _adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices];
        
        _vertexDictionary = new Dictionary<T, int>();
        for (int i = 0; i < _numberOfVertices; i++)
        {
            _vertexDictionary[vertices[i]] = i; // Maps each vertex to its index.
        }
    }

    /// <summary>
    /// Performs a breadth-first search on the graph starting from the given vertex.
    /// </summary>
    /// <param name="startVertex">The vertex from which to start the search.</param>
    /// <exception cref="Exception">Thrown when the start vertex is invalid.</exception>
    public void BFS(T startVertex)
    {
        if (!_vertexDictionary.ContainsKey(startVertex))
        {
            throw new Exception("Invalid start vertex.");
        }
        
        bool[] visited = new bool[_numberOfVertices];
        Queue<int> queue = new Queue<int>();

        int startIndex = _vertexDictionary[startVertex];
        visited[startIndex] = true; // Mark start vertex as visited
        queue.Enqueue(startIndex);

        Console.WriteLine("\nBreadth-First Search:");
        while (queue.Count > 0)
        {
            int currentVertex = queue.Dequeue();
            Console.Write($"{GetVertexName(currentVertex)} "); // Print the current vertex

            // Add all unvisited neighbors to the queue
            for (int i = 0; i < _numberOfVertices; i++)
            {
                if (_adjacencyMatrix[currentVertex, i] > 0 && !visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }
    
    
    // Helper method to get vertex name by index
    private T? GetVertexName(int index)
    {
        foreach (var pair in _vertexDictionary)
        {
            if (pair.Value == index)
                return pair.Key;
        }
        return default(T);
    }
    
    /// <summary>
    /// Adds an edge between two vertices with an optional weight.
    /// </summary>
    /// <param name="source">The source vertex.</param>
    /// <param name="destination">The destination vertex.</param>
    /// <param name="weight">The weight of the edge. Default is 1.</param>
    /// <exception cref="Exception">Thrown when one or both vertices are invalid.</exception>
    public void AddEdge(T source, T destination, int weight = 1)
    {
        if (_vertexDictionary.TryGetValue(source, out var sourceIndex) &&
            _vertexDictionary.TryGetValue(destination, out var destinationIndex))
        {
            _adjacencyMatrix[sourceIndex, destinationIndex] = weight;
            
            // For undirected graphs, add the edge in both directions.
            if (_graphDirectionType == EnGraphDirectionType.Directed)
            {
                _adjacencyMatrix[destinationIndex, sourceIndex] = weight;
            }
        }
        else
        {
            throw new Exception($"Ignored. Invalid vertices.{source} ===> {destination}");
        }
    }
    
    /// <summary>
    /// Displays the graph in adjacency matrix format.
    /// </summary>
    /// <param name="message">An optional message to display before the matrix.</param>
    public void DisplayGraph(string message = "")
    {
        Console.WriteLine($"\n {message} \n");
        
        // Print column headers (vertices)
        Console.Write("  ");
        foreach (var vertex in _vertexDictionary.Keys)
        {
            Console.Write(vertex + " ");
        }
        Console.WriteLine();

        
        // Print each row of the matrix.
        foreach (var source in _vertexDictionary)
        {
            Console.Write(source.Key + " ");
            for(int j =0;j<_numberOfVertices;j++)
            {
                Console.Write(_adjacencyMatrix[source.Value, j] + " ");
            }
            Console.WriteLine();
        }
        
    }
}
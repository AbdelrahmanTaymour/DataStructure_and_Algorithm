namespace DSA_Implementations.DS___Graphs;

/// <summary>
/// Represents a generic graph data structure that supports directed and undirected graphs, 
/// and allows operations such as adding/removing edges, checking connections, 
/// and displaying the graph in adjacency matrix form.
/// </summary>
/// <typeparam name="T">The type of the vertices. Must implement <see cref="IComparable{T}"/> for comparison reasons.</typeparam>
public class GraphAdjacencyMatrix<T> where T : IComparable<T>
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
    public GraphAdjacencyMatrix(List<T> vertices, EnGraphDirectionType graphDirectionType = EnGraphDirectionType.UnDirected)
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
    /// Removes an edge between two vertices.
    /// </summary>
    /// <param name="source">The source vertex.</param>
    /// <param name="destination">The destination vertex.</param>
    /// <exception cref="Exception">Thrown when one or both vertices are invalid.</exception>
    public void RemoveEdge(T source, T destination)
    {
        if (_vertexDictionary.TryGetValue(source, out var sourceIndex) &&
            _vertexDictionary.TryGetValue(destination, out var destinationIndex))
        {
            _adjacencyMatrix[sourceIndex, destinationIndex] = 0;
            _adjacencyMatrix[destinationIndex, sourceIndex] = 0;
        }
        else
        {
            throw new Exception("Invalid vertices.");
        }
    }

    /// <summary>
    /// Determines if an edge exists between two vertices.
    /// </summary>
    /// <param name="source">The source vertex.</param>
    /// <param name="destination">The destination vertex.</param>
    /// <returns>True if an edge exists, false otherwise.</returns>
    public bool IsEdge(T source, T destination)
    {
        if (_vertexDictionary.TryGetValue(source, out var sourceIndex) &&
            _vertexDictionary.TryGetValue(destination, out var destinationIndex))
        {
            return _adjacencyMatrix[sourceIndex, destinationIndex] > 0;
        }

        return false;
    }

    /// <summary>
    /// Gets the in-degree of a given vertex (number of edges coming into the vertex).
    /// </summary>
    /// <param name="vertex">The vertex for which in-degree is calculated.</param>
    /// <returns>The in-degree of the vertex.</returns>
    public int GetInDegree(T vertex)
    {
        int degree = 0;
        if (_vertexDictionary.TryGetValue(vertex, out var vertexIndex))
        {
            for(int i =0;i<_numberOfVertices;i++)
            {
                if (_adjacencyMatrix[i, vertexIndex] > 0)
                    degree++;
            }
        }
        return degree;
    }
    
    /// <summary>
    /// Gets the out-degree of a given vertex (number of edges going out of the vertex).
    /// </summary>
    /// <param name="vertex">The vertex for which out-degree is calculated.</param>
    /// <returns>The out-degree of the vertex.</returns>
    public int GetOutDegree(T vertex)
    {
        int degree = 0;
        if (_vertexDictionary.TryGetValue(vertex, out var vertexIndex))
        {
            for (int i = 0; i < _numberOfVertices; i++)
            {
                if (_adjacencyMatrix[vertexIndex, i] > 0)
                    degree++;
            }
        }
        return degree;
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
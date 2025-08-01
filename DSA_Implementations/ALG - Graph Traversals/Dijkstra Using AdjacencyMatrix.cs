using DSA_Implementations.DS___Graphs;

namespace DSA_Implementations.ALG___Graph_Traversals;

public class DijkstraUsingAdjacencyMatrix<T>
{
    
    public enum enGraphDirectionType { Directed, unDirected }

    private int[,] _adjacencyMatrix;
    private Dictionary<T, int> _vertexDictionary;
    private int _numberOfVertices;
    private enGraphDirectionType _GraphDirectionType;

    // Constructor
    public DijkstraUsingAdjacencyMatrix(List<T> vertices, enGraphDirectionType GraphDirectionType)
    {
        _GraphDirectionType = GraphDirectionType;
        _numberOfVertices = vertices.Count;
        _adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices];
        _vertexDictionary = new Dictionary<T, int>();

        for (int i = 0; i < vertices.Count; i++)
        {
            _vertexDictionary[vertices[i]] = i;
        }
    }

    // Add an edge to the graph
    public void AddEdge(T source, T destination, int weight)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
        {
            int sourceIndex = _vertexDictionary[source];
            int destinationIndex = _vertexDictionary[destination];
            _adjacencyMatrix[sourceIndex, destinationIndex] = weight;

            if (_GraphDirectionType == enGraphDirectionType.unDirected)
            {
                _adjacencyMatrix[destinationIndex, sourceIndex] = weight;
            }
        }
        else
        {
            Console.WriteLine($"Invalid vertices: {source} or {destination}");
        }
    }

    // Display the graph as an adjacency matrix
    public void DisplayGraph(string message)
    {
        Console.WriteLine("\n" + message + "\n");
        Console.Write("  ");
        foreach (var vertex in _vertexDictionary.Keys)
        {
            Console.Write(vertex + " ");
        }
        Console.WriteLine();

        foreach (var source in _vertexDictionary)
        {
            Console.Write(source.Key + " ");
            for (int j = 0; j < _numberOfVertices; j++)
            {
                Console.Write(_adjacencyMatrix[source.Value, j] + " ");
            }
            Console.WriteLine();
        }
    }

    
    // Dijkstra's Algorithm: Finds the shortest paths from a source vertex
    public void Dijkstra(T startVertex)
    {

        // Adjacency Matrix : O(V^2)
        // In the Next lesson we will use: Adjacency List with Min-Heap: O((V+E) log⁡ V)

        if (!_vertexDictionary.ContainsKey(startVertex))
        {
            Console.WriteLine("Invalid start vertex.");
            return;
        }

        // Initialize distance and visited arrays
        int startIndex = _vertexDictionary[startVertex];
        int[] distances = new int[_numberOfVertices]; // Stores shortest distances
        bool[] visited = new bool[_numberOfVertices]; // Tracks processed vertices
        T[] predecessors = new T[_numberOfVertices]; // Tracks the previous vertex on the shortest path

        // Initialize all distances to infinity and mark all vertices as unvisited
        for (int i = 0; i < _numberOfVertices; i++)
        {
            distances[i] = int.MaxValue; // Set distance to "infinity"
            visited[i] = false; // Mark as unvisited
            predecessors[i] = default; // No predecessors initially
        }
        distances[startIndex] = 0; // Distance to the source is 0

        // Main loop: Process each vertex
        for (int count = 0; count < _numberOfVertices - 1; count++)
        {
            // Find the unvisited vertex with the smallest distance
            int minVertex = GetMinDistanceVertex(distances, visited);
            visited[minVertex] = true; // Mark this vertex as visited

            // Update distances for all neighbors of the current vertex
            for (int v = 0; v < _numberOfVertices; v++)
            {
                // Update distance if:
                // 1. There is an edge.
                // 2. The vertex is unvisited.
                // 3. The new distance is shorter.
                if (!visited[v] && _adjacencyMatrix[minVertex, v] > 0 &&
                    distances[minVertex] != int.MaxValue &&
                    distances[minVertex] + _adjacencyMatrix[minVertex, v] < distances[v])
                {
                    distances[v] = distances[minVertex] + _adjacencyMatrix[minVertex, v];
                    predecessors[v] = GetVertexName(minVertex); // Record the predecessor, prev node.
                }
            }
        }

        // Display the shortest paths and their distances
        Console.WriteLine("\nShortest paths from vertex " + startVertex + ":");
        for (int i = 0; i < _numberOfVertices; i++)
        {
            Console.WriteLine($"{startVertex} -> {GetVertexName(i)}: Distance = {distances[i]}, Path = {GetPath(predecessors, i)}");
        }
    }

    // Finds the unvisited vertex with the smallest distance
    private int GetMinDistanceVertex(int[] distances, bool[] visited)
    {
        int minDistance = int.MaxValue; // Start with infinity
        int minIndex = -1; // Invalid index initially

        // Iterate over all vertices
        for (int i = 0; i < _numberOfVertices; i++)
        {
            // Update the minimum if the vertex is unvisited and has a smaller distance
            if (!visited[i] && distances[i] < minDistance)
            {
                minDistance = distances[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    // Helper to get the vertex name by its index
    private T? GetVertexName(int index)
    {
        foreach (var pair in _vertexDictionary)
        {
            if (pair.Value == index)
                return pair.Key;
        }
        return default;
    }

    // Reconstructs the shortest path from the source to a vertex using predecessors
    private string? GetPath(T[] predecessors, int currentIndex)
    {
        // Base case: If there is no predecessor, return the current vertex
        if (predecessors[currentIndex] == null)
            return GetVertexName(currentIndex).ToString();

        // Recursive case: Build the path from the predecessor
        return GetPath(predecessors, _vertexDictionary[predecessors[currentIndex]]) + " -> " + GetVertexName(currentIndex);
    }
}
Here is an example implementation of a graph class in C#:

```
public class Graph<T>
{
    private readonly Dictionary<T, List<T>> _adjacencyList;

    public Graph()
    {
        _adjacencyList = new Dictionary<T, List<T>>();
    }

    public void AddVertex(T vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
        {
            _adjacencyList[vertex] = new List<T>();
        }
    }

    public void AddEdge(T startVertex, T endVertex)
    {
        if (!_adjacencyList.ContainsKey(startVertex))
        {
            AddVertex(startVertex);
        }

        if (!_adjacencyList.ContainsKey(endVertex))
        {
            AddVertex(endVertex);
        }

        _adjacencyList[startVertex].Add(endVertex);
        _adjacencyList[endVertex].Add(startVertex);
    }

    public void RemoveVertex(T vertex)
    {
        if (_adjacencyList.ContainsKey(vertex))
        {
            var adjacentVertices = _adjacencyList[vertex];
            foreach (var adjacentVertex in adjacentVertices)
            {
                _adjacencyList[adjacentVertex].Remove(vertex);
            }

            _adjacencyList.Remove(vertex);
        }
    }

    public void RemoveEdge(T startVertex, T endVertex)
    {
        if (_adjacencyList.ContainsKey(startVertex) && _adjacencyList.ContainsKey(endVertex))
        {
            _adjacencyList[startVertex].Remove(endVertex);
            _adjacencyList[endVertex].Remove(startVertex);
        }
    }

    public bool ContainsVertex(T vertex)
    {
        return _adjacencyList.ContainsKey(vertex);
    }

    public bool ContainsEdge(T startVertex, T endVertex)
    {
        return _adjacencyList.ContainsKey(startVertex) &&
               _adjacencyList[startVertex].Contains(endVertex);
    }

    public List<T> GetAdjacentVertices(T vertex)
    {
        return _adjacencyList.ContainsKey(vertex)
            ? new List<T>(_adjacencyList[vertex])
            : new List<T>();
    }
}
```

This implementation uses a dictionary `_adjacencyList` to store the adjacency list representation of the graph, where each vertex is a key with its corresponding adjacent vertices represented as a list.

The `AddVertex` method adds a new vertex to the graph, while `AddEdge` adds a new edge between two vertices by adding them as adjacent vertices of each other in the adjacency list.

The `RemoveVertex` method removes a vertex from the graph and all its adjacent edges. `RemoveEdge` removes an edge between two vertices by removing them from each other's adjacent vertices list.

`ContainsVertex` checks if a vertex exists in the graph, while `ContainsEdge` checks if an edge between two vertices exists.

`GetAdjacentVertices` returns a list of all adjacent vertices of a given vertex, or an empty list if the vertex does not exist in the graph.
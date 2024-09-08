public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int G { get; set; } // Cost from start to this node
    public int H { get; set; } // Heuristic cost to goal
    public int F => G + H; // Total cost
    public Node Parent { get; set; }

    public Node(int x, int y)
    {
        X = x;
        Y = y;
    }
}
public class AStar
{
    private static List<Node> GetNeighbors(Node node, int[,] grid)
    {
        var neighbors = new List<Node>();

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = node.X + dx[i];
            int newY = node.Y + dy[i];

            if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1) && grid[newX, newY] == 0)
            {
                neighbors.Add(new Node(newX, newY));
            }
        }

        return neighbors;
    }

    private static int Heuristic(Node a, Node b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    public static List<Node> FindPath(int[,] grid, Node start, Node goal)
    {
        var openList = new List<Node> { start };
        var closedList = new HashSet<Node>();

        start.G = 0;
        start.H = Heuristic(start, goal);

        while (openList.Count > 0)
        {
            var current = openList.OrderBy(node => node.F).First();

            if (current.X == goal.X && current.Y == goal.Y)
            {
                var path = new List<Node>();
                while (current != null)
                {
                    path.Add(current);
                    current = current.Parent;
                }
                path.Reverse();
                return path;
            }

            openList.Remove(current);
            closedList.Add(current);

            foreach (var neighbor in GetNeighbors(current, grid))
            {
                if (closedList.Contains(neighbor))
                    continue;

                int tentativeG = current.G + 1;

                if (!openList.Contains(neighbor) || tentativeG < neighbor.G)
                {
                    neighbor.G = tentativeG;
                    neighbor.H = Heuristic(neighbor, goal);
                    neighbor.Parent = current;

                    if (!openList.Contains(neighbor))
                        openList.Add(neighbor);
                }
            }
        }

        return null; // No path found
    }
}




public static void Main()
{
    int[,] grid = {
        { 0, 1, 0, 0, 0 },
        { 0, 1, 0, 1, 0 },
        { 0, 0, 0, 1, 0 },
        { 0, 1, 0, 0, 0 },
        { 0, 0, 0, 1, 0 }
    };

    Node start = new Node(0, 0);
    Node goal = new Node(4, 4);

    var path = AStar.FindPath(grid, start, goal);

    if (path != null)
    {
        foreach (var node in path)
        {
            Console.WriteLine($"({node.X}, {node.Y})");
        }
    }
    else
    {
        Console.WriteLine("No path found.");
    }
}



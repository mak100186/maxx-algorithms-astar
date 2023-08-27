namespace Maxx.Algorithms.PathfindingAStar.Extensions
{
    using System.Drawing;

    using Models;

    public static class PrintExtension
    {
        public static void Print(this Grid grid, Point A, Point B)
        {
            for (var row = 0; row < grid.Height; row++)
            {
                var line = "";
                for (var col = 0; col < grid.Width; col++)
                {
                    var node = grid[col, row];

                    if (node.Location.Equals(A))
                    {
                        line += " A ";
                    } 
                    else if (node.Location.Equals(B))
                    {
                        line += " B ";
                    }
                    else if (node.IsWalkable)
                    {
                        line += " . ";
                    }
                    else
                    {
                        line += " | ";
                    }
                    
                }
                Console.WriteLine(line);
            }
        }

        public static void PrintPath(this Grid grid, IEnumerable<Point> path, Point A, Point B)
        {
            for (var row = 0; row < grid.Height; row++)
            {
                var line = "";
                for (var col = 0; col < grid.Width; col++)
                {
                    var node = grid[col, row];

                    if (node.IsWalkable)
                    {
                        if (node.Location.Equals(A))
                        {
                            line += " A ";
                        }
                        else if (node.Location.Equals(B))
                        {
                            line += " B ";
                        }
                        else if (path.Contains(node.Location))
                        {
                            line += " x ";
                        }
                        else
                        {
                            line += " . ";
                        }
                    }
                    else
                    {
                        line += " | ";
                    }

                }
                Console.WriteLine(line);
            }
        }
    }
}
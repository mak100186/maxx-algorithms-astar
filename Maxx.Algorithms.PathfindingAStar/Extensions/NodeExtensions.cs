using System.Drawing;

using Maxx.Algorithms.PathfindingAStar.Models;

namespace Maxx.Algorithms.PathfindingAStar.Extensions
{
    public static class NodeExtensions
    {
        public static List<Node> GetAdjacentWalkableNodes(this Node fromNode, Node endNode)
        {
            var walkableNodes = new List<Node>();
            var nextLocations = fromNode.Location.GetAdjacentLocations();

            foreach (var location in nextLocations)
            {
                var x = location.X;
                var y = location.Y;
                var grid = fromNode.Grid;

                // Stay within the grid's boundaries
                if (x < 0 || x >= grid.Width || y < 0 || y >= grid.Height)
                {
                    continue;
                }

                var node = grid[x, y];

                // Ignore non-walkable nodes
                if (!node.IsWalkable)
                {
                    continue;
                }

                // Ignore already-closed nodes
                if (node.State == NodeState.Closed)
                {
                    continue;
                }
                
                // If it's untested, set the parent and flag it as 'Open' for consideration
                node.ParentNode = fromNode;
                node.State = NodeState.Open;

                node.G = GetG(node);
                node.H = GetH(node.Location, endNode.Location);

                walkableNodes.Add(node);
            }

            walkableNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
            return walkableNodes;
        }

        private static float GetG(Node node)
        {
            float gVal = 0;
            var parent = node.ParentNode;
            while (parent != null)
            {
                gVal += parent.G;
                parent = parent.ParentNode;
            }

            return gVal;
        }

        private static float GetH(Point p1, Point p2)
        {
            var a = MathF.Abs(p1.X - p2.X);
            var b = MathF.Abs(p1.Y - p2.Y);

            return MathF.Sqrt(a * a + b * b);
        }
    }
}
namespace Maxx.Algorithms.PathfindingAStar;

using System;
using System.Drawing;

using Extensions;

using Models;

internal class Program
{
    static void Main(string[] args)
    {
        var searchParams = new SearchParameters
        {
            Map = new[,]
            {
                { true, true, true, true, true, true, true, true},
                { true, false, true, true, true, true, true, true},
                { true, false, false, false, false, false, true, true},
                { true, false, true, false, true, false, true, true},
                { true, false, true, false, true, true, true, true},
                { true, false, true, true, true, true, true, true},
                { true, false, false, false, false, false, true, true},
                { true, true, true, true, true, true, true, true},
                { true, true, true, true, true, true, true, true},
                { true, true, true, true, true, true, true, true},
                { true, true, true, true, true, true, true, true},
                { true, true, true, true, true, true, true, true},
            },
            StartLocation = new Point(0, 4),
            EndLocation = new Point(4, 4)
        };
        
        AStar.ValidateParams(searchParams);

        var grid = Grid.CreateGrid(searchParams.Map);
        grid.Print(searchParams.StartLocation, searchParams.EndLocation);

        var path = AStar.FindPath(searchParams, grid);

        Console.WriteLine(path.ToLogString());
        grid.PrintPath(path, searchParams.StartLocation, searchParams.EndLocation);
    }

    private static class AStar
    {
        public static List<Point> FindPath(SearchParameters search, Grid grid)
        {
            var startNode = grid[search.StartLocation.X, search.StartLocation.Y];
            var endNode = grid[search.EndLocation.X, search.EndLocation.Y];

            var path = new List<Point>();
            var success = Search(startNode, endNode);
            if (success)
            {
                var node = endNode;
                while (node.ParentNode != null)
                {
                    path.Add(node.Location);
                    node = node.ParentNode;
                }
                path.Reverse();
            }
            return path;
        }

        public static void ValidateParams(SearchParameters searchParams)
        {
            if (!searchParams.Map[searchParams.StartLocation.X, searchParams.StartLocation.Y])
            {
                throw new ArgumentException("Start location is not walkable");
            }

            if (!searchParams.Map[searchParams.EndLocation.X, searchParams.EndLocation.Y])
            {
                throw new ArgumentException("End location is not walkable");
            }
        }

        private static bool Search(Node currentNode, Node endNode)
        {
            currentNode.State = NodeState.Closed;
            var nextNodes = currentNode.GetAdjacentWalkableNodes(endNode);
            
            foreach (var nextNode in nextNodes)
            {
                if (nextNode.Location == endNode.Location)
                {
                    return true;
                }

                if (Search(nextNode, endNode)) // Note: Recurses back into Search(Node)
                    return true;
            }
            return false;
        }
    }
}
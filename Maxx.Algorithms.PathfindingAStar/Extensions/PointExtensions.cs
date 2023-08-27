namespace Maxx.Algorithms.PathfindingAStar.Extensions
{
    using System.Drawing;

    public static class PointExtensions
    {
        public static IEnumerable<Point> GetAdjacentLocations(this Point currentLocation, bool canTraverseDiagonally = true)
        {
            if (canTraverseDiagonally)
            {
                return new List<Point>
                {
                    currentLocation with { X = currentLocation.X + 1 }, //right
                    new(currentLocation.X + 1, currentLocation.Y + 1), //bottom-right
                    currentLocation with { Y = currentLocation.Y - 1 }, //bottom
                    new(currentLocation.X - 1, currentLocation.Y - 1), //bottom-left
                    currentLocation with { X = currentLocation.X - 1 }, //left
                    new(currentLocation.X - 1, currentLocation.Y + 1), //top-left
                    currentLocation with { Y = currentLocation.Y + 1 }, //top
                    new(currentLocation.X + 1, currentLocation.Y + 1) //top-right
                };
            }

            return new List<Point>
            {
                currentLocation with { X = currentLocation.X + 1 }, //right
                currentLocation with { Y = currentLocation.Y - 1 }, //bottom
                currentLocation with { X = currentLocation.X - 1 }, //left
                currentLocation with { Y = currentLocation.Y + 1 } //top
            };
        }

        public static string ToLogString(this IEnumerable<Point> path)
        {
            return string.Join(',', path);
        }
    }
}
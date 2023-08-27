namespace Maxx.Algorithms.PathfindingAStar.Models;

using System.Drawing;

public class SearchParameters
{
    public Point StartLocation { get; set; }
    public Point EndLocation { get; set; }
    public bool[,] Map { get; set; }
}
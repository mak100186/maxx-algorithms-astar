namespace Maxx.Algorithms.PathfindingAStar.Models;

using System.Drawing;

public class Node
{
    public bool IsWalkable { get; set; }
    public Point Location { get; set; }
    public float G { get; set; }
    public float H { get; set; }
    public float F => G + H;
    public NodeState State { get; set; }
    public Node ParentNode { get; set; }
    public Grid Grid { get; set; }
}
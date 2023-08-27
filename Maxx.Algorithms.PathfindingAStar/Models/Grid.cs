using System.Drawing;

namespace Maxx.Algorithms.PathfindingAStar.Models;

public class Grid
{
    private readonly Node[,] _grid;
    public int Width { get; }
    public int Height { get; }
    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        _grid = new Node[width, height];
    }

    public Node this[int i, int j]
    {
        get => _grid[i, j];
        set => _grid[i, j] = value;
    }

    public void ForAll(Action<Node> action)
    {
        for (var row = 0; row < Height; row++)
        {
            for (var col = 0; col < Width; col++)
            {
                var node = _grid[row, col];

                action(node);
            }
        }
    }

    public static Grid CreateGrid(bool[,] searchParamsMap)
    {
        var rowsOrHeight = searchParamsMap.GetLength(0);
        var colsOrWidth = searchParamsMap.GetLength(1);

        var grid = new Grid(colsOrWidth, rowsOrHeight);

        for (var row = 0; row < rowsOrHeight; row++)
        {
            for (var col = 0; col < colsOrWidth; col++)
            {
                var nodeVal = searchParamsMap[row, col];

                grid[col, row] = new Node
                {
                    IsWalkable = nodeVal,
                    Location = new Point(col, row),
                    Grid = grid,
                    State = NodeState.Untested,
                    ParentNode = null,
                    G = 0f,
                    H = 0f
                };
            }
        }

        return grid;
    }
}
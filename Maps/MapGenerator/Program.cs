using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapRunner;
using System.IO;

namespace MapGenerator
{
    class Program
    {
        enum Way { N, S, E, W }
        static void Main(string[] args)
        {
            var seed = args.Length > 1 ? Convert.ToInt32(args[0]) : int.MaxValue;
            var moves = args.Length > 2 ? Convert.ToInt32(args[0]) : 100000;
            var maxPath = args.Length > 3 ? Convert.ToInt32(args[1]) : 1000;
            var map = new Map(seed);
            Explore(map, moves, maxPath);
            DrawMap(map);
        }

        private static void Explore(Map map, int moves, int maxPath)
        {
            List<Way> path = new List<Way>();
            for (int i = 0; i < moves; i++)
            {
                Func<MapSquare, bool> IsWest = s => s.X == map.Current.X - 1 && s.Y == map.Current.Y;
                Func<MapSquare, bool> IsEast = s => s.X == map.Current.X + 1 && s.Y == map.Current.Y;
                Func<MapSquare, bool> IsNorth = s => s.X == map.Current.X && s.Y == map.Current.Y + 1;
                Func<MapSquare, bool> IsSouth = s => s.X == map.Current.X && s.Y == map.Current.Y - 1;
                // First off just go somewhere we havent been before.
                if (map.Current.NorthEdge.EdgeType == MapSquareEdgeType.Path
                    && !map.Squares.Any(IsNorth)
                    && path.Count < maxPath)
                {
                    map.GoNorth();
                    path.Insert(0, Way.N);
                }
                else if (map.Current.EastEdge.EdgeType == MapSquareEdgeType.Path
                    && !map.Squares.Any(IsEast)
                    && path.Count < maxPath)
                {
                    map.GoEast();
                    path.Insert(0, Way.E);
                }
                else if (map.Current.SouthEdge.EdgeType == MapSquareEdgeType.Path
                    && !map.Squares.Any(IsSouth)
                    && path.Count < maxPath)
                {
                    map.GoSouth();
                    path.Insert(0, Way.S);
                }
                else if (map.Current.WestEdge.EdgeType == MapSquareEdgeType.Path
                    && !map.Squares.Any(IsWest)
                    && path.Count < maxPath)
                {
                    map.GoWest();
                    path.Insert(0, Way.W);
                }
                else
                {
                    // then go back the way we came.
                    if (path.Any())
                    {
                        if (path[0] == Way.S)
                        {
                            map.GoNorth();
                        }
                        else if (path[0] == Way.N)
                        {
                            map.GoSouth();
                        }
                        else if (path[0] == Way.W)
                        {
                            map.GoEast();
                        }
                        else if (path[0] == Way.E)
                        {
                            map.GoWest();
                        }
                        i--;
                        path.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void DrawMap(Map map)
        {
            if (File.Exists("map.txt"))
            {
                File.Delete("map.txt");
            }
            using (StreamWriter writer = new StreamWriter("map.txt"))
            {
                if (map.Squares.Any())
                {
                    var maxX = map.Squares.Max(s => s.X);
                    var minX = map.Squares.Min(s => s.X);
                    var maxY = map.Squares.Max(s => s.Y);
                    var minY = map.Squares.Min(s => s.Y);
                    for (int y = maxY; y >= minY; y--)
                    {
                        for (int x = minX; x <= maxX; x++)
                        {
                            if (y == 0 && x == 0)
                            {
                                writer.Write("X");
                            }
                            else
                            {
                                var square = map.Squares.SingleOrDefault(s => s.X == x && s.Y == y);
                                if (square == null)
                                {
                                    writer.Write(" ");
                                }
                                else
                                {
                                    if (square.NorthEdge.EdgeType == MapSquareEdgeType.Path)
                                    {
                                        if (square.EastEdge.EdgeType == MapSquareEdgeType.Path)
                                        {
                                            if (square.SouthEdge.EdgeType == MapSquareEdgeType.Path)
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("╬");
                                                }
                                                else
                                                {
                                                    writer.Write("╠");
                                                }
                                            }
                                            else
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("╩");
                                                }
                                                else
                                                {
                                                    writer.Write("╚");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (square.SouthEdge.EdgeType == MapSquareEdgeType.Path)
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("╣");
                                                }
                                                else
                                                {
                                                    writer.Write("║");
                                                }
                                            }
                                            else
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("╝");
                                                }
                                                else
                                                {
                                                    writer.Write("╨");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (square.EastEdge.EdgeType == MapSquareEdgeType.Path)
                                        {
                                            if (square.SouthEdge.EdgeType == MapSquareEdgeType.Path)
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("╦");
                                                }
                                                else
                                                {
                                                    writer.Write("╔");
                                                }
                                            }
                                            else
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("═");
                                                }
                                                else
                                                {
                                                    writer.Write("╞");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (square.SouthEdge.EdgeType == MapSquareEdgeType.Path)
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("╗");
                                                }
                                                else
                                                {
                                                    writer.Write("╥");
                                                }
                                            }
                                            else
                                            {
                                                if (square.WestEdge.EdgeType == MapSquareEdgeType.Path)
                                                {
                                                    writer.Write("╡");
                                                }
                                                else
                                                {
                                                    throw new Exception("WTF");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}

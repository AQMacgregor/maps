﻿// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 10:29:05 AM

using Map;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{
    /// <summary>
    /// This class is responsible for 
    /// </summary>
    class MapDrawer
    {
        public void DrawMap(Map.Map map)
        {
            if (File.Exists("map.txt"))
            {
                File.Delete("map.txt");
            }
            using (StreamWriter writer = new StreamWriter("map.txt"))
            {
                Draw(writer, map.Squares);
            }
        }
        public void DrawPath(Explorer.Path path)
        {
            if (File.Exists("path.txt"))
            {
                File.Delete("path.txt");
            }
            using (StreamWriter writer = new StreamWriter("path.txt"))
            {
                Draw(writer, path.Squares);
            }
        }
        private void Draw(StreamWriter writer, IReadOnlyList<MapSquare> squares)
        {
            if (squares.Any())
            {
                var maxX = squares.Max(s => s.X);
                var minX = squares.Min(s => s.X);
                var maxY = squares.Max(s => s.Y);
                var minY = squares.Min(s => s.Y);
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
                            var square = squares.FirstOrDefault(s => s.X == x && s.Y == y);
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
                                                writer.Write(" ");
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

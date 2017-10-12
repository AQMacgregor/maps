// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 10:29:05 AM
// Copyright : (c) Copyright Magnitude Software 2017

using MapRunner;
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

        public void DrawMap(List<MapSquare> squares)
        {
            if (File.Exists("map.txt"))
            {
                File.Delete("map.txt");
            }
            using (StreamWriter writer = new StreamWriter("map.txt"))
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
}

// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 12:51:39 PM
// Copyright : (c) Copyright Magnitude Software 2017

using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Generators
{
    /// <summary>
    /// This class is responsible for 
    /// </summary>
    public class StraightPathGenerator : Generator
    {
        private Random Random { get; set; }
        public StraightPathGenerator(int seed, Map.Map map) : base(map)
        {
            Random = new Random(seed);
        }

        public override void Generate()
        {
            int corner = (Convert.ToInt32(Math.Sqrt(Map.Squares.Count)) + 1) / 2;
            for (int x = -corner; x < corner; x++)
            {
                Map.AddSquare(CreateSquare(x, -corner, Map.Squares));
            }
            for (int y = -corner; y < corner; y++)
            {
                Map.AddSquare(CreateSquare(corner, y, Map.Squares));
            }
            for (int x = corner; x > -corner; x--)
            {
                Map.AddSquare(CreateSquare(x, corner, Map.Squares));
            }
            for (int y = corner; y > -corner; y--)
            {
                Map.AddSquare(CreateSquare(-corner, y, Map.Squares));
            }
        }
        public MapSquare CreateSquare(int x, int y, IReadOnlyList<MapSquare> squares)
        {
            MapSquareEdge north = null;
            MapSquareEdge east = null;
            MapSquareEdge south = null;
            MapSquareEdge west = null;

            var numberOfpaths = 0;
            MapSquare n = squares.SingleOrDefault(square => square.X == x && square.Y == y + 1);
            if (n != null)
            {
                north = new MapSquareEdge(n.SouthEdge.EdgeType);
                if (north.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }
            MapSquare e = squares.SingleOrDefault(square => square.X == x + 1 && square.Y == y);
            if (e != null)
            {
                east = new MapSquareEdge(e.WestEdge.EdgeType);
                if (east.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }
            MapSquare s = squares.SingleOrDefault(square => square.X == x && square.Y == y - 1);
            if (s != null)
            {
                south = new MapSquareEdge(s.NorthEdge.EdgeType);
                if (south.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }
            MapSquare w = squares.SingleOrDefault(square => square.X == x - 1 && square.Y == y);
            if (w != null)
            {
                west = new MapSquareEdge(w.EastEdge.EdgeType);
                if (west.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }

            var requiredNumberOfPaths = Random.Next(0, 4);
            if (requiredNumberOfPaths == 2 && numberOfpaths == 1)
            {
                if (north == null && south != null && south.EdgeType == MapSquareEdgeType.Path)
                {
                    north = new MapSquareEdge(MapSquareEdgeType.Path);
                    numberOfpaths++;
                }
                if (south == null && north != null && north.EdgeType == MapSquareEdgeType.Path)
                {
                    south = new MapSquareEdge(MapSquareEdgeType.Path);
                    numberOfpaths++;
                }
                if (east == null && west != null && west.EdgeType == MapSquareEdgeType.Path)
                {
                    east = new MapSquareEdge(MapSquareEdgeType.Path);
                    numberOfpaths++;
                }
                if (west == null && east != null && east.EdgeType == MapSquareEdgeType.Path)
                {
                    west = new MapSquareEdge(MapSquareEdgeType.Path);
                    numberOfpaths++;
                }
            }
            if (north == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    north = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    north = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (south == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    south = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    south = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (east == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    east = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    east = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (west == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    west = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    west = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            return new MapSquare(x, y, north, east, south, west);
        }
    }
}

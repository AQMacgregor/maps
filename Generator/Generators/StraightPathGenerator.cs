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
            var chanceOfTurn = 0.3;
            var chanceOfDoubleTurn = 0.05;
            var chanceOfBlock = 0.1;

            var turn = Random.Next(100) < chanceOfTurn * 100;
            var doubleTurn = Random.Next(100) < chanceOfDoubleTurn * 100;
            var block = Random.Next(100) < chanceOfBlock * 100;

            MapSquareEdge north = null;
            MapSquareEdge east = null;
            MapSquareEdge south = null;
            MapSquareEdge west = null;

            // First get what we are connected to and fill in the edge types accordingly.
            
            MapSquare e = squares.SingleOrDefault(square => square.X == x + 1 && square.Y == y);
            if (e != null)
            {
                east = new MapSquareEdge(e.WestEdge.EdgeType);
            }
            MapSquare w = squares.SingleOrDefault(square => square.X == x - 1 && square.Y == y);
            if (w != null)
            {
                west = new MapSquareEdge(w.EastEdge.EdgeType);
            }
            MapSquare n = squares.SingleOrDefault(square => square.X == x && square.Y == y + 1);
            if (n != null)
            {
                north = new MapSquareEdge(n.SouthEdge.EdgeType);
            }
            MapSquare s = squares.SingleOrDefault(square => square.X == x && square.Y == y - 1);
            if (s != null)
            {
                south = new MapSquareEdge(s.NorthEdge.EdgeType);
            }

            // Now we want to setup any straight lines
            if (east == null && west != null && west.EdgeType == MapSquareEdgeType.Path)
            {
                east = new MapSquareEdge(block ? MapSquareEdgeType.Blocked : MapSquareEdgeType.Path);
            }
            else if (west == null && east != null && east.EdgeType == MapSquareEdgeType.Path)
            {
                west = new MapSquareEdge(block ? MapSquareEdgeType.Blocked : MapSquareEdgeType.Path);
            }
            else if (north == null && south != null && south.EdgeType == MapSquareEdgeType.Path)
            {
                north = new MapSquareEdge(block ? MapSquareEdgeType.Blocked : MapSquareEdgeType.Path);
            }
            else if (south == null && north != null && north.EdgeType == MapSquareEdgeType.Path)
            {
                south = new MapSquareEdge(block ? MapSquareEdgeType.Blocked : MapSquareEdgeType.Path);
            }
            // Now fill in the rest
            if (north == null)
            {
                if (turn)
                {
                    north = new MapSquareEdge(MapSquareEdgeType.Path);
                    turn = doubleTurn;
                    doubleTurn = false;
                }
                else
                {
                    north = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (south == null)
            {
                if (turn)
                {
                    south = new MapSquareEdge(MapSquareEdgeType.Path);
                    turn = doubleTurn;
                    doubleTurn = false;
                }
                else
                {
                    south = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (east == null)
            {
                if (turn)
                {
                    east = new MapSquareEdge(MapSquareEdgeType.Path);
                    turn = doubleTurn;
                    doubleTurn = false;
                }
                else
                {
                    east = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (west == null)
            {
                if (turn)
                {
                    west = new MapSquareEdge(MapSquareEdgeType.Path);
                    turn = doubleTurn;
                    doubleTurn = false;
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

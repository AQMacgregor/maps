// Author 	 : Alexander.Macgregor
// Date	  	 : 10/11/2017 9:50:01 AM
// Copyright : (c) Copyright Magnitude Software 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRunner
{
    /// <summary>
    /// This class is responsible for 
    /// </summary>
    public class MapSquare
    {
        public int X {  get; private set; }
        public int Y { get; private set; }
        internal bool Visited { get; private set; }
        public MapSquareEdge NorthEdge { get; private set; }
        public MapSquareEdge EastEdge { get; private set; }
        public MapSquareEdge SouthEdge { get; private set; }
        public MapSquareEdge WestEdge { get; private set; }

        public MapSquare(Random rand, int x, int y, List<MapSquare> squares)
        {
            X = x;
            Y = y;
            var numberOfpaths = 0;
            MapSquare n = squares.SingleOrDefault(square => square.X == x && square.Y == y + 1);
            if(n != null)
            {
                NorthEdge = new MapSquareEdge(n.SouthEdge.EdgeType);
                if(NorthEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }
            MapSquare e = squares.SingleOrDefault(square => square.X == x + 1 && square.Y == y);
            if (e != null)
            {
                EastEdge = new MapSquareEdge(e.WestEdge.EdgeType);
                if (EastEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }
            MapSquare s = squares.SingleOrDefault(square => square.X == x && square.Y == y - 1);
            if (s != null)
            {
                SouthEdge = new MapSquareEdge(s.NorthEdge.EdgeType);
                if (SouthEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }
            MapSquare w = squares.SingleOrDefault(square => square.X == x - 1 && square.Y == y);
            if (w != null)
            {
                WestEdge = new MapSquareEdge(w.EastEdge.EdgeType);
                if (WestEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    numberOfpaths++;
                }
            }

            var requiredNumberOfPaths = rand.Next(0, 4);
            if (requiredNumberOfPaths == 2 && numberOfpaths == 1)
            {
                if (NorthEdge == null && SouthEdge != null && SouthEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    NorthEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                if (SouthEdge == null && NorthEdge != null && NorthEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    SouthEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                if (EastEdge == null && WestEdge != null && WestEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    EastEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                if (WestEdge == null && EastEdge != null && EastEdge.EdgeType == MapSquareEdgeType.Path)
                {
                    WestEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
            }
            if (NorthEdge == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    NorthEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    NorthEdge = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (SouthEdge == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    SouthEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    SouthEdge = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (EastEdge == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    EastEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    EastEdge = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            if (WestEdge == null)
            {
                if (requiredNumberOfPaths > numberOfpaths)
                {
                    WestEdge = new MapSquareEdge(MapSquareEdgeType.Path);
                }
                else
                {
                    WestEdge = new MapSquareEdge(MapSquareEdgeType.Blocked);
                }
            }
            Visited = false;
        }
        public void Visit()
        {
            Visited = true;
        }
        private MapSquare()
        {
            X = 0;
            Y = 0;
            NorthEdge = new MapSquareEdge();
            EastEdge = new MapSquareEdge();
            SouthEdge = new MapSquareEdge();
            WestEdge = new MapSquareEdge();
            Visited = true;
        }
        public static MapSquare Start()
        {
            return new MapSquare();
        }
    }
}

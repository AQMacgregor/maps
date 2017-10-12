// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 10:23:44 AM
// Copyright : (c) Copyright Magnitude Software 2017

using Explorer.PathFinder;
using MapRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    /// <summary>
    /// This class is responsible for 
    /// </summary>
    public class Explorer
    {
        MapSquare Current { get; set; }
        public Map Map { get; private set; }
        public Path Path { get; private set; }
        public Explorer(Map map)
        {
            Map = map;
            Path = new Path();
            Go(0, 0);
        }

        public bool CanGoNorth()
        {
            return Current.NorthEdge.EdgeType == MapSquareEdgeType.Path;
        }
        public bool HaveBeenNorth()
        {
            Func<MapSquare, bool> IsNorth = s => s.X == Current.X && s.Y == Current.Y + 1;
            return Path.Squares.Any(IsNorth);
        }
        public MapSquare GoNorth()
        {
            if (CanGoNorth())
            {
                return Go(Current.X, Current.Y + 1);
            }
            else
            {
                return Current;
            }
        }

        public bool CanGoSouth()
        {
            return Current.SouthEdge.EdgeType == MapSquareEdgeType.Path;
        }
        public bool HaveBeenSouth()
        {
            Func<MapSquare, bool> IsSouth = s => s.X == Current.X && s.Y == Current.Y - 1;
            return Path.Squares.Any(IsSouth);
        }
        public MapSquare GoSouth()
        {
            if (CanGoSouth())
            {
                return Go(Current.X, Current.Y - 1);
            }
            else
            {
                return Current;
            }
        }

        public bool CanGoEast()
        {
            return Current.EastEdge.EdgeType == MapSquareEdgeType.Path;
        }
        public bool HaveBeenEast()
        {
            Func<MapSquare, bool> IsEast = s => s.X == Current.X + 1 && s.Y == Current.Y;
            return Path.Squares.Any(IsEast);
        }
        public MapSquare GoEast()
        {
            if (CanGoEast())
            {
                return Go(Current.X + 1, Current.Y);
            }
            else
            {
                return Current;
            }
        }

        public bool CanGoWest()
        {
            return Current.WestEdge.EdgeType == MapSquareEdgeType.Path;
        }
        public bool HaveBeenWest()
        {
            Func<MapSquare, bool> IsWest = s => s.X == Current.X - 1 && s.Y == Current.Y;
            return Path.Squares.Any(IsWest);
        }
        public MapSquare GoWest()
        {
            if (CanGoWest())
            {
                return Go(Current.X - 1, Current.Y);
            }
            else
            {
                return Current;
            }
        }

        private MapSquare Go(int x, int y)
        {
            Current = Map.Squares.SingleOrDefault(s => s.X == x && s.Y == y);
            if (Current == null)
            {
                Map.Generate();
                Current = Go(x, y);
            }
            Path.Squares.Add(Current);
            return Current;
        }
    }
}

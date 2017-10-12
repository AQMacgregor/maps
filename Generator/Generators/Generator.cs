using Explorer;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Generators
{
    public abstract class Generator : ILocationListener
    {
        public Map.Map Map { get; protected set;}
        public Generator(Map.Map map)
        {
            Map = map;
            Map.AddSquare(new MapSquare(0, 0, new MapSquareEdge(MapSquareEdgeType.Path), new MapSquareEdge(MapSquareEdgeType.Path), new MapSquareEdge(MapSquareEdgeType.Path), new MapSquareEdge(MapSquareEdgeType.Path)));
        }
        public abstract void Generate();

        public void MovedTo(MapSquare location)
        {
            // If its at the edge run a generate
            MapSquare n = Map.Squares.SingleOrDefault(square => square.X == location.X && square.Y == location.Y + 1);
            MapSquare e = Map.Squares.SingleOrDefault(square => square.X == location.X + 1 && square.Y == location.Y);
            MapSquare s = Map.Squares.SingleOrDefault(square => square.X == location.X && square.Y == location.Y - 1);
            MapSquare w = Map.Squares.SingleOrDefault(square => square.X == location.X - 1 && square.Y == location.Y);
            if(n == null || e == null || s == null || w == null)
            {
                Generate();
            }
        }
    }
}

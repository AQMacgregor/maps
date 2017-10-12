using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRunner
{
    public class Map
    {
        private List<MapSquare> m_squares;
        public List<MapSquare> Squares { get { return m_squares.Where(s => s.Visited).ToList(); } }
        public MapSquare Current { get; private set; }
        private Random Random { get; set; }

        public Map(int seed)
        {
            Random = new Random(seed);
            Current = MapSquare.Start();
            m_squares = new List<MapSquare>() { Current };
        }
        private void Generate()
        {
            int corner = (Convert.ToInt32(Math.Sqrt(m_squares.Count)) + 1)/2;
            for(int x = -corner; x < corner; x++)
            {
                m_squares.Add(new MapSquare(Random, x, -corner, m_squares));
            }
            for (int y = -corner; y < corner; y++)
            {
                m_squares.Add(new MapSquare(Random, corner, y, m_squares));
            }
            for (int x = corner; x > -corner; x--)
            {
                m_squares.Add(new MapSquare(Random, x, corner, m_squares));
            }
            for (int y = corner; y > -corner; y--)
            {
                m_squares.Add(new MapSquare(Random, -corner, y, m_squares));
            }
        }
        public MapSquare GoNorth()
        {
            if (Current.NorthEdge.EdgeType == MapSquareEdgeType.Path)
            {
                return Go(Current.X, Current.Y + 1);
            }
            else
            {
                return Current;
            }
        }
        public MapSquare GoSouth()
        {
            if (Current.SouthEdge.EdgeType == MapSquareEdgeType.Path)
            {
                return Go(Current.X, Current.Y - 1);
            }
            else
            {
                return Current;
            }
        }
        public MapSquare GoEast()
        {
            if (Current.EastEdge.EdgeType == MapSquareEdgeType.Path)
            {
                return Go(Current.X + 1, Current.Y);
            }
            else
            {
                return Current;
            }
        }
        public MapSquare GoWest()
        {
            if (Current.WestEdge.EdgeType == MapSquareEdgeType.Path)
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
            Current = m_squares.SingleOrDefault(s => s.X == x && s.Y == y);
            if (Current == null)
            {
                Generate();
                Current = Go(x, y);
            }
            Current.Visit();
            return Current;
        }
    }
}

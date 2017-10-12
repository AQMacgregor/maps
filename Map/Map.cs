using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRunner
{
    public class Map
    {
        public List<MapSquare> Squares { get; private set; }
        private Random Random { get; set; }

        public Map(int seed)
        {
            Random = new Random(seed);
            Squares = new List<MapSquare>() { MapSquare.Start() };
        }
        public void Generate( int generations = 1)
        {
            for (int i = 0; i < generations; i++)
            {
                Generate();
            }
        }
        private void Generate()
        {
            int corner = (Convert.ToInt32(Math.Sqrt(Squares.Count)) + 1)/2;
            for(int x = -corner; x < corner; x++)
            {
                Squares.Add(new MapSquare(Random, x, -corner, Squares));
            }
            for (int y = -corner; y < corner; y++)
            {
                Squares.Add(new MapSquare(Random, corner, y, Squares));
            }
            for (int x = corner; x > -corner; x--)
            {
                Squares.Add(new MapSquare(Random, x, corner, Squares));
            }
            for (int y = corner; y > -corner; y--)
            {
                Squares.Add(new MapSquare(Random, -corner, y, Squares));
            }
        }
    }
}

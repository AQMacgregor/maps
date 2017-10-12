// Author 	 : Alexander.Macgregor
// Date	  	 : 10/11/2017 9:50:01 AM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    /// <summary>
    /// This class is responsible for 
    /// </summary>
    public class MapSquare
    {
        public int X {  get; private set; }
        public int Y { get; private set; }
        public MapSquareEdge NorthEdge { get; private set; }
        public MapSquareEdge EastEdge { get; private set; }
        public MapSquareEdge SouthEdge { get; private set; }
        public MapSquareEdge WestEdge { get; private set; }
        public MapSquare(int x, int y, MapSquareEdge n, MapSquareEdge e, MapSquareEdge s, MapSquareEdge w)
        {
            X = x;
            Y = y;
            NorthEdge = n;
            EastEdge = e;
            SouthEdge = s;
            WestEdge = w;
        }
    }
}

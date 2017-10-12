using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class Map
    {
        List<MapSquare> m_squares = new List<MapSquare>();
        public IReadOnlyList<MapSquare> Squares
        {
            get
            {
                return m_squares.AsReadOnly();
            }
        }


        public void AddSquare(MapSquare square)
        {
            m_squares.Add(square);
        }
    }
}

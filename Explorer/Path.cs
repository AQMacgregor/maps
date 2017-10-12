// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 10:43:07 AM

using Map;
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
    public class Path
    {
        private List<MapSquare> m_squares;
        private List<ILocationListener> m_listeners;
        public IReadOnlyList<MapSquare> Squares
        {
            get
            {
                return m_squares.AsReadOnly();
            }
        }
        public Path(List<ILocationListener> listeners)
        {
            m_squares = new List<MapSquare>();
            m_listeners = listeners;
        }
        public void AddLocation(MapSquare square)
        {
            m_squares.Add(square);
            m_listeners.ForEach(l => l.MovedTo(square));
        }
    }
}

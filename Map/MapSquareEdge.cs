// Author 	 : Alexander.Macgregor
// Date	  	 : 10/11/2017 9:50:19 AM

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
    public class MapSquareEdge
    {
        public MapSquareEdgeType EdgeType { get; private set; }
        public MapSquareEdge(MapSquareEdgeType edgeType)
        {
            EdgeType = edgeType;
        }
    }
}

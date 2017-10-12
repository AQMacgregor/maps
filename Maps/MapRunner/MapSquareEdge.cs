// Author 	 : Alexander.Macgregor
// Date	  	 : 10/11/2017 9:50:19 AM
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
    public class MapSquareEdge
    {
        public MapSquareEdgeType EdgeType { get; private set; }
        public MapSquareEdge(MapSquareEdgeType edgeType)
        {
            EdgeType = edgeType;
        }
        internal MapSquareEdge()
        {
            EdgeType = MapSquareEdgeType.Path;
        }
    }
}

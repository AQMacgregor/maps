// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 10:43:07 AM
// Copyright : (c) Copyright Magnitude Software 2017

using MapRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.PathFinder
{
    /// <summary>
    /// This class is responsible for 
    /// </summary>
    public class Path
    {
        public List<MapSquare> Squares { get; private set; }
        public Path()
        {
            Squares = new List<MapSquare>();
        }
    }
}

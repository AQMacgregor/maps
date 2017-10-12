// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 3:09:46 PM
// Copyright : (c) Copyright Magnitude Software 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map;

namespace Explorer.Explorers
{
    /// <summary>
    /// This class is responsible for 
    /// </summary>
    public class RandomExplorer : Explorer
    {
        public RandomExplorer(Map.Map map, List<ILocationListener> listeners) 
            : base(map, listeners)
        {
        }
        public void Explore(int seed, int moves)
        {
            Random rand = new Random(seed);
            for(int i = 0; i < moves; i ++)
            {
                switch (rand.Next(4))
                {
                    case 0:
                        GoNorth();
                        break;
                    case 1:
                        GoEast();
                        break;
                    case 2:
                        GoSouth();
                        break;
                    case 3:
                        GoWest();
                        break;
                }

            }

        }
    }
}

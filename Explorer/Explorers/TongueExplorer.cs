using MapRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.PathFinder
{
    public class TongueExplorer : Explorer
    {
        public TongueExplorer(Map map) 
            :base(map)
        {
        }

        enum Way { N, S, E, W }

        public void Explore(int moves, int maxPath)
        {
            List<Way> path = new List<Way>();
            for (int i = 0; i < moves; i++)
            {
                // First off just go somewhere we havent been before.
                if (CanGoNorth()
                    && !HaveBeenNorth()
                    && path.Count < maxPath)
                {
                    GoNorth();
                    path.Insert(0, Way.N);
                }
                else if (CanGoEast()
                    && !HaveBeenEast()
                    && path.Count < maxPath)
                {
                    GoEast();
                    path.Insert(0, Way.E);
                }
                else if (CanGoSouth()
                    && !HaveBeenSouth()
                    && path.Count < maxPath)
                {
                    GoSouth();
                    path.Insert(0, Way.S);
                }
                else if (CanGoWest()
                    && !HaveBeenWest()
                    && path.Count < maxPath)
                {
                    GoWest();
                    path.Insert(0, Way.W);
                }
                else
                {
                    // then go back the way we came.
                    if (path.Any())
                    {
                        if (path[0] == Way.S)
                        {
                            GoNorth();
                        }
                        else if (path[0] == Way.N)
                        {
                            GoSouth();
                        }
                        else if (path[0] == Way.W)
                        {
                            GoEast();
                        }
                        else if (path[0] == Way.E)
                        {
                            GoWest();
                        }
                        i--;
                        path.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}

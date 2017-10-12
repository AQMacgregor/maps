using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapRunner;
using System.IO;
using Explorer.PathFinder;

namespace MapGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = args.Length > 1 ? Convert.ToInt32(args[0]) : int.MaxValue;
            var moves = args.Length > 2 ? Convert.ToInt32(args[0]) : 100;
            var maxPath = args.Length > 3 ? Convert.ToInt32(args[1]) : 100;
            var map = new Map(seed);

            var explorer = new TongueExplorer(map);
            explorer.Explore(moves, maxPath);

            MapDrawer drawer = new MapDrawer();
            drawer.DrawMap(explorer.Path.Squares);
        }
    }
}

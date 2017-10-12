using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map;
using System.IO;
using Explorer.Explorers;
using Generator.Generators;

namespace MapGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = args.Length > 1 ? Convert.ToInt32(args[0]) : int.MaxValue;
            var moves = args.Length > 2 ? Convert.ToInt32(args[0]) : 10000;
            var maxPath = args.Length > 3 ? Convert.ToInt32(args[1]) : 100;
            var map = new Map.Map();
            var generator = new StraightPathGenerator(seed, map);
            var explorer = new TongueExplorer(map, new List<Explorer.ILocationListener>() { generator });
            explorer.Explore(moves, maxPath);

            MapDrawer drawer = new MapDrawer();
            drawer.DrawMap(map);
            drawer.DrawPath(explorer.Path);
        }
    }
}

// Author 	 : Alexander.Macgregor
// Date	  	 : 10/12/2017 1:11:38 PM

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
    public interface ILocationListener
    {
        void MovedTo(MapSquare location);
    }
}

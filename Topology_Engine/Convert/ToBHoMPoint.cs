using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using Topologic;
using BH.Engine.Geometry;

namespace BH.Engine.Topology
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Point ToBHoMPoint(this Vertex vertex)
        {
            return new Point { X = vertex.X, Y = vertex.Y, Z = vertex.Z };
        }

        /***************************************************/
    }
}

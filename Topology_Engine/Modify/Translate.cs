using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

namespace BH.Engine.Topology
{
    public static partial class Modify
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Topologic.Topology Translate(this Topologic.Topology topology, Vector vector)
        {
            return topology.Translate(vector.X, vector.Y, vector.Z);
        }

        /***************************************************/
    }
}

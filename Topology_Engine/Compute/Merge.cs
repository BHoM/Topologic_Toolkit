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
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Topologic.Topology Merge(this Topologic.Topology topology, Topologic.Topology otherTopology)
        {
            return topology.Merge(otherTopology);
        }

        /***************************************************/
    }
}

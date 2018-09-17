using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

namespace BH.Engine.Topology
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static List<Topologic.Topology> SharedTopologies(this Topologic.Topology topology, Topologic.Topology otherTopology)
        {
            return topology.SharedTopologies(otherTopology);
        }

        /***************************************************/
    }
}

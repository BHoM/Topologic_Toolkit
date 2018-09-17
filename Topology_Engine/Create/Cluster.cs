using System.Collections.Generic;
using System.Linq;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using Topologic;

namespace BH.Engine.Topology
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Topologic.Cluster Cluster(IEnumerable<Topologic.Topology> topologies)
        {
            return Topologic.Cluster.ByTopologies(topologies);
        }

        /***************************************************/
    }
}

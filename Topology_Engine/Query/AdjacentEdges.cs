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

        public static List<Edge> AdjacentEdges(this Edge edge, Topologic.Topology parentTopology)
        {
            return edge.AdjacentEdges(parentTopology);
        }

        /***************************************************/
    }
}

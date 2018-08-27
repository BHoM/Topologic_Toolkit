using System.Collections.Generic;
using System.Linq;
using BH.oM.Geometry;
using Topologic;
using BH.Engine.Geometry;

namespace BH.Engine.Topology
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Wire Wire(IEnumerable<Edge> edges)
        {
            return Topologic.Wire.ByEdges(edges);
        }

        /***************************************************/

        public static Wire Wire(Polyline polyLine)
        {
            return Topologic.Wire.ByEdges(polyLine.SubParts().Select(x => Create.Edge(x)));
        }

        /***************************************************/
    }
}

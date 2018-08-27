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

        public static Topologic.Face Face(IEnumerable<Edge> edges)
        {
            return Topologic.Face.ByEdges(edges);
        }

        /***************************************************/

        public static Topologic.Face Face(Wire wire)
        {
            return Topologic.Face.ByWire(wire);
        }

        /***************************************************/

        public static Topologic.Face Face(IEnumerable<IEnumerable<Vertex>> vertecies)
        {
            return Topologic.Face.ByVertices(vertecies);
        }

        /***************************************************/

        public static Topologic.Face Face(Polyline polyLine)
        {
            if (!polyLine.IsClosed())
                return null;

            return Topologic.Face.ByWire(Create.Wire(polyLine));
        }

        /***************************************************/
    }
}

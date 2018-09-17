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
            return Topologic.Face.ByExternalBoundary(wire);
        }

        /***************************************************/

        public static Topologic.Face Face(IEnumerable<IEnumerable<Vertex>> vertices)
        {
            return Topologic.Face.ByVertices(vertices);
        }

        /***************************************************/

        public static Topologic.Face Face(Polyline polyLine)
        {
            if (!polyLine.IsClosed())
                return null;

            return Topologic.Face.ByExternalBoundary(Create.Wire(polyLine));
        }

        /***************************************************/

        public static Topologic.Face Face(Wire outerWire, IEnumerable<Wire> innerWires)
        {
            return Topologic.Face.ByExternalInternalBoundaries(outerWire, innerWires);
        }

        /***************************************************/

        public static Topologic.Face Face(Polyline outerPolyline, IEnumerable<Polyline> innerPolylines)
        {
            if (!outerPolyline.IsClosed())
                return null;

            List<Wire> innerWires = new List<Topologic.Wire>();
            foreach(Polyline innerPolyline in innerPolylines)
            {
                if (!innerPolyline.IsClosed())
                    return null;
                innerWires.Add(Create.Wire(innerPolyline));
            }

            return Topologic.Face.ByExternalInternalBoundaries(Create.Wire(outerPolyline), innerWires);
        }

        /***************************************************/
    }
}

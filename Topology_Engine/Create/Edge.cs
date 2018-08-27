using System.Collections.Generic;
using System.Linq;
using BH.oM.Geometry;
using Topologic;

namespace BH.Engine.Topology
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Edge Edge(IEnumerable<Vertex> vertecies)
        {
            return Topologic.Edge.ByVertices(vertecies);
        }

        /***************************************************/

        public static Edge Edge(Line line)
        {
            return Topologic.Edge.ByVertices(new Vertex[] { Create.Vertex(line.Start), Create.Vertex(line.End) });
        }

        /***************************************************/
    }
}
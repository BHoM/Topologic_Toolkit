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

        public static Shell Shell(IEnumerable<Vertex> vertices, IEnumerable<IEnumerable<int>> faceIndices)
        {
            return Topologic.Shell.ByVerticesFaceIndices(vertices, faceIndices);
        }

        /***************************************************/

        public static Shell Shell(IEnumerable<Wire> wires)
        {
            return Topologic.Shell.ByLoft(wires);
        }

        /***************************************************/

        public static Shell Shell(IEnumerable<Topologic.Face> faces)
        {
            return Topologic.Shell.ByFaces(faces);
        }

        /***************************************************/
    }
}

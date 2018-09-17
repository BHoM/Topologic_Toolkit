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

        public static Topologic.Cell Cell(IEnumerable<Topologic.Face> faces)
        {
            return Topologic.Cell.ByFaces(faces);
        }

        /***************************************************/

        public static Topologic.Cell Cell(Topologic.Shell shell)
        {
            return Topologic.Cell.ByShell(shell);
        }

        /***************************************************/

        public static Topologic.Cell Cell(IEnumerable<Vertex> vertices, IEnumerable<IEnumerable<int>> faceIndices)
        {
            return Topologic.Cell.ByVerticesFaceIndices(vertices, faceIndices);
        }

        /***************************************************/

        public static Topologic.Cell Cell(IEnumerable<Topologic.Wire> wires)
        {
            return Topologic.Cell.ByLoft(wires);
        }

        /***************************************************/
    }
}

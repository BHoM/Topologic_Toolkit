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

        public static List<Vertex> SharedVertices(this Cell cell, Cell otherCell)
        {
            return cell.SharedVertices(otherCell);
        }

        /***************************************************/

        public static Vertex SharedVertex(this Edge edge, Edge otherEdge)
        {
            return edge.SharedVertex(otherEdge);
        }

        /***************************************************/

        public static List<Vertex> SharedVertices(this Topologic.Face face, Topologic.Face otherFace)
        {
            return face.SharedVertices(otherFace);
        }

        /***************************************************/
    }
}

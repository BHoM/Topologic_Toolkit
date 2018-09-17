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

        public static List<Edge> SharedEdges(this Cell cell, Cell otherCell)
        {
            return cell.SharedEdges(otherCell);
        }

        /***************************************************/

        public static List<Edge> SharedEdges(this Topologic.Face face, Topologic.Face otherFace)
        {
            return face.SharedEdges(otherFace);
        }

        /***************************************************/
    }
}

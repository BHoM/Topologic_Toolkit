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

        public static List<Edge> Edges(this Vertex vertex, Topologic.Topology parentTopology)
        {
            return vertex.Edges(parentTopology);
        }

        /***************************************************/

        public static List<Edge> Edges(this Cell cell)
        {
            return cell.Edges();
        }

        /***************************************************/

        public static List<Edge> Edges(this CellComplex cellComplex)
        {
            return cellComplex.Edges();
        }

        /***************************************************/

        public static List<Edge> Edges(this Cluster cluster)
        {
            return cluster.Edges();
        }

        /***************************************************/

        public static List<Edge> Edges(this Topologic.Face face)
        {
            return face.Edges();
        }

        /***************************************************/

        public static List<Edge> Edges(this Shell shell)
        {
            return shell.Edges();
        }

        /***************************************************/

        public static List<Edge> Edges(this Wire wire)
        {
            return wire.Edges();
        }

        /***************************************************/

        public static List<Edge> Edges(this DualGraph dualGraph)
        {
            return dualGraph.Edges();
        }

        /***************************************************/
    }
}

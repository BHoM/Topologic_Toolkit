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

        public static List<Vertex> Vertices(this Cluster cluster)
        {
            return cluster.Vertices();
        }

        /***************************************************/

        public static List<Vertex> Vertices(this Cell cell)
        {
            return cell.Vertices();
        }

        /***************************************************/

        public static List<Vertex> Vertices(this CellComplex cellComplex)
        {
            return cellComplex.Vertices();
        }

        /***************************************************/

        public static List<Vertex> Vertices(this Edge edge)
        {
            return edge.Vertices();
        }

        /***************************************************/

        public static List<Vertex> Vertices(this Topologic.Face face)
        {
            return face.Vertices();
        }

        /***************************************************/

        public static List<Vertex> Vertices(this Shell shell)
        {
            return shell.Vertices();
        }

        /***************************************************/

        public static List<Vertex> Vertices(this Wire wire)
        {
            return wire.Vertices();
        }

        /***************************************************/
    }
}

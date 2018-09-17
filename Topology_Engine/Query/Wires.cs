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

        public static List<Wire> Wires(this Cell cell)
        {
            return cell.Wires();
        }

        /***************************************************/

        public static List<Wire> Wires(this CellComplex cellComplex)
        {
            return cellComplex.Wires();
        }

        /***************************************************/

        public static List<Wire> Wires(this Cluster cluster)
        {
            return cluster.Wires();
        }

        /***************************************************/

        public static List<Wire> Wires(this Edge edge)
        {
            return edge.Wires();
        }

        /***************************************************/

        public static List<Wire> Wires(this Topologic.Face face)
        {
            return face.Wires();
        }

        /***************************************************/

        public static List<Wire> Wires(this Shell shell)
        {
            return shell.Wires();
        }

        /***************************************************/
    }
}

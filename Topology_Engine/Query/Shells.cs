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

        public static List<Shell> Shells(this Cell cell)
        {
            return cell.Shells();
        }

        /***************************************************/

        public static List<Shell> Shells(this CellComplex cellComplex)
        {
            return cellComplex.Shells();
        }

        /***************************************************/

        public static List<Shell> Shells(this Cluster cluster)
        {
            return cluster.Shells();
        }

        /***************************************************/

        public static List<Shell> Shells(this Topologic.Face face)
        {
            return face.Shells();
        }

        /***************************************************/
    }
}

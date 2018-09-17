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

        public static List<Shell> InnerBoundaries(this Cell cell)
        {
            return cell.InnerBoundaries();
        }

        /***************************************************/

        public static List<Topologic.Face> InnerBoundaries(this CellComplex cellComplex)
        {
            return cellComplex.InnerBoundaries();
        }

        /***************************************************/

        public static List<Wire> InnerBoundaries(this Topologic.Face face)
        {
            return face.InnerBoundaries();
        }

        /***************************************************/
    }
}

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

        public static Shell OuterBoundary(this Cell cell)
        {
            return cell.OuterBoundary();
        }

        /***************************************************/

        public static Cell OuterBoundary(this CellComplex cellComplex)
        {
            return cellComplex.OuterBoundary();
        }

        /***************************************************/

        public static Wire OuterBoundary(this Topologic.Face face)
        {
            return face.OuterBoundary();
        }

        /***************************************************/
    }
}

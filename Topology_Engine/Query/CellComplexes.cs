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

        public static List<CellComplex> CellComplexes(this Cell cell, Topologic.Topology parentTopology)
        {
            return cell.CellComplexes(parentTopology);
        }

        /***************************************************/

        public static List<CellComplex> CellComplexes(this Cluster cluster, Topologic.Topology parentTopology)
        {
            return cluster.CellComplexes(parentTopology);
        }

        /***************************************************/
    }
}

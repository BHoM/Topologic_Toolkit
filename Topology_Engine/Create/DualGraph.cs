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

        public static Topologic.DualGraph DualGraph(CellComplex cellComplex, bool useCells, bool useNonManifoldFaces, bool useManifoldFaces, bool useApertures)
        {
            return Topologic.DualGraph.ByCellComplex(cellComplex, useCells, useNonManifoldFaces, useManifoldFaces, useApertures);
        }

        /***************************************************/
    }
}

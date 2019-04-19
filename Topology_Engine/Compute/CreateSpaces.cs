using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using Topologic;
using BH.Engine.Geometry;

using BH.Engine.Environment;

namespace BH.Engine.Topology
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static List<Cell> CreateSpaces(IEnumerable<Panel> panels)
        {
            //TODO: Create spaces from the cells
            CellComplex complex = CellComplex.ByFaces(panels.Select(x => x.ToFace()));

            //complex = complex.SelfMerge() as CellComplex;

            return complex.Cells();
        }
    }
}

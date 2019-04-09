using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic.Utilities;

namespace BH.Topologic.Utilities.CellUtility
{
    public static partial class Create
    {
        public static global::Topologic.Cell ByLoft(IEnumerable<global::Topologic.Wire> wires)
        {
            return global::Topologic.Utilities.CellUtility.ByLoft(wires);
        }
    }

    public static partial class Query
    {
        public static double Volume(this global::Topologic.Cell edge)
        {
            return global::Topologic.Utilities.CellUtility.Volume(edge);
        }

        public static bool Contains(this global::Topologic.Cell cell, global::Topologic.Vertex vertex)
        {
            return global::Topologic.Utilities.CellUtility.Contains(cell, vertex);
        }
    }

}
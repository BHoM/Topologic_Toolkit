using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Utilities.ShellUtility
{
    public static partial class Create
    {
        public static Shell ByLoft(IEnumerable<Wire> wires)
        {
            return global::Topologic.Utilities.ShellUtility.ByLoft(wires);
        }
    }
}
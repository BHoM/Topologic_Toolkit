using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.Context
{
    public static partial class Query
    {
        public static global::Topologic.Topology Topology(this global::Topologic.Context context)
        {
            return context.Topology;
        }

    }
}
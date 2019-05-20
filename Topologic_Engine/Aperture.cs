using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Topologic.Core.Aperture
{
    public static partial class Query
    {
        public static global::Topologic.Topology Topology(this global::Topologic.Aperture aperture)
        {
            return aperture.Topology;
        }
    }

    public static partial class Create
    {
        public static global::Topologic.Aperture ByTopologyContext(global::Topologic.Topology topology, global::Topologic.Context context)
        {
            return global::Topologic.Aperture.ByTopologyContext(topology, context);
        }
    }
}

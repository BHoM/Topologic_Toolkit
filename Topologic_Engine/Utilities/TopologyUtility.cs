using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic.Utilities;

namespace BH.Topologic.Utilities.TopologyUtility
{
    public static partial class Query
    {
        public static double Distance(this global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return global::Topologic.Utilities.TopologyUtility.Distance(topology,otherTopology);
        }

        public static global::Topologic.Vertex CenterOfMass(this global::Topologic.Topology topology)
        {
            return global::Topologic.Utilities.TopologyUtility.CenterOfMass(topology);
        }
    }

    public static partial class Modify
    {
        public static global::Topologic.Topology Translate(this global::Topologic.Topology topology, double x, double y, double z)
        {
            return global::Topologic.Utilities.TopologyUtility.Translate(topology,x, y, z);
        }

        public static global::Topologic.Topology Rotate(this global::Topologic.Topology topology, global::Topologic.Vertex origin,
                double xVector, double yVector, double zVector,
                double degree)
        {
            return global::Topologic.Utilities.TopologyUtility.Rotate(topology, origin, xVector, yVector, zVector, degree);
        }

        public static global::Topologic.Topology Scale(this global::Topologic.Topology topology, global::Topologic.Vertex origin, double xFactor, double yFactor, double zFactor)
        {
            return global::Topologic.Utilities.TopologyUtility.Scale(topology, origin, xFactor, yFactor, zFactor);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic.Utilities;

namespace BH.Topologic.Utilities.EdgeUtility
{
    public static partial class Create
    {
        public static global::Topologic.Edge ByVertices(IEnumerable<global::Topologic.Vertex> vertices)
        {
            return global::Topologic.Utilities.EdgeUtility.ByVertices(vertices);
        }

        public static global::Topologic.Edge ByCircle(global::Topologic.Vertex centerPoint, double radius,
                double xAxisX, double xAxisY, double xAxisZ,
                double normalX, double normalY, double normalZ)
        {
            return global::Topologic.Utilities.EdgeUtility.ByCircle(centerPoint, radius, xAxisX, xAxisY, xAxisZ, normalX, normalY, normalZ);
        }
    }

    public static partial class Query
    {
        public static double ParameterAtVertex(this global::Topologic.Edge edge, global::Topologic.Vertex vertex)
        {
            return global::Topologic.Utilities.EdgeUtility.ParameterAtVertex(edge, vertex);
        }

        public static global::Topologic.Vertex VertexAtParameter(this global::Topologic.Edge edge, double u)
        {
            return global::Topologic.Utilities.EdgeUtility.VertexAtParameter(edge, u);
        }
    }


}
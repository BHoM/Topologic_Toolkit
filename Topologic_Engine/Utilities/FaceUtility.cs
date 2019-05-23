using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic.Utilities;

namespace BH.Topologic.Utilities.FaceUtility
{
    public static partial class Create
    {
        public static global::Topologic.Face ByVertices(IEnumerable<IEnumerable<global::Topologic.Vertex>> vertices)
        {
            return global::Topologic.Utilities.FaceUtility.ByVertices(vertices);
        }
    }

    public static partial class Query
    {
        public static double Area(global::Topologic.Face face)
        {
            return global::Topologic.Utilities.FaceUtility.Area(face);
        }

        public static List<double> ParametersAtVertex(global::Topologic.Face face, global::Topologic.Vertex vertex)
        {
            return global::Topologic.Utilities.FaceUtility.ParametersAtVertex(face, vertex);
        }

        public static List<double> NormalAtParameters(global::Topologic.Face face, double u, double v)
        {
            return global::Topologic.Utilities.FaceUtility.NormalAtParameters(face, u, v);
        }

        public static global::Topologic.Vertex VertexAtParameters(global::Topologic.Face face, double u, double v)
        {
            return global::Topologic.Utilities.FaceUtility.VertexAtParameters(face, u, v);
        }
    }

    public static partial class Modify
    {
        public static global::Topologic.Face TrimByWire(global::Topologic.Face face, global::Topologic.Wire wire)
        {
            return global::Topologic.Utilities.FaceUtility.TrimByWire(face, wire);
        }
    }
}
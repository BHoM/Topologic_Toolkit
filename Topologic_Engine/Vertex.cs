using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.Vertex
{
    public static partial class Convert
    {
        internal static IGeometry BasicGeometry(global::Topologic.Vertex vertex)
        {
            return Point(vertex);
        }

        internal static Point Point(global::Topologic.Vertex vertex)
        {
            return new Point { X = vertex.X, Y = vertex.Y, Z = vertex.Z };
        }
    }

    public static partial class Query
    {
        public static List<double> Coordinates(global::Topologic.Vertex vertex)
        {
            return vertex.Coordinates;
        }

        public static double X(global::Topologic.Vertex vertex)
        {
            return vertex.X;
        }

        public static double Y(global::Topologic.Vertex vertex)
        {
            return vertex.Y;
        }

        public static double Z(global::Topologic.Vertex vertex)
        {
            return vertex.Z;
        }

        public static int Type()
        {
            return global::Topologic.Vertex.Type();
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.Vertex vertex)
        {
            return vertex.Edges;
        }
    }

    public static partial class Create
    {
        internal static global::Topologic.Vertex ByPoint(Point point)
        {
            return global::Topologic.Vertex.ByCoordinates(point.X, point.Y, point.Z);
        }

        public static global::Topologic.Vertex ByCoordinates(double x, double y, double z)
        {
            return global::Topologic.Vertex.ByCoordinates(x, y, z);
        }
    }
}
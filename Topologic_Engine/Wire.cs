using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.Wire
{
    public static partial class Create
    {
        public static global::Topologic.Wire ByEdges(System.Collections.Generic.IEnumerable<global::Topologic.Edge> edges)
        {
            return global::Topologic.Wire.ByEdges(edges);
        }

        internal static global::Topologic.Wire ByLines(IEnumerable<Line> lines)
        {
            return global::Topologic.Wire.ByEdges(lines.Select(x => BH.Topologic.Core.Edge.Create.ByLine(x)));
        }

        internal static global::Topologic.Wire ByPolyline(Polyline polyLine)
        {
            return global::Topologic.Wire.ByEdges(BH.Engine.Geometry.Query.SubParts(polyLine).Select(x => BH.Topologic.Core.Edge.Create.ByLine(x)));
        }

        internal static global::Topologic.Wire ByCurve(ICurve bhomCurve)
        {
            // If polycurve and polyline, get the curves and lines, then create a wire from all the curves
            PolyCurve bhomPolyCurve = bhomCurve as PolyCurve;
            if(bhomPolyCurve != null)
            {
                List<global::Topologic.Edge> edges = new List<global::Topologic.Edge>();
                foreach(ICurve bhomCastCurve in bhomPolyCurve.Curves)
                {
                    edges.Add(Edge.Create.ByCurve(bhomCastCurve));
                }

                return ByEdges(edges);
            }

            Polyline bhomPolyline = bhomCurve as Polyline;
            if (bhomPolyline != null)
            {
                return ByPolyline(bhomPolyline);
            }

            // Otherwise, create a wire with a single curve.
            throw new NotImplementedException("Cannot create a wire from a single curve.");
            //return global::Topologic.Wire.ByEdges(edges);
        }
    }

    public static partial class Convert
    {
        internal static IGeometry BasicGeometry(this global::Topologic.Wire wire)
        {
            return Polyline(wire);
        }

        internal static Polyline Polyline(this global::Topologic.Wire wire)
        {
            List<global::Topologic.Vertex> vertices = wire.Vertices;
            List<Point> bhomPoints = new List<Point>();
            foreach (global::Topologic.Vertex vertex in vertices)
            {
                bhomPoints.Add(Vertex.Convert.Point(vertex));
            }

            return new Polyline { ControlPoints = bhomPoints };
        }
    }

    public static partial class Query
    {

        public static List<global::Topologic.Edge> Edges(this global::Topologic.Wire wire)
        {
            return wire.Edges;
        }

        public static List<global::Topologic.Face> Faces(this global::Topologic.Wire wire)
        {
            return wire.Faces;
        }

        public static List<global::Topologic.Vertex> Vertices(this global::Topologic.Wire wire)
        {
            return wire.Vertices();
        }

        public static bool IsClosed(this global::Topologic.Wire wire)
        {
            return wire.IsClosed;
        }

        public static int Type(this global::Topologic.Wire wire)
        {
            return global::Topologic.Wire.Type();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.Edge
{
    public static partial class Convert
    {
        internal static IGeometry BasicGeometry(this global::Topologic.Edge edge)
        {
            // Only line for now
            return Line(edge);
        }

        internal static Line Line(this global::Topologic.Edge edge)
        {
            global::Topologic.Vertex startVertex = edge.StartVertex;
            Point bhomStartPoint = Vertex.Convert.Point(startVertex);
            global::Topologic.Vertex endVertex = edge.EndVertex;
            Point bhomEndPoint = Vertex.Convert.Point(endVertex);
            Line line = new Line { Start = bhomStartPoint, End = bhomEndPoint, Infinite = false };
            return line;
        }
    }

    public static partial class Query
    {
        public static List<global::Topologic.Edge> AdjacentEdges(this global::Topologic.Edge edge)
        {
            return edge.AdjacentEdges;
        }

        public static global::Topologic.Vertex StartVertex(this global::Topologic.Edge edge)
        {
            return edge.StartVertex;
        }

        public static global::Topologic.Vertex EndVertex(this global::Topologic.Edge edge)
        {
            return edge.EndVertex;
        }

        public static List<global::Topologic.Vertex> Vertices(this global::Topologic.Edge edge)
        {
            return edge.Vertices;
        }

        public static List<global::Topologic.Wire> Wires(this global::Topologic.Edge edge)
        {
            return edge.Wires;
        }

        public static global::Topologic.Vertex SharedVertex(this global::Topologic.Edge edge, global::Topologic.Edge otherEdge)
        {
            return edge.SharedVertex(otherEdge);
        }

        public static int Type(this global::Topologic.Edge edge)
        {
            return global::Topologic.Edge.Type();
        }
    }

    public static partial class Create
    {
        public static global::Topologic.Edge ByStartVertexEndVertex(global::Topologic.Vertex startVertex, global::Topologic.Vertex endVertex)
        {
            return global::Topologic.Edge.ByStartVertexEndVertex(startVertex, endVertex);
        }

        internal static global::Topologic.Edge ByLine(Line line)
        {
            if(line.Infinite)
            {
                throw new ArgumentException("Infinite line is not supported.");
            }

            global::Topologic.Vertex startVertex = Vertex.Create.ByPoint(line.Start);
            global::Topologic.Vertex endVertex = Vertex.Create.ByPoint(line.End);

            return global::Topologic.Edge.ByStartVertexEndVertex(startVertex, endVertex);
        }
        
        internal static global::Topologic.Edge ByCurve(ICurve bhomCurve)
        {
            // Currently only handle lines
            Line bhomLine = bhomCurve as Line;
            if(bhomLine != null)
            {
                return ByLine(bhomLine);
            }

            throw new NotImplementedException("Curves other than lines are not yet supported.");
        }
    }
}
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
            Object edgeGeometry = edge.BasicGeometry;

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

        public static List<global::Topologic.Vertex> SharedVertices(this global::Topologic.Edge edge, global::Topologic.Edge otherEdge)
        {
            return edge.SharedVertices(otherEdge);
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

        internal static global::Topologic.Edge ByLine(Line bhomLine)
        {
            if(bhomLine.Infinite)
            {
                throw new ArgumentException("Infinite line is not supported.");
            }

            global::Topologic.Vertex startVertex = Vertex.Create.ByPoint(bhomLine.Start);
            global::Topologic.Vertex endVertex = Vertex.Create.ByPoint(bhomLine.End);

            return global::Topologic.Edge.ByStartVertexEndVertex(startVertex, endVertex);
        }

        internal static global::Topologic.Edge ByArc(Arc bhomArc)
        {
            throw new NotImplementedException("Arcs are not yet supported.");
        }

        internal static global::Topologic.Edge ByCircle(Circle bhomCircle)
        {
            throw new NotImplementedException("Circles are not yet supported.");

            //Point bhomCentre = bhomCircle.Centre;
            //Vector bhomNormal = bhomCircle.Normal;
            //double radius = bhomCircle.Radius;
            //return global::Topologic.Utilities.EdgeUtility.ByCircle(
            //    Vertex.Create.ByPoint(bhomCentre),
            //    radius,
            //    1.0, 0.0, 0.0,
            //    bhomNormal.X, bhomNormal.Y, bhomNormal.Z
            //    );
        }

        internal static global::Topologic.Edge ByEllipse(Ellipse bhomEllipse)
        {
            throw new NotImplementedException("Ellipses are not yet supported.");
            //Point bhomCentre = bhomEllipse.Centre;
            //Vector bhomAxis1 = bhomEllipse.Axis1;
            //Vector bhomAxis2 = bhomEllipse.Axis2;
            //Vector bhomNormal = BH.Engine.Geometry.Query.CrossProduct(bhomAxis1, bhomAxis2);
            //double majorRadius = bhomEllipse.Radius1;
            //double minorRadius = bhomEllipse.Radius2;
            //if(minorRadius > majorRadius)
            //{
            //    double temp = minorRadius;
            //    minorRadius = majorRadius;
            //    majorRadius = temp;
            //}

            //return global::Topologic.Utilities.EdgeUtility.ByEllipse(
            //    Vertex.Create.ByPoint(bhomCentre),
            //    majorRadius, minorRadius,
            //    bhomAxis1.X, bhomAxis1.Y, bhomAxis1.Z,
            //    bhomNormal.X, bhomNormal.Y, bhomNormal.Z
            //    );
        }

        internal static global::Topologic.Edge ByNurbsCurve(NurbsCurve bhomNurbsCurve)
        {
            throw new NotImplementedException("NurbsCurves are not yet supported.");

            //List<Point> bhomControlPoints = bhomNurbsCurve.ControlPoints;
            //List<double> bhomKnots = bhomNurbsCurve.Knots;
            //List<double> bhomWeights = bhomNurbsCurve.Weights;

            //List<global::Topologic.Vertex> controlPoints = new List<global::Topologic.Vertex>();
            //foreach(Point bhomControlPoint in bhomControlPoints)
            //{
            //    controlPoints.Add(Vertex.Create.ByPoint(bhomControlPoint));
            //}

            //return global::Topologic.Utilities.EdgeUtility.ByNurbsCurve(
            //    controlPoints, bhomKnots, bhomWeights, 
            //    3, // minimum degree
            //    true, false // OCCT default
            //    );
        }

        internal static global::Topologic.Edge ByCurve(ICurve bhomCurve)
        {
            // Currently only handle lines
            Line bhomLine = bhomCurve as Line;
            if(bhomLine != null)
            {
                return ByLine(bhomLine);
            }

            Arc bhomArc = bhomCurve as Arc;
            if (bhomArc != null)
            {
                return ByArc(bhomArc);
            }

            Circle bhomCircle = bhomCurve as Circle;
            if (bhomCircle != null)
            {
                return ByCircle(bhomCircle);
            }

            Ellipse bhomEllipse = bhomCurve as Ellipse;
            if (bhomEllipse != null)
            {
                return ByEllipse(bhomEllipse);
            }

            NurbsCurve bhomNurbsCurve = bhomCurve as NurbsCurve;
            if (bhomNurbsCurve != null)
            {
                return ByNurbsCurve(bhomNurbsCurve);
            }

            throw new NotImplementedException("This type of Curve is not supported.");
        }
    }
}
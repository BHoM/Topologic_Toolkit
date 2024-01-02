/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * Topologic_Toolkit is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Affero General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * Topologic_Toolkit is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Affero General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Affero General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/agpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Engine.Topologic
{
    public static partial class Convert
    {
        internal static IGeometry BasicGeometry(global::Topologic.Edge edge)
        {
            Object edgeGeometry = edge.BasicGeometry;

            // Only line for now
            return Line(edge);
        }

        internal static BH.oM.Geometry.Line Line(global::Topologic.Edge edge)
        {
            global::Topologic.Vertex startVertex = edge.StartVertex;
            Point bhomStartPoint = Convert.Point(startVertex);
            global::Topologic.Vertex endVertex = edge.EndVertex;
            Point bhomEndPoint = Convert.Point(endVertex);
            BH.oM.Geometry.Line line = new BH.oM.Geometry.Line { Start = bhomStartPoint, End = bhomEndPoint, Infinite = false };
            return line;
        }
    }

    public static partial class Query
    {
        public static List<global::Topologic.Edge> AdjacentEdges(global::Topologic.Edge edge)
        {
            return edge.AdjacentEdges;
        }

        public static global::Topologic.Vertex StartVertex(global::Topologic.Edge edge)
        {
            return edge.StartVertex;
        }

        public static global::Topologic.Vertex EndVertex(global::Topologic.Edge edge)
        {
            return edge.EndVertex;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Edge edge)
        {
            return edge.Vertices;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.Edge edge)
        {
            return edge.Wires;
        }

        public static List<global::Topologic.Vertex> SharedVertices(global::Topologic.Edge edge, global::Topologic.Edge otherEdge)
        {
            return edge.SharedVertices(otherEdge);
        }

        public static int EdgeType()
        {
            return global::Topologic.Edge.Type();
        }
    }

    public static partial class Create
    {
        public static global::Topologic.Edge EdgeByStartVertexEndVertex(global::Topologic.Vertex startVertex, global::Topologic.Vertex endVertex)
        {
            return global::Topologic.Edge.ByStartVertexEndVertex(startVertex, endVertex);
        }

        internal static global::Topologic.Edge EdgeByLine(BH.oM.Geometry.Line bhomLine)
        {
            if(bhomLine.Infinite)
            {
                throw new ArgumentException("Infinite line is not supported.");
            }

            global::Topologic.Vertex startVertex = Create.VertexByPoint(bhomLine.Start);
            global::Topologic.Vertex endVertex = Create.VertexByPoint(bhomLine.End);

            return global::Topologic.Edge.ByStartVertexEndVertex(startVertex, endVertex);
        }

        internal static global::Topologic.Edge EdgeByArc(Arc bhomArc)
        {
            throw new NotImplementedException("Arcs are not yet supported.");
        }

        internal static global::Topologic.Edge EdgeByCircle(Circle bhomCircle)
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

        internal static global::Topologic.Edge EdgeByEllipse(Ellipse bhomEllipse)
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

        internal static global::Topologic.Edge EdgeByNurbsCurve(BH.oM.Geometry.NurbsCurve bhomNurbsCurve)
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

        internal static global::Topologic.Edge EdgeByCurve(ICurve bhomCurve)
        {
            // Currently only handle lines
            BH.oM.Geometry.Line bhomLine = bhomCurve as BH.oM.Geometry.Line;
            if(bhomLine != null)
            {
                return EdgeByLine(bhomLine);
            }

            Arc bhomArc = bhomCurve as Arc;
            if (bhomArc != null)
            {
                return EdgeByArc(bhomArc);
            }

            Circle bhomCircle = bhomCurve as Circle;
            if (bhomCircle != null)
            {
                return EdgeByCircle(bhomCircle);
            }

            Ellipse bhomEllipse = bhomCurve as Ellipse;
            if (bhomEllipse != null)
            {
                return EdgeByEllipse(bhomEllipse);
            }

            BH.oM.Geometry.NurbsCurve bhomNurbsCurve = bhomCurve as BH.oM.Geometry.NurbsCurve;
            if (bhomNurbsCurve != null)
            {
                return EdgeByNurbsCurve(bhomNurbsCurve);
            }

            throw new NotImplementedException("This type of Curve is not supported.");
        }
    }
}


/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
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
    public static partial class Create
    {
        public static global::Topologic.Wire WireByEdges(System.Collections.Generic.IEnumerable<global::Topologic.Edge> edges)
        {
            return global::Topologic.Wire.ByEdges(edges);
        }

        internal static global::Topologic.Wire WireByLines(IEnumerable<BH.oM.Geometry.Line> lines)
        {
            return global::Topologic.Wire.ByEdges(lines.Select(x => Create.EdgeByLine(x)));
        }

        internal static global::Topologic.Wire WireByPolyLine(Polyline polyLine)
        {
            return global::Topologic.Wire.ByEdges(BH.Engine.Geometry.Query.SubParts(polyLine).Select(x => Create.EdgeByLine(x)));
        }

        internal static global::Topologic.Wire WireByPolyCurve(PolyCurve bhomPolyCurve)
        {
            List<global::Topologic.Edge> edges = new List<global::Topologic.Edge>();
            foreach (ICurve bhomCastCurve in bhomPolyCurve.Curves)
            {
                edges.Add(Create.EdgeByCurve(bhomCastCurve));
            }

            return WireByEdges(edges);
        }

        internal static global::Topologic.Wire WireByCurve(ICurve bhomCurve)
        {
            // If polycurve and polyline, get the curves and lines, then create a wire from all the curves
            PolyCurve bhomPolyCurve = bhomCurve as PolyCurve;
            if(bhomPolyCurve != null)
            {
                return WireByPolyCurve(bhomPolyCurve);
            }

            Polyline bhomPolyLine = bhomCurve as Polyline;
            if (bhomPolyLine != null)
            {
                return WireByPolyLine(bhomPolyLine);
            }
            
            throw new NotImplementedException("Cannot create a wire from a single curve.");
        }
    }

    public static partial class Convert
    {
        internal static IGeometry BasicGeometry(global::Topologic.Wire wire)
        {
            return Polyline(wire);
        }

        internal static Polyline Polyline(global::Topologic.Wire wire)
        {
            List<global::Topologic.Vertex> vertices = wire.Vertices;
            List<Point> bhomPoints = new List<Point>();
            foreach (global::Topologic.Vertex vertex in vertices)
            {
                bhomPoints.Add(Convert.Point(vertex));
            }
            if(bhomPoints.Count > 0 && wire.IsClosed)
            {
                bhomPoints.Add(bhomPoints[0]);
            }

            return new Polyline { ControlPoints = bhomPoints };
        }
    }

    public static partial class Query
    {

        public static List<global::Topologic.Edge> Edges(global::Topologic.Wire wire)
        {
            return wire.Edges;
        }

        public static List<global::Topologic.Face> Faces(global::Topologic.Wire wire)
        {
            return wire.Faces;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Wire wire)
        {
            return wire.Vertices;
        }

        public static bool IsClosed(global::Topologic.Wire wire)
        {
            return wire.IsClosed;
        }

        public static int WireType()
        {
            return global::Topologic.Wire.Type();
        }
    }
}
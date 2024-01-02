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

        public static int VertexType()
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
        internal static global::Topologic.Vertex VertexByPoint(Point point)
        {
            return global::Topologic.Vertex.ByCoordinates(point.X, point.Y, point.Z);
        }

        public static global::Topologic.Vertex VertexByCoordinates(double x, double y, double z)
        {
            return global::Topologic.Vertex.ByCoordinates(x, y, z);
        }
    }
}


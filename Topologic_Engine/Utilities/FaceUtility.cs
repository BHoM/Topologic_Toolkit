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
using Topologic.Utilities;

namespace BH.Engine.Topologic
{
    public static partial class Create
    {
        public static global::Topologic.Face FaceByVertices(IEnumerable<IEnumerable<global::Topologic.Vertex>> vertices)
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

        public static List<global::Topologic.Shell> AdjacentShells(global::Topologic.Face face, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.FaceUtility.AdjacentShells(face, parentTopology);
        }

        public static List<global::Topologic.Cell> AdjacentCells(global::Topologic.Face face, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.FaceUtility.AdjacentCells(face, parentTopology);
        }

        public static bool IsInside(global::Topologic.Face face, global::Topologic.Vertex vertex, double tolerance = 0.0001)
        {
            return global::Topologic.Utilities.FaceUtility.IsInside(face, vertex, tolerance);
        }

        public static global::Topologic.Vertex InternalVertex(global::Topologic.Face face, double tolerance = 0.0001)
        {
            return global::Topologic.Utilities.FaceUtility.InternalVertex(face, tolerance);
        }
    }

    public static partial class Modify
    {
        public static global::Topologic.Face TrimByWire(global::Topologic.Face face, global::Topologic.Wire wire, bool reverseWire)
        {
            return global::Topologic.Utilities.FaceUtility.TrimByWire(face, wire, reverseWire);
        }
    }
}
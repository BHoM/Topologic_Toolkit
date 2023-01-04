/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using Topologic.Utilities;

namespace BH.Engine.Topologic
{
    public static partial class Create
    {
        public static global::Topologic.Edge EdgeByVertices(IEnumerable<global::Topologic.Vertex> vertices)
        {
            return global::Topologic.Utilities.EdgeUtility.ByVertices(vertices);
        }

        public static global::Topologic.Edge EdgeByCircle(global::Topologic.Vertex centerPoint, double radius,
                double xAxisX, double xAxisY, double xAxisZ,
                double normalX, double normalY, double normalZ)
        {
            return global::Topologic.Utilities.EdgeUtility.ByCircle(centerPoint, radius, xAxisX, xAxisY, xAxisZ, normalX, normalY, normalZ);
        }
    }

    public static partial class Query
    {
        public static double ParameterAtVertex(global::Topologic.Edge edge, global::Topologic.Vertex vertex)
        {
            return global::Topologic.Utilities.EdgeUtility.ParameterAtVertex(edge, vertex);
        }

        public static global::Topologic.Vertex VertexAtParameter(global::Topologic.Edge edge, double u)
        {
            return global::Topologic.Utilities.EdgeUtility.VertexAtParameter(edge, u);
        }

        public static List<global::Topologic.Wire> AdjacentWires(global::Topologic.Edge edge, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.EdgeUtility.AdjacentWires(edge, parentTopology);
        }
    }
}

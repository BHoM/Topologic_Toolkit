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
        public static global::Topologic.Cell CellByLoft(IEnumerable<global::Topologic.Wire> wires)
        {
            return global::Topologic.Utilities.CellUtility.ByLoft(wires);
        }
    }

    public static partial class Query
    {
        public static double Volume(global::Topologic.Cell cell)
        {
            return global::Topologic.Utilities.CellUtility.Volume(cell);
        }

        public static bool Contains(global::Topologic.Cell cell, global::Topologic.Vertex vertex, bool allowOnBoundary = false, double tolerance = 0.0001)
        {
            return global::Topologic.Utilities.CellUtility.Contains(cell, vertex, allowOnBoundary, tolerance);
        }
    }

    public static partial class Compute
    {
        public static global::Topologic.Vertex VertexInCell(global::Topologic.Cell cell, bool allowOnBoundary = false, double tolerance = 0.0001)
        {
            // Get all vertices
            List<global::Topologic.Vertex> vertices = cell.Vertices;
            if (vertices.Count == 0)
            {
                return null;
            }

            // If centroid is inside, use it
            global::Topologic.Vertex cellCenterOfMass = cell.CenterOfMass;
            if (CellUtility.Contains(cell, cellCenterOfMass, allowOnBoundary, tolerance))
            {
                return cellCenterOfMass;
            }

            // Get the first vertex
            global::Topologic.Vertex firstVertex = vertices[0];

            foreach (global::Topologic.Vertex anotherVertex in vertices)
            {
                if (anotherVertex.IsSame(firstVertex))
                {
                    continue;
                }

                global::Topologic.Edge edge = global::Topologic.Edge.ByStartVertexEndVertex(firstVertex, anotherVertex);
                global::Topologic.Vertex edgeCenterOfMass = edge.CenterOfMass;
                if (CellUtility.Contains(cell, edgeCenterOfMass, allowOnBoundary, tolerance))
                {
                    return edgeCenterOfMass;
                }
            }

            return null;
        }
    }
}
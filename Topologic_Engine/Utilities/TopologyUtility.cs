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
    public static partial class Query
    {
        public static double Distance(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return global::Topologic.Utilities.TopologyUtility.Distance(topology,otherTopology);
        }

        public static global::Topologic.Vertex CenterOfMass(global::Topologic.Topology topology)
        {
            return topology.CenterOfMass;
        }

        public static global::Topologic.Vertex Centroid(global::Topologic.Topology topology)
        {
            return topology.Centroid;
        }
    }

    public static partial class Modify
    {
        public static global::Topologic.Topology Translate(global::Topologic.Topology topology, double x = 0.0, double y = 0.0, double z = 0.0)
        {
            return global::Topologic.Utilities.TopologyUtility.Translate(topology,x, y, z);
        }

        public static global::Topologic.Topology Rotate(global::Topologic.Topology topology, global::Topologic.Vertex origin,
                double xVector = 0.0, double yVector = 0.0, double zVector = 0.0,
                double degree = 0.0)
        {
            return global::Topologic.Utilities.TopologyUtility.Rotate(topology, origin, xVector, yVector, zVector, degree);
        }

        public static global::Topologic.Topology Scale(global::Topologic.Topology topology, global::Topologic.Vertex origin, double xFactor = 1.0, double yFactor = 1.0, double zFactor = 1.0)
        {
            return global::Topologic.Utilities.TopologyUtility.Scale(topology, origin, xFactor, yFactor, zFactor);
        }

        public static List<global::Topologic.Topology> AdjacentTopologies(global::Topologic.Topology topology, global::Topologic.Topology parentTopology, int topologyType)
        {
            return global::Topologic.Utilities.TopologyUtility.AdjacentTopologies(topology, parentTopology, topologyType);
        }

        public static List<global::Topologic.Edge> AdjacentEdges(global::Topologic.Topology topology, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.TopologyUtility.AdjacentEdges(topology, parentTopology);
        }

        public static List<global::Topologic.Face> AdjacentFaces(global::Topologic.Topology topology, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.TopologyUtility.AdjacentFaces(topology, parentTopology);
        }

        public static List<global::Topologic.Cell> AdjacentCells(global::Topologic.Topology topology, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.TopologyUtility.AdjacentCells(topology, parentTopology);
        }
    }
}
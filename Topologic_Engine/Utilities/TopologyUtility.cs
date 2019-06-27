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
        public static global::Topologic.Topology Translate(global::Topologic.Topology topology, double x, double y, double z)
        {
            return global::Topologic.Utilities.TopologyUtility.Translate(topology,x, y, z);
        }

        public static global::Topologic.Topology Rotate(global::Topologic.Topology topology, global::Topologic.Vertex origin,
                double xVector, double yVector, double zVector,
                double degree)
        {
            return global::Topologic.Utilities.TopologyUtility.Rotate(topology, origin, xVector, yVector, zVector, degree);
        }

        public static global::Topologic.Topology Scale(global::Topologic.Topology topology, global::Topologic.Vertex origin, double xFactor, double yFactor, double zFactor)
        {
            return global::Topologic.Utilities.TopologyUtility.Scale(topology, origin, xFactor, yFactor, zFactor);
        }
    }
}
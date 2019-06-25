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
    public static partial class Convert
    {
        internal static CompositeGeometry BasicGeometry(global::Topologic.Cluster cluster)
        {
            return CompositeGeometry(cluster);
        }

        internal static CompositeGeometry CompositeGeometry(global::Topologic.Cluster cluster)
        {
            List<global::Topologic.Cell> cells = cluster.Cells;
            List<IGeometry> bhomSolids = new List<IGeometry>();
            foreach (global::Topologic.Cell cell in cells)
            {
                bhomSolids.Add(Convert.BoundaryRepresentation(cell));
            }
            return new CompositeGeometry { Elements = bhomSolids };
        }
    }

    public static partial class Query
    {
        public static List<global::Topologic.Shell> Shells(global::Topologic.Cluster cluster)
        {
            return cluster.Shells;
        }

        public static List<global::Topologic.Face> Faces(global::Topologic.Cluster cluster)
        {
            return cluster.Faces;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.Cluster cluster)
        {
            return cluster.Wires;
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.Cluster cluster)
        {
            return cluster.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Cluster cluster)
        {
            return cluster.Vertices;
        }

        public static List<global::Topologic.Cell> Cells(global::Topologic.Cluster cluster)
        {
            return cluster.Cells;
        }

        public static List<global::Topologic.CellComplex> CellComplexes(global::Topologic.Cluster cluster)
        {
            return cluster.CellComplexes;
        }

        public static int ClusterType()
        {
            return global::Topologic.Cluster.Type();
        }
    }

    public static partial class Create
    {
        public static global::Topologic.Cluster ClusterByTopologies(IEnumerable<global::Topologic.Topology> topologies)
        {
            return global::Topologic.Cluster.ByTopologies(topologies);
        }

        internal static global::Topologic.Cluster ClusterByCompositeGeometry(CompositeGeometry bhomCompositeGeometry, double tolerance)
        {
            List<global::Topologic.Topology> topologies = new List<global::Topologic.Topology>();
            foreach (IGeometry bhomGeometry in bhomCompositeGeometry.Elements)
            {
                global::Topologic.Topology topology = Create.TopologyByGeometry(bhomGeometry, tolerance);
                topologies.Add(topology);
            }

            return ClusterByTopologies(topologies);
        }
    }
}
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
    public static partial class Query
    {
        public static List<global::Topologic.Shell> AdjacentShells(global::Topologic.Wire wire, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.WireUtility.AdjacentShells(wire, parentTopology);
        }

        public static List<global::Topologic.Cell> AdjacentCells(global::Topologic.Wire wire, global::Topologic.Topology parentTopology)
        {
            return global::Topologic.Utilities.WireUtility.AdjacentCells(wire, parentTopology);
        }
        
        public static global::Topologic.Wire RemoveCollinearEdges(global::Topologic.Wire wire, double tolerance = 0.0001)
        {
            return global::Topologic.Utilities.WireUtility.RemoveCollinearEdges(wire, tolerance);
        }
    }
}


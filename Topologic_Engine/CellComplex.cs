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
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Engine.Topologic
{
    public static partial class Convert
    {
        internal static CompositeGeometry BasicGeometry(global::Topologic.CellComplex cellComplex)
        {
            return CompositeGeometry(cellComplex);
        }

        internal static CompositeGeometry CompositeGeometry(global::Topologic.CellComplex cellComplex)
        {
            List<global::Topologic.Cell> cells = cellComplex.Cells;
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
        public static List<global::Topologic.Cell> Cells(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Cells;
        }

        public static List<global::Topologic.Face> Faces(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Faces;
        }

        public static List<global::Topologic.Shell> Shells(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Shells;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Wires;
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Vertices;
        }

        public static global::Topologic.Cell ExternalBoundary(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.ExternalBoundary;
        }

        public static List<global::Topologic.Face> InternalBoundaries(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.InternalBoundaries;
        }

        public static List<global::Topologic.Face> NonManifoldFaces(global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.NonManifoldFaces;
        }

        public static int CellComplexType()
        {
            return global::Topologic.CellComplex.Type();
        }

    }

    public static partial class Create
    {
        public static global::Topologic.CellComplex CellComplexByFaces(IEnumerable<global::Topologic.Face> faces, double tolerance = 0.0001)
        {
            return global::Topologic.CellComplex.ByFaces(faces, tolerance);
        }

        public static global::Topologic.CellComplex CellComplexByCells(IEnumerable<global::Topologic.Cell> cells)
        {
            return global::Topologic.CellComplex.ByCells(cells);
        }

    }
}

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
        internal static IGeometry BasicGeometry(global::Topologic.Cell cell)
        {
            return BoundaryRepresentation(cell);
        }

        internal static BoundaryRepresentation BoundaryRepresentation(global::Topologic.Cell cell)
        {
            List<global::Topologic.Face> faces = cell.Faces;
            List<ISurface> bhomSurfaces = new List<ISurface>();
            foreach (global::Topologic.Face face in faces)
            {
                bhomSurfaces.Add(Convert.PlanarSurface(face));
            }
            return new BoundaryRepresentation(bhomSurfaces);
        }
    }

    public static partial class Query
    {
        public static List<global::Topologic.CellComplex> CellComplexes(global::Topologic.Cell cell)
        {
            return cell.CellComplexes;
        }

        public static List<global::Topologic.Shell> Shells(global::Topologic.Cell cell)
        {
            return cell.Shells;
        }

        public static List<global::Topologic.Face> Faces(global::Topologic.Cell cell)
        {
            return cell.Faces;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.Cell cell)
        {
            return cell.Wires;
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.Cell cell)
        {
            return cell.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Cell cell)
        {
            return cell.Vertices;
        }

        public static List<global::Topologic.Cell> AdjacentCells(global::Topologic.Cell cell)
        {
            return cell.AdjacentCells;
        }

        public static List<global::Topologic.Face> SharedFaces(global::Topologic.Cell cell, global::Topologic.Cell otherCell)
        {
            return cell.SharedFaces(otherCell);
        }

        public static List<global::Topologic.Edge> SharedEdges(global::Topologic.Cell cell, global::Topologic.Cell otherCell)
        {
            return cell.SharedEdges(otherCell);
        }

        public static List<global::Topologic.Vertex> SharedVertices(global::Topologic.Cell cell, global::Topologic.Cell otherCell)
        {
            return cell.SharedVertices(otherCell);
        }

        public static global::Topologic.Shell ExternalBoundary(global::Topologic.Cell cellComplex)
        {
            return cellComplex.ExternalBoundary;
        }

        public static List<global::Topologic.Shell> InternalBoundaries(global::Topologic.Cell cell)
        {
            return cell.InternalBoundaries;
        }

        public static int Type()
        {
            return global::Topologic.Cell.Type();
        }

    }

    public static partial class Create
    {
        public static global::Topologic.Cell CellByFaces(IEnumerable<global::Topologic.Face> faces, double tolerance = 0.0001)
        {
            return global::Topologic.Cell.ByFaces(faces, tolerance);
        }

        public static global::Topologic.Cell CellByShell(global::Topologic.Shell shell)
        {
            return global::Topologic.Cell.ByShell(shell);
        }

        internal static global::Topologic.Cell CellBySolid(ISolid bhomSolid, double tolerance)
        {
            BoundaryRepresentation bhomBoundaryRepresentation = bhomSolid as BoundaryRepresentation;
            if (bhomBoundaryRepresentation != null)
            {
                return CellByBoundaryRepresentation(bhomBoundaryRepresentation, tolerance);
            }

            Cuboid bhomCuboid = bhomSolid as Cuboid;
            if (bhomCuboid != null)
            {
                return CellByCuboid(bhomCuboid);
            }

            Sphere bhomSphere = bhomSolid as Sphere;
            if (bhomSphere != null)
            {
                return CellBySphere(bhomSphere);
            }
            throw new NotImplementedException("This type of Solid is not yet supported.");
        }

        internal static global::Topologic.Cell CellBySphere(Sphere bhomSphere)
        {
            return global::Topologic.Utilities.CellUtility.BySphere(bhomSphere.Centre.X, bhomSphere.Centre.Y, bhomSphere.Centre.Z, bhomSphere.Radius);
        }

        internal static global::Topologic.Cell CellByCuboid(Cuboid bhomCuboid)
        {
            return global::Topologic.Utilities.CellUtility.ByCuboid(
                bhomCuboid.CoordinateSystem.Origin.X, bhomCuboid.CoordinateSystem.Origin.Y, bhomCuboid.CoordinateSystem.Origin.Z,
                bhomCuboid.Length, bhomCuboid.Depth, bhomCuboid.Depth,
                bhomCuboid.CoordinateSystem.Z.X, bhomCuboid.CoordinateSystem.Z.Y, bhomCuboid.CoordinateSystem.Z.Z,
                bhomCuboid.CoordinateSystem.X.X, bhomCuboid.CoordinateSystem.X.Y, bhomCuboid.CoordinateSystem.X.Z);
        }

        internal static global::Topologic.Cell CellByBoundaryRepresentation(BoundaryRepresentation bhomBoundaryRepresentation, double tolerance)
        {
            List<global::Topologic.Face> faces = new List<global::Topologic.Face>();
            foreach (ISurface bhomSurface in bhomBoundaryRepresentation.Surfaces)
            {
                global::Topologic.Face face = Create.FaceBySurface(bhomSurface);
                faces.Add(face);
            }

            return global::Topologic.Cell.ByFaces(faces, tolerance);
        }

        internal static global::Topologic.Topology CellByBoundingBox(BoundingBox bhomBoundingBox)
        {
            global::Topologic.Vertex minVertex = Create.VertexByPoint(bhomBoundingBox.Min);
            global::Topologic.Vertex maxVertex = Create.VertexByPoint(bhomBoundingBox.Max);
            return global::Topologic.Utilities.CellUtility.ByTwoCorners(minVertex, maxVertex);
        }
    }
}
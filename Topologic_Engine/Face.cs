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
        internal static IGeometry BasicGeometry(global::Topologic.Face face)
        {
            return PlanarSurface(face);
        }

        internal static BH.oM.Geometry.PlanarSurface PlanarSurface(global::Topologic.Face face)
        {
            Polyline bhomExternalBoundary = Convert.Polyline(face.ExternalBoundary);
            List<ICurve> bhomInternalBoundaries = new List<ICurve>();
            List<global::Topologic.Wire> internalBoundaries = face.InternalBoundaries;
            foreach(global::Topologic.Wire internalBoundary in internalBoundaries)
            {
                bhomInternalBoundaries.Add(Convert.Polyline(internalBoundary));
            }
            BH.oM.Geometry.PlanarSurface planarSurface = new BH.oM.Geometry.PlanarSurface(bhomExternalBoundary, bhomInternalBoundaries);
            return planarSurface;
        }
    }

    public static partial class Query
    {
        public static List<global::Topologic.Face> AdjacentFaces(global::Topologic.Face face)
        {
            return face.AdjacentFaces;
        }

        public static List<global::Topologic.Cell> Cells(global::Topologic.Face face)
        {
            return face.Cells;
        }

        public static List<global::Topologic.Shell> Shells(global::Topologic.Face face)
        {
            return face.Shells;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Face face)
        {
            return face.Vertices;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.Face face)
        {
            return face.Wires;
        }

        public static List<global::Topologic.Edge> SharedEdges(global::Topologic.Face face, global::Topologic.Face otherFace)
        {
            return face.SharedEdges(otherFace);
        }

        public static global::Topologic.Wire ExternalBoundary(global::Topologic.Face face)
        {
            return face.ExternalBoundary;
        }

        public static List<global::Topologic.Wire> InternalBoundaries(global::Topologic.Face face)
        {
            return face.InternalBoundaries;
        }

        public static int FaceType()
        {
            return global::Topologic.Face.Type();
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.Face face)
        {
            return face.Edges;
        }

        public static List<global::Topologic.Vertex> SharedVertices(global::Topologic.Face face, global::Topologic.Face otherFace)
        {
            return face.SharedVertices(otherFace);
        }
    }

    public static partial class Create
    {
        public static global::Topologic.Face FaceByWire(global::Topologic.Wire wire)
        {
            return global::Topologic.Face.ByWire(wire);
        }

        public static global::Topologic.Face FaceByExternalInternalBoundaries(global::Topologic.Wire outerWire, IEnumerable<global::Topologic.Wire> innerWires)
        {
            return global::Topologic.Face.ByExternalInternalBoundaries(outerWire, innerWires);
        }

        public static global::Topologic.Face FaceByEdges(IEnumerable<global::Topologic.Edge> edges)
        {
            return global::Topologic.Face.ByEdges(edges);
        }

        internal static global::Topologic.Face FaceBySurface(ISurface bhomSurface)
        {
            BH.oM.Geometry.PlanarSurface bhomPlanarSurface = bhomSurface as BH.oM.Geometry.PlanarSurface;
            if (bhomPlanarSurface != null)
            {
                return FaceByPlanarSurface(bhomPlanarSurface);
            }

            throw new NotImplementedException("This type of BHoM surface is not yet supported.");
        }

        internal static global::Topologic.Face FaceByPlanarSurface(BH.oM.Geometry.PlanarSurface bhomPlanarSurface)
        {
            ICurve bhomExternalBoundary = bhomPlanarSurface.ExternalBoundary;
            List<ICurve> bhomInternalBoundaries = bhomPlanarSurface.InternalBoundaries;

            global::Topologic.Wire externalBoundary = Create.WireByCurve(bhomExternalBoundary);
            List<global::Topologic.Wire> internalBoundaries = new List<global::Topologic.Wire>();
            if (bhomInternalBoundaries != null)
            {
                foreach (ICurve bhomInternalBoundary in bhomInternalBoundaries)
                {
                    global::Topologic.Wire internalBoundary = Create.WireByCurve(bhomInternalBoundary);
                    internalBoundaries.Add(internalBoundary);
                }
            }
            return global::Topologic.Face.ByExternalInternalBoundaries(externalBoundary, internalBoundaries);
        }
    }

    public static partial class Modify
    {
        public static global::Topologic.Face AddInternalBoundaries(global::Topologic.Face face, List<global::Topologic.Wire> internalBoundaries)
        {
            return face.AddInternalBoundaries(internalBoundaries);
        }

        public static global::Topologic.Face AddApertureDesign(global::Topologic.Face face, global::Topologic.Face apertureDesign, int numEdgeSamples)
        {
            return face.AddApertureDesign(apertureDesign, numEdgeSamples);
        }
    }
}

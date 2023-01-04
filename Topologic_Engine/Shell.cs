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
        internal static IGeometry BasicGeometry(global::Topologic.Shell shell)
        {
            return PolySurface(shell);
        }

        internal static PolySurface PolySurface(global::Topologic.Shell shell)
        {
            List<global::Topologic.Face> faces = shell.Faces;
            List<ISurface> bhomSurfaces = new List<ISurface>();
            foreach (global::Topologic.Face face in faces)
            {
                bhomSurfaces.Add(Convert.PlanarSurface(face));
            }
            return new PolySurface { Surfaces = bhomSurfaces };
        }
    }

    public static partial class Query
    {
        public static List<global::Topologic.Cell> Cells(global::Topologic.Shell shell)
        {
            return shell.Cells;
        }

        public static List<global::Topologic.Face> Faces(global::Topologic.Shell shell)
        {
            return shell.Faces;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.Shell shell)
        {
            return shell.Wires;
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.Shell shell)
        {
            return shell.Edges;
        }

        public static bool IsClosed(global::Topologic.Shell shell)
        {
            return shell.IsClosed;
        }

        public static int ShellType()
        {
            return global::Topologic.Shell.Type();
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Shell shell)
        {
            return shell.Vertices;
        }

    }

    public static partial class Create
    {
        public static global::Topologic.Shell ShellByFaces(IEnumerable<global::Topologic.Face> faces, double tolerance = 0.0001)
        {
            return global::Topologic.Shell.ByFaces(faces, tolerance);
        }

        internal static global::Topologic.Shell ShellByPolySurface(PolySurface bhomPolySurface, double tolerance)
        {
            List<global::Topologic.Face> faces = new List<global::Topologic.Face>();
            foreach(ISurface bhomSurface in bhomPolySurface.Surfaces)
            {
                global::Topologic.Face face = Create.FaceBySurface(bhomSurface);
                faces.Add(face);
            }

            return global::Topologic.Shell.ByFaces(faces, tolerance);
        }

        internal static global::Topologic.Shell ShellByMesh(Mesh bhomMesh)
        {
            List<global::Topologic.Face> faces = new List<global::Topologic.Face>();
            foreach (BH.oM.Geometry.Face bhomFace in bhomMesh.Faces)
            {
                List<Point> bhomControlPoints = new List<Point>();
                Point p1 = bhomMesh.Vertices[bhomFace.A];
                bhomControlPoints.Add(p1);
                Point p2 = bhomMesh.Vertices[bhomFace.B];
                bhomControlPoints.Add(p2);
                Point p3 = bhomMesh.Vertices[bhomFace.C];
                bhomControlPoints.Add(p3);
                Point p4 = null;
                if (bhomFace.D >= 0)
                {
                    p4 = bhomMesh.Vertices[bhomFace.D];
                    bhomControlPoints.Add(p4);
                }
                bhomControlPoints.Add(p1); // close the wire
                Polyline bhomBoundary = new Polyline { ControlPoints = bhomControlPoints };
                BH.oM.Geometry.PlanarSurface bhomPlanarSurface = new BH.oM.Geometry.PlanarSurface(bhomBoundary, null);
                global::Topologic.Face face = Create.FaceByPlanarSurface(bhomPlanarSurface);
                faces.Add(face);
            }
            return global::Topologic.Shell.ByFaces(faces, 0.0001);
        }
    }
}

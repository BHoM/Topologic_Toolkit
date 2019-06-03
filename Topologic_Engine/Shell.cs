using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.Shell
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
                bhomSurfaces.Add(Face.Convert.PlanarSurface(face));
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

        public static int Type()
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
        public static global::Topologic.Shell ByFaces(IEnumerable<global::Topologic.Face> faces, double tolerance = 0.0001)
        {
            return global::Topologic.Shell.ByFaces(faces, tolerance);
        }

        internal static global::Topologic.Shell ByPolySurface(PolySurface bhomPolySurface, double tolerance)
        {
            List<global::Topologic.Face> faces = new List<global::Topologic.Face>();
            foreach(ISurface bhomSurface in bhomPolySurface.Surfaces)
            {
                global::Topologic.Face face = Topologic.Core.Face.Create.BySurface(bhomSurface);
                faces.Add(face);
            }

            return global::Topologic.Shell.ByFaces(faces, tolerance);
        }

        internal static global::Topologic.Shell ByMesh(Mesh bhomMesh)
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
                PlanarSurface bhomPlanarSurface = new PlanarSurface { ExternalBoundary = bhomBoundary, InternalBoundaries = null };
                global::Topologic.Face face = Face.Create.ByPlanarSurface(bhomPlanarSurface);
                faces.Add(face);
            }
            return global::Topologic.Shell.ByFaces(faces, 0.0001);
        }
    }
}
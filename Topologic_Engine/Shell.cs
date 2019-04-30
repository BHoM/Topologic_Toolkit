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
        internal static IGeometry BasicGeometry(this global::Topologic.Shell shell)
        {
            return PolySurface(shell);
        }

        internal static PolySurface PolySurface(this global::Topologic.Shell shell)
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
        public static List<global::Topologic.Cell> Cells(this global::Topologic.Shell shell)
        {
            return shell.Cells;
        }

        public static List<global::Topologic.Face> Faces(this global::Topologic.Shell shell)
        {
            return shell.Faces;
        }

        public static List<global::Topologic.Wire> Wires(this global::Topologic.Shell shell)
        {
            return shell.Wires;
        }

        public static List<global::Topologic.Edge> Edges(this global::Topologic.Shell shell)
        {
            return shell.Edges;
        }

        public static bool IsClosed(this global::Topologic.Shell shell)
        {
            return shell.IsClosed;
        }

        public static int Type(this global::Topologic.Shell shell)
        {
            return global::Topologic.Shell.Type();
        }

        public static List<global::Topologic.Vertex> Vertices(this global::Topologic.Shell shell)
        {
            return shell.Vertices();
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
    }
}
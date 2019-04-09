using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.CellComplex
{
    public static partial class Convert
    {
        internal static IGeometry BasicGeometry(this global::Topologic.CellComplex cellComplex)
        {
            return PolySurface(cellComplex);
        }

        internal static PolySurface PolySurface(this global::Topologic.CellComplex cellComplex)
        {
            List<global::Topologic.Face> faces = cellComplex.Faces;
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
        public static List<global::Topologic.Cell> Cells(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Cells;
        }

        public static List<global::Topologic.Face> Faces(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Faces;
        }

        public static List<global::Topologic.Shell> Shells(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Shells;
        }

        public static List<global::Topologic.Wire> Wires(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Wires;
        }

        public static List<global::Topologic.Edge> Edges(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.Vertices();
        }

        public static global::Topologic.Cell ExternalBoundary(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.ExternalBoundary;
        }

        public static List<global::Topologic.Face> InternalBoundaries(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.InternalBoundaries;
        }

        public static List<global::Topologic.Face> NonManifoldFaces(this global::Topologic.CellComplex cellComplex)
        {
            return cellComplex.NonManifoldFaces;
        }

        public static int Type(this global::Topologic.CellComplex cellComplex)
        {
            return global::Topologic.CellComplex.Type();
        }

    }

    public static partial class Create
    {
        public static global::Topologic.CellComplex ByFaces(IEnumerable<global::Topologic.Face> faces)
        {
            return global::Topologic.CellComplex.ByFaces(faces);
        }

        public static global::Topologic.CellComplex ByCells(IEnumerable<global::Topologic.Cell> cells)
        {
            return global::Topologic.CellComplex.ByCells(cells);
        }

    }
}
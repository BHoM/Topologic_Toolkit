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
                bhomSolids.Add(Cell.Convert.BoundaryRepresentation(cell));
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

        public static int Type()
        {
            return global::Topologic.CellComplex.Type();
        }

    }

    public static partial class Create
    {
        public static global::Topologic.CellComplex ByFaces(IEnumerable<global::Topologic.Face> faces, double tolerance = 0.0001)
        {
            return global::Topologic.CellComplex.ByFaces(faces, tolerance);
        }

        public static global::Topologic.CellComplex ByCells(IEnumerable<global::Topologic.Cell> cells)
        {
            return global::Topologic.CellComplex.ByCells(cells);
        }

    }
}
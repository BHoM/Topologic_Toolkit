using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.Cell
{
    public static partial class Convert
    {
        internal static IGeometry BasicGeometry(this global::Topologic.Cell cell)
        {
            return PolySurface(cell);
        }

        internal static PolySurface PolySurface(this global::Topologic.Cell cell)
        {
            List<global::Topologic.Face> faces = cell.Faces;
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
        public static List<global::Topologic.CellComplex> CellComplexes(this global::Topologic.Cell cell)
        {
            return cell.CellComplexes;
        }

        public static List<global::Topologic.Shell> Shells(this global::Topologic.Cell cell)
        {
            return cell.Shells;
        }

        public static List<global::Topologic.Face> Faces(this global::Topologic.Cell cell)
        {
            return cell.Faces;
        }

        public static List<global::Topologic.Wire> Wires(this global::Topologic.Cell cell)
        {
            return cell.Wires;
        }

        public static List<global::Topologic.Edge> Edges(this global::Topologic.Cell cell)
        {
            return cell.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(this global::Topologic.Cell cell)
        {
            return cell.Vertices;
        }

        public static List<global::Topologic.Cell> AdjacentCells(this global::Topologic.Cell cell, global::Topologic.Topology parentTopology)
        {
            return cell.AdjacentCells(parentTopology);
        }

        public static List<global::Topologic.Face> SharedFaces(this global::Topologic.Cell cell, global::Topologic.Cell otherCell)
        {
            return cell.SharedFaces(otherCell);
        }

        public static List<global::Topologic.Edge> SharedEdges(this global::Topologic.Cell cell, global::Topologic.Cell otherCell)
        {
            return cell.SharedEdges(otherCell);
        }

        public static List<global::Topologic.Vertex> SharedVertices(this global::Topologic.Cell cell, global::Topologic.Cell otherCell)
        {
            return cell.SharedVertices(otherCell);
        }

        public static global::Topologic.Shell ExternalBoundary(this global::Topologic.Cell cellComplex)
        {
            return cellComplex.ExternalBoundary;
        }

        public static List<global::Topologic.Shell> InternalBoundaries(this global::Topologic.Cell cell)
        {
            return cell.InternalBoundaries();
        }

        public static int Type(this global::Topologic.Cell cell)
        {
            return global::Topologic.Cell.Type();
        }

    }

    public static partial class Create
    {
        public static global::Topologic.Cell ByFaces(IEnumerable<global::Topologic.Face> faces, double tolerance = 0.001)
        {
            return global::Topologic.Cell.ByFaces(faces, tolerance);
        }

        public static global::Topologic.Cell ByShell(global::Topologic.Shell shell)
        {
            return global::Topologic.Cell.ByShell(shell);
        }

    }
}
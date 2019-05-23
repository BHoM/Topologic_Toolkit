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
                bhomSurfaces.Add(Face.Convert.PlanarSurface(face));
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

        public static int Type(global::Topologic.Cell cell)
        {
            return global::Topologic.Cell.Type();
        }

    }

    public static partial class Create
    {
        public static global::Topologic.Cell ByFaces(IEnumerable<global::Topologic.Face> faces, double tolerance = 0.0001)
        {
            return global::Topologic.Cell.ByFaces(faces, tolerance);
        }

        public static global::Topologic.Cell ByShell(global::Topologic.Shell shell)
        {
            return global::Topologic.Cell.ByShell(shell);
        }

        internal static global::Topologic.Cell BySolid(ISolid bhomSolid, double tolerance)
        {
            BoundaryRepresentation bhomBoundaryRepresentation = bhomSolid as BoundaryRepresentation;
            if (bhomBoundaryRepresentation != null)
            {
                return ByBoundaryRepresentation(bhomBoundaryRepresentation, tolerance);
            }

            Cuboid bhomCuboid = bhomSolid as Cuboid;
            if (bhomCuboid != null)
            {
                return ByCuboid(bhomCuboid);
            }

            Sphere bhomSphere = bhomSolid as Sphere;
            if (bhomSphere != null)
            {
                return BySphere(bhomSphere);
            }
            throw new NotImplementedException("This type of Solid is not yet supported.");
        }

        internal static global::Topologic.Cell BySphere(Sphere bhomSphere)
        {
            return global::Topologic.Utilities.CellUtility.BySphere(bhomSphere.Centre.X, bhomSphere.Centre.Y, bhomSphere.Centre.Z, bhomSphere.Radius);
        }

        internal static global::Topologic.Cell ByCuboid(Cuboid bhomCuboid)
        {
            return global::Topologic.Utilities.CellUtility.ByCuboid(
                bhomCuboid.CoordinateSystem.Origin.X, bhomCuboid.CoordinateSystem.Origin.Y, bhomCuboid.CoordinateSystem.Origin.Z,
                bhomCuboid.Length, bhomCuboid.Depth, bhomCuboid.Depth,
                bhomCuboid.CoordinateSystem.Z.X, bhomCuboid.CoordinateSystem.Z.Y, bhomCuboid.CoordinateSystem.Z.Z,
                bhomCuboid.CoordinateSystem.X.X, bhomCuboid.CoordinateSystem.X.Y, bhomCuboid.CoordinateSystem.X.Z);
        }

        internal static global::Topologic.Cell ByBoundaryRepresentation(BoundaryRepresentation bhomBoundaryRepresentation, double tolerance)
        {
            List<global::Topologic.Face> faces = new List<global::Topologic.Face>();
            foreach (ISurface bhomSurface in bhomBoundaryRepresentation.Surfaces)
            {
                global::Topologic.Face face = Topologic.Core.Face.Create.BySurface(bhomSurface);
                faces.Add(face);
            }

            return global::Topologic.Cell.ByFaces(faces, tolerance);
        }

        internal static global::Topologic.Topology ByBoundingBox(BoundingBox bhomBoundingBox)
        {
            global::Topologic.Vertex minVertex = BH.Topologic.Core.Vertex.Create.ByPoint(bhomBoundingBox.Min);
            global::Topologic.Vertex maxVertex = BH.Topologic.Core.Vertex.Create.ByPoint(bhomBoundingBox.Max);
            return global::Topologic.Utilities.CellUtility.ByTwoCorners(minVertex, maxVertex);
        }
    }
}
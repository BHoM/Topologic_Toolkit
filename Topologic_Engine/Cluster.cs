using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Topologic.Core.Cluster
{
    public static partial class Convert
    {
        internal static CompositeGeometry BasicGeometry(global::Topologic.Cluster cluster)
        {
            return CompositeGeometry(cluster);
        }

        internal static CompositeGeometry CompositeGeometry(global::Topologic.Cluster cluster)
        {
            List<global::Topologic.Cell> cells = cluster.Cells;
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
        public static List<global::Topologic.Shell> Shells(global::Topologic.Cluster cluster)
        {
            return cluster.Shells;
        }

        public static List<global::Topologic.Face> Faces(global::Topologic.Cluster cluster)
        {
            return cluster.Faces;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.Cluster cluster)
        {
            return cluster.Wires;
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.Cluster cluster)
        {
            return cluster.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Cluster cluster)
        {
            return cluster.Vertices;
        }

        public static List<global::Topologic.Cell> Cells(global::Topologic.Cluster cluster)
        {
            return cluster.Cells;
        }

        public static List<global::Topologic.CellComplex> CellComplexes(global::Topologic.Cluster cluster)
        {
            return cluster.CellComplexes;
        }

        public static int Type()
        {
            return global::Topologic.Cluster.Type();
        }
    }

    public static partial class Create
    {
        public static global::Topologic.Cluster ByTopologies(IEnumerable<global::Topologic.Topology> topologies)
        {
            return global::Topologic.Cluster.ByTopologies(topologies);
        }

        internal static global::Topologic.Cluster ByCompositeGeometry(CompositeGeometry bhomCompositeGeometry, double tolerance)
        {
            List<global::Topologic.Topology> topologies = new List<global::Topologic.Topology>();
            foreach (IGeometry bhomGeometry in bhomCompositeGeometry.Elements)
            {
                global::Topologic.Topology topology = Topologic.Core.Topology.Create.ByGeometry(bhomGeometry, tolerance);
                topologies.Add(topology);
            }

            return ByTopologies(topologies);
        }
    }
}
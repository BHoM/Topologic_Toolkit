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
    public static partial class Query
    {
        public static List<global::Topologic.Shell> Shells(this global::Topologic.Cluster cluster)
        {
            return cluster.Shells;
        }

        public static List<global::Topologic.Face> Faces(this global::Topologic.Cluster cluster)
        {
            return cluster.Faces;
        }

        public static List<global::Topologic.Wire> Wires(this global::Topologic.Cluster cluster)
        {
            return cluster.Wires;
        }

        public static List<global::Topologic.Edge> Edges(this global::Topologic.Cluster cluster)
        {
            return cluster.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(this global::Topologic.Cluster cluster)
        {
            return cluster.Vertices;
        }

        public static List<global::Topologic.Cell> Cells(this global::Topologic.Cluster cluster)
        {
            return cluster.Cells;
        }

        public static List<global::Topologic.CellComplex> CellComplexes(this global::Topologic.Cluster cluster)
        {
            return cluster.CellComplexes;
        }

        public static int Type(this global::Topologic.Cluster cluster)
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

    }
}
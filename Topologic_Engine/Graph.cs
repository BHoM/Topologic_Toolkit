using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic.Utilities;

namespace BH.Topologic.Core.Graph
{
    public static partial class Create
    {
        public static global::Topologic.Graph ByTopology(global::Topologic.Topology topology,
            bool direct = true,
            bool viaSharedTopologies = false,
            bool viaSharedApertures = false,
            bool toExteriorTopologies = false,
            bool toExteriorApertures = false)
        {
            return global::Topologic.Graph.ByTopology(topology, direct, viaSharedTopologies, viaSharedApertures, toExteriorTopologies, toExteriorApertures);
        }
    }

    public static partial class Query
    {
        public static List<global::Topologic.Vertex> Vertices(this global::Topologic.Graph graph)
        {
            return graph.Vertices;
        }

        public static List<global::Topologic.Vertex> IsolatedVertices(this global::Topologic.Graph graph)
        {
            return graph.IsolatedVertices;
        }

        public static List<global::Topologic.Edge> Edges(this global::Topologic.Graph graph)
        {
            return graph.Edges;
        }

        public static global::Topologic.Topology Topology(this global::Topologic.Graph graph)
        {
            return graph.Topology;
        }

        public static List<global::Topologic.Vertex> VerticesAtCoordinates(this global::Topologic.Graph graph, double x, double y, double z,
			double tolerance = 0.0001)
        {
            return graph.VerticesAtCoordinates(x, y, z, tolerance);
        }

        public static int Degree(this global::Topologic.Graph graph, global::Topologic.Vertex vertex)
        {
            return graph.Degree(vertex);
        }

        public static List<global::Topologic.Vertex> AdjacentVertices(this global::Topologic.Graph graph, global::Topologic.Vertex vertex)
        {
            return graph.AdjacentVertices(vertex);
        }

        public static bool ContainsVertex(this global::Topologic.Graph graph, global::Topologic.Vertex vertex, double tolerance = 0.0001)
        {
            return graph.ContainsVertex(vertex, tolerance);
        }

        public static bool ContainsEdge(this global::Topologic.Graph graph, global::Topologic.Edge edge, double tolerance = 0.0001)
        {
            return graph.ContainsEdge(edge, tolerance);
        }

        public static List<int> DegreeSequence(this global::Topologic.Graph graph)
        {
            return graph.DegreeSequence;
        }

        public static double Density(this global::Topologic.Graph graph)
        {
            return graph.Density;
        }

        public static bool IsComplete(this global::Topologic.Graph graph)
        {
            return graph.IsComplete;
        }

        public static int MinimumDelta(this global::Topologic.Graph graph)
        {
            return graph.MinimumDelta;
        }

        public static int MaximumDelta(this global::Topologic.Graph graph)
        {
            return graph.MaximumDelta;
        }

        public static int Diameter(this global::Topologic.Graph graph)
        {
            return graph.Diameter;
        }

        public static global::Topologic.Edge EdgeAtVertices(this global::Topologic.Graph graph, global::Topologic.Vertex vertex1, global::Topologic.Vertex vertex2,
			double tolerance = 0.0001)
        {
            return graph.EdgeAtVertices(vertex1, vertex2, tolerance);
        }

        public static List<global::Topologic.Edge> IncidentEdges(this global::Topologic.Graph graph, global::Topologic.Vertex vertex,
            double tolerance = 0.0001)
        {
            return graph.IncidentEdges(vertex, tolerance);
        }
    }

    public static partial class Modify
    {
        public static global::Topologic.Graph AddVertices(this global::Topologic.Graph graph, List<global::Topologic.Vertex> vertices, double tolerance = 0.0001)
        {
            return graph.AddVertices(vertices, tolerance);
        }

        public static global::Topologic.Graph AddEdges(this global::Topologic.Graph graph, List<global::Topologic.Edge> edges, double tolerance = 0.0001)
        {
            return graph.AddEdges(edges, tolerance);
        }

        public static global::Topologic.Graph RemoveVertices(this global::Topologic.Graph graph, List<global::Topologic.Vertex> vertices)
        {
            return graph.RemoveVertices(vertices);
        }

        public static global::Topologic.Graph RemoveEdges(this global::Topologic.Graph graph, List<global::Topologic.Edge> edges)
        {
            return graph.RemoveEdges(edges);
        }

        public static global::Topologic.Graph Connect(this global::Topologic.Graph graph, global::Topologic.Vertex vertex1, global::Topologic.Vertex vertex2, double tolerance = 0.0001)
        {
            return graph.Connect(vertex1, vertex2, tolerance);
        }
    }

    public static partial class Compute
    {
        public static List<global::Topologic.Wire> AllPaths(this global::Topologic.Graph graph, global::Topologic.Vertex startVertex, global::Topologic.Vertex endVertex, Nullable<int> timeLimitinSeconds)
        {
            return graph.AllPaths(startVertex, endVertex, timeLimitinSeconds);
        }

        public static global::Topologic.Wire Path(this global::Topologic.Graph graph, global::Topologic.Vertex startVertex, global::Topologic.Vertex endVertex)
        {
            return graph.Path(startVertex, endVertex);
        }

        public static global::Topologic.Wire ShortestPath(this global::Topologic.Graph graph, global::Topologic.Vertex startVertex, global::Topologic.Vertex endVertex)
        {
            return graph.ShortestPath(startVertex, endVertex);
        }

        public static double Distance(this global::Topologic.Graph graph, global::Topologic.Vertex startVertex, global::Topologic.Vertex endVertex)
        {
            return graph.Distance(startVertex, endVertex);
        }

        public static bool IsErdoesGallai(this global::Topologic.Graph graph, List<int> sequence)
        {
            return graph.IsErdoesGallai(sequence);
        }
    }
}
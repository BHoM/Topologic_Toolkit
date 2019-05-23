using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;
using Topologic.Utilities;

namespace BH.Topologic.Core.Topology
{

    public static partial class Convert
    {
        //public static List<IGeometry> Geometry(global::Topologic.Topology topology)
        public static IGeometry Geometry(global::Topologic.Topology topology)
        {
            //return null;
            return BasicGeometry(topology); // will this do?
            //List<IGeometry> output = new List<IGeometry>();
            //topology.RecursiveGeometry(ref output);
            //return output;
        }

        //internal static void RecursiveGeometry(global::Topologic.Topology topology, ref List<IGeometry> output)
        //{
        //    List<IGeometry> objects = new List<IGeometry>();
        //    objects.Add(BasicGeometry(topology));

        //    List<global::Topologic.Topology> subContents = topology.SubContents;
        //    List<IGeometry> subContentGeometries = new List<IGeometry>();
        //    foreach(global::Topologic.Topology subContent in subContents)
        //    {
        //        List<Object> dynamoThisGeometries = new List<Object>();
        //        RecursiveGeometry(subContent, ref subContentGeometries);
        //    }

        //    if (subContentGeometries.Count > 0)
        //    {
        //        objects.Add(subContentGeometries);
        //    }

        //    output.Add(objects);
        //}

        internal static IGeometry BasicGeometry(global::Topologic.Topology topology)
        {
            global::Topologic.Vertex vertex = topology as global::Topologic.Vertex;
            if (vertex != null)
            {
                return Vertex.Convert.BasicGeometry(vertex);
            }

            global::Topologic.Edge edge = topology as global::Topologic.Edge;
            if (edge != null)
            {
                return Edge.Convert.BasicGeometry(edge);
            }

            global::Topologic.Wire wire = topology as global::Topologic.Wire;
            if (wire != null)
            {
                return Wire.Convert.BasicGeometry(wire);
            }

            global::Topologic.Face face = topology as global::Topologic.Face;
            if (face != null)
            {
                return Face.Convert.BasicGeometry(face);
            }

            global::Topologic.Shell shell = topology as global::Topologic.Shell;
            if (shell != null)
            {
                return Shell.Convert.BasicGeometry(shell);
            }

            global::Topologic.Cell cell = topology as global::Topologic.Cell;
            if (cell != null)
            {
                return Cell.Convert.BasicGeometry(cell);
            }

            global::Topologic.CellComplex cellComplex = topology as global::Topologic.CellComplex;
            if (cellComplex != null)
            {
                return CellComplex.Convert.BasicGeometry(cellComplex);
            }

            global::Topologic.Cluster cluster = topology as global::Topologic.Cluster;
            if (cluster != null)
            {
                return Cluster.Convert.BasicGeometry(cluster);
            }

            //global::Topologic.Aperture aperture = topology as global::Topologic.Aperture;
            //if (aperture != null)
            //{
            //    return Aperture.Convert.BasicGeometry(aperture);
            //}

            throw new NotImplementedException("Geometry for this shape is not supported yet");
        }
    }

    public static partial class Create
    {
        public static global::Topologic.Topology ByGeometry(BH.oM.Geometry.IGeometry geometry, double tolerance = 0.0001)
        {
            BH.oM.Geometry.Point bhomPoint = geometry as BH.oM.Geometry.Point;
            if (bhomPoint != null)
            {
                return BH.Topologic.Core.Vertex.Create.ByPoint(bhomPoint);
            }

            // Handle polyline and polycurve first
            BH.oM.Geometry.Polyline bhomPolyline = geometry as BH.oM.Geometry.Polyline;
            if (bhomPolyline != null)
            {
                if (bhomPolyline.ControlPoints.Count < 2)
                {
                    throw new Exception("An invalid polyline with fewer than 2 control points is given.");
                }
                else if (bhomPolyline.ControlPoints.Count == 2)
                {
                    BH.oM.Geometry.Line bhomLine = BH.Engine.Geometry.Create.Line(bhomPolyline.ControlPoints[0], bhomPolyline.ControlPoints[1]);
                    return BH.Topologic.Core.Edge.Create.ByLine(bhomLine);
                }
                else
                {
                    return BH.Topologic.Core.Wire.Create.ByPolyLine(bhomPolyline);
                }
            }

            BH.oM.Geometry.PolyCurve bhomPolyCurve = geometry as BH.oM.Geometry.PolyCurve;
            if (bhomPolyCurve != null)
            {
                if (bhomPolyCurve.Curves.Count == 0)
                {
                    throw new Exception("An invalid polycurve with no curve is given.");
                }
                else if (bhomPolyCurve.Curves.Count == 1)
                {
                    BH.oM.Geometry.ICurve bhomACurve = bhomPolyCurve.Curves[0];
                    return BH.Topologic.Core.Edge.Create.ByCurve(bhomACurve);
                }
                else
                {
                    return BH.Topologic.Core.Wire.Create.ByPolyCurve(bhomPolyCurve);
                }
            }

            // Then curve
            BH.oM.Geometry.ICurve bhomCurve = geometry as BH.oM.Geometry.ICurve;
            if (bhomCurve != null)
            {
                return BH.Topologic.Core.Edge.Create.ByCurve(bhomCurve);
            }

            // Do polysurface first.
            BH.oM.Geometry.PolySurface bhomPolySurface = geometry as BH.oM.Geometry.PolySurface;
            if (bhomPolySurface != null)
            {
                return BH.Topologic.Core.Shell.Create.ByPolySurface(bhomPolySurface, tolerance);
            }

            // Then surface
            BH.oM.Geometry.ISurface bhomSurface = geometry as BH.oM.Geometry.ISurface;
            if (bhomSurface != null)
            {
                return BH.Topologic.Core.Face.Create.BySurface(bhomSurface);
            }

            BH.oM.Geometry.ISolid bhomSolid = geometry as BH.oM.Geometry.ISolid;
            if (bhomSolid != null)
            {
                return BH.Topologic.Core.Cell.Create.BySolid(bhomSolid, tolerance);
            }

            BH.oM.Geometry.BoundingBox bhomBoundingBox = geometry as BH.oM.Geometry.BoundingBox;
            if (bhomBoundingBox != null)
            {
                return BH.Topologic.Core.Cell.Create.ByBoundingBox(bhomBoundingBox);
            }

            BH.oM.Geometry.CompositeGeometry bhomCompositeGeometry = geometry as BH.oM.Geometry.CompositeGeometry;
            if (bhomCompositeGeometry != null)
            {
                return BH.Topologic.Core.Cluster.Create.ByCompositeGeometry(bhomCompositeGeometry, tolerance);
            }

            BH.oM.Geometry.Mesh bhomMesh = geometry as BH.oM.Geometry.Mesh;
            if (bhomMesh != null)
            {
                return BH.Topologic.Core.Topology.Create.ByMesh(bhomMesh);
            }

            throw new NotImplementedException("This BHoM geometry is not yet supported.");
        }

        private static global::Topologic.Topology ByMesh(Mesh bhomMesh)
        {
            global::Topologic.Shell shell = BH.Topologic.Core.Shell.Create.ByMesh(bhomMesh);
            if (shell == null)
                return null;

            List<global::Topologic.Face> faces = shell.Faces;
            if(faces.Count == 0)
            {
                return null;
            }
            else if (faces.Count == 1)
            {
                return faces[0];
            }

            // else
            return shell;
        }

        public static List<global::Topologic.Topology> ByVerticesIndices(IEnumerable<global::Topologic.Vertex> vertices, IEnumerable<List<int>> vertexIndices)
        {
            return global::Topologic.Topology.ByVerticesIndices(vertices, vertexIndices);
        }

        public static global::Topologic.Topology ByImportedBRep(String path)
        {
            return global::Topologic.Topology.ByImportedBRep(path);
        }

    }


    public static partial class Query
    {
        public static int Dimensionality(global::Topologic.Topology topology)
        {
            return topology.Dimensionality;
        }

        public static List<global::Topologic.Aperture> Apertures(global::Topologic.Topology topology)
        {
            return topology.Apertures;
        }

        public static List<global::Topologic.Topology> Contents(global::Topologic.Topology topology)
        {
            return topology.Contents;
        }

        public static List<global::Topologic.Context> Contexts(global::Topologic.Topology topology)
        {
            return topology.Contexts;
        }

        public static string Analyze(global::Topologic.Topology topology)
        {
            return topology.Analyze();
        }

        public static List<global::Topologic.Shell> Shells(global::Topologic.Topology topology)
        {
            return topology.Shells;
        }

        public static List<global::Topologic.Face> Faces(global::Topologic.Topology topology)
        {
            return topology.Faces;
        }

        public static List<global::Topologic.Wire> Wires(global::Topologic.Topology topology)
        {
            return topology.Wires;
        }

        public static List<global::Topologic.Edge> Edges(global::Topologic.Topology topology)
        {
            return topology.Edges;
        }

        public static List<global::Topologic.Vertex> Vertices(global::Topologic.Topology topology)
        {
            return topology.Vertices;
        }

        public static List<global::Topologic.Cell> Cells(global::Topologic.Topology topology)
        {
            return topology.Cells;
        }

        public static List<global::Topologic.CellComplex> CellComplexes(global::Topologic.Topology topology)
        {
            return topology.CellComplexes;
        }

        public static bool IsSame(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.IsSame(otherTopology);
        }

        public static global::Topologic.Topology ClosestSimplestSubshape(global::Topologic.Topology topology, global::Topologic.Topology selector)
        {
            return topology.ClosestSimplestSubshape(selector);
        }

        public static String TypeAsString(global::Topologic.Topology topology)
        {
            return topology.TypeAsString;
        }

        public static int Type(global::Topologic.Topology topology)
        {
            return topology.Type;
        }

        public static Dictionary<String, Object> Dictionary(global::Topologic.Topology topology)
        {
            return topology.Dictionary;
        }
    }

    public static partial class Modify
    {
        public static global::Topologic.Topology AddContents(global::Topologic.Topology topology, List<global::Topologic.Topology> contents, int typeFilter = 0)
        {
            return topology.AddContents(contents, typeFilter);
        }

        public static global::Topologic.Topology AddApertures(global::Topologic.Topology topology, IEnumerable<global::Topologic.Topology> apertureTopologies)
        {
            return topology.AddApertures(apertureTopologies);
        }


        public static global::Topologic.Topology SetDictionary(global::Topologic.Topology topology, Dictionary<String, Object> dictionary)
        {
            return topology.SetDictionary(dictionary);
        }

    }

    public static partial class Compute
    {
        public static global::Topologic.Topology Difference(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Difference(otherTopology);
        }

        public static List<global::Topologic.Topology> Filter(List<global::Topologic.Topology> topologies, int typeFilter)
        {
            return global::Topologic.Topology.Filter(topologies, typeFilter);
        }

        public static global::Topologic.Topology Impose(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Impose(otherTopology);
        }

        public static global::Topologic.Topology Imprint(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Imprint(otherTopology);
        }

        public static global::Topologic.Topology Intersect(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Intersect(otherTopology);
        }

        public static global::Topologic.Topology Merge(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Merge(otherTopology);
        }

        public static global::Topologic.Topology SelfMerge(global::Topologic.Topology topology)
        {
            return topology.SelfMerge();
        }

        public static global::Topologic.Topology Slice(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Slice(otherTopology);
        }

        public static global::Topologic.Topology Divide(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Divide(otherTopology);
        }

        public static global::Topologic.Topology Union(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.Union(otherTopology);
        }

        public static global::Topologic.Topology XOR(global::Topologic.Topology topology, global::Topologic.Topology otherTopology)
        {
            return topology.XOR(otherTopology);
        }

        public static bool ExportToBRep(global::Topologic.Topology topology, String path)
        {
            return topology.ExportToBRep(path);
        }

        public static global::Topologic.Topology ShallowCopy(global::Topologic.Topology topology)
        {
            return topology.ShallowCopy();
        }

    }
}
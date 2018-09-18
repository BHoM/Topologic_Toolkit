using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

namespace BH.Engine.Topology
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Point Geometry(this Vertex vertex)
        {
            return new Point { X = vertex.X, Y = vertex.Y, Z = vertex.Z };
        }

        /***************************************************/

        public static Line Geometry(this Edge edge)
        {
            return new Line { Start = edge.Vertices().First().Geometry(), End = edge.Vertices().Last().Geometry() };
        }

        /***************************************************/

        public static List<Line> Geometry(this Wire wire)
        {
            return wire.Edges().Select(e => e.Geometry()).ToList();
        }

        /***************************************************/

        public static List<Line> Geometry(this Topologic.Face face)
        {
            return face.Edges().Select(x => x.Geometry()).ToList();
        }

        /***************************************************/

        public static List<Line> Geometry(this Shell shell)
        {
            return shell.Faces().SelectMany(x => x.Geometry()).ToList();
        }

        /***************************************************/

        public static List<Line> Geometry(this Cell cell)
        {
            return cell.Shells().SelectMany(x => x.Geometry()).ToList();
        }

        /***************************************************/

        public static List<Line> Geometry(this CellComplex cellComplex)
        {
            return cellComplex.Cells().SelectMany(x => x.Geometry()).ToList();
        }

        /***************************************************/

        public static List<Line> Geometry(this Cluster cluster)
        {
            return cluster.Edges().Select(x => x.Geometry()).ToList();
        }

        /***************************************************/

        public static List<Line> Geometry(this DualGraph dualGraph)
        {
            return dualGraph.Edges().Select(x => x.Geometry()).ToList();
        }

        /***************************************************/
    }
}

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

        public static List<Line> Geometry(this Cell cell)
        {
            return cell.Edges().Select(x => x.Geometry()).ToList();
        }

        /***************************************************/
    }
}

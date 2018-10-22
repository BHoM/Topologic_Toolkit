using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;
using BH.Engine.Geometry;

namespace BH.Engine.Topology
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static bool MatchVertices(this BuildingElement ele, List<Vertex> vertices)
        {
            if (ele == null) return false;

            MongoDB.Bson.BsonDocument bd = BH.Engine.Serialiser.Convert.ToBson(ele);
            BuildingElement element = (BuildingElement)BH.Engine.Serialiser.Convert.FromBson(bd);

            List<Point> elementVertices = element.PanelCurve.IControlPoints();
            if (elementVertices.Count == 0) return false;
            elementVertices.RemoveAt(elementVertices.Count - 1); //Remove the last point because it is a repeat of the first point

            bool allPointsMatch = true;
            foreach(Point pt in elementVertices)
            {
                if (!allPointsMatch) break; //No point continuing if we have already found a failure
                allPointsMatch &= pt.MatchVertex(vertices);
            }

            return allPointsMatch;
        }

        /***************************************************/

        public static bool MatchVertex(this Point pt, Vertex vertex, double tolerance = BH.oM.Geometry.Tolerance.Distance)
        {
            return
                (pt.X >= (vertex.X - tolerance)) && (pt.X <= (vertex.X + tolerance)) &&
                (pt.Y >= (vertex.Y - tolerance)) && (pt.Y <= (vertex.Y + tolerance)) &&
                (pt.Z >= (vertex.Z - tolerance)) && (pt.Z <= (vertex.Z + tolerance));
        }

        /***************************************************/

        public static bool MatchVertex(this Point pt, List<Vertex> vertices)
        {
            foreach (Vertex v in vertices)
                if (pt.MatchVertex(v)) return true;

            return false;
        }
    }
}

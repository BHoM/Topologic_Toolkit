using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;

namespace BH.Engine.Topology
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static List<List<Panel>> Panels(List<Cell> cells, List<Panel> ele)
        {
            List<MongoDB.Bson.BsonDocument> bd = new List<MongoDB.Bson.BsonDocument>();
            foreach (Panel e in ele)
                bd.Add(BH.Engine.Serialiser.Convert.ToBson(e));

            List<Panel> elements = new List<Panel>();
            foreach (MongoDB.Bson.BsonDocument b in bd)
                elements.Add((Panel)BH.Engine.Serialiser.Convert.FromBson(b));

            List<List<Panel>> rtn = new List<List<Panel>>();

            foreach(Cell c in cells)
            {
                rtn.Add(new List<Panel>()); //Add a new list for the building elements which make up this cell

                List<Topologic.Face> f = c.Faces();
                foreach(Topologic.Face face in f)
                {
                    List<Vertex> v = face.Vertices();

                    foreach (Panel be in elements)
                    {
                        if (be.MatchVertices(v))
                        {
                            rtn.Last().Add(be);
                            break;
                        }
                    }
                }
            }

            return rtn;
        }

        /***************************************************/

        public static List<Panel> UnusedPanels(this List<Panel> elements, List<List<Panel>> elementsAsSpaces)
        {
            //This method obtains the building elements which aren't used to make up any spaces defined by Topologic
            List<Panel> unusedElements = new List<Panel>();

            foreach(Panel be in elements)
            {
                List<List<Panel>> spaces = elementsAsSpaces.Where(x => x.Where(y => y.BHoM_Guid == be.BHoM_Guid).ToList().Count > 0).ToList();

                if (spaces.Count == 0)
                    unusedElements.Add(be);
            }

            return unusedElements;
        }
    }
}

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

        public static List<List<BuildingElement>> BuildingElements(List<Cell> cells, List<BuildingElement> ele)
        {
            List<MongoDB.Bson.BsonDocument> bd = new List<MongoDB.Bson.BsonDocument>();
            foreach (BuildingElement e in ele)
                bd.Add(BH.Engine.Serialiser.Convert.ToBson(e));

            List<BuildingElement> elements = new List<BuildingElement>();
            foreach (MongoDB.Bson.BsonDocument b in bd)
                elements.Add((BuildingElement)BH.Engine.Serialiser.Convert.FromBson(b));

            List<List<BuildingElement>> rtn = new List<List<BuildingElement>>();

            foreach(Cell c in cells)
            {
                rtn.Add(new List<BuildingElement>()); //Add a new list for the building elements which make up this cell

                List<Topologic.Face> f = c.Faces();
                foreach(Topologic.Face face in f)
                {
                    List<Vertex> v = face.Vertices();

                    foreach (BuildingElement be in elements)
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
    }
}

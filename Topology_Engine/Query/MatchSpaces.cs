using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

using BH.oM.Environment.Elements;
using BH.Engine.Environment;

namespace BH.Engine.Topology
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static List<List<BuildingElement>> MatchSpaces(this List<List<BuildingElement>> elementsAsSpaces, List<Space> spaces)
        {
            List<List<BuildingElement>> outElements = new List<List<BuildingElement>>();

            foreach(List<BuildingElement> bes in elementsAsSpaces)
            {
                List<MongoDB.Bson.BsonDocument> bd = new List<MongoDB.Bson.BsonDocument>();
                foreach (BuildingElement be in bes)
                    bd.Add(BH.Engine.Serialiser.Convert.ToBson(be));

                outElements.Add(new List<BuildingElement>());

                foreach (MongoDB.Bson.BsonDocument b in bd)
                    outElements.Last().Add((BuildingElement)BH.Engine.Serialiser.Convert.FromBson(b));
            }

            foreach (List<BuildingElement> bes in outElements)
            {
                Space foundSp = null;

                foreach(Space s in spaces)
                {
                    if(s.Location == null)
                    {
                        foundSp = s; break;
                    }
                    if (!bes.IsContaining(s.Location))
                        continue;
                    else
                    {
                        foundSp = s;
                        break;
                    }
                }

                if(foundSp != null)
                {
                    foreach(BuildingElement be in bes)
                        be.CustomData.Add("Space_Custom_Data", foundSp.CustomData);
                }
            }

            return outElements;
        }
    }
}
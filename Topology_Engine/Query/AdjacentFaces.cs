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

        public static List<Topologic.Face> AdjacentFaces(this Topologic.Face face, Topologic.Topology parentTopology)
        {
            return face.AdjacentFaces(parentTopology);
        }

        /***************************************************/
    }
}

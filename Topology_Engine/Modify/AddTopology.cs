using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic;

namespace BH.Engine.Topology
{
    public static partial class Modify
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Topologic.Cluster AddTopology(this Topologic.Cluster cluster, Topologic.Topology topology)
        {
            return cluster.AddTopology(topology);
        }

        /***************************************************/
    }
}

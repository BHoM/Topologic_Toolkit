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

        public static Topologic.Face Trim(this Topologic.Face face, Topologic.Wire wire)
        {
            return face.Trim(wire);
        }

        /***************************************************/
    }
}

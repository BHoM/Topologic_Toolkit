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

        public static List<Topologic.Face> Faces(this Cell cell)
        {
            return cell.Faces();
        }

        /***************************************************/

        public static List<Topologic.Face> Faces(this CellComplex cellComplex)
        {
            return cellComplex.Faces();
        }

        /***************************************************/

        public static List<Topologic.Face> Faces(this Cluster cluster)
        {
            return cluster.Faces();
        }

        /***************************************************/

        public static List<Topologic.Face> Faces(this Shell shell)
        {
            return shell.Faces();
        }

        /***************************************************/

        public static List<Topologic.Face> Faces(this Wire wire)
        {
            return wire.Faces();
        }

        /***************************************************/
    }
}

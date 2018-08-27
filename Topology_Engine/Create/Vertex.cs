using BH.oM.Geometry;
using Topologic;

namespace BH.Engine.Topology
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Vertex Vertex(Point point)
        {
            return Topologic.Vertex.ByCoordinates(point.X, point.Y, point.Z);
        }

        /***************************************************/
    }
}
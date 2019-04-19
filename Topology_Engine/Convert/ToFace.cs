using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using Topologic;
using BH.Engine.Geometry;
using BH.Engine.Environment;

namespace BH.Engine.Topology
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Topologic.Face ToFace(this Panel panel)
        {
            List<ICurve> curves = panel.ToPolyline().ISubParts().ToList();

            List<Line> lines = new List<Line>();

            foreach (ICurve crv in curves)
            {
                if (!(crv is Line))
                    return null;
                else
                    lines.Add(crv as Line);
            }

            return Create.Face(lines.Select(x => Create.Edge(x)));
        }
    }
}

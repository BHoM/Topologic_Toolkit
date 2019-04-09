using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using Topologic.Utilities;

namespace BH.Topologic.Utilities.Bitwise
{
    public static partial class Compute
    {
        public static int And(List<int> arguments)
        {
            return global::Topologic.Utilities.Bitwise.And(arguments);
        }


        public static int Or(List<int> arguments)
        {
            return global::Topologic.Utilities.Bitwise.Or(arguments);
        }


        public static int Xor(List<int> arguments)
        {
            return global::Topologic.Utilities.Bitwise.Xor(arguments);
        }


        public static int Not(int argument)
        {
            return global::Topologic.Utilities.Bitwise.Not(argument);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _253505_Shishov_Lab1.Entities
{
    internal class GenericMath<T>
    {
        public GenericMath() { }
        public static T Add<T>(T left, T right) where T: IAdditionOperators<T,T,T>
        {
            return left + right;
        }
    }
}

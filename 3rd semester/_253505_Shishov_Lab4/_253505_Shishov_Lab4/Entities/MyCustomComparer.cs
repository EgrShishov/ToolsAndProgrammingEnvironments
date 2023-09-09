using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab4.Entities
{
    internal class MyCustomComparer<T> : IComparer<T> where T : Goods
    {
        public int Compare(T? x, T? y)
        {
            if (x==null || y==null) throw new ArgumentNullException();
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}

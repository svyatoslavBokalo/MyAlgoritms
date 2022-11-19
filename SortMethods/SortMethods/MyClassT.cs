using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMethods
{
    internal class MyClassT<T>
    {
        T a;

        public MyClassT(T a)
        {
            this.a = a;
        }

        public override string? ToString()
        {
            return a.ToString();
        }
    }
}

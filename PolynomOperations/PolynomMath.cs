using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomOperations
{
    public class PolynomMath<T> where T : struct
    {

        private List<T> polynom = new List<T>();

        internal PolynomMath(List<T> array)
        {
            polynom = array;
        }

        public int HeadPow()
        {
            return polynom.Count();
        }

        public T GetSolution(double x)
        {
            T res = polynom[0];

            for (int i = 1; i < HeadPow(); i++)
                res += (dynamic)polynom[i] * Math.Pow(x, i);

            return res;
        }
    }
}

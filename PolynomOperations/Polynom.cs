using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomOperations
{
    [Serializable]
    public class Polynom<T> where T : struct
    {
        public PolynomMath<T> Operations => new PolynomMath<T>(Array);
        public CopyMaker<Polynom<T>> Copy => new CopyMaker<Polynom<T>>(this);

        private List<T> genericArray;

        public List<T> Array
        {
            get { return genericArray; }
            set
            {
                if (typeof(T) == typeof(int) || typeof(T) == typeof(double) || typeof(T) == typeof(short))
                {
                    genericArray = value;
                }
                else throw new ImpossiblePolynomOperationException();
            }
        }

        public Polynom()
        {

        }

        public Polynom(T[] arrayCoefficients)
        {
            Array = new List<T>(arrayCoefficients);
        }

        public Polynom(List<T> arrayCoefficients)
        {
            Array = new List<T>(arrayCoefficients);
        }

        public Polynom(int headPow)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(double) || typeof(T) == typeof(short))
            {
                Array = new List<T>(headPow);
                for (int i = 0; i < headPow; i++)
                {
                    Array.Add((dynamic)0);
                }
            }
            else throw new ImpossiblePolynomOperationException();

        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= Array.Count) throw new IndexOutOfRangeException();
                return this.Array[i];
            }

            set
            {
                if (i < 0 || i >= Array.Count) throw new IndexOutOfRangeException();
                this.Array[i] = value;
            }
        }

        
        public static Polynom<T> operator +(Polynom<T> poly1, Polynom<T> poly2)
        {
            Polynom<T> maxPoly = Math.Max(poly1.Array.Count, poly2.Array.Count) == poly1.Array.Count ? poly1 : poly2;
            Polynom<T> minPoly = Math.Max(poly1.Array.Count, poly2.Array.Count) == poly1.Array.Count ? poly2 : poly1;

            Polynom<T> resultPoly = new Polynom<T>(maxPoly.Array);

            for (int i = 0; i < minPoly.Array.Count; i++)
                resultPoly[i] = (dynamic)maxPoly[i] + minPoly[i];

            return resultPoly;
        }

        public static Polynom<T> operator *(Polynom<T> poly1, Polynom<T> poly2)
        {
            Polynom<T> resultPoly = new Polynom<T>(poly1.Array.Count + poly2.Array.Count - 1);
            resultPoly.Array.Select(x => 0);

            for (int i = 0; i < poly1.Array.Count; i++)
                for (int j = 0; j < poly2.Array.Count; j++)
                    resultPoly[i + j] += (dynamic)poly1[i] * poly2[j];

            return resultPoly;
        }

        public static Polynom<T> operator -(Polynom<T> poly1, Polynom<T> poly2)
        {
            Polynom<T> maxPoly = Math.Max(poly1.Array.Count, poly2.Array.Count) == poly1.Array.Count ? poly1 : poly2;
            Polynom<T> minPoly = Math.Max(poly1.Array.Count, poly2.Array.Count) == poly1.Array.Count ? poly2 : poly1;

            Polynom<T> resultPoly = new Polynom<T>(maxPoly.Array);

            for (int i = 0; i < minPoly.Array.Count; i++)
                resultPoly[i] = (dynamic)maxPoly[i] - minPoly[i];

            return resultPoly;
        }
    }
}

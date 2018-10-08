using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{
    [Serializable]
    public class MatrixTable<T> where T: struct
    {
        private T[,] matrix;

        public MatrixMath<T> Operations => new MatrixMath<T>(this);
        public CopyMaker<MatrixTable<T>> Copy => new CopyMaker<MatrixTable<T>>(this);

        public T[,] Matrix
        {
            set
            {
                if (typeof(T) == typeof(int) || typeof(T) == typeof(double) || typeof(T) == typeof(short))
                {
                    matrix = value;
                }
                else throw new ImpossibleMatrixOperationException();
            }
            get
            {
                return matrix;
            }
        }
        public MatrixTable()
        {
                
        }

        public MatrixTable(T[,] arrayCoefficients)
        {
            try
            {
                Matrix = arrayCoefficients;
            }
            catch (OverflowException)
            {
                throw new OverflowException("Matrix dimension must be equal or bigger than 0 !");
            }
            catch (Exception)
            {
                throw;
            }

        }
        public MatrixTable(int arraySizeX, int arraySizeY)
        {
            try
            {
                Matrix = new T[arraySizeX, arraySizeY];
            }
            catch (OverflowException)
            {
                throw new OverflowException("Matrix dimension must be equal or bigger than 0 !");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static MatrixTable<T> operator *(MatrixTable<T> a, MatrixTable<T> b)
        {
            if (a.Matrix.GetLength(1) != b.Matrix.GetLength(0))
                throw new ImpossibleMatrixOperationException();
            var result = new MatrixTable<T>(a.Matrix.GetLength(0), b.Matrix.GetLength(1));
            for (int i = 0; i < a.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < b.Matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < b.Matrix.GetLength(0); k++)
                    {
                        result[i, j] += (dynamic)a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        public static MatrixTable<T> operator -(MatrixTable<T> a, MatrixTable<T> b)
        {
            if (a.Matrix.GetLength(0) != b.Matrix.GetLength(0) || a.Matrix.GetLength(1) != b.Matrix.GetLength(1))
            {
                throw new ImpossibleMatrixOperationException();
            }
            int arraySizeX = a.Matrix.GetLength(0);
            int arraySizeY = a.Matrix.GetLength(1);
            var A = new MatrixTable<T>(arraySizeX, arraySizeY);

            for (int i = 0; i < arraySizeY; i++)
            {
                for (int j = 0; j < arraySizeX; j++)
                {
                    A[i, j] = (dynamic)a[i, j] - b[i, j];
                }
            }

            return A;
        }
        public static MatrixTable<T> operator +(MatrixTable<T> a, MatrixTable<T> b)
        {
            if (a.Matrix.GetLength(0) != b.Matrix.GetLength(0) || a.Matrix.GetLength(1) != b.Matrix.GetLength(1))
            {
                throw new ImpossibleMatrixOperationException();
            }
            int arraySizeX = a.Matrix.GetLength(0);
            int arraySizeY = a.Matrix.GetLength(1);
            var A = new MatrixTable<T>(arraySizeX, arraySizeY);

            for (int i = 0; i < arraySizeY; i++)
            {
                for (int j = 0; j < arraySizeX; j++)
                {
                    A[i, j] = (dynamic)a[i, j] + b[i, j];
                }
            }

            return A;
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Matrix.GetLength(0) || j < 0 || j >= Matrix.GetLength(1))
                    throw new IndexOutOfRangeException();
                return this.Matrix[i, j];
            }

            set
            {
                if (!(i < 0 || i >= Matrix.GetLength(0) || j < 0 || j >= Matrix.GetLength(1)))
                    this.Matrix[i, j] = value;
                else throw new ImpossibleMatrixOperationException();
            }
        }
    }

    
}

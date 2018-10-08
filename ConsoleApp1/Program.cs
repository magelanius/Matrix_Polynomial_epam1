using MatrixOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolynomOperations;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace ConsoleApp1
{
    [TestFixture]
    class Program
    {
        [Test]
        static void Main(string[] args)
        {

            //var m1 = new MatrixTable<double>(2, 2);

            //m1.Matrix1[0, 0] = "hey";
            //m1.Matrix = FillMatrix(m1.Matrix);

            //n[0, 0] = 0;
            //double[,] m = { { 1, 1 }, { 1, 1 } };
            
            var a = new MatrixTable<double>(new double[,] { { 3,5},{ 5, 6 } });
            
            var b = new MatrixTable<double>(new double[,] { { 3, 5 }, { 5, 6 } });

            var c = a + b;

            //a[4, 2] = 5;
            //var cbcbv = new MatrixTable<double>(-4,5);
            ////var t = a + m1;
            //var t1 = a.Operations.MatricesSizeEqual(n);

            List<double> l = new List<double> { 1, 2, 3, 4 };
            List<double> l2 = new List<double> { 1, 2, -3, -4 };

            var p1 = new Polynom<double>(l);
            var p2 = new Polynom<double>(l2);
            var test = p1 + p2;
            var t1 = test.Operations.HeadPow();
            var p7 = new Polynom<int>(new int[] { 1, 3 });
            var vc = a.Copy.DeepCopy();
            var p3 = p2 * p1;
            

            GC.Collect();
            Console.WriteLine(GC.GetTotalMemory(false));


        }
        






        static double[,] FillMatrix(double[,] a)
        {
            Random random = new Random();

            for (int i = 0; i < a.GetLength(1); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    a[j, i] = random.Next(0, 100) + random.NextDouble();
                }
            }
            return a;
        }
        static double[,] FillMatrix(int n, int m)
        {
            Random random = new Random();
            var a = new double[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[j, i] = random.Next(0, 100) + random.NextDouble();
                }
            }
            return a;
        }
    }
}

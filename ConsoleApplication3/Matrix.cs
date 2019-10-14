using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApplication3
{
    public class Matrix
    {
        public float[,] AugmentedMatrix { get; }
        public float[,] CoeffecientMatrix { get; }
        public int m
        {
            get
            {
                if (AugmentedMatrix == null) return -1;
                return AugmentedMatrix.GetLength(0);
            }
        }

        public int n
        {
            get
            {
                if (AugmentedMatrix == null) return -1;
                return AugmentedMatrix.GetLength(1);
            }
        }
        public Matrix(float[] coeffecients, int n)
        {

            if (coeffecients.Length % n != 0) throw new ArgumentException($"Coeffecients are off by {coeffecients.Length % n}");
            var m = coeffecients.Length / n;
            AugmentedMatrix = new float[m, n];
            CoeffecientMatrix = new float[m,n - 1];
            var l = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    AugmentedMatrix[i, j] = coeffecients[l];
                    if (j < n - 1)
                    {
                        CoeffecientMatrix[i, j] = coeffecients[l];
                    }
                    l++;
                }
        }

        public Matrix(Polynomial[] equations)
        {

        }
        public void PrintMatrix()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(AugmentedMatrix[i, j]);
                    if (j < n - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public void PrintCoeffecientMatrix()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write(CoeffecientMatrix[i, j]);
                    if (j < n - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        public int FindLeadingVar()
        {
            var leading = new Tuple<int, int>(0, 0);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!AugmentedMatrix[i, j].Equals(0) && j <= leading.Item2)
                    {
                        leading = new Tuple<int, int>(i, j);
                        i++;
                        break;
                    }
                }
            }
            return leading.Item1;
        }

        public void SwitchRow(int source, int destination)
        {

            for (int i = 0; i < m; i++)
            {
                var ce = AugmentedMatrix[destination, i];
                AugmentedMatrix[destination, i] = AugmentedMatrix[source, i];
                AugmentedMatrix[source, i] = ce;
            }
        }

        public void AddRow(int source, int destination, float factor)
        {
            // get number of columns
            // iterate through columns
            for (var i = 0; i < n; i++)
            {
                // get multiple
                float multiple = 0f - ((1f / factor) * AugmentedMatrix[source, i]);
                // add to destination
                AugmentedMatrix[destination, i] = AugmentedMatrix[destination, i] + multiple;
            }

        }

        public void Gaussian()
        {

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (AugmentedMatrix[i, j].Equals(1)) break;

                    if (!AugmentedMatrix[i, j].Equals(0))
                    {
                        var source = AugmentedMatrix[i, j];
                        if (!source.Equals(1))
                        {
                            AddRow(i, i, source);
                        }
                        // reassign source incase it changed
                        source = AugmentedMatrix[i, j];
                        for (int p = i + 1; p < m; p++)
                        {
                            if (p > m) break;
                            if (!AugmentedMatrix[p, j].Equals(0))
                            {
                                var target = AugmentedMatrix[p, j];
                                var factor = source / target;
                                AddRow(i, p, factor);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void Jordan()
        {

            for (int i = m - 1; i > -1; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!AugmentedMatrix[i, j].Equals(0))
                    {
                        var source = AugmentedMatrix[i, j];
                        for (int p = i - 1; p > -1; p--)
                        {
                            if (p < 0) break;
                            if (!AugmentedMatrix[p, j].Equals(0))
                            {
                                var target = AugmentedMatrix[p, j];
                                var factor = source / target;
                                AddRow(i, p, factor);
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public static class Matrices
    {
        public static void PrintMatrix(float[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                    if (j < n - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }
        }
        public static int FindLeadingVar(float[,] matrix)
        {
            var leading = new Tuple<int, int>(0, 0);
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!matrix[i, j].Equals(0) && j <= leading.Item2)
                    {
                        leading = new Tuple<int, int>(i, j);
                        i++;
                        break;
                    }
                }
            }
            return leading.Item1;
        }

        public static void SwitchRow(float[,] matrix, int source, int destination)
        {
            var m = matrix.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                var ce = matrix[destination, i];
                matrix[destination, i] = matrix[source, i];
                matrix[source, i] = ce;
            }
        }

        public static void AddRow(float[,] matrix, int source, int destination, float factor)
        {
            // get number of columns
            var n = matrix.GetLength(1);
            // iterate through columns
            for (var i = 0; i < n; i++)
            {
                // get multiple
                float multiple = 0f - ((1f / factor) * matrix[source, i]);
                // add to destination
                matrix[destination, i] = matrix[destination, i] + multiple;
            }

        }

        public static void Gaussian(float[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j].Equals(1)) break;

                    if (!matrix[i, j].Equals(0))
                    {
                        var source = matrix[i, j];
                        if (!source.Equals(1))
                        {
                            AddRow(matrix, i, i, source);
                        }
                        // reassign source incase it changed
                        source = matrix[i, j];
                        for (int p = i + 1; p < m; p++)
                        {
                            if (p > m) break;
                            if (!matrix[p, j].Equals(0))
                            {
                                var target = matrix[p, j];
                                var factor = source / target;
                                AddRow(matrix, i, p, factor);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public static void Jordan(float[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            for (int i = m - 1; i > -1; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!matrix[i, j].Equals(0))
                    {
                        var source = matrix[i, j];
                        for (int p = i - 1; p > -1; p--)
                        {
                            if (p < 0) break;
                            if (!matrix[p, j].Equals(0))
                            {
                                var target = matrix[p, j];
                                var factor = source / target;
                                AddRow(matrix, i, p, factor);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}

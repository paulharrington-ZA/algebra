using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new float[3,4];
            matrix[0, 0] = 0;
            matrix[0, 1] = 2;
            matrix[0, 2] = 2;
            matrix[0, 3] = 1;
            matrix[1, 0] = 0;
            matrix[1, 1] = 2;
            matrix[1, 2] = 1;
            matrix[1, 3] = 1;
            matrix[2, 0] = 1;
            matrix[2, 1] = 2;
            matrix[2, 2] = 4;
            matrix[2, 3] = 6;
            var leading = FindLeadingVar(matrix);
            Console.WriteLine("Original Matrix");
            PrintMatrix(matrix);
            Console.WriteLine($"Leading Variable is in row: { leading}");
            if (leading > 0)
                SwitchRow(matrix, leading, 0);
            Console.WriteLine("After Sort");
            PrintMatrix(matrix);
            Console.ReadKey();
            Gaussian(matrix);
            Console.WriteLine("After Gausian");
            PrintMatrix(matrix);
            Console.ReadKey();

            Jordan(matrix);
            Console.WriteLine("After Gauss-Jordan");
            PrintMatrix(matrix);
            Console.ReadKey();
        }

        static void PrintMatrix(float[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                    if (j < n - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }
        }
        static int FindLeadingVar(float[,] matrix)
        {
            var leading = new Tuple<int, int>(0,0);
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!matrix[i, j].Equals(0) && j <= leading.Item2)
                    {
                        leading = new Tuple<int, int>(i,j);
                        i++;
                        break;
                    }
                }
            }
            return leading.Item1;
        }

        static void SwitchRow(float[,] matrix, int source, int destination)
        {
            var m = matrix.GetLength(1);
            
            for (int i = 0; i < m; i++)
            {
                var ce = matrix[destination, i];
                matrix[destination, i] = matrix[source, i];
                matrix[source, i] = ce;
            }
        }

        static void AddRow(float[,] matrix, int source, int destination, float factor)
        {
            // get number of columns
            var n = matrix.GetLength(1);
            // iterate through columns
            for (var i = 0; i < n; i ++)
            {
                // get multiple
                float multiple = 0f - ((1f/factor)*matrix[source, i]);
                // add to destination
                matrix[destination, i] = matrix[destination, i] + multiple;
            }

        }

        static void Gaussian(float[,] matrix)
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
                            AddRow(matrix,i,i,source);
                        }
                        // reassign source incase it changed
                        source = matrix[i, j];
                        for (int p = i + 1; p < m; p++)
                        {
                            if (p > m) break;
                            if (!matrix[p,j].Equals(0))
                            {
                                var target = matrix[p,j];
                                var factor = source/target;
                                AddRow(matrix,i,p,factor);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        static void Jordan(float[,] matrix)
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

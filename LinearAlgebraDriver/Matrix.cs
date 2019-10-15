using System;
using System.CodeDom;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApplication3
{
    public class Matrix
    {
        public double[,] AugmentedMatrix { get; }
        public double[,] CoeffecientMatrix { get; }
        public int M
        {
            get
            {
                if (AugmentedMatrix == null) return -1;
                return AugmentedMatrix.GetLength(0);
            }
        }

        public int N
        {
            get
            {
                if (AugmentedMatrix == null) return -1;
                return AugmentedMatrix.GetLength(1);
            }
        }
        public Matrix(double[] coeffecients, int n)
        {

            if (coeffecients.Length % n != 0) throw new ArgumentException($"Coeffecients are off by {coeffecients.Length % n}");
            var m = coeffecients.Length / n;
            AugmentedMatrix = new double[m, n];
            CoeffecientMatrix = new double[m, n - 1];
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

        public Matrix(Polynomial system)
        {
            var coeffecients = new double[(system.Definition.R * system.N) + system.N];
            var n = system.N + 1;
            var l = 0;
            var m = system.SystemOfEquations.Length;
            AugmentedMatrix = new double[system.SystemOfEquations.Length, n];
            CoeffecientMatrix = new double[m, n - 1];
            for (int i = 0; i < m; i++)
            {
                var equation = system.SystemOfEquations[i];
                for (int j = 0; j < equation.Left.Length; j++)
                {
                    AugmentedMatrix[i, j] = equation.Left[j].FittedValue;
                    if (j < CoeffecientMatrix.GetLength(1))
                        CoeffecientMatrix[i, j] = equation.Left[j].FittedValue;
                }
                AugmentedMatrix[i, equation.R] = equation.Y;
            }
        }

        public string PrintMatrix()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append(AugmentedMatrix[i, j]);
                    if (j < N - 1) sb.Append(", ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string PrintMatrix(double[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var sb = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append(matrix[i, j]);
                    if (j < n - 1) sb.Append(", ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void PrintCoeffecientMatrix()
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    Console.Write(CoeffecientMatrix[i, j]);
                    if (j < N - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        public int FindLeadingVar()
        {
            var ln = 0;
            var leads = new LeadingVar[M];
            for (int i = 0; i < M; i++)
            {
                while (AugmentedMatrix[i, ln].Equals(0))
                {
                    ln++;
                }
                leads[i] = new LeadingVar(i, ln);
            }

            var sorted = leads.OrderBy(l => l.VarIndex);
            return sorted.First().RowIndex;
        }

        public void SwitchRow(int source, int destination)
        {

            for (int i = 0; i < M; i++)
            {
                var ce = AugmentedMatrix[destination, i];
                AugmentedMatrix[destination, i] = AugmentedMatrix[source, i];
                AugmentedMatrix[source, i] = ce;
            }
        }

        public void FactorRow(int source, int destination, double factor)
        {
            // get number of columns
            // iterate through columns
            for (var i = 0; i < N; i++)
            {
                // get multiple
                double multiple = 0f - ((1f / factor) * AugmentedMatrix[source, i]);
                // add to destination
                AugmentedMatrix[destination, i] = AugmentedMatrix[destination, i] + multiple;
            }

        }

        private bool CleanColumn(double[,] matrix, int i, int c)
        {
            var clean = true;
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            for (int k = i + 1; k < m; k++)
            {
                if (matrix[k, c].Equals(0)) continue;
                clean = false;
                break;
            }
            return clean;
        }

        public struct LeadingVar
        {
            public int RowIndex;
            public int VarIndex;

            public LeadingVar(int rowIndex, int varIndex)
            {
                RowIndex = rowIndex;
                VarIndex = varIndex;
            }
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                var struc = (LeadingVar)obj;
                return struc.VarIndex == VarIndex;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
        public void Gaussian()
        {

            for (int i = 0; i < M; i++)
            {
                // get the index of the leading variable
                var j = 0;
                var r = AugmentedMatrix.GetRow(i);
                while (r[j].Equals(0)) j++;

                var source = AugmentedMatrix[i, j];
                // check if the leading var of the row is one
                if (!source.Equals(1))
                {
                    // if not, factor the row by itself with a factor of 1 / leading var
                    FactorRow(i, i, source);
                }
                // reassign source incase it changed, we should now have a leading factor of 1
                source = AugmentedMatrix[i, j];
                var clean = CleanColumn(AugmentedMatrix, i, j);
                if (!clean)
                    for (int p = i + 1; p < M; p++)
                    {
                        if (!AugmentedMatrix[p, j].Equals(0))
                        {
                            var target = AugmentedMatrix[p, j];
                            var factor = source / target;
                            FactorRow(i, p, factor);
                        }
                    }
            }
        }


        public void Jordan()
        {

            for (int i = M - 1; i > -1; i--)
            {
                for (int j = 0; j < N; j++)
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
                                FactorRow(i, p, factor);
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void Add(double[,] matrix)
        {
            var aM = matrix.GetLength(0);
            var aN = matrix.GetLength(1);
            if (aM != M || aN != N)
                throw new Exception("Matrices must be same size to be added");

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    AugmentedMatrix[i, j] += matrix[i, j];
                }
        }

        private double GetMultipleValue(double[,] A, double[,] B, int row, int col)
        {
            double total = 0;
            for (int i = 0; i < B.GetLength(1); i++)
                total += A[row, i]*B[col, i];
            return total;
        }

        public double[,] Multiply(double[,] matrix)
        {
            var aM = matrix.GetLength(0);
            var aN = matrix.GetLength(1);
            if (aM != N) return null;

            var resultMatrix = new double[M, aN];

            for (int i = 0; i < M; i++)
                for (int j = 0; j < aN; j++)
                {
                    resultMatrix[i, j] = GetMultipleValue(AugmentedMatrix, matrix, i, j);
                }

            return resultMatrix;
        }
    }

    // copied from stack overflow
    public static class ArrayExt
    {
        public static T[] GetRow<T>(this T[,] array, int row)
        {
            if (!typeof(T).IsPrimitive)
                throw new InvalidOperationException("Not supported for managed types.");

            if (array == null)
                throw new ArgumentNullException("array");

            int cols = array.GetUpperBound(1) + 1;
            T[] result = new T[cols];

            int size;

            if (typeof(T) == typeof(bool))
                size = 1;
            else if (typeof(T) == typeof(char))
                size = 2;
            else
                size = Marshal.SizeOf<T>();

            Buffer.BlockCopy(array, row * cols * size, result, 0, cols * size);

            return result;
        }
    }

}

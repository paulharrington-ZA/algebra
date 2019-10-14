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
            var leading = Matrices.FindLeadingVar(matrix);
            Console.WriteLine("Original Matrix");
            Matrices.PrintMatrix(matrix);
            Console.WriteLine($"Leading Variable is in row: { leading}");
            if (leading > 0)
                Matrices.SwitchRow(matrix, leading, 0);
            Console.WriteLine("After Sort");
            Matrices.PrintMatrix(matrix);
            Console.ReadKey();
            Matrices.Gaussian(matrix);
            Console.WriteLine("After Gausian");
            Matrices.PrintMatrix(matrix);
            Console.ReadKey();

            Matrices.Jordan(matrix);
            Console.WriteLine("After Gauss-Jordan");
            Matrices.PrintMatrix(matrix);
            Console.ReadKey();
        }

 
    }
}

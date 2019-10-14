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
            var matrix = new Matrix(new float[] {0,2,2,1,0,2,1,1,1,2,4,6}, 4);
            var leading = matrix.FindLeadingVar();
            Console.WriteLine("Original Matrix");
            matrix.PrintMatrix();
            Console.WriteLine($"Leading Variable is in row: { leading}");
            if (leading > 0)
               matrix.SwitchRow(leading, 0);
            Console.WriteLine("After Sort");
            matrix.PrintMatrix();
            
            matrix.Gaussian();
            Console.WriteLine("After Gausian");
            matrix.PrintMatrix();
            

            matrix.Jordan();
            Console.WriteLine("After Gauss-Jordan");
            matrix.PrintMatrix();
            
        }

 
    }
}

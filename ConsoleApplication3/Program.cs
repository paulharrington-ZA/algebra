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
            Console.OutputEncoding = Encoding.Unicode;
            var poly = new Polynomial(4);
            poly.Definition.Print();
            Console.ReadKey();
            poly.Fit(new[]
            {
                new Polynomial.Point(-3,-2), 
                new Polynomial.Point(-1,1), 
                new Polynomial.Point(2,4), 
                new Polynomial.Point(4,2), 
            });

            poly.PrintEquations();
            poly.Matrix.PrintMatrix();
            var matrix = poly.Matrix;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Polynomial
    {
        public int N { get; private set; }
        public Equation Definition { get; }

        public Equation[] SystemOfEquations { get; private set; }

        public Matrix Matrix => new Matrix(this);

        public Polynomial(int n)
        {
            Definition = new Equation(n - 1);
        }
        public class Equation
        {
            public Atom[] Left { get; }
            public Atom[] Right { get; }
            public int R { get; set; }
            public double Y { get; set; }

            public Equation(int r)
            {
                Left = new Atom[r];
                for (int i = 0; i < r; i++)
                {
                    Left[i] = new Atom(i);
                }

                R = r;
            }
            public void Print(bool fitted = false)
            {
                foreach (Atom t in Left)
                {
                    t.Print(fitted);
                }
                Console.Write("=");
                

                Console.WriteLine();
            }
        }

        public void Fit(Point[] points)
        {
            if (points == null) throw new ArgumentException("No points to fit");

            SystemOfEquations = new Equation[points.Length];
            var r = Definition.R;
            for (int i = 0; i < points.Length; i++)
            {
                SystemOfEquations[i] = new Equation(r);
                for (int j = 0; j < r; j++)
                {
                    SystemOfEquations[i].Left[j].VariableValue = points[i].X;
                }

                SystemOfEquations[i].Y = points[i].Y;
            }

            N = points.Length;
        }

        public class Atom
        {
            private readonly Dictionary<int, string> _subScriptUnicodes = new Dictionary<int, string>
        {
            {0, "\u2080" },
            {1, "\u00b9" },
            {2, "\u2082" },
            {3, "\u2083" },
            {4, "\u2084" },
            {5, "\u2085" },
            {6, "\u2086" },
            {7, "\u2087" },
            {8, "\u2088" },
            {9, "\u2089" }
        };
            private readonly Dictionary<int, string> _superScriptUnicodes = new Dictionary<int, string>
        {
            {0, "\xB0" },
            {1, "\xB1" },
            {2, "\xB2" },
            {3, "\xB3" },
            {4, "\xB4" },
            {5, "\xB5" },
            {6, "\xB6" },
            {7, "\xB7" },
            {8, "\xB8" },
            {9, "\xB9" }
        };
            public double Coeffecient;
            public char Variable;
            public int Order;

            public Atom(int order, char variable = 'x')
            {
                Order = order;
                Variable = variable;
            }

            public double VariableValue { get; set; }

            public double FittedValue => Math.Pow(VariableValue, Order);

            public void Print(bool fitted = false)
            {
                var output = !fitted ? 
                    Order > 0 ? $" a{_subScriptUnicodes[Order]}{Variable}{_superScriptUnicodes[Order]}" : $" a{_subScriptUnicodes[Order]}"
                    : Order > 0 ? $" a{_subScriptUnicodes[Order]}{FittedValue}" : $" a{_subScriptUnicodes[Order]}";
                Console.Write(output);
            }
        }

        public struct Point
        {
            public double X;
            public double Y;

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        public void PrintEquations()
        {
            foreach (var equation in SystemOfEquations)
            {
                equation.Print(true);
            }
        }
    }

    
}

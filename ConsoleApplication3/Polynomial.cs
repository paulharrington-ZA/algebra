using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Polynomial
    {
        public int N;

        
        public Polynomial Fit(Point[] points)
        {
            return new Polynomial();
        }
        public class Atom
        {
            public float Coeffecient;
            public char Variable;
            public int Order;
            
        }

        public struct Point
        {
            public float X;
            public float Y;
        }
        
    }

    
}

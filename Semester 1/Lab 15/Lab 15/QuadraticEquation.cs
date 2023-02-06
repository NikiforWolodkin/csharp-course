using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public static class QuadraticEquation
    {
        private class Variables
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public int? D { get; set; }
            public int? X1 { get; set; }
            public int? X2 { get; set; }

            public Variables(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
                D = null;
                X1 = null;
                X2 = null;
            }
        }

        public static int SumQuadraticEquationSolutions(int a, int b, int c)
        {
            Variables variables = new Variables(a, b, c);

            Task<int> D = new Task<int>((variables) =>
            {
                return (int)(Math.Pow(((Variables)variables).B, 2) - 4 * ((Variables)variables).A * ((Variables)variables).C);
            }, variables);
            D.Start();
            variables.D = D.Result;

            Task<int> x1 = new Task<int>((variables) =>
            {
                if (((Variables)variables).D < 0)
                {
                    return 0;
                }

                return -(((Variables)variables).B / (2 * ((Variables)variables).A));
            }, variables);
            x1.Start();
            variables.X1 = x1.Result;

            Task<int> x2 = new Task<int>((variables) =>
            {
                if (((Variables)variables).D < 0)
                {
                    return 0;
                }

                return -(((Variables)variables).B / (2 * ((Variables)variables).A));
            }, variables);
            x2.Start();
            variables.X2 = x2.Result;

            Task<int> result = new Task<int>((variables) =>
            {
                return (int)(((Variables)variables).X1 + ((Variables)variables).X2);
            }, variables);
            result.Start();

            return result.Result;
        }
    }
}

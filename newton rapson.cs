using System;
// root finding
namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            //this is my main method where i apply the function to find the roots of ech equation
            // i did 20 iterations as that was sufficient to get and answer for each
            // equation 1
            Console.WriteLine("the root of F1 is {0}", Newrap(-1.5, 20, F1, D1));
            Console.WriteLine();
            //equation 2
            Console.WriteLine("the root of F2 is {0}", Newrap(5.1, 20, F2, D2));
            Console.WriteLine();
            // equation 2 with p0 = 5.45
            Newrap(5.45, 20, F2, D2);
            Console.WriteLine();
            // equation 3 
            Console.WriteLine("the root of F3 is {0}", Newrap(0.5, 20, F3, D3));
            Console.ReadLine();
        }
        // my newton rapson method
        //i didnt set tolerance as an input to the function as its constant for all three equations 
        public static double Newrap(double p0, double N, Func<double, double> func, Func<double, double> der)
        {
            double tol = 1e-10;
            // i set p = 0 here so that i could be able to return something in the case of a failed attempt
            double p = 0;
            int i = 1;

            while (i <= N)
            {
                if (der(p0) == 0)
                {
                    Console.WriteLine("the derivative of the function equals zero therefore the method failed");
                    break;
                }
                // equation
                p = p0 - func(p0) / der(p0);
                Console.WriteLine("the p after {0} iteration(s) is {1}", i, p);
                //if differnce between iterations is less than the tolerance we finish
                if (Math.Abs(p - p0) < tol)
                {
                    return p;
                }
                //otherwise we try again
                else
                {
                    i++;
                    p0 = p;
                }
            }
            Console.WriteLine("the method failed after {0} iterations", N);
            return p;
        }
        //these are just the functions and their derivatives
        // i did these manually
        public static double F1(double x)
        {
            return 3 * x * x * x - 3 * x * x - x + 2;
        }
        public static double D1(double x)
        {
            return 9 * x * x - 6 * x - 1;
        }
        public static double F2(double x)
        {
            return 1 / (x - 5) + Math.Log(x - 4) - 5;
        }
        public static double D2(double x)
        {
            return 1 / (x - 4) - 1 / ((x - 5) * (x - 5));
        }
        public static double F3(double x)
        {
            return 1 / (x * x * x) + Math.Exp(x) - 5;
        }
        public static double D3(double x)
        {
            return Math.Exp(x) - 3 / (x * x * x * x);
        }
    }
}

using System;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            //this is my main method where i apply the function to find the roots of ech equation
            // i did 10 iterations as that was sufficient to get and answer for the first two attempts and i did 50 iterations for thethird attempt
            double a = Secant(0, 15, 1e-4, 50, g);
            Console.WriteLine("when p0=0 and p1 =15, the secant answers are {0} and {1}", a, 30 - a);
            Console.WriteLine();
            double b = Secant(1, 14, 1e-4, 50, g);
            Console.WriteLine("when p0=1 and p1 =14, the secant answers are {0} and {1}", b, 30 - b);
            Console.WriteLine();
            double c = Position(0, 15, 1e-4, 50, g);
            Console.WriteLine("when p0=0 and p1 =15, the Method of False Position answers are {0} and {1}", c, 30 - c);
            Console.ReadLine();
        }
        public static double Secant(double p0, double p1, double tol, int N, Func<double, double> f)
        {
            //equation
            int i = 2;
            double q0 = f(p0);
            double q1 = f(p1);
            // i set p = 0 here so that i could be able to return something in the case of a failed attempt
            double p = 0;
            while (i <= N)
            {
                if(q1 == q0)
                {
                    Console.WriteLine("the denominator is 0 therefoe the method fails");
                    break;
                }
                if (p0<0)
                {
                    Console.WriteLine("the root is complex therefoe the method fails");
                    break;
                }
                //equation 
                p = p1 - q1 * (p1 - p0) / (q1 - q0);
                Console.WriteLine("the solutions after {0} iteration(s) are {1} and {2}", i, p, 30 - p);
                //if differnce between iterations is less than the tolerance we finish
                if (Math.Abs(p0 - p1) < tol)
                {
                    return p;
                }
                //otherwise we try again
                else
                {
                    i++;
                    p0 = p1;
                    q0 = q1;
                    p1 = p;
                    q1 = f(p);
                }
            }
            Console.WriteLine("the method failed after {0} iterations", i);
            return p;
        }
        public static double Position(double p0, double p1, double tol, int N, Func<double, double> f)
        {
            // from notes
            int i = 2;
            double q;
            double q0 = f(p0);
            double q1 = f(p1);
            // p=0 see explanation above
            double p = 0;
            while (i <= N)
            {
                if (q1 == q0)
                {
                    Console.WriteLine("the denominator is 0 therefoe the method fails");
                    break;
                }
                if (p0 < 0)
                {
                    Console.WriteLine("the root is complex therefoe the method fails");
                    break;
                }
                // from notes
                p = p1 - q1 * (p1 - p0) / (q1 - q0);
                Console.WriteLine("the solutions after {0} iteration(s) are {1} and {2}", i, p, 30 - p);
                if (Math.Abs(p0 - p1) < tol)
                {
                    return p;
                }
                // equation
                i++;
                q = f(p);
                if (q * q1 < 0)
                {
                    p0 = p1;
                    q0 = q1;
                }
                p1 = p;
                q1 = q;
            }
            Console.WriteLine("the method failed after {0} iterations", i);
            return p;
        }
        // thsi is the equation we are trying to solve
        public static double g(double x)
        {
            return (x + Math.Sqrt(x)) * (30 - x + Math.Sqrt(30 - x)) - 255.55;
        }
    }
}
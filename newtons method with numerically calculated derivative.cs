using System;

namespace ConsoleApp1
{
    class Polynomial
    {
        // creating variables
        private int[] coefficients;
        private int degree;
        private int maxiters;
        private double tolerance;
        // sets values of variables if polynomial is called with no input
        public Polynomial()
        {
            degree = 0;
            maxiters = 1000;
            tolerance = 0.000006;
            coefficients = new int[1];
        }
        //sets values of variables if polynomial is called with input degree
        // this() invokes default constructor 
        public Polynomial(int degree) : this()
        {
            // sets values of variables
            maxiters = 1000;
            tolerance = 0.000006;
            // if (0 <= degree) is true, we set coefficient to length to degree+1 and all elements to 0
            if (0 <= degree)
            {
                coefficients = new int[degree + 1];
                for (int i = 0; i < coefficients.Length; ++i)
                {
                    coefficients[i] = 0;
                }
            }
        }
        public int Degree
        {
            get
            {
                return degree;
            }
            // value is what you set Degree to in main 
            set
            {
                if (value >= 0)
                {
                    // creates new array of length value+1
                    int[] newarray = new int[value + 1];
                    // takes all elements in coefficients and puts them in this new array
                    for (int i = 0; i <= degree; i++)
                    {
                        newarray[i] = coefficients[i];
                    }
                    // set new array to coefficints to make rest of code easier
                    coefficients = newarray;
                    // the degree is now what you put Degree equal to in main
                    degree = value;
                }

            }
        }
        public bool setCoefficient(double val, int power)
        {
            // checks if input is valid
            if (power >= 0 & power <= degree)
            {
                // put val into an integer as elements in this array cant be anything but an integer
                // as coefficients[] is for integers and val is a double from assignment sheet
                // takes val and puts it as the coefficient of x to the power of "power"
                coefficients[power] = Convert.ToInt32(val);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void evaluate(double x, ref double p, ref double q)
        {
            // a_n is our last element in our array
            // so p and q are a_n in the formula
            p = coefficients[degree];
            q = coefficients[degree];
            // creating a loop which does horners algortihm as laid out on assignment sheet
            for (int i = degree - 1; i >= 0; i--)
            {
                p = x * p + coefficients[i];
                if (i == 0)
                {
                    break;
                }
                q = x * q + p;
            }
        }
        public double FindRoot(double initguess)
        {
            // creating variables
            int times = 0;
            double p = 0;
            double q = 0;
            double d = 0;
            double a = initguess;
            // does the first iteration of newtons method outside while loop as q>tolerance
            do
            {
                // let d be the n-1 term
                d = a;
                // newtons method formula
                evaluate(a, ref p, ref q);
                a = a - (p / q);
                // increases every time you do an iteration
                times++;
            }
            // the loop keeps going until we get an error or the difference between our nth term and our n-1 term was less than the tolerance
            while (Math.Abs(q) > 0.000006 & times < maxiters & Math.Abs(d - a) > tolerance);
            // prints the two possible "errors" if the constraints are true
            if (Math.Abs(q) <= tolerance)
            {
                Console.WriteLine("error messages:the derivative is unacceptably close to zero \n we therefore stop iterating newtons method");
            }
            if(times > maxiters)
            {
                Console.WriteLine("error messages: exceeded maxiters iterations\n we therefore stop iterating newtons method");
            }
            // if neither of these constraints are true that means the difference between our nth term and our n-1 term was less than the tolerance

            return a;
        }

    }
    class test
    {
        static void Main(string[] args)
        {
            // creates a new polynomial class
            Polynomial b = new Polynomial();
            // let degree equal to 3 as the given equation has a power to 3
            b.Degree = 3;
            // gets all the coefficients of the equation and puts them in the right position of our array
            b.setCoefficient(-2, 3);
            b.setCoefficient(-3, 2);
            b.setCoefficient(2, 1);
            b.setCoefficient(1, 0);
            // finds the 3 roots given a good first guess
            double r1 = b.FindRoot(-10);
            double r2 = b.FindRoot(0);
            double r3 = b.FindRoot(10);
            // converts to string with 4 places after decimal point and prints
            Console.WriteLine(r1.ToString("F4"));
            Console.WriteLine(r2.ToString("F4"));
            Console.WriteLine(r3.ToString("F4"));
        }
    }
}

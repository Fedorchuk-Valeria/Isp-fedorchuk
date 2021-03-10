using System;

namespace lab2_3
{
    class Program
    {
        static double InputCheckForSides(double a)
        {
            while (a == -1)
            {
                string temp = Console.ReadLine();
                try
                {
                    a = Convert.ToDouble(temp);
                }
                catch (Exception)
                {
                    Console.WriteLine("Input Error. Try again");
                }
                if (a < -1 || a == 0)
                {
                    Console.WriteLine("Input Error. Try again");
                    a = -1;
                }
            }
            return a;
        }

        static double InputCheckForCorners(double A)
        {
            while (A == -1)
            {
                string temp = Console.ReadLine();
                try
                {
                    A = Convert.ToDouble(temp);
                }
                catch (Exception)
                {
                    Console.WriteLine("Input Error. Try again");
                }
                if (A <-1 || A >= 180 || A == 0)
                {
                    Console.WriteLine("Input Error. Try again");
                    A = -1;
                }
            }
            return A;
        }

        static double CosineTheorem(double a, double b, double C)
        {
            double c, СRadian;
            СRadian = C * Math.PI / 180;
            c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(СRadian));
            c = Math.Round(c, 3, MidpointRounding.AwayFromZero);
            return c;
        }

        static double SineTheorem(double c, double C, double b)
        {
            double СRadian = C * Math.PI / 180;
            double sinB = Math.Sin(СRadian) * b / c;
            double B = Math.Asin(sinB);
            B = B * 180 / Math.PI;
            return B;
        }

        static double ThirdСorner(double B, double C)
        {
            return 180 - B - C;
        }

        static double Perimeter(double a, double b, double c)
        {
            return a + b + c;
        }

        static double Square(double a, double b, double C)
        {
            double СRadian = C * Math.PI / 180;
            double S = 0.5 * a * b * Math.Sin(СRadian);
            return S;
        }

        static double InscribedСircle(double S, double P)
        {
            double p = P / 2;
            return S / p;
        }

        static double CircumscribedСircle(double a, double b, double c, double S)
        {
            double R = a * b * c / (4 * S);
            return R;
        }

        static void Main(string[] args)
        {
            double a = -1, b = -1, СDegrees = -1;
            double c, BDegrees, ADegrees, P, S, r, R;
            Console.WriteLine("Enter the first side of the triangle:");
            a = InputCheckForSides(a);
            Console.WriteLine("Enter the second side of the triangle:");
            b = InputCheckForSides(b);
            Console.WriteLine("Enter the angle between these sides(degrees):");
            СDegrees = InputCheckForCorners(СDegrees);
            c = CosineTheorem(a, b, СDegrees);
            //Console.WriteLine(c);
            BDegrees = SineTheorem(c, СDegrees, b);
            ADegrees = ThirdСorner(СDegrees, BDegrees);
            P = Perimeter(a, b, c);
            S = Square(a, b, СDegrees);
            r = InscribedСircle(S, P);
            R = CircumscribedСircle(a, b, c, S);
            Console.WriteLine($"Sides of the triangle - {a}, {b}, {c}");
            Console.WriteLine($"Angles of the triangle - {ADegrees}, {BDegrees}, {СDegrees}");
            Console.WriteLine($"Perimeter of the triangle - {P}");
            Console.WriteLine($"Inscribed circle radius - {r}");
            Console.WriteLine($"Radius of the circumscribed circle - {R}");
            Console.WriteLine($"Area of the triangle - {S}");
        }
    }
}

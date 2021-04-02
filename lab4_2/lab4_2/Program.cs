using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace lab4_2
{
    class Program
    {
        [DllImport("triangle.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Perimeter(double firstSide, double secondSide, double thirdSide);

        [DllImport("triangle.dll", CallingConvention = CallingConvention.FastCall)]
        public static extern double CosineTheorem(double firstSide, double secondSide, double thirdAngle);

        [DllImport("triangle.dll", CallingConvention = CallingConvention.FastCall)]
        public static extern double SineTheorem(double thirdSide, double thirdAngle, double secondSide);

        [DllImport("triangle.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double ThirdСorner(double secondAngle, double thirdAngle);

        [DllImport("triangle.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Square(double firstSide, double secondSide, double thirdAngle);

        [DllImport("triangle.dll", CallingConvention = CallingConvention.ThisCall)]
        public static extern double InscribedСircle(double S, double P);

        [DllImport("triangle.dll", CallingConvention = CallingConvention.ThisCall)]
        public static extern double CircumscribedСircle(double firstSide, double secondSide, double thirdSide, double S);
        static void Main(string[] args)
        {
            double firstSide = 21.2;
            double secondSide = 11.2;
            double thirdAngle = 30;

            double thirdSide = CosineTheorem(firstSide, secondSide, thirdAngle);
            double secondAngle = SineTheorem(thirdSide, thirdAngle, secondSide);
            double firstAngle = ThirdСorner(thirdAngle, secondAngle);
            double P = Perimeter(firstSide, secondSide, thirdSide);
            double S = Square(firstSide, secondSide, thirdAngle);
            double r = InscribedСircle(S, P);
            double R = CircumscribedСircle(firstSide, secondSide, thirdSide, S);

            Console.WriteLine($"Sides of the triangle - {firstSide}, {secondSide}, {thirdSide}");
            Console.WriteLine($"Angles of the triangle - {firstAngle}, {secondAngle}, {thirdAngle}");
            Console.WriteLine($"Perimeter of the triangle - {P}");
            Console.WriteLine($"Inscribed circle radius - {r}");
            Console.WriteLine($"Radius of the circumscribed circle - {R}");
            Console.WriteLine($"Area of the triangle - {S}");
        }
    }
}

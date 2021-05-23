using System;

namespace lab7_isp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction num1 = new Fraction();
            Fraction num2 = new Fraction(6, 20);
            Fraction num3 = new Fraction(20, 7);

            Console.WriteLine();
            Console.WriteLine(num1.WithSlash());
            Console.WriteLine(num2.WithSlash());
            Console.WriteLine(num3.WithSlash());
            Console.WriteLine();

            num2 = num1 + num2;
            Console.WriteLine(num2.WithSlash());
            Console.WriteLine(num2.ToFloat());

            num1 = num1 - num2;
            Console.WriteLine(num1.WithSlash());

            num1 = num1 * num2;
            Console.WriteLine(num1.WithSlash());
            Console.WriteLine(num1.ToFloat());

            num1 = num1 / num2;
            Console.WriteLine(num1.WithSlash());

            if (num1 == num2)
            {
                Console.WriteLine("==");
            }

            if (num1 != num2)
            {
                Console.WriteLine("!=");
            }

            if(num2 > num3)
            {
                Console.WriteLine($"{num2.WithSlash()} > {num3.WithSlash()}");
            }

            if (num2 < num3)
            {
                Console.WriteLine($"{num2.WithSlash()} < {num3.WithSlash()}");
            }

            int a = (int)num3;
            Console.WriteLine(a);

            double d = num3;
            Console.WriteLine(d);
        }
    }
}

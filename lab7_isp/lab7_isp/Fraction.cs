using System;

namespace lab7_isp
{
    class Fraction : IComparable<Fraction>
    {
        private int numerator;
        private int denominator;

        static int GCF(int num, int den)
        {
            int a, b;

            if (Math.Abs(num) > den)
            {
                a = Math.Abs(num);
                b = den;
            }
            else
            {
                b = Math.Abs(num);
                a = den;
            }

            int temp;

            while (a % b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            return b;
        }

        public void Reduction()
        {
            int del = GCF(numerator, denominator);
            numerator /= del;
            denominator /= del;
        }

        public Fraction()
        {
            int check = -1;
            int positionOfSign = 0;
            char sign = '0';
            string temp = "";

            Console.WriteLine("Enter number:");

            while (check > 1 || check == -1)
            {
                if (check != -1)
                {
                    Console.WriteLine("Input error. Try again.");
                }

                temp = Console.ReadLine();
                check = 0;

                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 0 && temp[0] == '-')
                    {
                        i++;
                    }
                    if (check > 1 || (temp[i] < '0' || temp[i] > '9'))
                    {
                        if (temp[i] == '.' || temp[i] == '/' || temp[i] == ',' || i == 0 || i == temp.Length - 1)
                        {
                            check++;

                            if (check == 1)
                            {
                                positionOfSign = i;
                                sign = temp[i];
                            }
                        }
                        else
                        {
                            check = 2;
                            break;
                        }
                    }
                }
            }

            string num;
            string den;

            if (positionOfSign == 0)
            {
                num = temp;
                den = "1";
            }
            else
            {
                num = temp.Substring(0, positionOfSign);
                den = temp.Substring(positionOfSign + 1, temp.Length - 1 - positionOfSign);
            }

            if (num[0] == '-')
            {
                num = num.Trim(new char[] { '-' });
                numerator = 0 - Convert.ToInt32(num);
            }
            else
            {
                numerator = Convert.ToInt32(num);
            }

            denominator = Convert.ToInt32(den);

            if (sign == '.' || sign == ',')
            {
                numerator = numerator * 10 * den.Length + denominator;
                denominator = 10 * den.Length;
            }

            Reduction();
        }

        public Fraction(int num, int den)
        {
            numerator = num;
            denominator = den;

            Reduction();
        }

        public int Numerator
        {
            get
            {
                return numerator;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
        }

        public int CompareTo(Fraction fraction)
        {
            int numerator1 = numerator * fraction.Denominator;
            int numerator2 = fraction.Numerator * denominator;

            if (numerator1 == numerator2)
            {
                return 0;
            }
            else if (numerator1 < numerator2)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        
        public string WithSlash()
        {
            string temp = Convert.ToString(numerator) + '/' + Convert.ToString(denominator);
            return temp;
        }

        public string ToFloat()
        {
            float f = (float)numerator / denominator;
            return Convert.ToString(Math.Round(f, 2, MidpointRounding.AwayFromZero));
        }

        public static Fraction operator +(Fraction num1, Fraction num2)
        {
            int den = num1.Denominator * num2.Denominator;
            int num = num1.Numerator * num2.Denominator + num2.Numerator * num1.Denominator;

            Fraction newNum = new Fraction(num, den);

            return newNum;
        }

        public static Fraction operator -(Fraction num1, Fraction num2)
        {
            int den = num1.Denominator * num2.Denominator;
            int num = num1.Numerator * num2.Denominator - num2.Numerator * num1.Denominator;

            Fraction newNum = new Fraction(num, den);

            return newNum;
        }

        public static Fraction operator *(Fraction num1, Fraction num2)
        {
            int den = num1.Denominator * num2.Denominator;
            int num = num1.Numerator * num2.Numerator;

            Fraction newNum = new Fraction(num, den);

            return newNum;
        }

        public static Fraction operator /(Fraction num1, Fraction num2)
        {
            int den = num1.Denominator * num2.Numerator;
            int num = num1.Numerator * num2.Denominator;

            Fraction newNum = new Fraction(num, den);

            return newNum;
        }

        public static bool operator ==(Fraction num1, Fraction num2)
        {
            int numerator1 = num1.Numerator * num2.Denominator;
            int numerator2 = num2.Numerator * num1.Denominator;

            return numerator1 == numerator2;
        }

        public static bool operator !=(Fraction num1, Fraction num2)
        {
            return !(num1 == num2);
        }

        public static bool operator >(Fraction num1, Fraction num2)
        {
            int numerator1 = num1.Numerator * num2.Denominator;
            int numerator2 = num2.Numerator * num1.Denominator;

            return numerator1 > numerator2;
        }

        public static bool operator <(Fraction num1, Fraction num2)
        {
            return !(num1 > num2);
        }

        public static explicit operator int(Fraction num)
        {
            double f = Convert.ToDouble(num.ToFloat());
            int n = (int)Math.Round(f);

            return n;
        }

        public static implicit operator double(Fraction num)
        {
            double f = Convert.ToDouble(num.ToFloat());

            return Math.Round(f, 2, MidpointRounding.AwayFromZero);
        }
    }
}
   

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            int lenght, k, s, temp, temp2, wordLenght;
            double number = 0;
            Console.WriteLine("Enter line:");
            str = Console.ReadLine();
            while (str == "" || str == " ")
            {
                Console.WriteLine("Try again");
                str = Console.ReadLine();
            }
            lenght = str.Length;
            for (int i = 0; i < lenght; i++)
            {
             
                k = i;
                temp2 = i;
                while ( i < lenght && str[i] != ' ') 
                {
                    k++;
                    i++;
                }
                
                i = temp2;
                if ((str[i] >= '0' && str[i] <= '9') || (str[i] >= 'A' && str[i] <= 'F'))
                {
                    wordLenght = k - i;
                    for (temp = i+1; temp < k;)
                    {
                        if ((str[temp] >= '0' && str[temp] <= '9') || (str[temp] >= 'A' && str[temp] <= 'F'))
                        {
                            temp++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (temp == k)
                    {
                        for (k = k - 1; k >= i; k--)
                        {
                            switch (str[k])
                            {
                                case 'A': s = 10; break;
                                case 'B': s = 11; break;
                                case 'C': s = 12; break;
                                case 'D': s = 13; break;
                                case 'E': s = 14; break;
                                case 'F': s = 15; break;
                                default: s = str[k] - '0'; break;
                            }
                            number += s * Math.Pow(16, temp - k - 1);
                        }
                        for (; i <= temp-1; i++)
                        {
                            Console.Write(str[i]);
                        }
                        Console.WriteLine($"   {number}\n");
                    }
                    
                    i = temp2 + wordLenght;
                    number = 0;    
                   
                } else 
                {
                    i = k;
                    
                }

            }

        }
    }
}


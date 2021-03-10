using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtTime, lenghtData1, lenghtData2;
            string time = DateTime.Now.ToString("HH:mm:ss");
            string data1 = DateTime.Now.ToString("dd MMMM yyyy");
            string data2 = DateTime.Now.ToString("dd:MM:yyyy");
            Console.WriteLine(time + "  " + data1 + "  " + data2);
            lenghtTime = time.Length;
            lenghtData1 = data1.Length;
            lenghtData2 = data2.Length;
            int[] arr = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for(int i = 0; i < 10; i++)
            {
               for(int j = 0; j < lenghtTime; j++)
               {
                    if(time[j] == i  + '0')
                    {
                        arr[i]++;
                    }
               }
            }
            Console.WriteLine("In the time:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} - {arr[i]} pieces");
                arr[i] = 0;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < lenghtData1; j++)
                {
                    if (data1[j] == i + '0')
                    {
                        arr[i]++;
                    }
                }
            }
            Console.WriteLine("In the date of the first format:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} - {arr[i]} pieces");
                arr[i] = 0;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < lenghtData2; j++)
                {
                    if (data2[j] == i + '0')
                    {
                        arr[i]++;
                    }
                }
            }
            Console.WriteLine("In the date of the second format:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} - {arr[i]} pieces");
                arr[i] = 0;
            }
        }
    }
}


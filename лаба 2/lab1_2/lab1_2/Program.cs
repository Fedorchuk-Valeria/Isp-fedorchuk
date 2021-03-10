using System;

namespace lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght1, lenght2;
            string dateTime1 = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
            string dateTime2 = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            Console.WriteLine($"{dateTime1}  {dateTime2}");
            lenght1 = dateTime1.Length;
            lenght2 = dateTime2.Length;
            int[] arr = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for(int i = 0; i < 10; i++)
            {
               for(int j = 0; j < lenght1; j++)
               {
                    if(dateTime1[j] == i  + '0')
                    {
                        arr[i]++;
                    }
               }
            }
            Console.WriteLine("In the datetime of the first format:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} - {arr[i]} pieces");
                arr[i] = 0;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < lenght2; j++)
                {
                    if (dateTime2[j] == i + '0')
                    {
                        arr[i]++;
                    }
                }
            }
            Console.WriteLine("In the datetime of the second format:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} - {arr[i]} pieces");
                arr[i] = 0;
            }
        }
    }
}

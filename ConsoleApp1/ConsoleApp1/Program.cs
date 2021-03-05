using System;

namespace ConsoleApp1
{
    class Program
    {
        static void OpenAnEmptyBox(int number)        
        {
            int emptyBox = number;
            Random rand = new Random();
            while (emptyBox == number)
            {
                emptyBox = rand.Next(4);
            }
            emptyBox++;
            Console.WriteLine(emptyBox + " - empty box, there is nothing in it");
        }
        static void Hint50_50(int number)
        {
            int[] withoutMoney = new int[2] { number, number };
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                while (withoutMoney[i] == withoutMoney[0] && withoutMoney[i] == withoutMoney[1])
                {
                    withoutMoney[i] = rand.Next(5);
                }
                withoutMoney[i]++;
            }
            for (int i = 0; i < 2; i++)
            {
                Console.Write(withoutMoney[i] + " ");
            }
            Console.WriteLine("- empty boxes");
        }
        static void CallAFriend(int number)
        {
            Random rand = new Random();
            int friendHelp = rand.Next(number + 1, number + 2);
            Console.WriteLine("Your friend think, that money in " + friendHelp + " box!");
        }
        static void Main(string[] args)
        {
            int balance = 50;
            int[] boxes = new int[5] { 0, 0, 0, 0, 0 };
            int numberOfMoneyBox;
            int dollars = 10;
            int choice = 0;
            string temp1, temp2, temp3;

            int notMoney = 0;
            int fiftyFifty = 0;
            int friend = 0;
            Random rand = new Random();

            Console.WriteLine("Do you know how to play? (Y/N)");
            temp3 = Console.ReadLine();
            while (temp3 != "Y" && temp3 != "N")
            {
                if (temp3 != "+" || temp3 != "-")
                {
                    Console.WriteLine("Input Error. Try again");
                    temp3 = Console.ReadLine();
                }
            }

            if (temp3 == "N")
            {
                Console.WriteLine("You should choose one of five boxes that contain money. If you guess correctly," + "\nyou get a certain amount and the rate rises.If you don't guess, your money is taken away." + 
                "\nYou have the right to use hints. Winning - your balance exceeds 100, loss - 0.\n\n");

            }

            while (balance != 0 && balance < 100)
            {
                numberOfMoneyBox = rand.Next(5);
                boxes[numberOfMoneyBox] = dollars;
                Console.WriteLine("                                                                                  Rate: " + dollars + "        Your balance: " + balance);
                Console.WriteLine("===================     " + "===================     " + "===================     " + "===================     " + "===================     ");
                Console.WriteLine("        1               " + "          2             " + "         3              " + "         4              " + "         5              ");
                Console.WriteLine("===================     " + "===================     " + "===================     " + "===================     " + "===================     ");
                if (notMoney == 0 || fiftyFifty == 0 || friend == 0)
                {
                    Console.WriteLine("Need help? + or -?");
                    temp2 = Console.ReadLine();
                    while (temp2 != "+" && temp2 != "-")
                    {
                        if (temp2 != "+" || temp2 != "-")
                        {
                            Console.WriteLine("Input Error. Try again");
                            temp2 = Console.ReadLine();
                        }
                    }

                    if (temp2 == "+")
                    {
                        if (notMoney == 0)
                        {
                            Console.WriteLine("1. Open an empty box");
                        }
                        if (fiftyFifty == 0)
                        {
                            Console.WriteLine("2. 50/50");
                        }
                        if (friend == 0)
                        {
                            Console.WriteLine("3. Friend's help");
                        }

                        string help;
                        help = Console.ReadLine();
                        while (help != "1" && help != "2" && help != "3")
                        {
                            Console.WriteLine("Input Error. Try again");
                            help = Console.ReadLine();
                        }
                        if (help == "1" && notMoney != 0)
                        {
                            while (help != "2" && help != "3")
                            {
                                Console.WriteLine("You have already used this hint. Try again");
                                help = Console.ReadLine();
                            }
                            
                        }
                        if (help == "2" && fiftyFifty != 0)
                        {
                            while (help != "1" && help != "3")
                            {
                                Console.WriteLine("You have already used this hint. Try again");
                                help = Console.ReadLine();
                            }
                        }
                        if (help == "3" && friend != 0)
                        {
                            while (help != "1" && help != "2")
                            {
                                Console.WriteLine("You have already used this hint. Try again");
                                help = Console.ReadLine();
                            }
                        }

                        if (help == "1" && notMoney == 0)
                        {
                            OpenAnEmptyBox(numberOfMoneyBox);
                            notMoney++;
                        }
                        if (help == "2" && fiftyFifty == 0)
                        {
                            Hint50_50(numberOfMoneyBox);
                            fiftyFifty++;
                        }
                        if (help == "3" && friend == 0)
                        {
                            CallAFriend(numberOfMoneyBox);
                            friend++;
                        }
                    }
                }
  
                Console.WriteLine("Choose a box:");

                while (choice == 0) 
                {
                    temp1 = Console.ReadLine();
                    try
                    {
                        choice = Convert.ToInt32(temp1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Input Error. Try again");
                    }
                    if (choice < 0 || choice > 5)
                    {
                        Console.WriteLine("Input Error. Try again");
                        choice = 0;
                    }
                }
                if (choice == numberOfMoneyBox + 1)
                {
                    Console.WriteLine("Excellent! You guessed!");
                    balance += boxes[numberOfMoneyBox];
                    if (balance > 40)
                    {
                        dollars += 10;
                    }
                } else
                {
                    Console.WriteLine("Very sorry.You're not right.");
                    balance -= boxes[numberOfMoneyBox];
                    if (dollars != 10)
                    {
                        dollars -= 10;
                    } 
                }

                choice = 0;
            }

            if (balance != 0)
            {
                Console.WriteLine("\nYou won!");
            } else
            {
                Console.WriteLine("\nYou lose.");
            }
        }
    }
}

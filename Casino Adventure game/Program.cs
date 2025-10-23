using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Casino_Adventure_Game
{
    class Program
    {
        class Card
        {
            string suit;
            int rank;

            static string[,] aiHand1 = new string[3, 2];
            static Random rnd = new Random();
            static int HEIGHT;
            static int WIDTH;
            static string NAME = " ";
            static string temp = " ";
            static bool running = true;
            static int balance = 100;
            static void border() //Prints pretty border
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(".--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--.\n/ .. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\.. \\\n\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\\n \\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/\n / /\\/ /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /\\/\n/ /\\ \\/`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'\\ \\/\\ \\\n\\ \\/\\ \\                                                                                                                                                        /\\ \\/ /\n \\/ /\\ \\                                                                                                                                                      / /\\/ /\n / /\\/ /                                                                                                                                                      \\ \\/ /\\\n/ /\\ \\/                                                                                                                                                        \\ \\/\\ \\\n\\ \\/\\ \\                                                                                                                                                        /\\ \\/ /\n \\/ /\\ \\                                                                                                                                                      / /\\/ /\n / /\\/ /                                                                                                                                                      \\ \\/ /\\\n/ /\\ \\/                                                                                                                                                        \\ \\/\\ \\\n\\ \\/\\ \\                                                                                                                                                        /\\ \\/ /\n \\/ /\\ \\                                                                                                                                                      / /\\/ /\n / /\\/ /                                                                                                                                                      \\ \\/ /\\\n/ /\\ \\/                                                                                                                                                        \\ \\/\\ \\\n\\ \\/\\ \\                                                                                                                                                        /\\ \\/ /\n \\/ /\\ \\                                                                                                                                                      / /\\/ /\n / /\\/ /                                                                                                                                                      \\ \\/ /\\\n/ /\\ \\/                                                                                                                                                        \\ \\/\\ \\\n\\ \\/\\ \\                                                                                                                                                        /\\ \\/ /\n \\/ /\\ \\                                                                                                                                                      / /\\/ /\n / /\\/ /                                                                                                                                                      \\ \\/ /\\\n/ /\\ \\/                                                                                                                                                        \\ \\/\\ \\\n\\ \\/\\ \\                                                                                                                                                        /\\ \\/ /\n \\/ /\\ \\                                                                                                                                                      / /\\/ /\n / /\\/ /                                                                                                                                                      \\ \\/ /\\\n/ /\\ \\/                                                                                                                                                        \\ \\/\\ \\\n\\ \\/\\ \\                                                                                                                                                       /\\ \\/ /\n/ /\\/ /                                                                                                                                                       \\ \\/ /\\\n\\/ /\\ \\                                                                                                                                                       /\\ \\/ /\n/ /\\ \\/`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--/\\ \\/ /\n\\/ /\\/ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ /\\/ /\n/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\/ /\\\n\\/ /\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\/\\ \\ \\/\\ \\/\\ \\\n \\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ `'\\ / `' /\n  `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`-");
            }
            static void displayCard(string card)
            {
                type("The ", 50);
                switch (card.Substring(1, 2))
                {
                    case " 2":
                        type("2 of", 50);
                        break;
                    case " 3":
                        type("3 of", 50);
                        break;
                    case " 4":
                        type("4 of", 50);
                        break;
                    case " 5":
                        type("5 of", 50);
                        break;
                    case " 6":
                        type("6 of", 50);
                        break;
                    case " 7":
                        type("7 of", 50);
                        break;
                    case " 8":
                        type("8 of", 50);
                        break;
                    case " 9":
                        type("9 of", 50);
                        break;
                    case "10":
                        type("10 of", 50);
                        break;
                    case " J":
                        type("Jack of", 50);
                        break;
                    case " Q":
                        type("Queen of", 50);
                        break;
                    case " K":
                        type("King of", 50);
                        break;
                    case " A":
                        type("Ace of", 50);
                        break;
                }
                switch (card[0])
                {
                    case 'S':
                        type(" Spades", 50);
                        break;
                    case 'C':
                        type(" Clubs", 50);
                        break;
                    case 'D':
                        type(" Diamonds", 50);
                        break;
                    case 'H':
                        type(" Hearts", 50);
                        break;
                }
            }
            static void clear() //Custom Clear as Console.Clear is slow and could lead to excessive flashing
            {
                for (int i = 0; i < HEIGHT + 1; i++)
                {
                    for (int j = 0; j < WIDTH + 1; j++)
                    {
                        try
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write(" ");
                            Console.SetCursorPosition(0, 0);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            static void clear(int x1, int y1, int x2, int y2) //Clears a rectangle between two coordinates
            {
                for (int i = x1; i < x2 + 1; i++)
                {
                    for (int j = y1; j < y2 + 1; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
            }
            static void clearBorder()
            {
                clear(8, 6, 157, 32);
            }
            static void type(string phrase, int delay) //Type strings character by character
            {
                for (int i = 0; i < phrase.Length; i++)
                {
                    Console.Write(phrase[i]);
                    System.Threading.Thread.Sleep(delay);
                }
            }
            static void startUp() //Ensure user is in fullscreen and window size is obtained
            {
                Random rnd = new Random();
                Console.WriteLine(@"Please fullscreen the console
Press any key to continue:");
                Console.ReadKey();
                HEIGHT = Console.WindowHeight;
                WIDTH = Console.WindowWidth;
                clear();
            }
            static void logIn()
            {
                type("running Casino.exe", 50);
                Console.SetCursorPosition(0, 1);
                type(".....", 500);
                clear();
                type("program running", 50);
                clear();

                border();
                Console.SetCursorPosition(10, 7);
                type("Welcome to the virtual casino!", 50);

                bool valid = false;
                int age;
                while (!valid)
                {
                    Console.SetCursorPosition(10, 9);
                    type("Please enter your age to continue:", 50);
                    try
                    {
                        Console.SetCursorPosition(10, 10);
                        age = int.Parse(Console.ReadLine());
                        if (age < 18)
                        {
                            Console.SetCursorPosition(10, 12);
                            type("Oh no! You need to be 18+ to continue", 50);


                            clear(10, 12, 100, 13);
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 12);
                            type("Great!", 50);
                            valid = true;
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(10, 9);
                        Console.Write("                                  ");
                        Console.SetCursorPosition(10, 9);
                        type("Oops that's not a number", 50);
                        System.Threading.Thread.Sleep(300);
                    }
                    clear(10, 9, 100, 12);
                }

                Console.SetCursorPosition(10, 9);
                type("Now, enter your name:", 50);
                Console.SetCursorPosition(10, 10);
                NAME = Console.ReadLine();
                Console.SetCursorPosition(10, 12);
                temp = "Hello, " + NAME + "!";
                type(temp, 50);
                Console.SetCursorPosition(10, 14);
                type($"You have £{balance}, you only need to earn £1000 to leave!", 50);

                System.Threading.Thread.Sleep(2000);
                clearBorder();
            }
            static string menu()
            {
                Console.SetCursorPosition(10, 7);
                type($"You currently have £{balance}", 50);
                Console.SetCursorPosition(10, 9);
                type($"What would you like to do, {NAME}?", 50);
                Console.SetCursorPosition(10, 11);
                Console.Write("[1] - Slot machine");
                Console.SetCursorPosition(10, 12);
                Console.Write("[2] - Blackjack");
                Console.SetCursorPosition(10, 13);
                Console.Write("[3] - Poker");
                Console.SetCursorPosition(10, 14);
                Console.Write("[4] - Roulette");
                Console.SetCursorPosition(10, 15);
                Console.Write("[5] - Double or nothing coin flip");
                Console.SetCursorPosition(10, 16);
                Console.Write("[E] - Exit");


                Console.SetCursorPosition(10, 18);
                string choice = Console.ReadLine();
                Console.Write(choice);
                switch (choice)
                {
                    case "1":
                        return choice;
                    case "2":
                        return choice;
                    case "3":
                        return choice;
                    case "4":
                        return choice;
                    case "5":
                        return choice;
                    case "E":
                        return choice;
                    default:
                        Console.SetCursorPosition(10, 20);
                        type("That wasn't an option", 50);
                        type("...", 500);
                        return "fail";
                }
            }
            static void slotMachine()
            {
                border();
                clearBorder();
                string[] outcome = { "D:", "):", ":O", ":)", ":D", "££" };
                Console.SetCursorPosition(18, 7);
                Console.Write("D: D: D: = £10   ): ): ): = £15   :O :O :O = £20   :) :) :) = £50   :D :D :D = £100   ££ = £50   ££ ££ = £300   ££ ££ ££ = £1000");
                Console.SetCursorPosition(60, 10);
                Console.Write("_______            _______            _______");
                Console.SetCursorPosition(60, 11);
                Console.Write("|      |           |      |           |      |");
                Console.SetCursorPosition(60, 12);
                Console.Write("|      |           |      |           |      |");
                Console.SetCursorPosition(60, 13);
                Console.Write("|______|           |______|           |______|");

                Console.SetCursorPosition(63, 12);
                Console.Write("££");
                Console.SetCursorPosition(82, 12);
                Console.Write("££");
                Console.SetCursorPosition(101, 12);
                Console.Write("££");

                double chance = rnd.NextDouble();
                string slot1 = " ", slot2 = " ", slot3 = " ";
                int amount = 0;
                bool valid = false;
                while (!valid)
                {
                    Console.SetCursorPosition(10, 15);
                    type($"You currently have £{balance}, it costs £1 per play, how much money do you want to put in?", 50);
                    Console.SetCursorPosition(10, 16);
                    Console.Write("£");

                    try
                    {
                        amount = int.Parse(Console.ReadLine());
                        if (amount <= balance && amount >= 0)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 18);
                            type("Uh oh! You're too poor!", 50);
                            System.Threading.Thread.Sleep(1000);

                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Uh oh! That's not a number!", 50);
                        System.Threading.Thread.Sleep(1000);
                    }
                    clear(10, 15, 100, 18);
                }
                balance -= amount;
                if (amount > 0)
                {
                    for (int i = amount; i > 0; i--)
                    {
                        for (int j = 0; j < rnd.Next(50, 100); j++)
                        {
                            Console.SetCursorPosition(63, 12);
                            chance = rnd.NextDouble();
                            if (chance <= 0.3)
                            {
                                slot1 = outcome[0];
                            }
                            else if (chance <= 0.6)
                            {
                                slot1 = outcome[1];
                            }
                            else if (chance <= 0.8)
                            {
                                slot1 = outcome[2];
                            }
                            else if (chance <= 0.9)
                            {
                                slot1 = outcome[3];
                            }
                            else if (chance <= 0.99)
                            {
                                slot1 = outcome[4];
                            }
                            else
                            {
                                slot1 = outcome[5];
                            }
                            Console.Write(slot1);

                            Console.SetCursorPosition(82, 12);
                            chance = rnd.NextDouble();
                            if (chance <= 0.3)
                            {
                                slot2 = outcome[0];
                            }
                            else if (chance <= 0.6)
                            {
                                slot2 = outcome[1];
                            }
                            else if (chance <= 0.8)
                            {
                                slot2 = outcome[2];
                            }
                            else if (chance <= 0.9)
                            {
                                slot2 = outcome[3];
                            }
                            else if (chance <= 0.99)
                            {
                                slot2 = outcome[4];
                            }
                            else
                            {
                                slot2 = outcome[5];
                            }
                            Console.Write(slot2);

                            Console.SetCursorPosition(101, 12);
                            chance = rnd.NextDouble();
                            if (chance <= 0.35)
                            {
                                slot3 = outcome[0];
                            }
                            else if (chance <= 0.65)
                            {
                                slot3 = outcome[1];
                            }
                            else if (chance <= 0.85)
                            {
                                slot3 = outcome[2];
                            }
                            else if (chance <= 0.95)
                            {
                                slot3 = outcome[3];
                            }
                            else if (chance <= 0.995)
                            {
                                slot3 = outcome[4];
                            }
                            else
                            {
                                slot3 = outcome[5];
                            }
                            Console.Write(slot3);


                            System.Threading.Thread.Sleep(10);
                        }
                        Console.SetCursorPosition(10, 15);
                        if (slot1 == "D:" && slot2 == "D:" && slot3 == "D:")
                        {
                            type("Congratulations you won £10!", 50);
                            balance += 10;
                        }
                        else if (slot1 == "):" && slot2 == "):" && slot3 == "):")
                        {
                            type("Congratulations you won £15!", 50);
                            balance += 15;
                        }
                        else if (slot1 == ":O" && slot2 == ":O" && slot3 == ":O")
                        {
                            type("Congratulations you won £20!", 50);
                            balance += 20;
                        }
                        else if (slot1 == ":)" && slot2 == ":)" && slot3 == ":)")
                        {
                            type("Congratulations you won £50!", 50);
                            balance += 50;
                        }
                        else if (slot1 == ":D" && slot2 == ":D" && slot3 == ":D")
                        {
                            type("Congratulations you won £100!", 50);
                            balance += 100;
                        }
                        else if (slot1 == "££" || slot2 == "££" || slot3 == "££")
                        {
                            type("Congratulations you won £50!", 50);
                            balance += 50;
                        }
                        else if (slot1 == "££" && slot2 == "££" && slot3 == "££")
                        {
                            type("Congratulations you won £1000!", 50);
                            balance += 1000;
                        }
                        else if (slot1 == "££" && slot2 == "££" || slot1 == "££" && slot3 == "££" || slot2 == "££" && slot3 == "££")
                        {
                            type("Congratulations you won £300!", 50);
                            balance += 300;
                        }
                        else
                        {
                            Console.Write("You didn't win anything...");
                        }
                        Console.SetCursorPosition(10, 16);
                        Console.Write("Press any key to continue:");
                        Console.ReadKey();
                        clear(10, 15, 100, 16);
                    }
                }


            }
            static void blackjack()
            {
                border();
                clearBorder();

                string[] deck = { "S 2", "C 2", "D 2", "H 2", "S 3", "C 3", "D 3", "H 3", "S 4", "C 4", "D 4", "H 4", "S 5", "C 5", "D 5", "H 5", "S 6", "C 6", "D 6", "H 6", "S 7", "C 7", "D 7", "H 7", "S 8", "C 8", "D 8", "H 8", "S 9", "C 9", "D 9", "H 9", "S10", "C10", "D10", "H10", "S J", "C J", "D J", "H J", "S Q", "C Q", "D Q", "H Q", "S K", "C K", "D K", "H K", "S A", "C A", "D A", "H A" };
                int[] values = { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 1, 1 };
                string[] hand = new string[2];
                int handValue = 0;
                int bet = 0;
                Console.SetCursorPosition(10, 7);
                type("Welcome to the blackjack table!", 50);
                bool valid = false;
                while (!valid)
                {
                    try
                    {
                        Console.SetCursorPosition(10, 9);
                        type($"You currently have £{balance}", 50);
                        Console.SetCursorPosition(10, 11);
                        type("How much would you like to bet?", 50);
                        Console.SetCursorPosition(10, 13);
                        Console.Write("£");

                        bet = int.Parse(Console.ReadLine());
                        if (bet <= balance && bet > 0)
                        {
                            valid = true;
                        }
                        else if (bet < 0)
                        {
                            Console.SetCursorPosition(10, 15);
                            type("Oh no that's a negative number!", 50);
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 15);
                            type("Oh no, you are too poor to bet that much!", 50);
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(10, 15);
                        type("Oh no! You forgot what a number was!", 50);
                    }
                    System.Threading.Thread.Sleep(1000);
                    clear(10, 9, 100, 20);
                }
                clearBorder();
                balance -= bet;


                int chosen;
                chosen = rnd.Next(0, 52);
                hand[0] = deck[chosen];
                deck[chosen] = "XXX";
                handValue += values[chosen];

                valid = false;
                while (!valid)
                {
                    chosen = rnd.Next(0, 52);
                    if (deck[chosen] != "XXX")
                    {
                        hand[1] = deck[chosen];
                        deck[chosen] = "XXX";
                        handValue += values[chosen];
                        valid = true;
                    }
                }
                Console.SetCursorPosition(10, 7);
                type("You have:", 50);
                Console.SetCursorPosition(10, 8);
                displayCard(hand[0]);
                Console.SetCursorPosition(10, 9);
                displayCard(hand[1]);



                string choice = " ";
                int count = 2;
                bool playing = true, bust = false, win = true;
                while (playing && count < 6)
                {
                    Console.SetCursorPosition(10, 14);
                    type("What would you like to do?", 50);
                    Console.SetCursorPosition(10, 16);
                    Console.Write("[1] Hit");
                    Console.SetCursorPosition(10, 17);
                    Console.Write("[2] Stick");


                    valid = false;
                    while (!valid)
                    {
                        Console.SetCursorPosition(10, 19);
                        choice = Console.ReadLine();
                        if (choice == "1" || choice == "2")
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 21);
                            type("Oh no! That wasn't an option! Try reading next time!", 50);
                        }
                        System.Threading.Thread.Sleep(500);
                        clear(10, 19, 100, 21);
                    }
                    clear(10, 14, 100, 21);
                    if (choice == "1")
                    {
                        valid = false;
                        while (!valid)
                        {
                            chosen = rnd.Next(0, 52);
                            if (deck[chosen] != "XXX")
                            {
                                temp = deck[chosen];
                                deck[chosen] = "XXX";
                                handValue += values[chosen];
                                valid = true;
                            }
                        }
                        Console.SetCursorPosition(10, 8 + count);
                        displayCard(temp);
                        if (handValue > 21)
                        {
                            playing = false;
                            bust = true;
                            Console.SetCursorPosition(10, 14);
                            type("Oh no! You've gone bust!", 50);
                        }
                    }
                    else
                    {
                        playing = false;
                    }
                    count++;
                    clear(10, 14, 100, 21);
                    System.Threading.Thread.Sleep(1000);
                }
                if (bust)
                {
                    clearBorder();
                    win = false;
                }
                else
                {
                    int dealer = 0;
                    int dCount = 0;
                    while (dealer < 16 && dCount != 5)
                    {
                        dealer += values[rnd.Next(0, 52)];
                        dCount++;
                    }
                    Console.SetCursorPosition(10, 14);
                    if (dCount == 5)
                    {
                        type("The dealer got a five card trick, you loose...", 50);
                        win = false;
                    }
                    else if (count == 6)
                    {
                        type("You got a five card trick, you win!", 50);
                        win = true;
                    }
                    else if (dealer > 21)
                    {
                        type("The dealer went bust, you win!", 50);
                        win = true;
                    }
                    else if (dealer >= handValue)
                    {
                        type($"The dealer stuck on {dealer}, you loose...", 50);
                        win = false;
                    }
                    else if (dealer < handValue)
                    {
                        type($"The dealer stuck on {dealer}, you win!", 50);
                        win = true;
                    }
                }
                if (win)
                {
                    balance += bet * 2;
                }



            }

            static int pokerMenu(int pool, string[,] aiHand1)
            {
                Console.SetCursorPosition(10, 18);
                type($"You have £{balance}", 50);
                Console.SetCursorPosition(10, 19);
                type($"The pot is £{pool}", 50);
                Console.SetCursorPosition(10, 21);
                Console.Write("Do you want to:");
                Console.SetCursorPosition(10, 23);
                Console.Write("[1] - Check");
                Console.SetCursorPosition(10, 24);
                Console.Write("[2] - Raise");
                Console.SetCursorPosition(10, 25);
                Console.Write("[3] - Fold");
                bool valid = false;
                int choice = 0;
                while (!valid)
                {
                    try
                    {
                        Console.SetCursorPosition(10, 27);
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1 || choice == 2 || choice == 3)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 29);
                            type("That's not an option...", 50);
                        }
                    }
                    catch 
                    {
                        Console.SetCursorPosition(10, 29);
                        type("That's not an option...", 50);
                    }
                    System.Threading.Thread.Sleep(1000);
                    clear(10, 27, 100, 29);
                }
                clear(10, 18, 100, 29);
                return choice;
            }
            static int aiRaise(int pool)
            {
                
                
                
                
                
                
                
                
                
                return pool;
            }
            static int aiRaise(int pool, int raise)
            {
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                return pool;
            }
            static int raise(int pool)
            {
                int temps = 0;
                bool valid = false;
                Console.SetCursorPosition(10, 18);
                type($"You have £{balance}", 50);
                Console.SetCursorPosition(10, 20);
                type("How much would you like to raise?", 50);

                int raise = 0;
                valid = false;
                while (!valid)
                {
                    try
                    {
                        Console.SetCursorPosition(10, 22);
                        Console.Write("£");
                        raise = int.Parse(Console.ReadLine());
                        if (raise > 0 && raise <= balance)
                        {
                            pool += raise;
                            balance -= raise;
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 24);
                            type("That is not a valid amount...", 50);
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(10, 24);
                        type("That's not a number...", 50);
                    }
                    System.Threading.Thread.Sleep(1000);
                    clear(10, 22, 100, 24);
                }
                clear(10, 18, 100, 24);
                if (aiHand1[0, 0] != "XXX")
                {
                    temps = rnd.Next(1, 100);
                    if (temps < 80)
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 1 calls", 50);
                        pool += raise;
                        System.Threading.Thread.Sleep(500);
                    }
                    else if (temps < 90)
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 1 raises", 50);
                        pool += raise;
                        pool = aiRaise(pool, raise);
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 1 folds", 50);
                        aiHand1[0, 0] = "XXX";
                        System.Threading.Thread.Sleep(500);
                    }
                }
                if (aiHand1[1, 0] != "XXX" && (temps >= 90 || temps < 80))
                {
                    temps = rnd.Next(1, 100);
                    if (temps < 80)
                    {
                        Console.SetCursorPosition(10, 20);
                        type("Ai 2 calls", 50);
                        pool += raise;
                        System.Threading.Thread.Sleep(500);
                    }
                    else if (temps < 90)
                    {
                        Console.SetCursorPosition(10, 20);
                        type("Ai 2 raises", 50);
                        pool += raise;
                        pool = aiRaise(pool, raise);
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 20);
                        type("Ai 2 folds", 50);
                        aiHand1[1, 0] = "XXX";
                        System.Threading.Thread.Sleep(500);
                    }
                }
                if (aiHand1[2, 0] != "XXX" && (temps >= 90 || temps < 80))
                {
                    temps = rnd.Next(1, 100);
                    if (temps < 80)
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 3 calls", 50);
                        pool += raise;
                        System.Threading.Thread.Sleep(500);
                    }
                    else if (temps < 90)
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 3 raises", 50);
                        pool += raise;
                        pool = aiRaise(pool, raise);
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 3 folds", 50);
                        aiHand1[2, 0] = "XXX";
                        System.Threading.Thread.Sleep(500);
                    }
                }
                return pool;
            }
            static void poker()
            {
                string[] deck1 = { "S 2", "C 2", "D 2", "H 2", "S 3", "C 3", "D 3", "H 3", "S 4", "C 4", "D 4", "H 4", "S 5", "C 5", "D 5", "H 5", "S 6", "C 6", "D 6", "H 6", "S 7", "C 7", "D 7", "H 7", "S 8", "C 8", "D 8", "H 8", "S 9", "C 9", "D 9", "H 9", "S10", "C10", "D10", "H10", "S J", "C J", "D J", "H J", "S Q", "C Q", "D Q", "H Q", "S K", "C K", "D K", "H K", "S A", "C A", "D A", "H A" };
                Card[] deck = new Card[52];
                string[] hand1 = new string[2];
                Card[] hand = new Card[2];
                string[] river1 = { "Unrevealed", "Unrevealed", "Unrevealed", "Unrevealed", "Unrevealed"};
                Card[] river = new Card[5];
                
                Card[,] aiHand = new Card[3, 2];
                int temps;


                for (int i = 0; i < 52; i++)
                {
                    deck[i] = new Card();
                }

                for (int i = 0; i < 52; i++)
                {
                    switch (deck1[i].Substring(1, 2))
                    {
                        case " 2":
                            deck[i].rank = 2;
                            break;
                        case " 3":
                            deck[i].rank = 3;
                            break;
                        case " 4":
                            deck[i].rank = 4;
                            break;
                        case " 5":
                            deck[i].rank = 5;
                            break;
                        case " 6":
                            deck[i].rank = 6;
                            break;
                        case " 7":
                            deck[i].rank = 7;
                            break;
                        case " 8":
                            deck[i].rank = 8;
                            break;
                        case " 9":
                            deck[i].rank = 9;
                            break;
                        case "10":
                            deck[i].rank = 10;
                            break;
                        case " J":
                            deck[i].rank = 11;
                            break;
                        case " Q":
                            deck[i].rank = 12;
                            break;
                        case " K":
                            deck[i].rank = 13;
                            break;
                        case " A":
                            deck[i].rank = 14;
                            break;
                    }
                    switch (deck1[i][0])
                    {
                        case 'S':
                            deck[i].suit = "Spades";
                            break;
                        case 'C':
                            deck[i].suit = "Clubs";
                            break;
                        case 'D':
                            deck[i].suit = "Diamonds";
                            break;
                        case 'H':
                            deck[i].suit = "Hearts";
                            break;
                    }
                }


                border();
                Console.SetCursorPosition(10, 7);
                type("Welcome to the poker table!", 50);
                Console.SetCursorPosition(10, 9);
                type($"You have £{balance}, there are 3 others at the table", 50);
                int pool = 10 * rnd.Next(1, 11);
                Console.SetCursorPosition(10, 11);
                type($"The buy in is £{pool}, do you want to play? Y/N", 50);
                bool valid = false;
                string choice = " ";
                while (!valid)
                {
                    Console.SetCursorPosition(10, 12);
                    choice = Console.ReadLine();
                    if (choice.ToUpper() == "Y" || choice.ToUpper() == "N")
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 14);
                        type("Oh no! I think you pressed enter too quickly!", 50);
                    }
                    System.Threading.Thread.Sleep(1000);
                    clear(10, 12, 100, 14);
                }
                clear(10, 7, 100, 14);
                if (choice.ToUpper() == "Y" || balance >= pool)
                {
                    
                    balance -= pool;
                    pool *= 4;
                    
                    Console.SetCursorPosition(10, 7);
                    type("You have:", 50);
                    Console.SetCursorPosition(10, 8);
                    temps = rnd.Next(0, 52);
                    hand1[0] = deck1[temps];
                    hand[0] = deck[temps];
                    deck1[temps] = "XXX";
                    displayCard(hand1[0]);

                    valid = false;
                    while (!valid)
                    {
                        temps = rnd.Next(0, 52);
                        if (deck1[temps] != "XXX")
                        {
                            hand1[1] = deck1[temps];
                            hand[1] = deck[temps];
                            deck1[temps] = "XXX";
                            valid = true;
                        }
                    }
                    Console.SetCursorPosition(10, 9);
                    displayCard(hand1[1]);

                    Console.SetCursorPosition(10, 11);
                    type("The river is:", 50);
                    Console.SetCursorPosition(10, 12);
                    type("Unknown", 25);
                    Console.SetCursorPosition(10, 13);
                    type("Unknown", 25);
                    Console.SetCursorPosition(10, 14);
                    type("Unknown", 25);
                    Console.SetCursorPosition(10, 15);
                    type("Unknown", 25);
                    Console.SetCursorPosition(10, 16);
                    type("Unknown", 25);
                    
                    for (int i = 0; i < 3; i++)
                    {
                        valid = false;
                        while (!valid)
                        {
                            temps = rnd.Next(0, 52);
                            if (deck1[temps] != "XXX")
                            {
                                aiHand1[i, 0] = deck1[temps];
                                aiHand[i, 0] = deck[temps];
                                deck1[temps] = "XXX";
                                valid = true;
                            }
                        }
                        valid = false;
                        while (!valid)
                        {
                            temps = rnd.Next(0, 52);
                            if (deck1[temps] != "XXX")
                            {
                                aiHand1[i, 1] = deck1[temps];
                                aiHand[i, 1] = deck[temps];
                                deck1[temps] = "XXX";
                                valid = true;
                            }
                        }
                    }
                    bool happy = false;
                    while (!happy)
                    {
                        temps = pokerMenu(pool, aiHand1);
                        switch (temps)
                        {
                            case 1:


                                break;
                            case 2:
                                pool = raise(pool);

                                break;
                            case 3:
                                happy = true;
                                break;
                        }
                    }
                    if (temps != 3) 
                    {
                        
                    }
                    
                    
                    System.Threading.Thread.Sleep(1000);
                }
                else if (pool > balance)
                {
                    clearBorder();
                    Console.SetCursorPosition(10, 7);
                    type("Oh no it doesn't matter you are too poor anyway...", 50);
                }
            }

            static void roulette()
            {

            }
            static void coin()
            {

            }
            static void exit()
            {

            }
            static void Main(string[] args)
            {
                startUp();
                logIn();

                string choice;
                while (running)
                {
                    border();
                    choice = menu();
                    switch (choice)
                    {
                        case "1":
                            slotMachine();
                            break;
                        case "2":
                            blackjack();
                            break;
                        case "3":
                            poker();
                            break;
                        case "4":
                            roulette();
                            break;
                        case "5":
                            coin();
                            break;
                        case "E":
                            exit();
                            break;
                    }

                    if (balance <= 0)
                    {
                        clearBorder();
                        Console.SetCursorPosition(10, 7);
                        type("Uh oh", 50);
                        type("...", 1000);
                        Console.SetCursorPosition(10, 9);
                        type("You are broke", 150);
                        Console.SetCursorPosition(10, 11);
                        type("Goodbye", 200);
                        running = false;
                        clear();
                    }

                }
            }
        }
    }
}




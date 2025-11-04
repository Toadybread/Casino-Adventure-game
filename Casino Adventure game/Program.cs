using System;
using System.Collections.Generic;
using System.Linq;
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

            static bool fold = false;
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
                clear(10, 18, 100, 22);
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
                        if (balance > 0)
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
                        else
                        {
                            Console.SetCursorPosition(10, 27);
                            Console.ReadLine();
                            Console.SetCursorPosition(10, 29);
                            type("Nevermind, you have no money", 50);
                            choice = 4;
                            valid = true;
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
            static int playerResponse(int raise)
            {
                Console.SetCursorPosition(10, 18);
                type($"You have £{balance}", 50);
                Console.SetCursorPosition(10, 19);
                type($"The ai raised by £{raise}", 50);
                Console.SetCursorPosition(10, 21);
                Console.Write("Do you want to:");
                Console.SetCursorPosition(10, 23);
                Console.Write("[1] - Call");
                Console.SetCursorPosition(10, 24);
                Console.Write("[2] - Raise");
                Console.SetCursorPosition(10, 25);
                Console.Write("[3] - Fold");
                bool valid = false;
                int choice = 0;
                while (!valid)
                {
                    if (balance > raise)
                    {
                        try
                        {
                            if (balance > 0)
                            {
                                Console.SetCursorPosition(10, 27);
                                choice = int.Parse(Console.ReadLine());
                                if (choice == 1 || choice == 2 || choice == 3 && balance >= raise)
                                {
                                    valid = true;
                                }
                                else if (choice == 2)
                                {
                                    valid = true;
                                }
                                else if (balance < raise)
                                {
                                    balance = 0;
                                    choice = 4;
                                    valid = true;
                                }
                                else
                                {
                                    Console.SetCursorPosition(10, 29);
                                    type("That's not an option...", 50);
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 27);
                                Console.ReadLine();
                                Console.SetCursorPosition(10, 29);
                                type("Nevermind, you have no money", 50);
                                choice = 4;
                                valid = true;
                            }

                        }
                        catch
                        {
                            Console.SetCursorPosition(10, 29);
                            type("That's not an option...", 50);
                        }
                    }
                    else
                    {
                        clear(10, 21, 100, 25);
                        Console.SetCursorPosition(10, 18);
                        Console.SetCursorPosition(10, 21);
                        Console.Write("Do you want to:");
                        Console.SetCursorPosition(10, 23);
                        Console.Write("[1] - Go all in");
                        Console.SetCursorPosition(10, 24);
                        Console.Write("[2] - Fold");
                        try
                        {
                            if (balance > 0)
                            {
                                Console.SetCursorPosition(10, 26);
                                choice = int.Parse(Console.ReadLine());

                                if (choice == 2)
                                {
                                    valid = true;
                                    choice = 3;
                                }
                                else if (choice == 1)
                                {
                                    choice = 4;
                                    valid = true;
                                }
                                else
                                {
                                    Console.SetCursorPosition(10, 29);
                                    type("That's not an option...", 50);
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 27);
                                Console.ReadLine();
                                Console.SetCursorPosition(10, 29);
                                type("Nevermind, you have no money", 50);
                                choice = 4;
                                valid = true;
                            }

                        }
                        catch
                        {
                            Console.SetCursorPosition(10, 29);
                            type("That's not an option...", 50);
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                    clear(10, 27, 100, 29);
                }


                clear(10, 18, 100, 29);
                return choice;
            }
            static int aiRaise(int pool, int ai)
            {
                System.Threading.Thread.Sleep(1000);
                int raise = rnd.Next(1, 100);
                int temps = 0;
                switch (ai)
                {
                    case 1:
                        type($" by {raise}", 50);

                        if (aiHand1[1, 0] != "XXX")
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
                                pool = aiRaise(pool, 2, raise);
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
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 calls", 50);
                                pool += raise;
                                System.Threading.Thread.Sleep(500);
                            }
                            else if (temps < 90)
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 raises", 50);
                                pool += raise;
                                pool = aiRaise(pool, 3, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 folds", 50);
                                aiHand1[2, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        clear(10, 18, 100, 22);
                        switch (playerResponse(raise))
                        {
                            case 1:
                                balance -= raise;
                                pool += raise;
                                break;
                            case 2:
                                pool = Raise(pool, raise);
                                break;
                            case 3:
                                fold = true;
                                break;
                            case 4:
                                pool += balance;
                                balance = 0;
                                break;
                        }
                        break;
                    case 2:
                        type($" by {raise}", 50);
                        if (aiHand1[2, 0] != "XXX")
                        {
                            temps = rnd.Next(1, 100);
                            if (temps < 80)
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 calls", 50);
                                pool += raise;
                                System.Threading.Thread.Sleep(500);
                            }
                            else if (temps < 90)
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 raises", 50);
                                pool += raise;
                                pool = aiRaise(pool, 3, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 folds", 50);
                                aiHand1[2, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        clear(10, 18, 100, 22);
                        switch (playerResponse(raise))
                        {
                            case 1:
                                balance -= raise;
                                pool += raise;
                                break;
                            case 2:
                                pool = Raise(pool, raise);
                                break;
                            case 3:
                                fold = true;
                                break;
                            case 4:
                                pool += balance;
                                balance = 0;
                                break;
                        }
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
                                pool = aiRaise(pool, 1, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 18);
                                type("Ai 1 folds", 50);
                                aiHand1[0, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }



                        break;
                    case 3:
                        clear(10, 18, 100, 22);
                        switch (playerResponse(raise))
                        {
                            case 1:
                                balance -= raise;
                                pool += raise;
                                break;
                            case 2:
                                pool = Raise(pool, raise);
                                break;
                            case 3:
                                fold = true;
                                break;
                            case 4:
                                pool += balance;
                                balance = 0;
                                break;
                        }
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
                                pool = aiRaise(pool, 1, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 18);
                                type("Ai 1 folds", 50);
                                aiHand1[0, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        if (aiHand1[1, 0] != "XXX")
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
                                pool = aiRaise(pool, 3, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 20);
                                type("Ai 2 folds", 50);
                                aiHand1[1, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        break;
                }
                return pool;
            }
            static int aiRaise(int pool, int ai, int pRaise)
            {
                System.Threading.Thread.Sleep(1000);
                int raise = rnd.Next(1, 100);
                int temps = 0;
                switch (ai)
                {
                    case 1:
                        type($" by {raise}", 50);

                        if (aiHand1[1, 0] != "XXX")
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
                                pool = aiRaise(pool, 2, raise);
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
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 calls", 50);
                                pool += raise;
                                System.Threading.Thread.Sleep(500);
                            }
                            else if (temps < 90)
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 raises", 50);
                                pool += raise;
                                pool = aiRaise(pool, 3, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 folds", 50);
                                aiHand1[2, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        clear(10, 18, 100, 22);
                        switch (playerResponse(raise))
                        {
                            case 1:
                                balance -= raise;
                                pool += raise;
                                break;
                            case 2:
                                pool = Raise(pool, raise);
                                break;
                            case 3:
                                fold = true;
                                break;
                            case 4:
                                pool += balance;
                                balance = 0;
                                break;
                        }
                        break;
                    case 2:
                        type($" by {raise}", 50);
                        if (aiHand1[2, 0] != "XXX")
                        {
                            temps = rnd.Next(1, 100);
                            if (temps < 80)
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 calls", 50);
                                pool += raise;
                                System.Threading.Thread.Sleep(500);
                            }
                            else if (temps < 90)
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 raises", 50);
                                pool += raise;
                                pool = aiRaise(pool, 3, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 22);
                                type("Ai 3 folds", 50);
                                aiHand1[2, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        clear(10, 18, 100, 22);
                        switch (playerResponse(raise))
                        {
                            case 1:
                                balance -= raise;
                                pool += raise;
                                break;
                            case 2:
                                pool = Raise(pool, raise);
                                break;
                            case 3:
                                fold = true;
                                break;
                            case 4:
                                pool += balance;
                                balance = 0;
                                break;
                        }
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
                                pool = aiRaise(pool, 1, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 18);
                                type("Ai 1 folds", 50);
                                aiHand1[0, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }



                        break;
                    case 3:
                        clear(10, 18, 100, 22);
                        switch (playerResponse(raise))
                        {
                            case 1:
                                balance -= raise;
                                pool += raise;
                                break;
                            case 2:
                                pool = Raise(pool, raise);
                                break;
                            case 3:
                                fold = true;
                                break;
                            case 4:
                                pool += balance;
                                balance = 0;
                                break;
                        }
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
                                pool = aiRaise(pool, 1, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 18);
                                type("Ai 1 folds", 50);
                                aiHand1[0, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        if (aiHand1[1, 0] != "XXX")
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
                                pool = aiRaise(pool, 3, raise);
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 20);
                                type("Ai 2 folds", 50);
                                aiHand1[1, 0] = "XXX";
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        break;
                }
                pool += pRaise;
                return pool;
            }
            static int Raise(int pool, int pRaise)
            {
                pool += pRaise;
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
                            valid = true;
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
                raise += pRaise;
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
                        pool = aiRaise(pool, 1, raise);
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
                        pool = aiRaise(pool, 2, raise);
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
                        Console.SetCursorPosition(10, 22);
                        type("Ai 3 calls", 50);
                        pool += raise;
                        System.Threading.Thread.Sleep(500);
                    }
                    else if (temps < 90)
                    {
                        Console.SetCursorPosition(10, 22);
                        type("Ai 3 raises", 50);
                        pool += raise;
                        pool = aiRaise(pool, 3);
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 22);
                        type("Ai 3 folds", 50);
                        aiHand1[2, 0] = "XXX";
                        System.Threading.Thread.Sleep(500);
                    }
                }
                return pool;
            }
            static int aiTurn(int pool)
            {
                int temps = 0;
                clear(10, 18, 100, 24);
                if (aiHand1[0, 0] != "XXX")
                {
                    temps = rnd.Next(1, 100);
                    if (temps < 80)
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 1 checks", 50);
                        System.Threading.Thread.Sleep(500);
                    }
                    else if (temps < 90)
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 1 raises", 50);
                        pool = aiRaise(pool, 1);
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 18);
                        type("Ai 1 folds", 50);
                        aiHand1[0, 0] = "XXX";
                        System.Threading.Thread.Sleep(500);
                    }
                }
                if (aiHand1[1, 0] != "XXX")
                {
                    temps = rnd.Next(1, 100);
                    if (temps < 80)
                    {
                        Console.SetCursorPosition(10, 20);
                        type("Ai 2 checks", 50);
                        System.Threading.Thread.Sleep(500);
                    }
                    else if (temps < 90)
                    {
                        Console.SetCursorPosition(10, 20);
                        type("Ai 2 raises", 50);
                        pool = aiRaise(pool, 2);
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 20);
                        type("Ai 2 folds", 50);
                        aiHand1[1, 0] = "XXX";
                        System.Threading.Thread.Sleep(500);
                    }
                }
                if (aiHand1[2, 0] != "XXX")
                {
                    temps = rnd.Next(1, 100);
                    if (temps < 80)
                    {
                        Console.SetCursorPosition(10, 22);
                        type("Ai 3 checks", 50);
                        System.Threading.Thread.Sleep(500);
                    }
                    else if (temps < 90)
                    {
                        Console.SetCursorPosition(10, 22);
                        type("Ai 3 raises", 50);
                        pool = aiRaise(pool, 3);
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 22);
                        type("Ai 3 folds", 50);
                        aiHand1[2, 0] = "XXX";
                        System.Threading.Thread.Sleep(500);
                    }
                }
                return pool;
            }
            static void poker()
            {
                fold = false;
                string[] deck1 = { "S 2", "C 2", "D 2", "H 2", "S 3", "C 3", "D 3", "H 3", "S 4", "C 4", "D 4", "H 4", "S 5", "C 5", "D 5", "H 5", "S 6", "C 6", "D 6", "H 6", "S 7", "C 7", "D 7", "H 7", "S 8", "C 8", "D 8", "H 8", "S 9", "C 9", "D 9", "H 9", "S10", "C10", "D10", "H10", "S J", "C J", "D J", "H J", "S Q", "C Q", "D Q", "H Q", "S K", "C K", "D K", "H K", "S A", "C A", "D A", "H A" };
                Card[] deck = new Card[52];
                string[] hand1 = new string[2];
                Card[] hand = new Card[2];
                string[] river1 = { "Unrevealed", "Unrevealed", "Unrevealed", "Unrevealed", "Unrevealed" };
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
                                pool += aiTurn(0);
                                happy = true;
                                break;
                            case 2:
                                pool = Raise(pool, 0);
                                clear(10, 18, 100, 22);
                                break;
                            case 3:
                                happy = true;
                                fold = true;
                                break;
                            case 4:
                                pool += aiTurn(0);
                                happy = true;
                                break;
                        }
                    }
                    if (!fold)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            valid = false;
                            while (!valid)
                            {
                                temps = rnd.Next(0, 52);
                                if (deck1[temps] != "XXX")
                                {
                                    river1[i] = deck1[temps];
                                    river[i] = deck[temps];
                                    deck1[temps] = "XXX";
                                    valid = true;
                                }
                            }

                        }
                        clear(10, 18, 100, 22);
                        clear(10, 12, 100, 14);
                        Console.SetCursorPosition(10, 12);
                        displayCard(river1[0]);
                        Console.SetCursorPosition(10, 13);
                        displayCard(river1[1]);
                        Console.SetCursorPosition(10, 14);
                        displayCard(river1[2]);

                        happy = false;
                        while (!happy)
                        {
                            temps = pokerMenu(pool, aiHand1);
                            switch (temps)
                            {
                                case 1:
                                    pool += aiTurn(0);
                                    happy = true;
                                    break;
                                case 2:
                                    pool = Raise(pool, 0);
                                    clear(10, 18, 100, 22);
                                    break;
                                case 3:
                                    happy = true;
                                    fold = true;
                                    break;
                                case 4:
                                    pool += aiTurn(0);
                                    happy = true;
                                    break;
                            }
                        }
                    }
                    if (!fold)
                    {

                        valid = false;
                        while (!valid)
                        {
                            temps = rnd.Next(0, 52);
                            if (deck1[temps] != "XXX")
                            {
                                river1[3] = deck1[temps];
                                river[3] = deck[temps];
                                deck1[temps] = "XXX";
                                valid = true;
                            }
                        }


                        clear(10, 18, 100, 22);
                        clear(10, 15, 100, 15);
                        Console.SetCursorPosition(10, 15);
                        displayCard(river1[3]);


                        happy = false;
                        while (!happy)
                        {
                            temps = pokerMenu(pool, aiHand1);
                            switch (temps)
                            {
                                case 1:
                                    pool += aiTurn(0);
                                    happy = true;
                                    break;
                                case 2:
                                    pool = Raise(pool, 0);
                                    clear(10, 18, 100, 22);
                                    break;
                                case 3:
                                    happy = true;
                                    fold = true;
                                    break;
                                case 4:
                                    pool += aiTurn(0);
                                    happy = true;
                                    break;
                            }
                        }
                    }
                    if (!fold)
                    {

                        valid = false;
                        while (!valid)
                        {
                            temps = rnd.Next(0, 52);
                            if (deck1[temps] != "XXX")
                            {
                                river1[4] = deck1[temps];
                                river[4] = deck[temps];
                                deck1[temps] = "XXX";
                                valid = true;
                            }
                        }


                        clear(10, 18, 100, 22);
                        clear(10, 16, 100, 16);
                        Console.SetCursorPosition(10, 16);
                        displayCard(river1[4]);
                    }
                    if (!fold)
                    {
                        System.Threading.Thread.Sleep(1000);
                        clear(10, 18, 100, 22);
                        int[] scores = { -12, -12, -12, -12 };
                        // High card
                        for (int i = 0; i < 2; i++)
                        {
                            if (hand[i].rank > scores[0] + 14)
                            {
                                scores[0] = hand[i].rank;
                            }
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            if (river[i].rank > scores[0] + 14)
                            {
                                scores[0] = river[i].rank;
                            }
                        }

                        Card[] pCards = new Card[7];
                        for (int i = 0; i < 7; i++)
                        {
                            if (i < 2)
                            {
                                pCards[i] = hand[i];
                            }
                            else
                            {
                                pCards[i] = river[i - 2];
                            }
                        }

                        // Pair
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (i != j)
                                {
                                    if (pCards[i].rank == pCards[j].rank)
                                    {
                                        scores[0] = 1;

                                    }
                                }
                            }
                        }



                        //Three of a kind
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                for (int k = 0; k < 7; k++)
                                {
                                    if (i != j && i != k && j != k)
                                    {
                                        if (pCards[i].rank == pCards[j].rank && pCards[i].rank == pCards[k].rank)
                                        {
                                            scores[0] = 3;
                                        }
                                    }
                                }
                            }
                        }

                        // All unique five card combinations
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (i != j)
                                {
                                    for (int k = 0; k < 7; k++)
                                    {
                                        if (i != k && j != k)
                                        {
                                            for (int l = 0; l < 7; l++)
                                            {
                                                if (i != l && j != l && k != l)
                                                {
                                                    //Two pair
                                                    if (pCards[i].rank == pCards[j].rank && pCards[k].rank == pCards[l].rank)
                                                    {
                                                        if (scores[0] < 2)
                                                        {
                                                            scores[0] = 2;
                                                        }
                                                    }


                                                    // Four of a kind
                                                    if (pCards[i].rank == pCards[j].rank && pCards[i].rank == pCards[k].rank && pCards[i].rank == pCards[l].rank)
                                                    {
                                                        if (scores[0] < 7)
                                                        {
                                                            scores[0] = 7;
                                                        }
                                                    }


                                                    for (int m = 0; m < 7; m++)
                                                    {
                                                        if (i != m && j != m && k != m && l != m)
                                                        {
                                                            // Straight
                                                            if (pCards[i].rank + 1 == pCards[j].rank)
                                                            {
                                                                if (pCards[j].rank + 1 == pCards[k].rank)
                                                                {
                                                                    if (pCards[k].rank + 1 == pCards[l].rank)
                                                                    {
                                                                        if (pCards[l].rank + 1 == pCards[m].rank)
                                                                        {
                                                                            if (scores[0] < 4)
                                                                            {
                                                                                scores[0] = 4;
                                                                            }
                                                                            //Straight flush
                                                                            if (pCards[i].suit == pCards[j].suit && pCards[i].suit == pCards[k].suit && pCards[i].suit == pCards[l].suit && pCards[i].suit == pCards[m].suit)
                                                                            {
                                                                                if (scores[0] < 8)
                                                                                {
                                                                                    scores[0] = 8;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            // Flush
                                                            if (pCards[i].suit == pCards[j].suit && pCards[i].suit == pCards[k].suit && pCards[i].suit == pCards[l].suit && pCards[i].suit == pCards[m].suit)
                                                            {
                                                                if (scores[0] < 5)
                                                                {
                                                                    scores[0] = 5;
                                                                }
                                                                // Royal flush
                                                                if (pCards[i].rank == 10 && pCards[j].rank == 11 && pCards[k].rank == 12 && pCards[l].rank == 13 && pCards[m].rank == 14)
                                                                {
                                                                    scores[0] = 9;
                                                                }
                                                            }

                                                            //Full house
                                                            if (pCards[i].rank == pCards[j].rank && pCards[i].rank == pCards[k].rank && pCards[l].rank == pCards[m].rank)
                                                            {
                                                                if (scores[0] < 6)
                                                                {
                                                                    scores[0] = 6;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Console.SetCursorPosition(10, 18);
                        type("You got a ", 50);
                        switch (scores[0])
                        {
                            case -12:
                                type("wait you shouldn't get this", 50);
                                break;
                            case -11:
                                type("wait you shouldn't get this", 50);
                                break;
                            case -10:
                                type("high card 4! (You are really bad at this)", 50);
                                break;
                            case -9:
                                type("high card 5", 50);
                                break;
                            case -8:
                                type("high card 6", 50);
                                break;
                            case -7:
                                type("high card 7", 50);
                                break;
                            case -6:
                                type("high card 8", 50);
                                break;
                            case -5:
                                type("high card 9", 50);
                                break;
                            case -4:
                                type("high card 10", 50);
                                break;
                            case -3:
                                type("high card Jack", 50);
                                break;
                            case -2:
                                type("high card Queen", 50);
                                break;
                            case -1:
                                type("high card King", 50);
                                break;
                            case 0:
                                type("high card Ace", 50);
                                break;
                            case 1:
                                type("pair", 50);
                                break;
                            case 2:
                                type("two pair", 50);
                                break;
                            case 3:
                                type("three of a kind", 50);
                                break;
                            case 4:
                                type("straight", 50);
                                break;
                            case 5:
                                type("flush", 50);
                                break;
                            case 6:
                                type("full house", 50);
                                break;
                            case 7:
                                type("four of a kind", 50);
                                break;
                            case 8:
                                type("straight flush!", 50);
                                break;
                            case 9:
                                type("royal flush!", 50);
                                break;

                        }



                        for (int x = 1; x < 4; x++)
                        {
                            if (aiHand1[x - 1, 0] != "XXX")
                            {


                                System.Threading.Thread.Sleep(1000);
                                // High card
                                for (int i = 0; i < 2; i++)
                                {
                                    if (aiHand[x - 1, i].rank > scores[x] + 14)
                                    {
                                        scores[x] = aiHand[x - 1, i].rank;
                                    }
                                }
                                for (int i = 0; i < 5; i++)
                                {
                                    if (river[i].rank > scores[x] + 14)
                                    {
                                        scores[x] = river[i].rank;
                                    }
                                }


                                for (int i = 0; i < 7; i++)
                                {
                                    if (i < 2)
                                    {
                                        pCards[i] = aiHand[x - 1, i];
                                    }
                                    else
                                    {
                                        pCards[i] = river[i - 2];
                                    }
                                }

                                // Pair

                                for (int i = 0; i < 7; i++)
                                {
                                    for (int j = 0; j < 7; j++)
                                    {
                                        if (i != j)
                                        {
                                            if (pCards[i].rank == pCards[j].rank)
                                            {
                                                scores[x] = 1;
                                            }
                                        }
                                    }
                                }




                                //Three of a kind
                                for (int i = 0; i < 7; i++)
                                {
                                    for (int j = 0; j < 7; j++)
                                    {
                                        for (int k = 0; k < 7; k++)
                                        {
                                            if (i != j && i != k && j != k)
                                            {
                                                if (pCards[i].rank == pCards[j].rank && pCards[i].rank == pCards[k].rank)
                                                {
                                                    scores[x] = 3;
                                                }
                                            }
                                        }
                                    }
                                }

                                // All unique five card combinations
                                for (int i = 0; i < 7; i++)
                                {
                                    for (int j = 0; j < 7; j++)
                                    {
                                        if (i != j)
                                        {
                                            for (int k = 0; k < 7; k++)
                                            {
                                                if (i != k && j != k)
                                                {
                                                    for (int l = 0; l < 7; l++)
                                                    {
                                                        if (i != l && j != l && k != l)
                                                        {
                                                            //Two pair
                                                            if (pCards[i].rank == pCards[j].rank && pCards[k].rank == pCards[l].rank)
                                                            {
                                                                if (scores[x] < 2)
                                                                {
                                                                    scores[x] = 2;
                                                                }
                                                            }


                                                            // Four of a kind
                                                            if (pCards[i].rank == pCards[j].rank && pCards[i].rank == pCards[k].rank && pCards[i].rank == pCards[l].rank)
                                                            {
                                                                if (scores[x] < 7)
                                                                {
                                                                    scores[x] = 7;
                                                                }
                                                            }


                                                            for (int m = 0; m < 7; m++)
                                                            {
                                                                if (i != m && j != m && k != m && l != m)
                                                                {
                                                                    // Straight
                                                                    if (pCards[i].rank + 1 == pCards[j].rank)
                                                                    {
                                                                        if (pCards[j].rank + 1 == pCards[k].rank)
                                                                        {
                                                                            if (pCards[k].rank + 1 == pCards[l].rank)
                                                                            {
                                                                                if (pCards[l].rank + 1 == pCards[m].rank)
                                                                                {
                                                                                    if (scores[x] < 4)
                                                                                    {
                                                                                        scores[x] = 4;
                                                                                    }
                                                                                    //Striaght flush
                                                                                    if (pCards[i].suit == pCards[j].suit && pCards[i].suit == pCards[k].suit && pCards[i].suit == pCards[l].suit && pCards[i].suit == pCards[m].suit)
                                                                                    {
                                                                                        if (scores[x] < 8)
                                                                                        {
                                                                                            scores[x] = 8;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    // Flush
                                                                    if (pCards[i].suit == pCards[j].suit && pCards[i].suit == pCards[k].suit && pCards[i].suit == pCards[l].suit && pCards[i].suit == pCards[m].suit)
                                                                    {
                                                                        if (scores[x] < 5)
                                                                        {
                                                                            scores[x] = 5;
                                                                        }
                                                                        // Royal flush
                                                                        if (pCards[i].rank == 10 && pCards[j].rank == 11 && pCards[k].rank == 12 && pCards[l].rank == 13 && pCards[m].rank == 14)
                                                                        {
                                                                            scores[x] = 9;
                                                                        }
                                                                    }

                                                                    //Full house
                                                                    if (pCards[i].rank == pCards[j].rank && pCards[i].rank == pCards[k].rank && pCards[l].rank == pCards[m].rank)
                                                                    {
                                                                        if (scores[x] < 6)
                                                                        {
                                                                            scores[x] = 6;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            Console.SetCursorPosition(10, 20 + (2 * (x - 1)));
                            type($"Ai {x} ", 50);
                            switch (scores[x])
                            {
                                case -12:
                                    type("folded", 50);
                                    break;
                                case -11:
                                    type("wait you shouldn't get this", 50);
                                    break;
                                case -10:
                                    type("got a high card 4! (they are really bad at this)", 50);
                                    break;
                                case -9:
                                    type("got a high card 5", 50);
                                    break;
                                case -8:
                                    type("got a high card 6", 50);
                                    break;
                                case -7:
                                    type("got a high card 7", 50);
                                    break;
                                case -6:
                                    type("got a high card 8", 50);
                                    break;
                                case -5:
                                    type("got a high card 9", 50);
                                    break;
                                case -4:
                                    type("got a high card 10", 50);
                                    break;
                                case -3:
                                    type("got a high card Jack", 50);
                                    break;
                                case -2:
                                    type("got a high card Queen", 50);
                                    break;
                                case -1:
                                    type("got a high card King", 50);
                                    break;
                                case 0:
                                    type("got a high card Ace", 50);
                                    break;
                                case 1:
                                    type("got a pair", 50);
                                    break;
                                case 2:
                                    type("got a two pair", 50);
                                    break;
                                case 3:
                                    type("got a three of a kind", 50);
                                    break;
                                case 4:
                                    type("got a straight", 50);
                                    break;
                                case 5:
                                    type("got a flush", 50);
                                    break;
                                case 6:
                                    type("got a full house", 50);
                                    break;
                                case 7:
                                    type("got a four of a kind", 50);
                                    break;
                                case 8:
                                    type("got a straight flush!", 50);
                                    break;
                                case 9:
                                    type("got a royal flush!", 50);
                                    break;

                            }
                        }

                        if (scores[0] > scores[1] && scores[0] > scores[2] && scores[0] > scores[3])
                        {
                            balance += pool;
                        }
                        else if (scores[0] < scores[1] || scores[0] < scores[2] || scores[0] < scores[2])
                        {
                            System.Threading.Thread.Sleep(1);
                        }
                        else if (scores[0] == scores[1] && scores[0] == scores[3] && scores[0] == scores[3])
                        {
                            balance += pool / 4;
                        }

                        else if (scores[0] == scores[1] && scores[0] == scores[3] && scores[0] != scores[3])
                        {
                            balance += pool / 3;
                        }
                        else if (scores[0] == scores[1] && scores[0] != scores[3] && scores[0] == scores[3])
                        {
                            balance += pool / 3;
                        }
                        else if (scores[0] != scores[1] && scores[0] == scores[3] && scores[0] == scores[3])
                        {
                            balance += pool / 3;
                        }

                        else if (scores[0] == scores[1] && scores[0] != scores[3] && scores[0] != scores[3])
                        {
                            balance += pool / 2;
                        }
                        else if (scores[0] != scores[1] && scores[0] != scores[3] && scores[0] == scores[3])
                        {
                            balance += pool / 2;
                        }
                        else if (scores[0] != scores[1] && scores[0] == scores[3] && scores[0] != scores[3])
                        {
                            balance += pool / 2;
                        }
                    }
                }
                else if (pool > balance)
                {
                    clearBorder();
                    Console.SetCursorPosition(10, 7);
                    type("Oh no it doesn't matter you are too poor anyway...", 50);
                }
                System.Threading.Thread.Sleep(5000);
                clearBorder();
            }

            static void roulette()
            {
                border();
                Console.SetCursorPosition(10, 7);
                type($"Welcome to the roulette wheel! You have £{balance}", 50);
                Console.SetCursorPosition(10, 9);
                type("How much would you like to bet?", 50);
                bool valid = false;
                int bet = 0;
                while (!valid)
                {
                    Console.SetCursorPosition(10, 11);
                    Console.Write("£");
                    try
                    {
                        bet = int.Parse(Console.ReadLine());
                        if (bet <= balance && bet >= 0)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 13);
                            type("Try entering a valid amount next time...", 50);
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(10, 13);
                        type("Oops, you don't know what a number is...", 50);
                    }
                    System.Threading.Thread.Sleep(1000);
                    clear(10, 11, 100, 13);
                }

                if (bet > 0)
                {
                    clear(10, 9, 100, 13);
                    Console.SetCursorPosition(10, 9);
                    type("What do you want to bet on?", 50);
                    Console.SetCursorPosition(10, 10);
                    Console.Write("[0-36] - bet on a number (36x return)");
                    Console.SetCursorPosition(10, 11);
                    Console.Write("[E/O] - bet on even or odd (2x return) (0 is neither even nor odd)");
                    valid = false;
                    string choice = " ";
                    int temps = 0;
                    while (!valid)
                    {
                        Console.SetCursorPosition(10, 13);

                        choice = Console.ReadLine();
                        choice = choice.ToUpper();
                        try
                        {
                            temps = int.Parse(choice);
                            if (temps >= 0 && temps <= 36)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 15);
                                type("Try a number in range next time...", 50);
                            }
                        }
                        catch
                        {
                            if (choice == "E" || choice == "O")
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 15);
                                type("I don't even know what you put...", 50);
                            }
                        }
                        System.Threading.Thread.Sleep(1000);
                        clear(10, 13, 100, 15);
                    }

                    clearBorder();
                    Console.SetCursorPosition(10, 7);
                    Console.Write("0  1  2  3  4  5  6  7  8  9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30  31  32  33  34  35  36");
                    Console.SetCursorPosition(10, 8);
                    Console.Write("X");
                    Console.SetCursorPosition(10, 10);
                    type("Press any key to begin", 50);
                    Console.ReadKey();


                    int amount = rnd.Next(100, 200);
                    int result = 0;
                    int delay = (200 - amount) / 2;
                    for (int i = 1; i < amount; i++)
                    {
                        result++;
                        if (result > 36)
                        {
                            result = 0;
                        }
                        System.Threading.Thread.Sleep(delay);
                        delay++;
                        clear(10, 8, 157, 8);
                        Console.SetCursorPosition(10, 8);
                        for (int j = 0; j < result; j++)
                        {
                            Console.Write("   ");
                            if (j > 9)
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.Write("X");
                    }
                    clear(10, 9, 100, 22);
                    Console.SetCursorPosition(10, 10);
                    type($"The result was {result}, ", 50);
                    if (result == 0)
                    {
                        type("none", 50);
                    }
                    else if (result % 2 == 0)
                    {
                        type("even", 50);
                    }
                    else
                    {
                        type("odd", 50);
                    }
                    balance -= bet;
                    try
                    {
                        temps = int.Parse(choice);
                        if (temps == result)
                        {
                            balance += bet * 36;
                        }
                    }
                    catch
                    {
                        if (result == 0)
                        {
                            System.Threading.Thread.Sleep(1);
                        }
                        else if (result % 2 == 0 && choice == "E")
                        {
                            balance += bet * 2;
                        }
                        else if (result % 2 != 0 && choice == "O")
                        {
                            balance += bet * 2;
                        }
                    }
                }


                System.Threading.Thread.Sleep(5000);
            }
            static void tails()
            {
                Console.SetCursorPosition(65, 10);
                Console.Write("          .:-=-.");
                Console.SetCursorPosition(65, 11);
                Console.Write("      -@@@@%**#@@@@+. ");
                Console.SetCursorPosition(65, 12);
                Console.Write("    +@@=.         :@@%.");
                Console.SetCursorPosition(65, 13);
                Console.Write("  .@@=              :@@:   ");
                Console.SetCursorPosition(65, 14);
                Console.Write("  #@=    *##%@###:    %@-  ");
                Console.SetCursorPosition(65, 15);
                Console.Write(" -@%        +#        =@*  ");
                Console.SetCursorPosition(65, 16);
                Console.Write(" =@+        +#        -@#  ");
                Console.SetCursorPosition(65, 17);
                Console.Write(" :@%        +#        =@+  ");
                Console.SetCursorPosition(65, 18);
                Console.Write("  *@=       +#       .@@:  ");
                Console.SetCursorPosition(65, 19);
                Console.Write("  .#@%.             =@@.  ");
                Console.SetCursorPosition(65, 20);
                Console.Write("     :@@%.        .=@@-    ");
                Console.SetCursorPosition(65, 21);
                Console.Write("      .+@@@@@@@@@@%:  ");
            }
            static void heads()
            {
                Console.SetCursorPosition(65, 10);
                Console.Write("        :#@@@@@@@%-.");
                Console.SetCursorPosition(65, 11);
                Console.Write("    .:%@@=:.....:-%@@=. ");
                Console.SetCursorPosition(65, 12);
                Console.Write("   .%@*.           .+@@:");
                Console.SetCursorPosition(65, 13);
                Console.Write("  :@@:   --.    -=   .#@- ");
                Console.SetCursorPosition(65, 14);
                Console.Write(" .%@:    *#.    *%    .@@. ");
                Console.SetCursorPosition(65, 15);
                Console.Write(" :@%     *#.....*%     +@= ");
                Console.SetCursorPosition(65, 16);
                Console.Write(" :@%     *%-----#%     +@= ");
                Console.SetCursorPosition(65, 17);
                Console.Write(" .%@:    *#.    *%    .@@. ");
                Console.SetCursorPosition(65, 18);
                Console.Write("  :@%:   +*.    +*   .#@=  ");
                Console.SetCursorPosition(65, 19);
                Console.Write("   .%@*.           .+@@:   ");
                Console.SetCursorPosition(65, 20);
                Console.Write("    .:@@@=.......-%@@=.   ");
                Console.SetCursorPosition(65, 21);
                Console.Write("        -#@@@@@@@%-  ");
            }
            static void coin()
            {
                border();
                Console.SetCursorPosition(10, 7);
                type("Welcome to the coin flip room!", 50);
                Console.SetCursorPosition(10, 9);
                type($"You have £{balance}", 50);
                Console.SetCursorPosition(10, 11);
                type("Do you want to play? Y/N", 50);
                bool valid = false;
                string choice = " ";
                while (!valid)
                {
                    Console.SetCursorPosition(10, 13);
                    choice = Console.ReadLine();
                    choice = choice.ToUpper();
                    if (choice == "Y" || choice == "N")
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 15);
                        type("That wasn't an option...", 50);
                    }
                    System.Threading.Thread.Sleep(1000);
                    clear(10, 13, 100, 15);
                }
                clearBorder();
                if (choice == "Y")
                {
                    heads();
                    Console.SetCursorPosition(10, 23);
                    type("[H]-heads or [T]-tails?", 50);
                    valid = false;
                    while (!valid)
                    {
                        Console.SetCursorPosition(10, 25);
                        choice = Console.ReadLine();
                        choice = choice.ToUpper();
                        if (choice == "H" || choice == "T")
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 25);
                            type("That's not an option...", 50);
                        }
                        System.Threading.Thread.Sleep(1000);
                        clear(10, 23, 100, 25);
                    }


                    clear(10, 23, 100, 27);
                    Console.SetCursorPosition(10, 23);
                    type("Press any key to continue", 50);
                    Console.ReadKey();
                    clear(10, 23, 100, 23);

                    int amount = rnd.Next(10, 20);
                    int delay = 1000 - amount * 50;
                    bool head = true;
                    for (int i = 0; i < amount; i++)
                    {
                        clearBorder();
                        if (head)
                        {
                            tails();
                            head = false;
                        }
                        else
                        {
                            heads();
                            head = true;
                        }
                        System.Threading.Thread.Sleep(delay);
                        delay += 50;
                    }
                    System.Threading.Thread.Sleep(1000);
                    if ((head && choice == "H") || (!head && choice == "T"))
                    {
                        Console.SetCursorPosition(10, 23);
                        type("You win!", 50);
                        balance *= 2;
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 23);
                        type("You lose...", 50);
                        balance = 0;
                    }
                }
            }
            static void exit()
            {
                border();
                if (balance >= 1000)
                {
                    Console.SetCursorPosition(10, 7);
                    type("Are you really sure you want to leave?", 50);

                    Console.SetCursorPosition(10, 9);
                    type($"You only have £{balance}, you could make more...", 50);

                    Console.SetCursorPosition(10, 11);
                    type("Leave? Y/N", 50);

                    int leave = 0;
                    bool valid = false;
                    string choice = " ";
                    while (!valid)
                    {
                        Console.SetCursorPosition(10, 13);
                        choice = Console.ReadLine();
                        choice = choice.ToUpper();
                        if (choice == "Y" && leave == 3)
                        {
                            Console.SetCursorPosition(10, 15);
                            type("Fine", 50);
                            type("...", 100);
                            type(" ", 1000);
                            type("I'll let you leave", 50);
                            type("...", 100);
                            valid = true;
                        }
                        else if (choice == "N")
                        {
                            Console.SetCursorPosition(10, 15);
                            type("I always knew you wanted to stay!", 50);
                            valid = true;
                        }
                        else if (choice == "Y")
                        {
                            switch (leave)
                            {
                                case 0:
                                    Console.SetCursorPosition(10, 15);
                                    type("Come on... you don't really want to leave do you?", 50);
                                    break;
                                case 1:
                                    Console.SetCursorPosition(10, 15);
                                    type("Really? You really don't want to make more money?", 50);
                                    break;
                                case 2:
                                    Console.SetCursorPosition(10, 15);
                                    type("Please...", 100);
                                    break;
                            }
                            leave++;
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 15);
                            type("That's not an option...", 50);
                        }
                        System.Threading.Thread.Sleep(2000);
                        clear(10, 13, 100, 15);
                    }
                    if (choice == "Y")
                    {
                        clearBorder();
                        Console.SetCursorPosition(10, 7);
                        System.Threading.Thread.Sleep(2000);
                        type("Bye", 100);
                        type("...", 500);
                        running = false;
                    }
                }
                else
                {
                    Console.SetCursorPosition(10, 7);
                    type("Oh no!", 50);
                    Console.SetCursorPosition(10, 9);
                    type($"You need at least £1000 to leave, but you only have £{balance}!", 50);
                    Console.SetCursorPosition(10, 11);
                    type("Try again later when you have more money...", 50);
                    System.Threading.Thread.Sleep(1000);
                    clearBorder();
                }
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
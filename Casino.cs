using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace five_and_five
{
    internal class Casino
    {
        private static double cash = 100, bet;
        public static string write;
        public static string[] main = { "{After getting shot by the joke monkey, you fell into a deep sleep]",
            "[Memories of a distant past begin flooding into your brain]",
            "[You begin to recall a memory of a casino]" };
        public static string[] casino = { "Welcome to the Gargolomew Casino!  Can I interest you in a round of Dice?",
            "Of course I can!  Come with me!",
            "[The staffer brings you to a dark and cramped room, lit only by a single candle.  A small table stands in the centre]",
            "Alright, here's how the game works!  I will roll two dice, and you will bet on the outcome.",
            "Your options are: doubles, not doubles, even sum, odd sum, or sevens.  You can also say \"leave\" to leave.",
            $"You currently have Kc{cash}.  Which would you like to choose? ",
            "We don't have that option at the Gargolomew casino!  Please select a valid option!"};
        public static string[] leave = { "Kindly get the %!&* out of the casino!", "[You drift off into a deep slumber]" };
        public static string[] option = { "Doubles", "Not doubles", "Even sum", "Odd sum", "Sevens", "Leave" };
        public static string[] exp = { " means that your bet will be doubled if you win!",
            " means that your bet will be quadrupled if you win!",
            " means that your bet will be septupled if you win!",
            "To win, doubles has to be rolled.",
            "To win, doubles must not be rolled.",
            "To win, an even sum must be rolled.",
            "To win, an odd sum must be rolled.",
            "To win, three sevens must be rolled in a row." };
        public static string[] betting = { "How much would you like to bet? Kc", "That is NOT a valid bet!  Please give a valid sum!" };
        public static string[] result = { "You won Kc", "You lost Kc" };
        public static string roll = "Rolling...";
        public static string choice, sbet, invalid;
        public static int[] rolls = { 0, 0 };
        public static int totalRoll;
        public static bool chosen = false, ndoubles = false, doubles = false, sumE = false, sumO = false, seven = false, space = true, set = false, visited = false, rol = false, binvalid = false;

        public static void Garg()
        {
            if (!visited)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                for (int i = 0; i < 3; i++)
                {
                    write = main[0 + i];
                    Write();
                }
                Thread.Sleep(700);
            }
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 6; i++)
            {
                write = casino[i];
                Write();
            }
            ndoubles = false; doubles = false; sumE = false; sumO = false; seven = false;
            while (!chosen)
            {
                casino[5] = $"You currently have Kc{cash}.  Which would you like to choose? ";
                if (!visited)
                    Console.SetCursorPosition(casino[5].Length, Console.CursorTop - 2);
                else
                {
                    write = casino[4];
                    Write();
                    space = false;
                    write = casino[5];
                    Write();
                    space = true;
                }
                choice = Console.ReadLine();
                if (binvalid)
                {
                    Console.WriteLine("");
                    invalid = casino[6];
                    Invalid();
                    Console.CursorLeft = 0;
                }
                else
                {
                    Console.WriteLine("");
                }
                binvalid = false;
                if (choice.ToLower() == option[0].ToLower())
                {
                    doubles = true;
                    visited = true;
                    Doubles();
                    doubles = false;
                }
                else if (choice.ToLower() == option[1].ToLower())
                {
                    ndoubles = true;
                    visited = true;
                    NDoubles();
                    ndoubles = false;
                }
                else if (choice.ToLower() == option[2].ToLower())
                {
                    sumE = true;
                    visited = true;
                    SumE();
                    sumE = false;
                }
                else if (choice.ToLower() == option[3].ToLower())
                {
                    sumO = true;
                    visited = true;
                    SumO();
                    sumO = false;
                }
                else if (choice.ToLower() == option[4].ToLower())
                {
                    seven = true;
                    visited = true;
                    Sevens();
                    seven = false;
                }
                else if (choice.ToLower() == option[5].ToLower())
                {
                    Leave();
                }
                else
                {
                    write = casino[6];
                    Write();
                    Console.SetCursorPosition(casino[5].Length, 16);
                    invalid = choice;
                    Invalid();
                    binvalid = true;
                }
            }
        }

        public static void Doubles()
        {
            write = option[0];
            space = false;
            Write();
            write = exp[1];
            space = true;
            Write();
            write = exp[3];
            Write();
            Bet();
            Roll();
            if (rolls[0] == rolls[1])
            {
                cash = cash + (bet * 4);
                write = result[0];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 4);
                Write();
            }
            else
            {
                cash = cash - (bet * 4);
                write = result[1];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 4);
                Write();
                if (cash <= 0)
                    Leave();
            }
        }

        public static void NDoubles()
        {
            write = option[1];
            space = false;
            Write();
            write = exp[0];
            space = true;
            Write();
            write = exp[4];
            Write();
            Bet();
            Roll();
            if (rolls[0] != rolls[1])
            {
                cash = cash + (bet * 2);
                write = result[0];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 2);
                Write();
            }
            else
            {
                cash = cash - (bet * 2);
                write = result[1];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 2);
                Write();
                if (cash <= 0)
                    Leave();
            }
        }

        public static void SumE()
        {
            write = option[2];
            space = false;
            Write();
            write = exp[0];
            space = true;
            Write();
            write = exp[5];
            Write();
            Bet();
            Roll();
            if (totalRoll % 2 == 0)
            {
                cash = cash + (bet * 2);
                write = result[0];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 2);
                Write();
            }
            else
            {
                cash = cash - (bet * 2);
                write = result[1];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 2);
                Write();
                if (cash <= 0)
                    Leave();
            }
        }

        public static void SumO()
        {
            write = option[3];
            space = false;
            Write();
            write = exp[0];
            space = true;
            Write();
            write = exp[6];
            Write();
            Bet();
            Roll();
            if (totalRoll % 2 != 0)
            {
                cash = cash + (bet * 2);
                write = result[0];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 2);
                Write();
            }
            else
            {
                cash = cash - (bet * 2);
                write = result[1];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 2);
                Write();
                if (cash <= 0)
                    Leave();
            }
        }

        public static void Sevens()
        {
            int[] sum = { 0, 0, 0 };
            write = option[4];
            space = false;
            Write();
            write = exp[2];
            space = true;
            Write();
            write = exp[7];
            Write();
            Bet();

            for (int i = 0; i < 3; i++)
            {
                Roll();
                sum[i] = totalRoll;
            }

            if (sum[0] == sum[1] && sum[0] == sum[2])
            {
                cash = cash + (bet * 7);
                write = result[0];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 7);
                Write();
            }
            else
            {
                cash = cash - (bet * 7);
                write = result[1];
                space = false;
                Write();
                space = true;
                write = Convert.ToString(bet * 7);
                Write();
                if (cash <= 0)
                    Leave();
            }
        }

        public static void Leave()
        {
            write = leave[0];
            Write();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            write = leave[1];
            Write();
            Thread.Sleep(1000);
            chosen = true;
        }
        public static void Bet()
        {
            write = betting[0];
            space = false;
            Write();
            while (!set)
            {
                Console.CursorLeft = betting[0].Length;
                sbet = Console.ReadLine();
                if (binvalid)
                {
                    invalid = betting[1];
                    Invalid();
                    Console.CursorLeft = 0;
                }
                binvalid = false;
                bool parse = double.TryParse(sbet, out bet);
                if (!parse)
                {
                    write = betting[1];
                    Write();
                    Console.SetCursorPosition(betting[0].Length, Console.CursorTop - 1);
                    invalid = choice;
                    Invalid();
                    binvalid = true;
                }
                else
                {
                    if (bet <= cash)
                    {
                        set = true;
                    }
                    else
                    {
                        write = betting[1];
                        Write();
                        Console.SetCursorPosition(betting[0].Length, Console.CursorTop - 1);
                        invalid = choice;
                        Invalid();
                        binvalid = true;
                    }
                }
            }
            set = false;
        }
        public static void Write()
        {
            int j = 1;
            if (rol)
                j = 10;
            for (int i = 0; i < write.Length; i++)
            {
                Console.Write(write[i]);
                Thread.Sleep(15 * j);
            }
            Thread.Sleep(300);

            if (space)
            {
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        public static void Roll()
        {
            rol = true;
            Die die1 = new Die();
            die1.RollDie();
            Thread.Sleep(500);
            Die die2 = new Die();
            die2.RollDie();

            rolls[0] = die1.Roll;
            rolls[1] = die2.Roll;
            totalRoll = rolls[1] + rolls[0];

            write = roll;
            Write();
            Console.WriteLine("");
            Console.WriteLine($"Die 1 = {die1}");
            die1.DrawRoll();
            Write();
            Console.WriteLine("");
            Console.WriteLine($"Die 2 = {die2}");
            die2.DrawRoll();

            rol = false;
        }

        public static void Invalid()
        {
            for (int i = 0; i < invalid.Length; i++)
            {
                Console.Write(" ");
            }
        }
    }
}

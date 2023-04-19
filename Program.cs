using five_and_five;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace the_six
{
    internal class Program
    {
        //TO DO
        //WORKING ON PASSING ATM, ODDSUM, AND THEN RANDOM
        public static System.Timers.Timer randcolor = new System.Timers.Timer();
        public static string[] main = { "{After getting shot by the joke monkey, you fell into a deep sleep]",//0
            "[Memories of a distant past begin flooding into your brain...]",//1
            "[You perceive yourself to be inside of a testing facility with inhumane practises]" };//2
        public static string[] facility = { "[You are standing in front of six doors, each one with a label above it]", //0
            "[The labels read: Prompter; Passing; OddSum; Random; Gargolomew; Dorm]",//1
            "Which door would you like to enter? ", //2
            "That is not a valid option.  Please select a valid door."};//3
        public static string[] prompter = { "[You enter the prompter room, and a solitary computer sits on a desk]",//0
                "[Text begins to appear on the screen]", //1
                "PLEASE INPUT A MINIMUM VALUE AND A MAXIMUM VALUE: ", //2
                "NOPE, THAT'S NOT A NUMBER.  YOU MUST ENTER TWO NUMBERS.", //3
                "PLEASE ENTER A VALUE BETWEEN THE VALUES YOU JUST SELECTED: ", //4
                "YEP, THAT'S A NUMBER BETWEEN THE TWO EARLIER VALUES.", //5
                $"NOPE, THAT'S NOT A VALUE BETWEEN THE TWO EARLIER VALUES. YOU MUST ENTER A VALUE BETWEEN {min} AND {max}.", //6
                "[The computer turns itself off, and with nothing else to do, you return to the hallway]", //7
                "YOU HAVE COMMITTED A GRAVE SIN, AND WILL DIE FOR YOUR AFFRONT.", //8
                "[You are smote by the machine, and drop down, dead]"}; //9
        public static string[] svalues = { "", "", "" };
        public static double[] values = { 0, 0, 0 };
        public static double max, min;
        public static string[] passing = { "[You enter the passing room, and a nervous-looking spalax is sitting at one end of a desk with its head in its hands]",//0
            "[With nothing better to do, you sit down at the other side and consult it]",//1
            "\"Can you help me?  I gave my students a test, but being blind, I have no way of seeing how many students completed the test nor a way of grading their papers...\" It despaired.",//2
            "[Again, with nothing better to do, you decide to help and grab the stack of completed test papers]",//3
            "How many students completed the test (#)? ", //4
            "That is an invalid number of students.  Please enter a real number.", //5
            "What were each of their grades (%)? ", //6
            "An invalid grade was submitted.  Please reenter each grade with a valid percentage.", //7
            "[You hand the spalax the graded papers, and inform him of the number of students that participated]", //8
            "\"So few children?!\" The spalax cried in dibelief. \"Unfathoma-\" [The spalax had a heart attack and died]", //9 //If you don't want the bad end, ensure more than 20 kids are in the spalax's class
            "\"All of my students completed the test!!\" The spalax exclaimed excitedly.", //10
            "\"But the majority of the class scored below 70%?!\" The spalax woefully blurted. \"I have failed as a teac-\" [The spalax had a heart attack and died]", //11
            "\"And the majority of the class scored above 70%!!\" The spalax rejoiced esctatically. \"My students are all so wonderf-\" [The spalax had a heart attack and died]", //12
            "[Bored of the passing room, you return to the hallway]", //13
            "[A voice echoes through the room.  You look over to see that the spalax has been smote]" //14
        };
        public static string sstudents;
        public static int students;
        public static string[] oddsum = {
                "[You enter the oddsum room, and a paradoxides is sitting behind a computer screen]",//0
                "[It signals for you to take a seat]", //1
                "[It types a message, and turns the monitor to face you.  It reads: PLEASE TELL ME AN INTEGER]", //2
                "Integer: ", //3
                "Nope, that's not an integer! (Or it's too big!)  Type a reasonable integer!", //4
                "[Within the span of 0 seconds, the paradoxides reveals that the oddsum is 0]",//5
                "[The paradoxides makes a >:3 face]", //6
                "[Fed up with the paradoxides' nonsense, you exit the room]" //7
        };
        public static int number, awesum = 0;
        public static string snumber;
        public static string[] random = { "[You enter the random room, and find that it is filled with neon signs flashing vibrant colours at random]", //0
        "[An upside-down elephant unfurls its trunk and reveals a slip of paper asking for two integers]", //1
        "Which integers will you give the elephant? ",//2
        "[The elephant frowns in pity, for you have not given it an integer.  It motions for you to try again]", //3
        "[You're jealous of the elephant's power, and storm out of the random room]", //4
        "[After giving the upside-down elephant your integers, the signs in the room rapidly change to display twenty-five random integers between the two you selected]", //5
        "[The elephant stops floating and simply falls on you]" //6
        };
        public static string[] srandom = { "", "" };
        public static int[] irandom = { 0, 0 };
        public static int[] sign = new int[25];
        public static int rmax, rmin;
        public static string dorm = "[You enter the dormitory and swiftly drift off to sleep...]";
        public static string[] garg = {"[You enter the room labeled \"Gargolomew\", and are instantly struck by a blinding headache...]",//0
        "[Your senses return and you find yourself sprawled out on the floor]",//1
        "[Perhaps it's best to avoid the \"Gargolomew\" room from here on out...]"};//2
        public static string[] option = { "prompter", //0
            "passing", //1
            "oddsum", //2
            "random", //3
            "gargolomew", //4
            "dorm" //5
        };
        public static string write, invalid, choice;
        public static int invalidated;
        public static bool space = true, chosen = false, binvalid = false, parse, input = false, counted = false, graded = false, pain = true, given = false, brandom = false;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < 3; i++)
            {
                write = main[i];
                Write();
            }

            while(!chosen)
            {
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < 3; i++)
                {
                    if (i == 2)
                        space = false;
                    write = facility[i];
                    Write();
                }
                space = true;
                pain = true;
                while (pain)
                {
                    Console.CursorLeft = facility[2].Length;
                    choice = Console.ReadLine();
                    if (binvalid)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        invalid = facility[3];
                        Invalid();
                        Console.CursorLeft = 0;
                    }
                    binvalid = false;
                    if (choice.ToLower() == option[0])
                    {
                        Prompter();
                        pain = false;
                    }
                    else if (choice.ToLower() == option[1])
                    {
                        Passing();
                        pain = false;
                    }
                    else if (choice.ToLower() == option[2])
                    {
                        OddSum();
                        pain = false;
                    }
                    else if (choice.ToLower() == option[3])
                    {
                        Random();
                        pain = false;
                    }
                    else if (choice.ToLower() == option[4])
                    {
                        Gargolomew();
                        pain = false;
                    }
                    else if (choice.ToLower() == option[5])
                    {
                        Dorm();
                    }
                    else
                    {
                        write = facility[3];
                        Write();
                        invalid = choice;
                        Console.SetCursorPosition(facility[2].Length, Console.CursorTop - 3);
                        Invalid();
                        binvalid = true;;
                    }
                }
            }
        }
        public static void Prompter()
        {
            invalidated = 0;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                    space = false;
                write = prompter[i];
                Write();
            }
            space = true;
            input = false;
            
            while (!input)
            {
                svalues[0] = Console.ReadLine();
                parse = double.TryParse(svalues[0], out values[0]);
                if (parse)
                {
                    if (binvalid)
                    {
                        invalid = prompter[3];
                        Invalid();
                    }
                    binvalid = false;
                    Console.SetCursorPosition((prompter[2].Length + svalues[0].Length + 1), Console.CursorTop - 1);
                    svalues[1] = Console.ReadLine();
                    parse = double.TryParse(svalues[1], out values[1]);
                    if (!parse)
                    {
                        write = prompter[3];
                        Write();
                        Console.SetCursorPosition(prompter[2].Length, Console.CursorTop - 3);
                        invalid = svalues[0] + svalues[1] + " ";
                        Invalid();
                        Console.CursorLeft = prompter[2].Length;
                        binvalid = true;
                    }
                    else
                        input = true;
                }
                else
                {
                    write = prompter[3];
                    Write();
                    Console.SetCursorPosition(prompter[2].Length, Console.CursorTop - 3);
                    invalid = svalues[0] + svalues[1] + " ";
                    Invalid();
                    Console.CursorLeft = prompter[2].Length;
                    binvalid = true;
                }
            }
            if (binvalid)
            {
                invalid = prompter[3];
                Invalid();
            }
            binvalid = false;
            Console.WriteLine("");
            if(values[0] > values[1])
            {
                max = values[0];
                min = values[1];
            }
            else if(values[0] < values[1])
            {
                max = values[1];
                min = values[0];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                write = prompter[8];
                Write();
                write = prompter[9];
                Write();
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            prompter[6] = $"NOPE, THAT'S NOT A VALUE BETWEEN THE TWO EARLIER VALUES. YOU MUST ENTER A VALUE BETWEEN {min} AND {max}.";
            space = false;
            write = prompter[4];
            Write();
            space = true;
            input = false;

            while (!input)
            {
                svalues[2] = Console.ReadLine();
                parse = double.TryParse(svalues[2], out values[2]);
                if (binvalid)
                {
                    invalid = prompter[6];
                    Invalid();
                }
                Console.CursorLeft = 0;
                binvalid = false;
                if (parse)
                {
                    if(values[2] > max || values[2] < min)
                    {
                        write = prompter[6];
                        Write();
                        binvalid = true;
                        Console.SetCursorPosition(prompter[4].Length, Console.CursorTop - 3);
                        invalid = svalues[2];
                        Invalid();
                        Console.CursorLeft = prompter[4].Length;
                    }
                    else 
                    {
                        input = true;
                    }
                }
                else
                {
                    write = prompter[6];
                    Write();
                    binvalid = true;
                    Console.SetCursorPosition(prompter[4].Length, Console.CursorTop - 3);
                    invalid = svalues[2];
                    Invalid();
                    Console.CursorLeft = prompter[4].Length;
                }
            }
            if (binvalid)
            {
                invalid = prompter[6];
                Invalid();
            }
            binvalid = false;
            Console.WriteLine("");
            write = prompter[5];
            Write();
            write = prompter[7];
            Write();
        }

        public static void Passing()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                    space = false;
                write = passing[i];
                Write();
            }
            space = true;
            graded = false;
            counted = false;

            while (!counted)
            {
                sstudents = Console.ReadLine();
                if (binvalid)
                {
                    invalid = passing[5];
                    Invalid();
                }
                binvalid = false;
                Console.CursorLeft = 0;
                parse = int.TryParse(sstudents, out students);
                if (!parse)
                {
                    write = passing[5];
                    Write();
                    Console.SetCursorPosition(passing[4].Length, Console.CursorTop - 3);
                    invalid = sstudents;
                    Invalid();
                    Console.CursorLeft = passing[4].Length;
                    binvalid = true;
                }
                else
                {
                    if (students < 0)
                    {
                        write = passing[5];
                        Write();
                        Console.SetCursorPosition(passing[4].Length, Console.CursorTop - 3);
                        invalid = sstudents;
                        Invalid();
                        Console.CursorLeft = passing[4].Length;
                        binvalid = true;
                    }
                    else
                    counted = true;
                }
            }

            Console.WriteLine("");
            double[] grades = new double[students];
            string[] sgrades = new string[students];
            double average = 0;
            space = false;
            write = passing[6];
            Write();
            space = true;

            while (!graded)
            {
                for (int i = 0; i < students; i++)
                {
                    sgrades[i] = Console.ReadLine();
                    if (binvalid)
                    {
                        invalid = passing[7];
                        Invalid();
                    }
                    binvalid = false;
                    Console.CursorLeft = 0;
                    parse = double.TryParse(sgrades[i], out grades[i]);
                    if (!parse)
                    {
                        for (int k = i; k > -1; k--)
                        {
                            if (k == 0)
                                Console.SetCursorPosition(passing[6].Length, Console.CursorTop - 1);
                            else
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            invalid = sgrades[k];
                            Invalid();
                        }
                        Console.WriteLine("");
                        write = passing[7];
                        Write();
                        Console.SetCursorPosition(passing[6].Length, Console.CursorTop - 3);
                        binvalid = true;
                        break;
                    }
                    else
                    {
                        if (grades[i] > 100 || grades[i] < 0)
                        {
                            for (int k = i; k > -1; k--)
                            {
                                if (k == 0)
                                    Console.SetCursorPosition(passing[6].Length, Console.CursorTop - 1);
                                else
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                invalid = sgrades[k];
                                Invalid();
                            }
                            Console.WriteLine("");
                            write = passing[7];
                            Write();
                            Console.SetCursorPosition(passing[6].Length, Console.CursorTop - 3);
                            binvalid = true;
                            break;
                        }
                        if (i == students - 1)
                            graded = true;
                    }
                }
            }
                double above = 0;
                Console.WriteLine("");
                for (int i = 0; i < grades.Length; i++)
                {
                    if (grades[i] >= 70)
                        above = above + 1;
                }
                average = above / students;
                average = average * 100;

                passing[8] = $"You informed the spalax that {students} students took the test, and that {Math.Round(average, 1)}% scored above a 70%]";
                write = passing[8];
                Write();

                if (students < 20)
                {
                    write = passing[9];
                    Write();
                }
                else
                {
                    write = passing[10];
                    Write();
                    if (average < 50)
                    {
                        write = passing[11];
                        Write();
                    }
                    else if (average > 50)
                    {
                        write = passing[12];
                        Write();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        write = prompter[8];
                        Write();
                        write = passing[14];
                        Write();
                    }
                }
                write = passing[13];
                Write();


        }

        public static void OddSum()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < 4; i++)
            {
                if (i == 3)
                    space = false;
                write = oddsum[i];
                Write();
            }
            space = true;
            given = false;
            while (!given)
            {
                snumber = Console.ReadLine();
                if (binvalid)
                {
                    invalid = oddsum[4];
                    Invalid();
                }
                binvalid = false;
                Console.CursorLeft = 0;
                parse = int.TryParse(snumber, out number);
                if(!parse)
                {
                    write = oddsum[4];
                    Write();
                    Console.SetCursorPosition(oddsum[3].Length, Console.CursorTop - 3);
                    invalid = snumber;
                    Invalid();
                    Console.CursorLeft = passing[4].Length;
                    binvalid = true;
                }
                else
                {
                    given = true;
                }
                Console.WriteLine("");
                for (int i = 0; i < number; i++)
                {
                    if (i % 2 == 1)
                        awesum += i;
                }

                oddsum[5] = $"[Within the span of .5 seconds, the paradoxides reveals that the oddsum is {awesum}]";
                for (int i = 0; i < 3; i++)
                {
                    write = oddsum[5 + i];
                    Write();
                }
            }
        }

        public static void Random()
        {
            randcolor.Elapsed += new ElapsedEventHandler(Colors);
            randcolor.Interval = 10;
            randcolor.Enabled = true;
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                    space = false;
                write = random[i];
                Write();
            }
            space = true;
            brandom = false;

            while (!brandom)
            {
                
                srandom[0] = Console.ReadLine();
                parse = int.TryParse(srandom[0], out irandom[0]);
                if (parse)
                {
                    if (binvalid)
                    {
                        invalid = random[3];
                        Invalid();
                    }
                    binvalid = false;
                    Console.SetCursorPosition((random[2].Length + srandom[0].Length + 1), Console.CursorTop - 1);
                    srandom[1] = Console.ReadLine();
                    parse = int.TryParse(srandom[1], out irandom[1]);
                    if (!parse)
                    {
                        write = random[3];
                        Write();
                        Console.SetCursorPosition(random[2].Length, Console.CursorTop - 3);
                        invalid = srandom[0] + srandom[1] + " ";
                        Invalid();
                        Console.CursorLeft = random[2].Length;
                        binvalid = true;
                    }
                    else
                        brandom = true;
                }
                else
                {
                    write = random[3];
                    Write();
                    Console.SetCursorPosition(random[2].Length, Console.CursorTop - 3);
                    invalid = srandom[0] + srandom[1] + " ";
                    Invalid();
                    Console.CursorLeft = random[2].Length;
                    binvalid = true;
                }
            }
            if (binvalid)
            {
                invalid = random[3];
                Invalid();
            }
            binvalid = false;
            Console.WriteLine("");
            if (irandom[0] > irandom[1])
            {
                rmax = irandom[0];
                rmin = irandom[1];
            }
            else if (irandom[0] < irandom[1])
            {
                rmax = irandom[1];
                rmin = irandom[0];
            }
            else
            {
                randcolor.Enabled = false;
                Console.ForegroundColor = ConsoleColor.Red;
                write = prompter[8];
                Write();
                write = random[6];
                Write();
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            Random rint = new Random();
            write = random[5];
            Write();
            space = false;
            for (int i = 0; i < 25; i++)
            {
                if (i == 24)
                    space = true;
                sign[i] = rint.Next(rmin, rmax + 1);
                write = sign[i].ToString() + " ";
                Write();
            }
            write = random[4];
            Write();
            randcolor.Enabled = false;
        }

        public static void Gargolomew()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            write = garg[0];
            Write();
            Casino casino = new Casino();
            Casino.Garg();
            Console.ForegroundColor = ConsoleColor.Red;
            write = garg[1];
            Write();
            write = garg[2];
            Write();
        }

        public static void Dorm()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            write = dorm;
            Write();
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
        
        public static void Write()
        {
            for (int i = 0; i < write.Length; i++)
            {
                Console.Write(write[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(300);

            if (space)
            {
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        public static void Invalid()
        {
            for (int i = 0; i < invalid.Length; i++)
            {
                Console.Write(" ");
            }
        }

        public static void Colors(object source, ElapsedEventArgs e)
        {
            int color;
            Random generator = new Random();
            color = generator.Next(1, 16);
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
        }
    }
}

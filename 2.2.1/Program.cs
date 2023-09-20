using System;

namespace _2._2._1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // defines arrays containing questions and answers
            string[] QuestionArray = { "What is the keyword in Python used to define a function?\nA) func\nB) def\nC) define\nD) function", "Which keyword is used to declare a variable as a constant in Python?\nA) const\nB) let\nC) final\nD) None of the above", "In Python, which keyword is used to exit from a loop prematurely? \nA) stop\nB) exit\nC) break\nD) continue", "What keyword is used to define a class in Python? \nA) type\nB) class\nC) define\nD) struct", "Which keyword is used to indicate that a method is not yet implemented and should be completed later? \nA) pass\nB) implement\nC) todo\nD) finalize", "In Python, what keyword is used to create a copy of an object? \nA) copy\nB) clone\nC) duplicate\nD) None of the above", "What keyword is used to raise an exception in Python?\nA) throw\nB) raise\nC) except\nD) error", "Which keyword is used to define a block of code that will be executed regardless of whether an exception is raised or not?\nA) try\nB) catch\nC) finally\nD) ensure", "What keyword is used to define a variable with a null or empty value in Python?\nA) null\nB) undefined\nC) None\nD) void", "In Python, which keyword is used to import modules or libraries?\nA) require\nB) include\nC) import\nD) use" };
            string[] AnswerArray = { "B", "D", "C", "B", "A", "D", "B", "C", "C", "C" };
            int[] AskedArray = { }; // contains all previous questions

            // quiz intro
            Console.WriteLine("Welcome to the Python Quiz (written in c# 💀)");
            Console.WriteLine("Are you ready!?\n");
            Console.ReadLine();
            Console.WriteLine("\nOn god!");
            Console.WriteLine("Press enter to start!");
            Console.ReadLine();
            Console.Clear();

            while (true)
            {

                while (true)
                {
                    int genrandom = RNG();
                    bool check = Array.Exists(AskedArray, element => element == genrandom); // rerolls 0-9 until a random unseen question number is found
                    if (check != true)
                    {

                        Console.WriteLine("Question " + Globals.Current_Question + ") ");
                        Console.Write(QuestionArray[genrandom] + "\n"); // outputs question

                        string answer = AnswerArray[genrandom]; // fetches correct answer string
                        //Console.WriteLine("\n##debug## answer var is "+answer);
                        string input = Convert.ToString(Console.ReadLine().ToUpper());

                        switch (input) // switch case that checks if the answer is right
                        {
                            case var _ when answer == input: // statement with a pattern matching case, uses a temporary variable. (var _)
                                Console.WriteLine("\nCorrect!\n");
                                Globals.Correct_Answers++; // updates "global" variable tracking correct answers

                                break;

                            case var _ when answer != input:
                                Console.WriteLine("\nNope, Sorry! The correct answer was " + answer + "\n");

                                break;
                        }

                        //updates AskedArray
                        int[] TempArray = new int[AskedArray.Length + 1]; // defines temporary array
                        for (int i = 0; i < AskedArray.Length; i++) // copies all data over iteratively
                        {
                            TempArray[i] = AskedArray[i];
                        }

                        TempArray[TempArray.Length - 1] = genrandom; // increases size of array
                        AskedArray = TempArray; // updates array

                        Globals.Current_Question++;

                        if (AskedArray.Length == 5) // checks if 5 questions have been asked!

                        {
                            Console.WriteLine("Congrats on finishing the test! Lets see how you did");
                            Console.WriteLine("You got (" + Globals.Correct_Answers + " / 5)\n\nThanks for playing!");
                            Console.WriteLine("\nPress any key to continue . . .");
                            Console.ReadLine();
                            Environment.Exit(0); // exits consoleapp
                        }

                    }
                }
            }
        }


        public static class Globals
        {
            public static int Current_Question = 1; // current question variable
            public static int Random_Value;
            public static int Correct_Answers;
        }



        private static Random rand = new Random(); // random number generator from 0-9
        public static int RNG()
        {
            return rand.Next(0, 9);
        }
    }
}

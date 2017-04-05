using System;
using System.Collections.Generic;
using System.Linq;


namespace L7__StudentInformation
{
    class StudentInformation
    {
        static void Main(string[] args)
        {
            List<string> classList = new List<string> { "Amber", "Bob", "Steve" };
            List<string> foodList = new List<string> { "Pizza", "Peas", "Pears" };
            List<string> hometownList = new List<string> { "Holland", "Zeeland", "Detroit" };

            bool keepGoing = true;

            Console.WriteLine("This program gives a list of the  students " +
                                "in the class and some info about them");

            while (keepGoing)
            {
                Console.WriteLine("Which student do you want to learn about? "
                                + "Enter a # between 1 and 3. Or type \"print\" "
                                + "to list the students in class");

                //begin the program processing
                ParseInput(GetInput(), classList, foodList, hometownList);

                //exit program               
                if (ExitProgram())
                {
                    Console.WriteLine("Goodbye!");
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
        }

        //get the user's input
        public static String GetInput()
        {
            string input = "";
            
            input = Console.ReadLine();

            //check that there is actually some input
            if (input == "")
            {
                return GetInput();
            }
            else { return input.ToLower(); }
        }

        //convert the input to something usable
        public static void ParseInput(string input,
                                        List<string> classList,
                                        List<string> foodList, 
                                        List<string> hometownList)
        {
            int result = 0;

            if (input == "print")
            {
                //get input, convert and display the results
                foreach (string student in classList)
                    Console.WriteLine(student);
            }
            //check for an integer and result is within bounds
            else if (int.TryParse(input, out result) && 
                        result > 0 && 
                        result < classList.Count+1)
            {
                result = result - 1;
                string studentName = classList[result];
                Console.WriteLine("Student " + input + " is " + studentName);
                GetInfo(result, studentName, foodList, hometownList);
            }
            else
            {
                Console.WriteLine("Not a valid input. Enter a # between 1 " +
                                    "and 3. Or type \"print\" to list the " +
                                    "students in class");

                ParseInput(GetInput(), classList, foodList, hometownList);
            }
        }

        //get the student's information
        public static void GetInfo (int input, 
                                    string studentName,
                                    List<string> foodList, 
                                    List<string> hometownList)
        {            
            Console.WriteLine("Do you want to know about " + studentName +
                                "'s favorite food? If so type \"FOOD\"." +
                                " Or type \"HOMETOWN\" to see where they grew up.");
            string infoRequested = GetInput();

            if (infoRequested.Equals("food"))
            {
                Console.WriteLine(studentName + "'s favorite food is " +
                                    foodList[input] + ".");
            }
            else if (infoRequested.Equals("hometown"))
            {
                Console.WriteLine(studentName + "'s hometown is " +
                                    hometownList[input] + ".");
            }
            else
            {
                Console.WriteLine("Not a valid input");
                GetInfo(input, studentName, foodList, hometownList);
            }

        }

        //exit the program when the user wants to
        public static Boolean ExitProgram()
        {
            Console.WriteLine("Do you want to continue? Enter Y or N.");
            var KP = Console.ReadKey(true);

            while (KP.Key != ConsoleKey.N && KP.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Not a vaid answer. Do you want to " +
                    "continue? Enter Y or N.");
                KP = Console.ReadKey(true);
            }
            return KP.Key == ConsoleKey.N ? true : false;
        }
    }
}
